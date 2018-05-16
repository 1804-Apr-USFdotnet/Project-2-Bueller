using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bueller.DA;

namespace Project2_Bueller
{
    public class Class1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating db");
            BuellerContext db = new BuellerContext();
            db.SaveChanges();
            Console.WriteLine("db created");
        }
    }

}
