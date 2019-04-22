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

#include "ClientManager.h"
#include "Client.h"

namespace SteerStone
{
    /// Static StopWorld
    volatile bool ClientManager::s_StopWorld = false;
   
    /// Singleton Class
    ClientManager* ClientManager::instance()
    {
        static ClientManager instance;
        return &instance;
    }

    /// FindClient
    /// @p_Id : Account Id of client
    Client *ClientManager::FindClient(uint32 const& p_Id) const
    {
        auto const& l_Itr = m_Clients.find(p_Id);
        if (l_Itr != m_Clients.end() && l_Itr->second)
            return l_Itr->second;

        return nullptr;
    }
    
    /// AddClient
    /// @p_Client : Client we are adding
    void ClientManager::AddClient(Client* p_Client)
    {
        /// If the habbo already exists in our storage, then disconnect session, and insert our new session
        auto const& l_Itr = m_Clients.find(p_Client->GetId());
        if (l_Itr != m_Clients.end())
            delete l_Itr->second;

        m_Clients[p_Client->GetId()] = p_Client;
    }
   
    /// RemoveClient
    /// @p_Client : Client to remove
    void ClientManager::RemoveClient(Client* p_Client)
    {
        auto const& l_Itr = m_Clients.find(p_Client->GetId());
        if (l_Itr != m_Clients.end() && l_Itr->second)
            m_Clients.erase(l_Itr);
    }

    /// StopWorld
    /// Stop server from updating all clients and shut down
    bool ClientManager::StopClients()
    {
        return s_StopWorld;
    }

    /// UpdateClients
    /// @p_Diff : Diff time of updating all clients
    void ClientManager::UpdateClients(uint32 const& p_Diff)
    {
        for (auto l_Itr = m_Clients.begin(); l_Itr != m_Clients.end();)
        {
            Client* l_Client = l_Itr->second;

          
            ++l_Itr;
        }
    }
   
    /// Clean Up
    /// Clean up the objects before shutting down
    void ClientManager::CleanUp()
    {
        for (auto& l_Itr = m_Clients.begin(); l_Itr != m_Clients.end();)
        {
            delete l_Itr->second;
            l_Itr = m_Clients.erase(l_Itr);
        }

        m_Clients.clear();
    }
} ///< NAMESPACE STEERSTONE