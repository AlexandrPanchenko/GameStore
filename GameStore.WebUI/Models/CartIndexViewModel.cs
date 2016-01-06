using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.WebUI.Models
{
     public class CartIndexViewModel
    {

        public Cart cart { get; set; }
        public string ReturnURL { get; set; }
    }
}
