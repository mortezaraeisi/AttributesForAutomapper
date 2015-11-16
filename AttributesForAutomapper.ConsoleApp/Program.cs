using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using AttributesForAutomapper.DAL;
using AttributesForAutomapper.Domain;
using AttributesForAutomapper.ViewModels;
using AutoMapper;
using static System.Console;

namespace AttributesForAutomapper.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var assemblyToLoad = Assembly.GetAssembly(typeof (AdminStudentViewModel));//get assembly
            Configuration.Initialize(assemblyToLoad);//init automaper
            IList<Student> lst;
            using (var context = new MySampleContext())
            {
                lst = context.Students.Include(x => x.Books).ToList();
            }
            foreach (var student in lst)
                {
                    WriteLine(
                        $"[{student.Id}]*\n{student.Name} {student.Family}.\nmailto:{student.Email}.\nRegistered at'{student.RegisterDateTime}'");
                    foreach (var book in student.Books)
                        WriteLine($"\tBook name:{book.Name}, Book price:{book.Price}");
                }
            
            WriteLine("\n<><><><><><><><><> End of original list <><><><><><><><>\n");
            var lstViewModel = Mapper.Map<IList<Student>, IList<AdminStudentViewModel>>(lst);
            foreach (var adminStudentViewModel in lstViewModel)
            {
                WriteLine(
                    $"[{adminStudentViewModel.Id}]*\n\t{adminStudentViewModel.FirstName} {adminStudentViewModel.LastName}.\n\t" +
                    $"mailto:{adminStudentViewModel.Email}.\n\tRegistered at'{adminStudentViewModel.RegisterDateTimePersian}'\n\t" +
                    $"Book Counts: {adminStudentViewModel.BookCounts} with total price of {adminStudentViewModel.TotalBookPrice}");
            }
            WriteLine("Press any key to exit...");
            ReadKey();
        }
    }
}
