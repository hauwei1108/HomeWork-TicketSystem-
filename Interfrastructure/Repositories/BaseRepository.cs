using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Util;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfrastructure.Repositories
{
    public abstract class BaseRepository : IBaseRepository
    {
        public DbUtil DbUtil { get; set; }

        protected IMapper Mapper { get; set; }

        protected abstract void AutoMapperConfiguration();

        public BaseRepository()
        {
            AutoMapperConfiguration();
        }

    }
}
