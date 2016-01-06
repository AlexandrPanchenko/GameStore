using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.WebUI.Models
{
   public class PagingInfo
    {
        public int TotalItem { get; set; }
        public int ItemOnPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPage {
        get{
                return (int)Math.Ceiling((decimal)TotalItem / ItemOnPage);
           }
       }


    }
}
