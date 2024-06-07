using kT7WcfServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Kt7WCF_Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(CustomService), new Uri("http://localhost:8733/Design_Time_Addresses/kT7WcfServiceLibrary/CustomService/mx")))
            {
                host.AddServiceEndpoint(typeof(ICustomService), new CustomBinding(), "");
                host.Open();

                Console.WriteLine("Service is running...");
                Console.ReadLine();
            }
        }
    }
}
