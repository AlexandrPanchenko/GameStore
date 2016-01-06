using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.WebUI.Models
{
    public class GameListViewModel
    {
        public IEnumerable<Game> games { get; set; }
        public PagingInfo pagingInfo { get; set; }
        public string CurrentCatregory { get; set; }
    }
}
