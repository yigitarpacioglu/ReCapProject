﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReCapProject.Business.Abstract;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAllService();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("Add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.AddService(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
      
        [HttpPost("Delete")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerService.DeleteService(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult Get(int id)
        {
            var result = _customerService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByUserId")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _customerService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
