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

namespace SteerStone.Handler
{
    public sealed class MessageHandler
    {
        /// <summary>
        /// Static Constructor used for when MessageHandler is called
        /// </summary>
        static MessageHandler() { }

        /// <summary>
        ///  Private constructor gets called on first creation of MessageHandler
        /// </summary>
        private MessageHandler() { }

        /// <summary>
        /// Return our single class
        /// </summary>
        public static MessageHandler Instance => m_Instance;

        /// <summary>
        /// Initialize our client handlers
        /// </summary>
        public void RegisterClientHandlers()
        {
            m_ClientHandler = new ClientHandler[m_MaxMessageId];
            //m_ClientHandler[0] = new ClientHandler(CLIENT_HELLO);
        }

        public void ExecuteClientMessageHandler(uint p_HeaderId)
        {
            if (p_HeaderId <= m_MaxMessageId)
                if (m_ClientHandler[p_HeaderId] != null)
                    m_ClientHandler[p_HeaderId].Invoke();
        }

        /// <summary>
        /// Variables declarations
        /// </summary>
        private delegate void ClientHandler();
        private ClientHandler[] m_ClientHandler;
        private uint m_MaxMessageId = 200; // Max Header Id
        private static readonly MessageHandler m_Instance = new MessageHandler();
    }
}
