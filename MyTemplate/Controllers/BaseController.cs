using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTemplateWeb.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected IMapper Mapper { get; set; }

        protected abstract void AutoMapperConfiguration();

        public BaseController()
        {
            AutoMapperConfiguration();
        }

        protected string GetContentType(string fileName)
        {
            string contentType;
            new FileExtensionContentTypeProvider().TryGetContentType(fileName, out contentType);
            return contentType ?? "application/octet-stream";
        }
    }
}
