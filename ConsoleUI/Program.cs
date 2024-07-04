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

        CarTest();
        BrandTest();
        ColorTest();

        DboTest();
    }

    private static void DboTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());

        foreach (var carDetails in carManager.GetProductDetails())
        {
            Console.WriteLine(carDetails.Description + " / " + carDetails.BrandName + " / " + carDetails.ColorName + " / " + carDetails.DailyPrice);
        }
    }

    private static void ColorTest()
    {
        ColorManager colorManager = new ColorManager(new EfColorDal());

        Color color = new Color() { ColorName = "Su Yeşili" };
        colorManager.Add(color);

        foreach (var c in colorManager.GetAll())
        {
            Console.WriteLine(c.ColorName);
        }
    }

    private static void BrandTest()
    {
        BrandManager brandManager = new BrandManager(new EfBrandDal());

        Brand brand = new Brand() { BrandName = "Porshce" };
        brandManager.Add(brand);

        foreach (var b in brandManager.GetAll())
        {
            Console.WriteLine(b.BrandName);
        }
    }

    private static void CarTest()
    {
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

        Car newCar = new Car() { Id = 6, BrandId = 2, ColorId = 1, ModelYear = 2030, DailyPrice = 300000, Description = "Siyah Opel marka araç" };
        carManager.Add(newCar);  //newCar nesnesini şartlar uyuyorsa ekler!
    }
}