﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyAPI.Models
{
    public class Pets
    {
        [JsonProperty(PropertyName = "givenName")]
        public string GivenName { get; set; }
    }
}

