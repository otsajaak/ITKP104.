using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Soketti
{
    class Program
    {
        public static void Main()
        {
            string server = "www.example.com"; //"localhost"
            string resurssi = "/";
            string message = "GET " + resurssi + " HTTP/1.1\r\nhost:" + server + "\r\nConnection:Close\r\n\r\n";

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Connect(server, 80); //25000
            byte[] msg = Encoding.ASCII.GetBytes(message);
            s.Send(msg);
            byte[] rec = new byte[1];
            string sivu = "";
            int paljon = 0;
            do
            {
                paljon = s.Receive(rec);

                //Console.Write(Encoding.ASCII.GetString(rec, 0, paljon));
                sivu += Encoding.ASCII.GetString(rec, 0, paljon);

            } while (paljon > 0);
            Console.Write(sivu);
            //Console.ReadKey();
            s.Close();

        }
    }
}
