using System.Collections.Generic;

namespace UmbUcommerce.Models
{
    public class FacetsDisplayedViewModel
            {
        public FacetsDisplayedViewModel()
        {
            Facets = new List<FacetViewModel>();
        }
        public IList<FacetViewModel> Facets { get; set; }

    }
}