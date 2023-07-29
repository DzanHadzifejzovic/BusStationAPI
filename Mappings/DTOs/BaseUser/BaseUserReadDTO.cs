﻿using Sieve.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappings.DTOs.BaseUser
{
    public class BaseUserReadDTO
    {
        public string Id { get; set; }
        [Sieve(CanSort = true,CanFilter =true)]
        public string FirstName { get; set; }
        [Sieve(CanSort = true)]
        public string LastName { get; set; }
        [Sieve(CanSort = true)]
        public string Username { get; set; }
        [Sieve(CanSort = true,CanFilter =true)]
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        [Sieve(CanFilter = true)]
        public IList<string>? Roles { get; set; }
    }
}
