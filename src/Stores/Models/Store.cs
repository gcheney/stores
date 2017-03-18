using System.ComponentModel.DataAnnotations;

namespace Stores.Models
{
    public class Store
    {
        [Display(Name ="Store Number")]
        public int StoreNumber { get; set; }

        [Display(Name ="Store Name")]
        public string StoreName { get; set; }

        [Display(Name ="Store Manager Name")]
        public string StoreManagerName { get; set; }

        [Display(Name ="Opening Time")]
        public string OpeningTime { get; set; }

        [Display(Name ="Closing Time")]
        public string ClosingTime { get; set; }
    }
}