﻿using AutoMapper;
using Store.Application.Infrastructure.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Tests.Infrastructure
{
    public static class AutoMapperFactory
    {
        public static IMapper Create()
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            return mappingConfig.CreateMapper();
        }
    }
}
