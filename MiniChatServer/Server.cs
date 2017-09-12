using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MiniChatServer
{
    public class Server
    {
        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 7070);
            server.Start();

            using (TcpClient socket = server.AcceptTcpClient())
            using (NetworkStream ns = socket.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                string myLine = "";
                string line = string.Empty;

                while (true)
                {
                    line = sr.ReadLine();
                    Console.WriteLine(line);

                    if (line.ToUpper() == "STOP")
                    {
                        Console.WriteLine("Server received stop command from client...");
                        break;
                    }

                    myLine = Console.ReadLine();

                    sw.WriteLine(myLine);
                    sw.Flush();
                    if (myLine.ToUpper() == "STOP")
                    {
                        Console.WriteLine("Server cast a stop command");
                        break;
                    }
                }
                

            }
            Console.WriteLine("Server stopped");
            Console.WriteLine("press any key to close window");
            Console.ReadLine();



        }



    }
}
