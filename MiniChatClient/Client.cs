using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MiniChatClient
{
    public class Client
    {
        public void Start()
        {
            TcpClient socket = new TcpClient("localhost", 7070);
            using (NetworkStream ns = socket.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {

                while (true)
                {
                    string cLine = Console.ReadLine();
                    sw.WriteLine(cLine);
                    sw.Flush();
                    if (cLine.ToUpper() == "STOP")
                    {
                        Console.WriteLine("Local host stopped connection with server");
                        break;
                    }

                    string line = sr.ReadLine();
                    Console.WriteLine(line);

                    if (line.ToUpper() == "STOP")
                    {
                        Console.WriteLine("Received stop command from server");
                        break;
                    }

                }

            }
            Console.WriteLine("Client stopped");
            Console.WriteLine("press any key to close window");
            Console.ReadLine();

        }
    }
}
