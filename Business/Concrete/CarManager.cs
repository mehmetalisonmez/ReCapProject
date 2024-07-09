using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _iCarDal;

        public CarManager(ICarDal iCarDal)
        {
            _iCarDal = iCarDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {           
          
                _iCarDal.Add(car);
                return new SuccessResult(CarMessages.CarAdded);
            
           
        }
        public IResult Delete(Car car)
        {
            _iCarDal.Delete(car);
            return new SuccessResult(CarMessages.CarDeleted);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _iCarDal.Update(car);
            return new SuccessResult(CarMessages.CarUpdated);
        }


        public IDataResult<List<Car>> GetAll()
        {
            
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(),CarMessages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.BrandId == brandId),CarMessages.CarsByBrandId);
            
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.ColorId == colorId), CarMessages.CarsByColorId);
            
        }

        public IDataResult<List<CarDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetProductDetails(), CarMessages.SomeCarsDetails);            
        }
    }
}
