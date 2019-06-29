using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Services
{
    public class TCPFileSender
    {
        IPAddress _address;
        TcpClient _client;
        TcpClient _clientInfo;

        int _port;

        NetworkStream streamInfo;

        public TCPFileSender(IPAddress address, int port)
        {
            _address = address;
            _port = port;
        }
        public TCPFileSender(string address, int port)
        {
            _address = IPAddress.Parse(address);
            _port = port;
        }

        bool Connect()
        {
            try
            {
                if (_client != null)
                    _client.Close();

                _client = new TcpClient();
                _clientInfo = new TcpClient();

                _client.Connect(_address, _port);
                _clientInfo.Connect(_address, _port);

                streamInfo = _clientInfo.GetStream();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public FileInfo sendFile(string file)
        {
            try
            {
                Connect();
                return sendInfo(file);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public FileInfo sendInfo(string file)
        {
            FileInfo _info = new FileInfo(file);
            byte[] fileSize = Encoding.UTF8.GetBytes(_info.Length.ToString() + @"..@.." + Path.GetFileName(file));
            streamInfo.Write(fileSize, 0, fileSize.Length);
            return _info;
        }
        void sendProcessing(string file)
        {
            _client.Client.SendFile(file);
        }
        public delegate void SendCompleteHandler(object sender);
        public event SendCompleteHandler SendCompleted;
    }

    public class TCPFileReciever
    {
        public TcpListener _listener, _listenerInfo;
        TcpClient _client;
        TcpClient _clientInfo;

        long _size;

        NetworkStream streamInfo;
        public TCPFileReciever(IPAddress address, int port)
        {
            _listener = new TcpListener(address, port);
            _listenerInfo = new TcpListener(address, port + 1);

        }
    }
}
