﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rmz.WeatherForecast.Api.Data.Entities
{
    public abstract class BaseEntity<KeyType>
    {
        public KeyType Id { get; set; }
    }
}
