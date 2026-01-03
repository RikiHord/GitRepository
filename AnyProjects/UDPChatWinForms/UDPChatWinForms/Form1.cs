using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDPChatWinForms
{
    public partial class Form1 : Form
    {

        //Settings
        bool alive = false;
        UdpClient client;
        const int LOCALPORT = 8001;
        const int REMOTEPORT = 8001;
        const int TTL = 20;
        const string HOST = "235.5.5.1";
        IPAddress groupAddress;

        string username;

        public Form1()
        {
            InitializeComponent();

            but_save.Enabled = true;
            but_exit.Enabled = false;
            but_send.Enabled = false;
            tb_chat.ReadOnly = true;

            groupAddress = IPAddress.Parse(HOST);
        }

        private void but_save_Click(object sender, EventArgs e)
        {
            username = tb_username.Text;
            tb_username.ReadOnly = true;

            try
            {
                client = new UdpClient(LOCALPORT);
                client.JoinMulticastGroup(groupAddress, TTL);

                var receiveTask = new Task(ReceiveMessage);
                receiveTask.Start();

                string msg = $"{username} вошел в чат";
                byte[] data = Encoding.Unicode.GetBytes(msg);
                client.Send(data, data.Length, HOST, REMOTEPORT);

                but_save.Enabled = false;
                but_exit.Enabled = true;
                but_send.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReceiveMessage()
        {
            alive = true;

            try
            {
                while (alive)
                {
                    IPEndPoint remoteIP = null;
                    byte[] data = client.Receive(ref remoteIP);
                    string message = Encoding.Unicode.GetString(data);

                    this.Invoke(new MethodInvoker(() =>
                    {
                        string time = DateTime.Now.ToShortTimeString();
                        tb_chat.Text = $"{time} {message} \r\n{tb_chat.Text}";
                    }));
                }
            }
            catch (ObjectDisposedException)
            {
                if (!alive) return;
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void but_send_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = $"{username}: {tb_msg.Text}";
                byte[] data = Encoding.Unicode.GetBytes(msg);
                client.Send(data, data.Length, HOST, REMOTEPORT);
                tb_msg.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExitChat()
        {
            string msg = $"{username} покидает чат";
            byte[] data = Encoding.Unicode.GetBytes(msg);
            client.Send(data, data.Length, HOST, REMOTEPORT);
            client.DropMulticastGroup(groupAddress);

            alive = false;
            client.Close();

            but_save.Enabled = true;
            but_exit.Enabled = false;
            but_send.Enabled = false;
        }

        private void but_exit_Click(object sender, EventArgs e)
        {
            ExitChat();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (alive) ExitChat();
        }
    }
}
