using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ClientServer
{


    public class ClientServer
    {

        static int clientCount;
        static void createClient(Object obj)
        {
            TcpListener server = (TcpListener)obj;
            TcpClient client = server.AcceptTcpClient();
            int clientId = Interlocked.Increment(ref clientCount);
            Console.WriteLine($"Client {clientId} connected");

            // Console.WriteLine("Client connected!!!!");

            NetworkStream stream = client.GetStream();

            byte[] buffer = new byte[1024];
            int byteRead = stream.Read(buffer, 0, buffer.Length);

            string message = Encoding.UTF8.GetString(buffer, 0, byteRead);

            Console.WriteLine("Client Say's: " + message);

            string reply = "Hello Client";

            byte[] data = Encoding.UTF8.GetBytes(reply);

            stream.Write(data, 0, data.Length);


            Console.WriteLine("!!!!!........... Conversation Started .............!!!!!  ");


            string m;
            string clientmsg;
            do
            {
                byte[] buff = new byte[1024];
                int byteR = stream.Read(buff, 0, buff.Length);
                clientmsg = Encoding.UTF8.GetString(buff, 0, byteR);
                Console.WriteLine("\nClient no" + clientId + " Say's: " + clientmsg);

                m = Console.ReadLine().ToString();
                byte[] serverMsg = Encoding.UTF8.GetBytes(m);
                stream.Write(serverMsg, 0, serverMsg.Length);



            } while (clientmsg != "bye");



            client.Close();
        }

        public static void Main(string[] args)
        {

            TcpListener server = new TcpListener(IPAddress.Any, 5002);
            try
            {
                server.Start();


                Console.WriteLine("Server started.........");
                Console.WriteLine("Waiting for client.....");

                while (true)
                {
                    Thread t1 = new Thread(createClient);
                    t1.Start(server);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error::   " + e.Message);
            }
            server.Stop();

        }
    }
}
