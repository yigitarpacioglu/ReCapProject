﻿using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Entities;


namespace ReCapProject.Entities.Concrete
{
    public class Car:IEntity
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Descriptions { get; set; }
        public int Findex { get; set; }


    }
}
