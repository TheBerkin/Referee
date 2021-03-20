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
                
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("userid> ");
                    var userIdText = Console.ReadLine().Trim();
                    Console.ResetColor();

                    if (!uint.TryParse(userIdText, out uint userId)) continue;

                    var user = await ko.GetUserAsync(userId);

                    if (user == null)
                    {
                        Console.WriteLine("User not found.");
                        continue;
                    }

                    Console.WriteLine();

                    var bans = (await user.GetBansAsync()).ToList();

                    if (user.IsBanned)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("[BANNED] ");
                        Console.ResetColor();
                    }
                    Console.WriteLine($"{user.Username}#{user.Id}");

                    Console.WriteLine($"\nBans ({bans.Count})\n");

                    foreach(var ban in bans)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(ban);
                        Console.ResetColor();
                    }

                    Console.WriteLine();
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
