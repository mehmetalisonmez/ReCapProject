using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class InMemoryDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryDal()
        {
            _cars = new List<Car>()
            {
                new Car() {CarId = 1, BrandId = 1,ColorId=1,ModelYear=2000,DailyPrice=1500.0m,Description ="Bu bir skoda arabadır.Benzinlidir" },
                new Car() {CarId = 2, BrandId = 1,ColorId=1,ModelYear=2005,DailyPrice=2000.0m,Description ="Bu bir skoda arabadır.LPG'lidir" },
                new Car() {CarId = 3, BrandId = 2,ColorId=2,ModelYear=2010,DailyPrice=2500.0m,Description ="Bu bir opel arabadır.Dizeldir" },
                new Car() {CarId = 4, BrandId = 2,ColorId=2,ModelYear=2015,DailyPrice=3000.0m,Description ="Bu bir opel arabadır.Benzinlidir" },
                new Car() {CarId = 5, BrandId = 2,ColorId=3,ModelYear=2020,DailyPrice=4000.0m,Description ="Bu bir opel arabadır.Elektriklidir" },
            };

        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Update(Car car)
        {           
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public List<Car> GetById(int BrandId)
        {
            return _cars.Where(c => c.BrandId == BrandId).ToList();
        }

    }
}
