using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class Server : Form
    {
        public bool isThoat = true;
        public Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }

        public event EventHandler dangxuat;
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            dangxuat(this, new EventArgs());

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (isThoat)
              Application.Exit();
        }
 
        IPEndPoint IP;
        Socket server;
        List<Socket> clientList;

        //kết nối đến sever
        void Connect()
        {
            clientList = new List<Socket>();
            IP = new IPEndPoint(IPAddress.Any, 9999);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            server.Bind(IP);
            Thread Listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        clientList.Add(client);

                        Thread reseive = new Thread(Receive);
                        reseive.IsBackground = true;
                        reseive.Start(client);
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 9999);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });
            Listen.IsBackground = true;
            Listen.Start();
        }
        //đóng kết nối hiện thời
     

        //nhận tin
        void Send(Socket client)
        {
            if (client != null && txbMessage.Text != string.Empty)
                client.Send(Serialize(txbMessage.Text));
        }
        //gửi tin
        void Receive(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    string message = (string)Deserialize(data);

                    foreach (Socket item in clientList)
                    {
                        if (item != null && item != client)
                            item.Send(Serialize(message));
                    }

                    AddMessage(message);
                }
            }
            catch
            {
                clientList.Remove(client);
                client.Close();
            }

        }

        //add dữ liệu vào khung chat
        void AddMessage(string s)
        {
            IsvMessage.Items.Add(new ListViewItem() { Text = s });
        }
        //phân mảnh
        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            return stream.ToArray();
        }
        //gom
        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
        }
       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click_1(object sender, EventArgs e)
        {
            foreach (Socket item in clientList)
            {
                Send(item);
            }
            AddMessage(txbMessage.Text);
            txbMessage.Clear();
        }

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isThoat)
                Application.Exit();
        }
    }
}
