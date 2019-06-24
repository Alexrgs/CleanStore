using AutoMapper;
using Store.Application.Abstractions.Mapping;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.Products.Queries.GetProduct
{
    public class ProductViewModel : IHaveCustomMapping
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal? UnitPrice { get; set; }

        public bool EditEnabled { get; set; }

        public bool DeleteEnabled { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Product, ProductViewModel>()
                .ForMember(pDTO => pDTO.EditEnabled, opt => opt.MapFrom<PermissionsResolver>())
                .ForMember(pDTO => pDTO.DeleteEnabled, opt => opt.MapFrom<PermissionsResolver>());
               
        }

        class PermissionsResolver : IValueResolver<Product, ProductViewModel, bool>
        {
            // TODO: inject your services and helper here
            public PermissionsResolver()
            {

            }

            public bool Resolve(Product source, ProductViewModel dest, bool destMember, ResolutionContext context)
            {
                return false;
            }
        }
    }
}
