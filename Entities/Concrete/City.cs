﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class City : IEntity
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
    }
}
