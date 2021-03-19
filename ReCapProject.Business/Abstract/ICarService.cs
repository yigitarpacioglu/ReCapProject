﻿using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Utilities.Business;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;

namespace ReCapProject.Business.Abstract
{
    public interface ICarService:ICrudServices<Car>
    {
        IDataResult<List<CarDetailDto>> GetCarDetailsService();
        IDataResult<List<CarDetailDto>> GetCarDetailsById(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorName(string colorName);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandName(string brandName);
        
    }
}
