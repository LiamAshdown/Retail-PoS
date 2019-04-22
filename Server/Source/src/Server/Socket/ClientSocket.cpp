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

#include "ClientSocket.h"
#include "Database/QueryDatabase.h"
#include "Common/SHA1.h"
#include "Client.h"

namespace SteerStone
{
    /// Constructor 
    /// @p_Service : Boost Service
    /// @p_CloseHandler : Close Handler Custom function
    ClientSocket::ClientSocket(boost::asio::io_service& p_Service, std::function<void(Socket*)> p_CloseHandler) :
        Socket(p_Service, std::move(p_CloseHandler)), m_Client(nullptr)
    {
        /// Secret key for RC4 encryption/decryption
        SetKey("XGZH2J4M5N6Q8R9SBUCVDXFYGZJ3K4M6P7Q8SATBUCWEXFYH2J3K5N6P7R");
    }
   
    /// ToClient
       /// Returns our Client Class
    Client* ClientSocket::ToClient()
    {
        return m_Client;
    }
    
    /// DestroyClient
    void ClientSocket::DestroyClient()
    {
        m_Client = nullptr;
    }
    
    /// SendPacket 
    /// @p_Buffer : Buffer which holds our data to be send to the client
    void ClientSocket::SendPacket(StringBuffer const* p_Buffer)
    {
        if (IsClosed())
            return;

        Write((const char*)p_Buffer->GetContents(), p_Buffer->GetSize());
    }
    
    /// ProcessIncomingData - Handle incoming data
    bool ClientSocket::ProcessIncomingData()
    {
        std::vector<uint8> l_BufferVec;
        l_BufferVec.resize(ReadLengthRemaining());
        if (Read((char*)&l_BufferVec[0], ReadLengthRemaining()))
        {
            /// Remove junk characters from end of string
            l_BufferVec.resize(l_BufferVec.size() + 1);
            l_BufferVec[l_BufferVec.size() - 1] = 0;

            std::vector<std::string> l_Split;
            boost::split(l_Split, Decrypt((char*)&l_BufferVec[0]), boost::is_any_of(" "));

            for (auto const& l_Itr : l_Split)
            {
                std::unique_ptr<ClientPacket> l_Packet = std::make_unique<ClientPacket>(l_Itr.substr(2)); ///< First 2 bytes is fake
                std::string test = l_Packet->ReadString();

                LOG_INFO << "[INCOMING]: " << "[" << l_Packet->GetHeader() << "] [" << sOpcode->GetClientPacket(l_Packet->GetHeader()).Name << "]";

                ExecutePacket(sOpcode->GetClientPacket(l_Packet->GetHeader()), std::move(l_Packet));
            }

            return true;
        }
        else
            return false;
    }
    
    /// Client Handlers
    void ClientSocket::ExecutePacket(OpcodeHandler const& p_Handler, std::unique_ptr<ClientPacket> p_Packet)
    {
        (this->*p_Handler.Handler)(std::move(p_Packet));
    }
    
    /// ClientPacket is not handled yet
    void ClientSocket::HandleNULL(std::unique_ptr<ClientPacket> p_Packet)
    {

    }
}
