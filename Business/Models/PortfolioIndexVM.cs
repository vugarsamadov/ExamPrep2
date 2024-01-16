using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Pagination;

namespace Business.Models
{
	public class PortfolioIndexVM
	{
        public GenericPaginatedEntity<PortfolioVM> Portfolios { get; set; }
    }
}
