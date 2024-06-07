using kT7WcfServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Clientkt7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var factory = new ChannelFactory<ICustomService>(new CustomBinding(), new EndpointAddress("http://localhost:8733/Design_Time_Addresses/kT7WcfServiceLibrary/CustomService/"));
            //var client = factory.CreateChannel();

            //string response = client.Echo("Hello, WCF!");
            //Console.WriteLine($"Response: {response}");

            //var binding = new WSHttpBinding();
            ////binding.Security.Mode = SecurityMode.Message;
            ////binding.Security.Message.ClientCredentialType =
            ////MessageCredentialType.Windows;
            var endpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/kT7WcfServiceLibrary/CustomService/mx");
            var channelFactory = new ChannelFactory<ICustomService>(new CustomBinding(), endpoint);

            var proxy = channelFactory.CreateChannel();
            string response = proxy.Echo("Hello1, WCF!");
            Console.WriteLine($"Response: {response}");

            //var endpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/kT7WcfServiceLibrary/CustomService/");
            //var binding = new BasicHttpBinding();
            //var channelFactory = new ChannelFactory<ICustomService>(binding, endpoint);

            //var proxy = channelFactory.CreateChannel();
            //string response = proxy.Echo("Hello1, WCF!");
            //Console.WriteLine($"Response: {response}");
            //Console.ReadLine();

            Console.ReadLine();
        }

    }
}
