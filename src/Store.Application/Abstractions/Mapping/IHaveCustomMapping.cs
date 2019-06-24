using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Abstractions.Mapping
{
    public interface IHaveCustomMapping
    {
        void CreateMappings(Profile configuration);
    }
}
