using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bueller.DA;
using Bueller.DA.Models;

namespace Project2_Bueller
{
    public class Class1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating db");
            BuellerContext db = new BuellerContext();
            Subject sub = new Subject()
            {
                Name = "Math",
                Department = "Math and Science"
            };
            db.Subjects.Add(sub);
            db.SaveChanges();
            //var s = db.Subjects.ToList().Find(x => x.Name == "Math");
            //db.SaveChanges();
            //Console.WriteLine(s);
            Console.WriteLine("db created");
        }
    }

}
