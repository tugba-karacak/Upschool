﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpschoolMicroservices.Order.Application.DTOs
{
 public   class AddressDto
    {
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
    }
}
