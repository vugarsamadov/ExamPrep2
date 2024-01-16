using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Models;
using Core.Entities;
using Microsoft.AspNetCore.Hosting;

namespace Business.Profiles
{
    public class UploadMappingAction : IMappingAction<PortfolioCreateVM, Portfolio>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UploadMappingAction(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async void Process(PortfolioCreateVM source, Portfolio destination, ResolutionContext context)
        {
            destination.ImageUrl = await source.Image.SaveImageAsync(_webHostEnvironment);
        }
    }
}
