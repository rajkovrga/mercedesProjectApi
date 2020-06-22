
using System;
using System.Runtime.CompilerServices;

namespace DataSeeder
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            var seeder = new Seeder(new DataAccess.DataContext());

            seeder.Run();

        }

        
    }
}
