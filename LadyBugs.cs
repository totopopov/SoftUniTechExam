using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {

            int fieldSize = int.Parse(Console.ReadLine());

            int[] bugsPosition = new int[fieldSize];


            int[] bugsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < bugsInput.Length; i++)
            {
                if (bugsInput[i]< bugsPosition.Length && bugsInput[i] >=0)
                {
                    bugsPosition[bugsInput[i]] = 1;
                }
            }
            

            var commandLine = Console.ReadLine().Split();

            while (!commandLine[0].Equals("end"))
            {
                int flyIndex = int.Parse(commandLine[0]);
                string direction = commandLine[1];
                int positions = int.Parse(commandLine[2]);

              

                if (0<=flyIndex&&flyIndex< fieldSize)
                {
                    if (positions<0)
                    {
                        if (direction.Equals("right"))
                        {
                            direction = "left";
                            positions = Math.Abs(positions);
                        }
                        else
                        {
                            direction = "right";
                            positions = Math.Abs(positions);
                        }

                    }



                    if (bugsPosition[flyIndex]==1)
                    {
                        bugsPosition[flyIndex] = 0;

                        if (direction.Equals("right"))
                        {

                            for (int i = flyIndex+positions; i < bugsPosition.Length; i+= positions)
                            {
                                if (bugsPosition[i]==0)
                                {
                                    bugsPosition[i] = 1;
                                    break;
                                }

                            }

                        }
                        else
                        {
                            for (int i = flyIndex - positions; i >= 0; i-= positions)
                            {
                                if (bugsPosition[i] == 0)
                                {
                                    bugsPosition[i] = 1;
                                    break;
                                }
                            }
                        }

                    }
                }
               // Console.WriteLine(string.Join(" ", bugsPosition));
                commandLine = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ",bugsPosition));


           



        }
    }
}
