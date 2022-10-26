using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luong
{
    internal class Program
    {
        static float calSalaryNoRe(float salary, int n)
        {
            for (int i = 0; i < n; i++)
            {
                salary = salary + (salary / 10);
            }
            return salary;
        }
        static float calSalaryUseRe(float salary, int n)
        {
            if (n == 0)
            {
                return salary;
            }
            else
            {
                n--;
                return (calSalaryUseRe(salary, n) / 10) + calSalaryUseRe(salary, n);
            }

        }
        static float calMonthNoRe(float money, float rate)
        {
            float month = 100 / rate;
            return Convert.ToUInt32(month);
        }
        static float calMonthUseRe(float money, float rate,int month=0)
        {
            if (money*rate * month/100-money >= 0)
            {
                return month;
            }
            else
            {
                return calMonthUseRe(money, rate, month+1);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("No Recursion:");
            Console.WriteLine("Enter Year:");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter salary:");
            float salary = Convert.ToSingle(Console.ReadLine());
            calSalaryNoRe(salary, year);
            Console.WriteLine(calSalaryNoRe(salary, year));
            Console.WriteLine("Enter Money");
            float money = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Rate");
            float rate= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Months needed:"+calMonthNoRe(money, rate));
            //
            Console.WriteLine("Using Recursion:");
            Console.WriteLine("Enter Year:");
            int year2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter salary:");
            float salary2 = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine(calSalaryUseRe(salary, year2));
            Console.WriteLine("Enter Money:");
            float money2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Rate:");
            float rate2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Months needed:" + calMonthUseRe(money2, rate2));


        }
    }
}
