using System;
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
                var subforum = await ko.GetSubforumAsync(1);
                var page = await subforum.GetPageAsync(1);

                Console.WriteLine($"Subforum: {subforum.Name}");
                Console.WriteLine($"(Threads: {subforum.ThreadCount})");

                if (page != null)
                {
                    Console.WriteLine($"(Page {page.PageNumber}/{page.PageCount})\n");

                    foreach (var thread in page.Threads)
                    {
                        Console.WriteLine($"-> {thread.Title}");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($"  - by {thread.Author}");
                        Console.WriteLine($"  - {thread.PostCount} post(s)");
                        Console.ResetColor();
                    }
                }
            }
            catch (KnockoutException ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Knockout error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine($"YOU FUCKED UP!\n\n{ex}");
            }
            finally
            {
                Console.ResetColor();
            }
        }
    }
}
