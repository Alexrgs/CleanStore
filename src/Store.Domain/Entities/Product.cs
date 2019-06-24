﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.Entities
{
    public class Product
    {   
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImgURL { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
    }
}
