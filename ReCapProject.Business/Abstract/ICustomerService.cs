﻿using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Utilities.Business;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;

namespace ReCapProject.Business.Abstract
{
    public interface ICustomerService:ICrudServices<Customer>
    {
        IDataResult<Customer> GetByUserId(int userId);
    }
}
