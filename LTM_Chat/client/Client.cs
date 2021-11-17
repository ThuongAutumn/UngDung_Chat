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

namespace client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Send();
            AddMessage(txbMessage.Text);
        }
        
        IPEndPoint IP;
        Socket client;

        //kết nối đến sever
        void Connect()
        {
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            try
            {
                client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối", "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }
        //đóng kết nối hiện thời
        void Close()
        {
            client.Close();
        }

        //nhận tin
        void Send()
        {
            if (txbMessage.Text != string.Empty)
                client.Send(Serialize(txbMessage.Text));
        }
        //gửi tin
        void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    string message = (string)Deserialize(data);
                    AddMessage(message);
                }
            }
            catch
            {
                Close();
            }
            
        }

        //add dữ liệu vào khung chat
        void AddMessage(string s)
        {
            IsvMessage.Items.Add(new ListViewItem() { Text = s });
            txbMessage.Clear();
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

        private void Client_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// đóng kết nối khi đóng form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
