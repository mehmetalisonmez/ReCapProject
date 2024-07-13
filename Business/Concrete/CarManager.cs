using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _iCarDal;
        IColorService _colorService;
        public CarManager(ICarDal iCarDal, IColorService colorService)
        {
            _iCarDal = iCarDal;
            _colorService = colorService;
        }


        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarCountOfBrandCorrect(car.BrandId), CheckIfCarNameExists(car.CarName),CheckIfColorLimitExceded());
            if (result != null)
            {
                return result;
            }
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

            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(), CarMessages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.BrandId == brandId), CarMessages.CarsByBrandId);

        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.ColorId == colorId), CarMessages.CarsByColorId);

        }

        public IDataResult<List<CarDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetProductDetails(), CarMessages.SomeCarsDetails);
        }

        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            var result = _iCarDal.GetAll(c => c.BrandId == brandId).Count;
            if (result > 5)
            {
                return new ErrorResult(CarMessages.CarCountOfBrandError);
            }
            return new SuccessResult(CarMessages.CarAdded);
        }

        private IResult CheckIfCarNameExists(string carName)
        {
            var result = _iCarDal.GetAll(c=>c.CarName == carName).Count;
            if (result >= 3 )
            {
                return new ErrorResult(CarMessages.CarNameExistsError);
            }
            return new SuccessResult(CarMessages.CarAdded);
        }

        //Eğer mevcut renk sayısı 20'yi geçtiyse s,steme yeni araç eklenemez 

        private IResult CheckIfColorLimitExceded()
        { 
            var result = _colorService.GetAll().Data.Count;
            if(result > 20 )
            {
                return new ErrorResult(CarMessages.ColorLimitExceded);
            }
            return new SuccessResult(CarMessages.CarAdded);
        }
    } 
}
