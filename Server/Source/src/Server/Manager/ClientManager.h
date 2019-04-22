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

#ifndef _MANAGER_CLIENT_MANAGER_h
#define _MANAGER_CLIENT_MANAGER_h
#include "Common/SharedDefines.h"
#include "Common/Timer.h"
#include "Config/Config.h"
#include "Database/QueryDatabase.h"
#include "Platform/Thread/ThreadPool.h"
#include <mutex>
#endif /* _MANAGER_CLIENT_MANAGER_h */

namespace SteerStone
{
    class Client;

    typedef std::unordered_map<uint32, Client*> ClientMap;

    /// Class which runs the hotel
    /// Singleton Class
    class ClientManager
    {
    public:
        static ClientManager* instance();

    public:
        /// Constructor
        ClientManager() {}
        /// Deconstructor
        ~ClientManager() {}

    public:
        /// FindClient
        /// @p_Id : Account Id of client
        Client* FindClient(uint32 const& p_Id) const;

        /// AddClient
        /// @p_Client : Client we are adding
        void AddClient(Client* p_Client);

        /// RemoveClient
        /// @p_Client : Client to remove
        void RemoveClient(Client* p_Client);

        /// StopWorld
        /// Stop server from updating all clients and shut down
        static bool StopClients();

        /// UpdateClients
        /// @p_Diff : Diff time of updating all clients
        void UpdateClients(uint32 const& p_Diff);

        /// Clean Up
        /// Clean up the objects before shutting down
        void CleanUp();

    private:
        /// Variables
        ClientMap m_Clients;                             ///< Container which holds the Clients
        std::mutex m_Mutex;                              ///< Mutex
        static volatile bool s_StopWorld;
    };
}

#define sHotel SteerStone::Hotel::instance()