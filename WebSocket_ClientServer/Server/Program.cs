using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientServer
{
    public class ClientServer
    {
        public static void Main(string[] args)
        {
            try
            {
                TcpListener server=new TcpListener(IPAddress.Any,5000);
                server.Start();


                Console.WriteLine("Server started.........");
                Console.Write("Waiting for client.....");

                TcpClient client =server.AcceptTcpClient();
                Console.WriteLine("Client connected!!!!");

                NetworkStream stream=client.GetStream();

                byte[] buffer=new byte[1024];
                int byteRead=stream.Read(buffer,0,buffer.Length);

                string message=Encoding.UTF8.GetString(buffer,0,byteRead);

                Console.WriteLine("Client Say's: "+message);

                string reply="Hello Client";

                byte[] data=Encoding.UTF8.GetBytes(reply);

                stream.Write(data,0,data.Length);

                client.Close();
                server.Stop();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error::   "+e.Message);
            }
        }
    }
}
