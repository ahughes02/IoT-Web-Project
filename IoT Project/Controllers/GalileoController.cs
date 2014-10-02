using System;
using System.IO.Ports;
using System.Web.Mvc;
using System.Text;
using System.Net.NetworkInformation;

namespace IoT_Project.Controllers
{
    public class GalileoController : Controller
    {
        public string pingGalileo(string ip)
        {
            // Base variables
            const int timeout = 120;
            var response = " No Response";

            // Create the ping class and set options
            var ping = new Ping();
            var options = new PingOptions {DontFragment = true};

            // Create a buffer of 32 bytes of data to be transmitted. 
            const string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var buffer = Encoding.ASCII.GetBytes(data);
            

            // Ping the ip and get the reply
            var reply = ping.Send(ip, timeout, buffer, options);

            if (reply != null && reply.Status == IPStatus.Success)
            {
                response = " Address: <b>" + reply.Address + "</b>";
                response += " Round Trip time: <b>" + reply.RoundtripTime + "</b>";
                response += " Time to live: <b>" + reply.Options.Ttl + "</b>";
                response += " Don't fragment: <b>" + reply.Options.DontFragment + "</b>";
                response += " Buffer size: <b>" + reply.Buffer.Length + "</b>";
            }

            return response;
        }

        public string galileoRequest(string COM)
        {
            string response = "No Response";

            var port = new SerialPort(COM, 9600, Parity.None, 8, StopBits.One)
            {
                ReadTimeout = 500,
                WriteTimeout = 500
            };

            try
            {
                port.Open();
            }
            catch (Exception)
            {
                return response;
            }

            port.Write("s");

            try
            {
                response = port.ReadLine();
            }
            catch (TimeoutException)
            { }

            return response;
        }
    }
}