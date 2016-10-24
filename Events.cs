using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problm3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, string> idEvents = new Dictionary<string, string>();
            Dictionary<string, List<string>> participants = new Dictionary<string, List<string>>();

            char[] separator = new char[] {' ', ',' };


            while (!input.Equals("Time for Code"))
            {
                try
                {    
                string[] inputSplitted = input.Split(separator,StringSplitOptions.RemoveEmptyEntries).ToArray();


                if (input.Contains("#"))
                {

                    if (inputSplitted[1][0].Equals('#'))
                    {
                        string id = (inputSplitted[0]);
                        string eventname = string.Concat(inputSplitted[1].Skip(1));

                        if (idEvents.ContainsValue(id) && idEvents.ContainsKey(eventname))
                        {
                            if (idEvents[eventname] == id)
                            {
                                List<string> friends = participants[eventname];

                                for (long i = 2; i < inputSplitted.Length; i++)
                                {
                                    if (inputSplitted[i][0].Equals('@'))
                                    {
                                        if (!friends.Contains(inputSplitted[i].Substring(1)))
                                        {
                                            friends.Add(inputSplitted[i].Substring(1));
                                        }
                                    }
                                }
                                participants[eventname] = friends;
                            }
                        }
                        else if (!idEvents.ContainsValue(id))
                        {
                            idEvents[eventname] = id;

                            List<string> friends = new List<string>();

                            for (long i = 2; i < inputSplitted.Length; i++)
                            {
                                if (inputSplitted[i][0].Equals('@'))
                                {
                                    if (!friends.Contains(inputSplitted[i].Substring(1)))
                                    {
                                        friends.Add(inputSplitted[i].Substring(1));
                                    }
                                }

                            }

                            participants[eventname] = friends;
                        }
                    }
                }

                    input = Console.ReadLine();
                }
                catch (Exception)
                {
                    input = Console.ReadLine();
                }
               


            }

            foreach (var itempair in participants.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine("{0} - {1}", itempair.Key, itempair.Value.Count);
                foreach (var person in itempair.Value.OrderBy(x => x))
                {
                    Console.WriteLine("@{0}", person);
                }
            }
        }
    }
}
