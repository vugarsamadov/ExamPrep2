using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Models;
using Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Business.Profiles
{
	public class PortfolioProfiles : Profile
	{
		

		
        public PortfolioProfiles(IWebHostEnvironment webHostEnvironment)
        {
            CreateMap<PortfolioCreateVM, Portfolio>()
                .ForMember(c=>c.ImageUrl,opt=>opt.Ignore())
                .AfterMap(async (src,dest)=>
                {
                    dest.ImageUrl = await src.Image.SaveImageAsync(webHostEnvironment);
				});


            CreateMap<PortfolioUpdateVM, Portfolio>()
				.ForMember(c => c.ImageUrl, opt => opt.Ignore())
				.AfterMap(async (src, dest) =>
				{
                    if(src.Image != null)
					    dest.ImageUrl = await src.Image.SaveImageAsync(webHostEnvironment);
				});

            CreateMap<Portfolio,PortfolioVM>();
            CreateMap<PortfolioVM,PortfolioUpdateVM>();
            

        }


    }
}
