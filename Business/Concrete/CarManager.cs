using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public void Add(Car car)
        {
           
            if(car.Description.Length >= 2 && car.DailyPrice>0) 
            {
                _iCarDal.Add(car);
            }
            else
            {
                throw new Exception("Araba eklemeniz için DailyPrice > 0 ve Description en az 2 karakter olmalıdır");
            }
            

        }

        public void Delete(Car car)
        {
            _iCarDal.Delete(car);
        }
        public void Update(Car car)
        {
            _iCarDal.Update(car);
        }
        public List<Car> GetAll()
        {
            return _iCarDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _iCarDal.GetAll(p => p.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _iCarDal.GetAll(p=>p.ColorId == colorId);
        }

    }
}
