using System;
using System.Linq;
using System.Threading.Tasks;

namespace Referee.Terminal
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var ko = new Knockout();

                foreach(var sub in await ko.GetSubforumsAsync())
                {
                    Console.WriteLine($"[#{sub.Id}] {sub.Name}");
                    Console.WriteLine($"  -> {sub.Description}");
                    Console.WriteLine($"  -> {sub.ThreadCount} threads");
                    Console.WriteLine($"  -> {sub.PostCount} posts");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine("YOU FUCKED UP!");
                Console.Error.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }
    }
}
