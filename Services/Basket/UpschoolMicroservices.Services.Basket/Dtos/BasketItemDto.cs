﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpschoolMicroservices.Services.Basket.Dtos
{
    public class BasketItemDto
    {
        public int Quantity { get; set; }
        public string ProductId  { get; set; }
        public string ProductName  { get; set; }
        public decimal Price  { get; set; }
    }
}
