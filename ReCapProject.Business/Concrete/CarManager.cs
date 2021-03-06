﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using Business.BusinessAspects.Autofac;
using Castle.Core.Internal;
using FluentValidation;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.Constants;
using ReCapProject.Business.ValidationRules.FluentValidation;
using ReCapProject.Core.Aspects.Autofac.Caching;
using ReCapProject.Core.Aspects.Autofac.Validation;
using ReCapProject.Core.CrossCuttingConcerns.Validation;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;

namespace ReCapProject.Business.Concrete
{
    public class CarManager : ICarService
    {
        private int hour = Values.hour;
        private ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        
        
        [CacheAspect]
        public IDataResult<List<Car>> GetAllService()
        {
            
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<List<Car>>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), CarMessages.CarsListed);
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<Car>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == id), CarMessages.CarsListed);

        }

        //[SecuredOperation("car.add")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult AddService(Car entity)
        {
            _carDal.Add(entity);
            return new SuccessResult(CarMessages.CarAdded);
        }

        public IResult UpdateService(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult(CarMessages.CarUpdated);
        }

        public IResult DeleteService(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult(CarMessages.CarDeleted);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsService()
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<List<CarDetailDto>>(GeneralMessages.Maintenance);
            }
            string defaultPath = "\\Assets\\default.jpg";
            var query = _carDal.GetCarDetails();
            query.ForEach(delegate (CarDetailDto car)
            {
                if (car.ImagePath.IsNullOrEmpty())
                {
                    car.ImagePath = defaultPath;
                }
            });
            return new SuccessDataResult<List<CarDetailDto>>(query,CarMessages.CarsListed);
        }

        public IDataResult<CarDetailDto> GetCarDetailsById(int id)
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<CarDetailDto>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetailsById(p => p.CarId == id), CarMessages.CarsListed);

        }


        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<List<CarDetailDto>>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c=>c.ColorId==colorId), CarMessages.CarsListed);
        }
        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<List<CarDetailDto>>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId), CarMessages.CarsListed);
        }
        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandAndColorId(int brandId, int colorId)
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<List<CarDetailDto>>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId && c.ColorId == colorId), CarMessages.CarsListed);
        }

    }
}
