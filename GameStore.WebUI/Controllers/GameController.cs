using System.Linq;
using System.Web.Mvc;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;
using GameStore.WebUI.Models;

namespace GameStore.WebUI.Controllers
{
    public class GameController:Controller
    {
        private IGameRepository _repository;
        public int PageItem = 4;
        public GameController(IGameRepository repository)
        {
            _repository = repository;
        }

        public FileContentResult GetImage(int gameId)
        {
            Game game = _repository.Games
                .FirstOrDefault(g => g.GameId == gameId);

            if (game != null)
            {
                return File(game.ImageData, game.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        public ViewResult List(string category, int page=1)
        {
            GameListViewModel model = new GameListViewModel()
            {
                games = _repository.Games.Where(c=>category == null || c.Category.Trim() == category.Trim()).OrderBy(game => game.GameId).Skip((page - 1) * PageItem).Take(PageItem),
                pagingInfo = new PagingInfo { CurrentPage = page, ItemOnPage = PageItem,
                TotalItem = category== null?_repository.Games.Count():_repository.Games.Where(g=>g.Category==category).Count() },
                CurrentCatregory = category

            };
           
            return View(model);
        }
       
    }
}
