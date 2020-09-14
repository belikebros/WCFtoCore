using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Microsoft.Extensions.Configuration;
using System.IO;
using WCFService;
using System.Data.SqlClient;

namespace WCFServiceConsoleHost
{
    class Program
    {
        private static IConfiguration _iconfiguration;
        private static string _connectionString;
       
        static void Main(string[] args)
        {
            GetAppSettingsFile();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                Console.WriteLine("Host started @ " + DateTime.Now.ToString());
            }
            Console.ReadLine();

            //using (WCFService.DataQuadService host = new WCFService.DataQuadService())
            //{
            //    host.Open();
            //    Console.WriteLine("Host started @ " + DateTime.Now.ToString());
            //    Console.ReadLine();
            //}
        }

        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _iconfiguration = builder.Build();
            _connectionString = _iconfiguration.GetConnectionString("DataquadEntities");
        }
    }
}
