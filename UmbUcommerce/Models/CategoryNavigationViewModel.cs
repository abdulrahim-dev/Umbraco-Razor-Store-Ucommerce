using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmbUcommerce.Models;

namespace UmbUcommerce.Models
{
	public class CategoryNavigationViewModel
	{
		public CategoryNavigationViewModel()
		{
			Categories = new List<CategoryViewModel>();
		}
		public IList<CategoryViewModel> Categories { get; set; } 
	}
}