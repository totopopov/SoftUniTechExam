using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem4
{
    class Program
    {
        static void Main(string[] args)
        {

            char[] separator = new char[]{' ', ','};
            char[] healthproblems=new char[]{ '1', '2','3', '4', '5', '6', '7', '8', '9', '0', '.', '*', '+', '-', '/' };

            var input = Console.ReadLine().Split(separator,StringSplitOptions.RemoveEmptyEntries);
            string pattern = @"((-| )*(\d)+\.*(\d)*)";
            Regex rgx = new Regex(pattern);

            foreach (var demon in input.OrderBy(x=>x))
            {
                double multiply = 1;
                double damage = 0;
                var health = 0;
                for (int i = 0; i < demon.Length; i++)
                {
                    if (!healthproblems.Contains(demon[i]))
                    {
                        health += (int)demon[i];
                    }
                    else
                    {
                        if (demon[i].Equals('*'))
                        {
                            multiply *= 2;
                        }
                        if (demon[i].Equals('/'))
                        {
                            multiply /= 2;
                        }

                    }


                }

               MatchCollection match= rgx.Matches(demon);
               
               foreach (Match digit in match)
               {
                  damage+=double.Parse(digit.Groups[1].ToString());
               
               }



                Console.WriteLine("{0} - {1} health, {2:0.00} damage",demon,health,multiply* damage);
            }




        }
    }
}
