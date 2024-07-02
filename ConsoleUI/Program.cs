using Business.Concrete;
using DataAccess.Concrete;

internal class Program
{
    private static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new InMemoryDal());

        foreach (var c in carManager.GetAll())
        {
            Console.WriteLine(c.Description);
        }

    }
}