using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AttributesForAutomapper.DAL;
using AttributesForAutomapper.Domain;
using AttributesForAutomapper.ViewModels;
using static System.Console;

namespace AttributesForAutomapper.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var assemblyToLoad = Assembly.GetAssembly(typeof (AdminStudentViewModel));//get assembly
            global::AttributesForAutomapper.Configuration.Initialize(assemblyToLoad);//init automaper

            IList<Student> lst;
            using (var context = new MySampleContext())
            {
                lst = context.Students.Include(x => x.Books).ToList();
                foreach (var student in lst)
                {
                    WriteLine(
                        $"{student.Id}- {student.Name} {student.Family}. mailto:{student.Email}. Registered at'{student.RegisterDateTime}'");
                }
            }

            var lstViewModel = AutoMapper.Mapper.Map<IList<Student>, IList<AdminStudentViewModel>>(lst);
            foreach (var adminStudentViewModel in lstViewModel)
            {
                WriteLine(
                    $"[{adminStudentViewModel.Id}]******************************-\n\t" +
                    $"{adminStudentViewModel.FirstName} {adminStudentViewModel.LastName}.\n\t" +
                    $"mailto:{adminStudentViewModel.Email}.\n\t" +
                    $"Registered at'{adminStudentViewModel.RegisterDateTimePersian}'\n\t" +
                    $"Book Counts: {adminStudentViewModel.BookCounts} with total price of {adminStudentViewModel.BookPrice}");

            }
            WriteLine("Press any key to exit...");
            ReadKey();
        }
    }
}
