using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework3.Models
{
    public class SampleData
    {
        public static void Initialize(UniversityContext context)
        {
            if (!context.Students.Any())
            {
                context.Students.AddRange(
                    new Student
                    {
                        Name = "Евгений Е",
                        Age = 21,
                        GroupName = "КН-601"
                    },
                    new Student
                    {
                        Name = "Андрей С",
                        Age = 22,
                        GroupName = "КН-701"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
