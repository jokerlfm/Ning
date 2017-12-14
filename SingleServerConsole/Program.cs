using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            AuthenticationServiceCore.Service authService = AuthenticationServiceCore.Service.GetService();
            authService.Start();

            RealmServiceCore.Service realmService = RealmServiceCore.Service.GetService();
            realmService.Start();

            while (true)
            {
                string command = Console.ReadLine();
                if (command.ToLower() == "quit")
                {
                    break;
                }
            }

            authService.Stop();
            realmService.Stop();
        }
    }
}
