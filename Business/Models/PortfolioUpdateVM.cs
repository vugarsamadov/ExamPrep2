using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Business.Models
{
    public class PortfolioUpdateVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
    }
}
