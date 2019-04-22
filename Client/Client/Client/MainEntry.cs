/*
* Liam Ashdown
* Copyright (C) 2019
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Windows.Forms;
using SteerStone.Handler;
using SteerStone.TCP;
using SteerStone.Encryption;

namespace SteerStone.Entry
{
    /// <summary>
    /// Main entry point to handle all forms
    /// </summary>
    public sealed class MainEntry : AsyncSocketClient
    {
        /// <summary>
        /// Static Constructor used for other forms are accessing this class
        /// </summary>
        static MainEntry() { }

        /// <summary>
        /// Private Constructor
        /// </summary>
        private MainEntry() { }

        /// <summary>
        /// Attempt to connect to database and load up forms etc..
        /// </summary>
        public void BootUp()
        {
            /// Initialize our server handlers
            m_MessageHandler.RegisterServerHandlers();

            /// Attempt to connect server
            if (!StartClient("127.0.0.1", 37120)) /// Hard coded address
                MessageBox.Show("Failed to connect to server, no response from server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                /// Boot up our login form for user to login
                m_Login = new Client.Login();
                m_Login.ShowDialog();
            }
        }
        /// <summary>
        /// Return our singleton class
        /// </summary>
        public static MainEntry GetInstance => m_Instance;

        /// <summary>
        /// Virtual method called when socket recieves data from server
        /// </summary>
        /// <param name="p_SocketData"></param>
        public override void ProcessIncomingData()
        {
            /// We can potentially recieve multiple packets in same stream, split them up and process from there
            string[] l_Buffer = System.Text.Encoding.Default.GetString(GetBuffer().Buffer).Split('\x1');
            foreach (string l_Itr in l_Buffer)
            {
                /// First 2 bytes are fake
                m_MessageHandler.ExecuteServerMessageHandler((uint)m_Base64.DecodeBase64((l_Itr.Substring(0, 2))));
            }
        }

        /// <summary>
        /// Pass the data into our socket class
        /// </summary>
        /// <param name="p_Buffer"></param>
        public void SendPacket(string p_Buffer)
        {
            Send(p_Buffer);
        }

        /// <summary>
        /// Returns our login form
        /// </summary>
        /// <returns></returns>
        public ref Client.Login GetLoginForm()
        {
            return ref m_Login;
        }

        /// <summary>
        /// Variables declarations
        /// </summary>
        private static readonly MainEntry m_Instance = new MainEntry();
        private static MessageHandler m_MessageHandler = new MessageHandler();
        Base64 m_Base64 = new Base64();

        /// Forms
        private Client.Login m_Login;
    }
}
