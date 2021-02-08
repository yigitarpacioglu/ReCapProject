﻿using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Business;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;

namespace ReCapProject.Business.Abstract
{
    public interface ICarService:ICrudServices<Car>
    {
        List<CarDetailDto> GetCarDetails();
    }
}