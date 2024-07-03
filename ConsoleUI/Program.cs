using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntitiyFramework;
using Entities.Concrete;

internal class Program
{
    private static void Main(string[] args)
    {
        //CarManager carManager = new CarManager(new InMemoryDal());

        //foreach (var c in carManager.GetAll())
        //{
        //    Console.WriteLine(c.Description);
        //}
        //Console.WriteLine("----------------------");

        //Car newCar = new Car();
        //newCar.Id = 6;
        //newCar.BrandId = 2;
        //newCar.ModelYear = 2025;
        //newCar.DailyPrice = 10000;
        //newCar.Description = "Opel markadır. Sonradan add ile ekledim";
        //newCar.ColorId = 1;

        //carManager.Add(newCar);
        //foreach (var c in carManager.GetAll())
        //{
        //    Console.WriteLine(c.Description);
        //}

        CarManager carManager = new CarManager(new EfCarDal());

        Console.WriteLine("Brand Id = 2 olanlar");
        foreach (var c in carManager.GetCarsByBrandId(2))
        {
            Console.WriteLine(c.Description);
        }

        Console.WriteLine("-------------");
        Console.WriteLine("Color Id = 1 olanlar");

        foreach (var c in carManager.GetCarsByColorId(1))
        {
            Console.WriteLine(c.Description);
        }

        Car newCar = new Car() {Id=6,BrandId=2,ColorId=1,ModelYear=2030,DailyPrice=300000,Description="Siyah Opel marka araç" };  
        carManager.Add(newCar);  //newCar nesnesini şartlar uyuyorsa ekler!
        
}
}