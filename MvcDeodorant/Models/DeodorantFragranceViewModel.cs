using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
namespace MvcDeodorant.Models
{
    public class DeodorantFragranceViewModel
    {

        public List<Deodorant> Deodorants { get; set; }
        public SelectList Fragrances { get; set; }
        public string DeodorantFragrance { get; set; }
        public string SearchString { get; set; }
    }
}
