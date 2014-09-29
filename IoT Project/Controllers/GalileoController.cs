using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            var timeout = 120;
            var response = " No Response";

            // Create the ping class and set options
            var ping = new Ping();
            var options = new PingOptions();
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted. 
            var data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var buffer = Encoding.ASCII.GetBytes(data);
            

            // Ping the ip and get the reply
            var reply = ping.Send(ip, timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                response = " Address: <b>" + reply.Address.ToString() + "</b>";
                response += " Round Trip time: <b>" + reply.RoundtripTime + "</b>";
                response += " Time to live: <b>" + reply.Options.Ttl + "</b>";
                response += " Don't fragment: <b>" + reply.Options.DontFragment + "</b>";
                response += " Buffer size: <b>" + reply.Buffer.Length + "</b>";
            }

            return response;
        }
    }
}