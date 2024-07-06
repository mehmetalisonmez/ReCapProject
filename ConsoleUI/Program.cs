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

        //  CarTest();
        //  BrandTest();
        //  ColorTest();
        //  DboTest();
        // CarTest2();
        // UserDegerleriEklemeTest();
        // CustomerDegerleriEklemeTest();
        // RentalDegerleriEklemeTest();

    }

    private static void RentalDegerleriEklemeTest()
    {
        RentalManager rentalManager = new RentalManager(new EfRentalDal());

        // Rental tablosuna veri ekleyelim
        List<Rental> rentals = new List<Rental>
        {
            new Rental { CarId = 1, CustomerId = 1, RentDate = DateTime.Now.AddDays(-10), ReturnDate = DateTime.Now.AddDays(-5) },
            new Rental { CarId = 2, CustomerId = 2, RentDate = DateTime.Now.AddDays(-8), ReturnDate = DateTime.Now.AddDays(-3) },
            new Rental { CarId = 3, CustomerId = 3, RentDate = DateTime.Now.AddDays(-15), ReturnDate = DateTime.Now.AddDays(10) }
        };

        foreach (var rental in rentals)
        {
            rentalManager.Add(rental);
        }
    }

    private static void CustomerDegerleriEklemeTest()
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

        // Customers tablosuna veri ekleyelim
        List<Customer> customers = new List<Customer>
        {
            new Customer { UserId = 1, CompanyName = "Fenrebahçe LTD ŞTİ" },
            new Customer { UserId = 2, CompanyName = "Galatasaray LTD ŞTİ" },
            new Customer { UserId = 3, CompanyName = "Beşiktaş LTD ŞTİ" },
            new Customer { UserId = 4, CompanyName = "Koç LTD ŞTİ" },
            new Customer { UserId = 5, CompanyName = "Hakmar LTD ŞTİ" },
            new Customer { UserId = 6, CompanyName = "Bim LTD ŞTİ" },
            new Customer { UserId = 7, CompanyName = "Şok LTD ŞTİ" },
            new Customer { UserId = 8, CompanyName = "Tarım Kredi LTD ŞTİ" },
            new Customer { UserId = 9, CompanyName = "File LTD ŞTİ" },
            new Customer { UserId = 10, CompanyName = "Akdeğer LTD ŞTİ" }
        };

        foreach (var customer in customers)
        {
            customerManager.Add(customer);
        }
    }

    private static void UserDegerleriEklemeTest()
    {
        UserManager userManager = new UserManager(new EfUserDal());

        // Users tablosuna veri ekleyelim
        List<User> users = new List<User>
        {
            new User { FirstName = "Ali", LastName = "Veli", Email = "ali.veli@gmail.com", Password = "password1" },
            new User { FirstName = "Ayşe", LastName = "Yılmaz", Email = "ayse.yilmaz@gmail.com", Password = "password2" },
            new User { FirstName = "Fatma", LastName = "Demir", Email = "fatma.demir@gmail.com", Password = "password3" },
            new User { FirstName = "Ahmet", LastName = "Kara", Email = "ahmet.kara@gmail.com", Password = "password4" },
            new User { FirstName = "Mehmet", LastName = "Şahin", Email = "mehmet.sahin@gmail.com", Password = "password5" },
            new User { FirstName = "Zeynep", LastName = "Çelik", Email = "zeynep.celik@gmail.com", Password = "password6" },
            new User { FirstName = "Hakan", LastName = "Kaya", Email = "hakan.kaya@gmail.com", Password = "password7" },
            new User { FirstName = "Elif", LastName = "Öztürk", Email = "elif.ozturk@gmail.com", Password = "password8" },
            new User { FirstName = "Emre", LastName = "Aydın", Email = "emre.aydin@gmail.com", Password = "password9" },
            new User { FirstName = "Can", LastName = "Çalışkan", Email = "can.caliskan@gmail.com", Password = "password10" }
        };

        foreach (var user in users)
        {
            userManager.Add(user);
        }
    }

    private static void CarTest2()
    {
        CarManager carManager = new CarManager(new EfCarDal());

        var result = carManager.GetProductDetails();

        if (result.Success == true)
        {
            foreach (var product in result.Data)
            {
                Console.WriteLine(product.Description + "/" + product.BrandName);
            }
        }
        else
        {
            Console.WriteLine(result.Message);
        }
    }

    private static void DboTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());

        foreach (var carDetails in carManager.GetProductDetails().Data)
        {
            Console.WriteLine(carDetails.Description + " / " + carDetails.BrandName + " / " + carDetails.ColorName + " / " + carDetails.DailyPrice);
        }
    }

    private static void ColorTest()
    {
        ColorManager colorManager = new ColorManager(new EfColorDal());

        Color color = new Color() { ColorName = "Su Yeşili" };
        colorManager.Add(color);

        foreach (var c in colorManager.GetAll().Data)
        {
            Console.WriteLine(c.ColorName);
        }
    }

    private static void BrandTest()
    {
        BrandManager brandManager = new BrandManager(new EfBrandDal());

        Brand brand = new Brand() { BrandName = "Porshce" };
        brandManager.Add(brand);

        foreach (var b in brandManager.GetAll().Data)
        {
            Console.WriteLine(b.BrandName);
        }
    }

    private static void CarTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());

        Console.WriteLine("Brand Id = 2 olanlar");
        foreach (var c in carManager.GetCarsByBrandId(2).Data)
        {
            Console.WriteLine(c.Description);
        }

        Console.WriteLine("-------------");
        Console.WriteLine("Color Id = 1 olanlar");

        foreach (var c in carManager.GetCarsByColorId(1).Data)
        {
            Console.WriteLine(c.Description);
        }

        Car newCar = new Car() { Id = 6, BrandId = 2, ColorId = 1, ModelYear = 2030, DailyPrice = 300000, Description = "Siyah Opel marka araç" };
        carManager.Add(newCar);  //newCar nesnesini şartlar uyuyorsa ekler!
    }
}