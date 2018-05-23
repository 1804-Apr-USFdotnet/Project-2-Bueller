﻿using Bueller.DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bueller.DAL.Repos
{
    public class ClassRepo : Crud<Class>
    {
        private readonly IDbContext _context;
        public ClassRepo(IDbContext context) : base(context)
        {
            _context = context;
        }

        public bool HasClassOnThisDay(string day, int classId)
        {
            var cls = this.Table.Where(x => x.ClassId == classId).FirstOrDefault();
            switch (day)
            {
                case "Monday":
                    if (cls.Mon == 1)
                        return true;
                    break;
                case "Tuesday":
                    if (cls.Tues == 1)
                        return true;
                    break;
                case "Wednesday":
                    if (cls.Wed == 1)
                        return true;
                    break;
                case "Thursday":
                    if (cls.Thurs == 1)
                        return true;
                    break;
                case "Friday":
                    if (cls.Fri == 1)
                        return true;
                    break;
            }
            return false;
        }

        public IEnumerable<Class> GetClassesByTeacherId(int id)
        {
            return this.Table.Where(x => x.TeacherId == id).ToList();
        }

        public IEnumerable<Class> GetClassesWithStudents()
        {
            return this.Table.Where(x => x.Students.Count() > 0).ToList();
        }

        public IEnumerable<Class> GetClassesWithAssignments()
        {
            return this.Table.Where(x => x.Assignments.Count() > 0).ToList();
        }

        public IEnumerable<Class> GetClassesByCredits(int credits)
        {
            return this.Table.Where(x => x.Credits == credits).ToList();
        }

        public IEnumerable<Class> GetClassesByRoomNumber(string room)
        {
            return this.Table.Where(x => x.RoomNumber.Equals(room)).ToList();
        }
    }
}
