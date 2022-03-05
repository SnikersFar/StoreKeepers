using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StorekeeperDetails.EfStuff.DbModel;
using StorekeeperDetails.EfStuff.Repositories;
using StorekeeperDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorekeeperDetails.Controllers
{
    public class HomeController : Controller
    {
        private DetailRepository _detailRepository;
        private StoreKeeperRepository _storeKeeperRepository;
        private IMapper _mapper;
        public HomeController(DetailRepository detailRepository, StoreKeeperRepository storeKeeperRepository, IMapper mapper)
        {
            _detailRepository = detailRepository;
            _storeKeeperRepository = storeKeeperRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var DataView = new DataViewModel()
            {
                Details = _mapper.Map<List<DetailViewModel>>(_detailRepository.GetAll()),
                Keepers = _mapper.Map<List<StoreKeeperViewModel>>(_storeKeeperRepository.GetAll()),
            };
            return View(DataView);
        }
        [HttpPost]
        public IActionResult Index(DetailViewModel detail)
        {
            //first Variant
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            // second Variant
            if (detail.NomenCode == null
                || detail.Name == null
                || !_storeKeeperRepository.Get(detail.KeeperId).IsActive
                || DateTime.Compare(detail.DateCreated, new DateTime()) == 0)
            {
                return RedirectToAction("Index");
            }
            var ModelDetail = _mapper.Map<Detail>(detail);
            if (detail.Id == 0)
            {
                ModelDetail.IsActive = true;
            }
            else
            {
                ModelDetail.IsActive = _detailRepository.Get(detail.Id).IsActive;
            }
            ModelDetail.Keeper = _storeKeeperRepository.Get(detail.KeeperId);
            _detailRepository.Save(ModelDetail);
            return RedirectToAction("Index");


        }
        public IActionResult RemoveDetail(long DeatilId)
        {
            _detailRepository.Remove(DeatilId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Keepers()
        {
            return View(_mapper.Map<List<StoreKeeperViewModel>>(_storeKeeperRepository.GetAll()));
        }

        [HttpPost]
        public IActionResult Keepeers(StoreKeeperViewModel viewKeeper)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var Keeper = _mapper.Map<StoreKeeper>(viewKeeper);
            Keeper.IsActive = true;
            Keeper.Details = new List<Detail>();
            _storeKeeperRepository.Save(Keeper);

            return RedirectToAction("Keepers");
        }
        public IActionResult RemoveKeeper(long keeperId)
        {
            var MyKeeper = _storeKeeperRepository.Get(keeperId);

            if (MyKeeper != null && MyKeeper.Details.Where(d => d.IsActive).ToList().Count == 0)
            {
                _storeKeeperRepository.Remove(keeperId);
            }

            return RedirectToAction("Keepers");
        }
    }
}
