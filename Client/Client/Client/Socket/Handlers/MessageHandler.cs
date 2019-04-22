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

using SteerStone.SharedDefines;
using SteerStone.Entry;

namespace SteerStone.Handler
{
    /// <summary>
    /// Responsible for executing the server opcode handlers
    /// </summary>
    public sealed class MessageHandler
    {
        /// <summary>
        ///  Private constructor gets called on first creation of MessageHandler
        /// </summary>
        public MessageHandler() { }

        /// <summary>
        /// Initialize our client handlers
        /// </summary>
        public void RegisterServerHandlers()
        {
            m_ServerHandler = new ServerHandler[Common.MaxHeaderId];
            m_ServerHandler[Common.SERVER_VERSION_CHECK] = new ServerHandler(HandleVersionCheck);
        }

        /// <summary>
        /// Execute the server opcode handler
        /// </summary>
        /// <param name="p_HeaderId"></param>
        public void ExecuteServerMessageHandler(uint p_HeaderId)
        {
            if (p_HeaderId <= Common.MaxHeaderId)
                if (m_ServerHandler[p_HeaderId] != null)
                    m_ServerHandler[p_HeaderId].Invoke();
        }

        /// <summary>
        /// Check if client version matches the expected version from server
        /// </summary>
        private void HandleVersionCheck()
        {
            /// TODO; Check version logic
        }

        /// <summary>
        /// Variables declarations
        /// </summary>
        private delegate void ServerHandler();
        private ServerHandler[] m_ServerHandler;
    }
}
