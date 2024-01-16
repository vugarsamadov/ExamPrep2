using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Business
{
	public static class FileExtensions
	{

		public const string PortfolioImagesPath = "wwwroot/portfolioimages";

		public static async Task<string> SaveImageAsync(this IFormFile file,IWebHostEnvironment env)
		{
			//if (env == null) return "asfsadf";

			var contentRoot = env.ContentRootPath;
			var dirPath = Path.Combine(contentRoot,PortfolioImagesPath);

			if (!Directory.Exists(dirPath))
				Directory.CreateDirectory(dirPath);

			var fileName = Guid.NewGuid()+file.FileName;

			var filePath = Path.Combine(dirPath, fileName);

			using (var newFile = File.Create(filePath))
			{ 
				await file.CopyToAsync(newFile);	
			}

			return fileName;
		}



	}
}
