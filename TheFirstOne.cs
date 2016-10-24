using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFirstOne
{
    class Program
    {
        static void Main(string[] args)
        {

            int marathondDays = int.Parse(Console.ReadLine());

            int runnersParticipating = int.Parse(Console.ReadLine());

            int averageLapsPerRunner = int.Parse(Console.ReadLine());

            int trackLenght = int.Parse(Console.ReadLine());

            int trackCapacity = int.Parse(Console.ReadLine());

            decimal donationsPerKm = decimal.Parse(Console.ReadLine());


            long allDaysCapacity = (long)marathondDays * trackCapacity;

            decimal runnersRunning = Math.Min(runnersParticipating, allDaysCapacity);

            decimal moneyRaised = (decimal)trackLenght * runnersRunning * averageLapsPerRunner * donationsPerKm / 1000;

            Console.WriteLine("Money raised: {0:0.00}",moneyRaised);



        }
    }
}
