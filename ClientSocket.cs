// Client Socket program which behaves like a messenger

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class ClientSocket
{
    static TcpClient client;
    public ClientSocket()
    {
        string host = "localhost";
        int port = 5987;
        client = new TcpClient();
        client.Connect(host, port);
    }

    public static void Main(string[] args)
    {
        try
        {
            ClientSocket oClientSocket = new ClientSocket();
            // oClientSocket.ReceiveMessage();
            Thread t = new Thread(new ThreadStart(oClientSocket.ReceiveMessage));
            t.Start();
            oClientSocket.SendMessage();
        }
        catch(Exception)
        {
            client.Close();
        }
    }

    public void SendMessage()
    {
        while (true)
        {
            string Message = Console.ReadLine();
            byte[] data = Encoding.ASCII.GetBytes(Message);
            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);
        }
    }

    public void ReceiveMessage()
    {
        while (true)
        {
            byte[] data = new byte[1024];
            NetworkStream stream = client.GetStream();
            int bytes = stream.Read(data, 0, data.Length);
            string ReceivedMessage = Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine(ReceivedMessage);
        }
    }

}
