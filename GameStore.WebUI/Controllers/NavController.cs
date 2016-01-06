using GameStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStore.WebUI.Controllers
{
    public class NavController : Controller
    {
       private IGameRepository _repository;


        public NavController(IGameRepository repository)
        {
            _repository = repository;
        }
        public PartialViewResult Menu(string category=null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = _repository.Games.Select(g => g.Category.Trim()).Distinct().OrderBy(x => x);
            return PartialView(categories);
        }
    }
}