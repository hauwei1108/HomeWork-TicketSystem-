using ApplicationCore.Interfaces.Services;
using ApplicationCore.Util;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Services
{
    public abstract class BaseService : IBaseService
    {
        public DbUtil DbUtil { get; set; }

        public Util.Util Util { get; set; }

        protected IMapper Mapper { get; set; }

        protected abstract void AutoMapperConfiguration();

        public BaseService()
        {
            AutoMapperConfiguration();
        }
    }
}
