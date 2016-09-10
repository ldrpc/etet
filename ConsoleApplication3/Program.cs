using MySql.Data.MySqlClient;
using RiotApi.Net.RestClient;
using RiotApi.Net.RestClient.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        public static Process proc { get; set; }

        public static Process procs { get; set; }
        static public IRiotClient riotClient = new RiotClient("RGAPI-0D0CE575-FE44-4B51-9F62-90A913C1D943");



        static void Main(string[] args) => new Program().Start();

        public void getMatch(string name)
        {
            try
            {
                Task.Delay(4000).Wait();
                var g = riotClient.Summoner.GetSummonersByName(RiotApiConfig.Regions.NA, name.ToLower().Replace(" ", string.Empty));
                var Fellow = new Dictionary<int, long>();
                var t = g[name.ToLower().Replace(" ", string.Empty)];
                var games = riotClient.Game.GetRecentGamesBySummonerId(RiotApiConfig.Regions.NA, t.Id).Games.ToList();
                Random rnd = new Random();
                int month = rnd.Next(0, 5);
                int i = 1;
                foreach (var e in games[month].FellowPlayers.ToList())
                {
                    Fellow.Add(i, e.SummonerId);
                    i++;

                }
                Task.Delay(1500).Wait();
                var FellowGames1 = riotClient.Game.GetRecentGamesBySummonerId(RiotApiConfig.Regions.NA, Fellow[1]).Games.ToList()[0];
                var FellowGames2 = riotClient.Game.GetRecentGamesBySummonerId(RiotApiConfig.Regions.NA, Fellow[2]).Games.ToList()[0];
                var FellowGames3 = riotClient.Game.GetRecentGamesBySummonerId(RiotApiConfig.Regions.NA, Fellow[3]).Games.ToList()[0];
                var FellowGames4 = riotClient.Game.GetRecentGamesBySummonerId(RiotApiConfig.Regions.NA, Fellow[4]).Games.ToList()[0];
                Task.Delay(1000).Wait();
                var user1 = riotClient.Summoner.GetSummonersById(RiotApiConfig.Regions.NA, Fellow[1].ToString())[Fellow[1].ToString()].Name;
                var user2 = riotClient.Summoner.GetSummonersById(RiotApiConfig.Regions.NA, Fellow[2].ToString())[Fellow[2].ToString()].Name;
                var user3 = riotClient.Summoner.GetSummonersById(RiotApiConfig.Regions.NA, Fellow[3].ToString())[Fellow[3].ToString()].Name;
                var user4 = riotClient.Summoner.GetSummonersById(RiotApiConfig.Regions.NA, Fellow[4].ToString())[Fellow[4].ToString()].Name;

                Console.WriteLine(name);
                Console.WriteLine(user1);
                Console.WriteLine(user2);
                Console.WriteLine(user3);
                Console.WriteLine(user4);

                AddUser(name);
                Task.Delay(500).Wait();
                AddUser(user1);
                Task.Delay(500).Wait();
                AddUser(user2);
                Task.Delay(500).Wait();
                AddUser(user3);
                Task.Delay(500).Wait();
                AddUser(user4);
                Task.Delay(500).Wait();

            }
            catch
            {

            }
        }
        public void getMom(string name)
        {
            try
            {
                Task.Delay(4000).Wait();
                var g = riotClient.Summoner.GetSummonersByName(RiotApiConfig.Regions.NA, name.ToLower().Replace(" ", string.Empty));
                var Fellow = new Dictionary<int, long>();
                var t = g[name.ToLower().Replace(" ", string.Empty)];
                var games = riotClient.Game.GetRecentGamesBySummonerId(RiotApiConfig.Regions.NA, t.Id).Games.ToList();
                Random rnd = new Random();
                int month = rnd.Next(0, 5);
                int i = 1;
                foreach (var e in games[month].FellowPlayers.ToList())
                {
                    Fellow.Add(i, e.SummonerId);
                    i++;

                }
                Task.Delay(1500).Wait();
                var FellowGames1 = riotClient.Game.GetRecentGamesBySummonerId(RiotApiConfig.Regions.NA, Fellow[1]).Games.ToList()[0];
                var FellowGames2 = riotClient.Game.GetRecentGamesBySummonerId(RiotApiConfig.Regions.NA, Fellow[2]).Games.ToList()[0];
                var FellowGames3 = riotClient.Game.GetRecentGamesBySummonerId(RiotApiConfig.Regions.NA, Fellow[3]).Games.ToList()[0];
                var FellowGames4 = riotClient.Game.GetRecentGamesBySummonerId(RiotApiConfig.Regions.NA, Fellow[4]).Games.ToList()[0];
                Task.Delay(1000).Wait();
                var user1 = riotClient.Summoner.GetSummonersById(RiotApiConfig.Regions.NA, Fellow[1].ToString())[Fellow[1].ToString()].Name;
                var user2 = riotClient.Summoner.GetSummonersById(RiotApiConfig.Regions.NA, Fellow[2].ToString())[Fellow[2].ToString()].Name;
                var user3 = riotClient.Summoner.GetSummonersById(RiotApiConfig.Regions.NA, Fellow[3].ToString())[Fellow[3].ToString()].Name;
                var user4 = riotClient.Summoner.GetSummonersById(RiotApiConfig.Regions.NA, Fellow[4].ToString())[Fellow[4].ToString()].Name;


                Console.WriteLine(user1);
                Console.WriteLine(user2);
                Console.WriteLine(user3);
                Console.WriteLine(user4);


                AddUser(user1);
                Task.Delay(500).Wait();
                AddUser(user2);
                Task.Delay(500).Wait();
                AddUser(user3);
                Task.Delay(500).Wait();
                AddUser(user4);
                Task.Delay(500).Wait();
            }
            catch
            {

            }
        }
        public bool AddUser(string name)
        {

            // First let's create the using statement:
            // The using statement will make sure your objects will be disposed after
            // usage. Even if you return a value in the block.
            // It's also syntax sugar for a "try - finally" block.
            string serverIp = "localhost";
            string username = "root";
            string password = "salami";
            string databaseName = "league";

            using (MySqlConnection cn = new MySqlConnection(string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName)))
            {
                // Here we have to create a "try - catch" block, this makes sure your app
                // catches a MySqlException if the connection can't be opened, 
                // or if any other error occurs.

                try
                {
                    // Here we already start using parameters in the query to prevent
                    // SQL injection.
                    string query = "INSERT INTO league (User) VALUES (@name);";

                    cn.Open();

                    // Yet again, we are creating a new object that implements the IDisposable
                    // interface. So we create a new using statement.

                    using (MySqlCommand cmd = new MySqlCommand(query, cn))
                    {
                        // Now we can start using the passed values in our parameters:

                        cmd.Parameters.AddWithValue("@name", name);

                        // Execute the query
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }

                    // All went well so we return true
                    getMom(name);
                    cn.Close();
                    return true;
                }
                catch (MySqlException)
                {
                    cn.Close();
                    // Here we got an error so we return false
                    return false;
                }
            }




        }
        public void Start()
        {
            Console.WriteLine("Program started... Using user clgimaqtipie696 as starter");
            getMatch("antifluke");


        }
        private static int StartProcessHidden(string FileName, bool WaitForExit, string Arguments = "")
        {
            using (Process myProc = new Process()) //Create a new object called myProc as Process.
            {
                myProc.StartInfo.FileName = FileName; //Give the process file name reveived by the method.
                myProc.StartInfo.Arguments = Arguments; //Give the arguments received.
                myProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; //As hidden window style.
                myProc.StartInfo.CreateNoWindow = true; //Create no window property as true.
                myProc.StartInfo.UseShellExecute = false; //Disable the shellexecute since we do not want to see any window.
                myProc.Start(); //Start the process.
                if (WaitForExit)
                    myProc.WaitForExit(); //Wait for the process if the 'WaitForExit' was sent as true.
                return myProc.ExitCode; //Return the exit code of the process to the method.
            }
        }
    }
}

