using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            var avgNumbers = numbers.Average();
            var sumNumbers = numbers.Sum();
            Console.WriteLine($"Average: {avgNumbers}, Sum: {sumNumbers}");

            //Order numbers in ascending order and decsending order. Print each to console.
            var ascending = numbers.Where(num=> num >= 0).OrderBy(num=> num +1 );
            
            foreach (int num in ascending)
            {
                Console.WriteLine($"{num}");
            }
            Console.WriteLine("-------------------");

            var descending = numbers.Where(num => num >=0).OrderByDescending(num => num);
            foreach (int num in descending)
            {
                Console.WriteLine($"{num}");
            }
            //Print to the console only the numbers greater than 6
            Console.WriteLine("---------Numbers Greater than 6-----------");
            var greaterThan6 = numbers.Where(num => num > 6);
            foreach(int num in greaterThan6)
            {
                Console.WriteLine($"{num}");
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("-------------------------");
            var descending2 = numbers.Where(num => num >= 6).OrderByDescending(num => num);
            foreach(int num in descending2)
            {
                Console.WriteLine($"{num}");
            }

            Console.WriteLine("----------------------");
            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[3] = 26;

            foreach(int num in descending2)
            {
                Console.WriteLine($"{num}");
            }
                
            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            Console.WriteLine("---------C or S------------");
            var cOrS = employees.Where(employee => employee.FirstName.Contains("S") || employee.FirstName.Contains("C")).OrderBy(employee => employee.FirstName);
            foreach (var name in cOrS)
            {
                Console.WriteLine($"{name.FullName}");
            }
            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("---------Over 26------------");
            var over26 = employees.Where(x => x.Age > 26).OrderBy(employee => employee.Age).ThenBy(employee => employee.FirstName);
            foreach (var name in over26)
            {
                Console.WriteLine($"{name.Age}, {name.FullName}");
            }
            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            List<Employee> randomness = new List<Employee>(employees.Where(employee => employee.YearsOfExperience <= 10 && employee.Age > 35));
            var sum = 0;
            foreach (var item in randomness)
            {
                sum += item.YearsOfExperience;    
            }
            Console.WriteLine($"{sum}");
            Console.WriteLine($"{(sum / randomness.Count())}");
            
            
            
            //Add an employee to the end of the list without using employees.Add()

            
            Console.WriteLine("--------------------------------------");

            var newEmployee = new Employee()
            {
                FirstName = "Ryan",
                LastName = "Reynolds",
                Age = 36,
                YearsOfExperience = 20
            };
            employees.Insert(10, newEmployee);

            foreach(var item in employees)
            {
                Console.WriteLine($"{item.FullName}");
            }
            
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
