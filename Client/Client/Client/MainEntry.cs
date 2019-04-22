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

using SteerStone.Handler;
using SteerStone.TCP;
using System.Windows.Forms;

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
        /// Constructor
        /// </summary>
        private MainEntry()
        {
        }

        /// <summary>
        /// Attempt to connect to database and load up forms etc..
        /// </summary>
        public void BootUp()
        {
            /// Attempt to connect server
            if (!StartClient("127.0.0.1", 37120)) /// Hard coded address
            {
                MessageBox.Show("Failed to connect to server, no response from server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                m_Login = new Client.Login();
                m_Login.ShowDialog();
            }
        }
        /// <summary>
        /// Return our single class
        /// </summary>
        public static MainEntry GetInstance => m_Instance;

        /// <summary>
        /// Virtual method called when socket recieves data from server
        /// </summary>
        /// <param name="p_SocketData"></param>
        public override void ProcessIncomingData()
        {
            /// We can potentially recieve multiple packets in same stream, split them up and process from there
            string[] l_Buffer = GetBuffer().BufferString.ToString().Split('\x1');
            foreach (string l_Itr in l_Buffer)
            {

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
        /// Variables declarations
        /// </summary>
        private static readonly MainEntry m_Instance = new MainEntry();

        /// Forms
        Client.Login m_Login;
    }
}
