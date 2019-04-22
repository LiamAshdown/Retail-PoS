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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using SteerStone.SharedDefines;
using SteerStone.Encryption;
using SteerStone.Handler;

namespace SteerStone.TCP
{
    /// <summary>
    /// Holds Buffer and size
    /// </summary>
    public class BufferData
    {
        public byte[] Buffer = new byte[Common.BufferSize];
        public StringBuilder BufferString = new StringBuilder();
    }

    /// <summary>
    ///  To Handle incoming data and sending outgoing data to and from server
    /// </summary>
    public class AsyncSocketClient : CryptionCoder
    {
        /// <summary>
        /// Attempt to connect client to server
        /// </summary>
        /// <param name="p_Address"></param>
        /// <param name="p_Port"></param>
        protected bool StartClient(string p_Address, int p_Port)
        {
            try
            {
                IPHostEntry l_IpHost = Dns.GetHostEntry(p_Address);
                IPAddress l_Ip = l_IpHost.AddressList[0];
                IPEndPoint l_RemoteEndPoint = new IPEndPoint(l_Ip, p_Port);

                m_Socket = new Socket(l_Ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                m_Socket.BeginConnect(l_RemoteEndPoint, new AsyncCallback(ConnectionCallBack), m_Socket);

                /// Let server know we are ready to accept data!
                ServerPacket l_ServerPacket = new ServerPacket();
                l_ServerPacket.AppendInterger(Common.SERVER_LOGIN);
                l_ServerPacket.AppendSOH();
                Send(l_ServerPacket.GetData());

                Recieve();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Wait for any incoming data from server
        /// </summary>
        protected void Recieve()
        {
            try
            {
                m_Socket.BeginReceive(m_Buffer.Buffer, 0, Common.BufferSize, SocketFlags.None, new AsyncCallback(RecieveCallBack), m_Buffer);
                m_RecieveCompleted.WaitOne();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// Read data sent by server
        /// </summary>
        /// <param name="p_Ar"></param>
        private void RecieveCallBack(IAsyncResult p_Ar)
        {
            try
            {
                int l_BytesRecieved = m_Socket.EndReceive(p_Ar);

                if (l_BytesRecieved > 0)
                {
                    m_Buffer.BufferString.Append(m_Cryption.DecryptRC4((Encoding.ASCII.GetString(m_Buffer.Buffer, 0, l_BytesRecieved))));
                    m_Buffer.BufferString.Append((Encoding.ASCII.GetString(m_Buffer.Buffer, 0, l_BytesRecieved)));

                    string test = m_Buffer.BufferString.ToString();

                    /// Pass the data into our Client to handle
                    ProcessIncomingData();

                    /// Continue to read data
                    m_Socket.BeginReceive(m_Buffer.Buffer, 0, Common.BufferSize, SocketFlags.None, new AsyncCallback(RecieveCallBack), m_Buffer);
                }

                m_RecieveCompleted.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public virtual void ProcessIncomingData() { }

        /// <summary>
        /// Send data to server
        /// </summary>
        /// <param name="p_Buffer"></param>
        protected void Send(string p_Buffer)
        {
            try
            {
                m_Socket.BeginSend(m_Cryption.EncryptRC4(p_Buffer), 0, m_Cryption.EncryptRC4(p_Buffer).Length, 0, new AsyncCallback(SendCallBack), m_Socket);
                m_SendCompleted.WaitOne();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// End of completion of sending data to server
        /// </summary>
        /// <param name="p_Ar"></param>
        private void SendCallBack(IAsyncResult p_Ar)
        {
            try
            {
                /// TODO; Should we do anything here?
                int l_BytesSent = m_Socket.EndSend(p_Ar);
                m_SendCompleted.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// Connection call back
        /// </summary>
        /// <param name="p_Ar"></param>
        private void ConnectionCallBack(IAsyncResult p_Ar)
        {
            try
            {
                m_Socket.EndConnect(p_Ar);
                m_ConnectCompleted.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        protected ref BufferData GetBuffer()
        {
            return ref m_Buffer;
        }

        /// <summary>
        /// Variables declarations
        /// </summary>
        private Socket m_Socket = null;
        private BufferData m_Buffer = new BufferData();
        private CryptionCoder m_Cryption = new CryptionCoder();
        private ManualResetEvent m_ConnectCompleted = new ManualResetEvent(false);
        private ManualResetEvent m_SendCompleted = new ManualResetEvent(false);
        private ManualResetEvent m_RecieveCompleted = new ManualResetEvent(false);
    }
}
