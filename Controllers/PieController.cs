using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetanyPieShop_coreMVC.Models;
using BetanyPieShop_coreMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BetanyPieShop_coreMVC.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List()
        {
            PiesListViewModel piesListViewModel = new PiesListViewModel()
            {
                Pies = this._pieRepository.AllPies,
                CurrentCategory = "Cheese Cakes"
            };
            return View(piesListViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = this._pieRepository.GetPieById(id);

            if (pie == null)
                return NotFound();
            return View(pie);
        }
    }
}
