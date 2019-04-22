using System;
using System.Windows.Forms;
using SteerStone.Handler;
using SteerStone.Entry;
using SteerStone.SharedDefines;

namespace Client
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Login to server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Button_Login_Click(object sender, EventArgs e)
        {
            /// Send our login details to server
            ServerPacket l_ServerPacket = new ServerPacket();
            l_ServerPacket.AppendInterger(Common.SERVER_LOGIN);
            l_ServerPacket.AppendString(Login_Box_Username.Text);
            l_ServerPacket.AppendString(Login_Box_Password.Text);
            MainEntry.GetInstance.SendPacket(l_ServerPacket.GetData());
        }
    }
}
