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

namespace SteerStone
{
    /// Singleton
    Opcodes* Opcodes::instance()
    {
        static Opcodes instance;
        return &instance;
    }

    OpcodeHandler const Opcodes::m_EmptyHandler =
    {
        "<none>",
        &ClientSocket::HandleNULL
    };

    /// InitializePackets
    /// Load our packets into storages to be accessed later
    void Opcodes::InitializePackets()
    {
        LOG_INFO << "Loaded " << m_ClientOpcode.size() << " CMSG opcodes";
        LOG_INFO << "Loaded " << m_ServerOpcode.size() << " SMSG opcodes";
    }

    /// StoreClientPacket
    /// Store Client packet into our storage
    /// @p_Opcode : Opcode Id
    /// @p_Name : Name of Opcode
    /// @p_Handler : Handler Function which we will be accessing too
    void Opcodes::StoreClientPacket(const uint64& p_Opcode, char const* p_Name, void(ClientSocket::*p_Handler)(std::unique_ptr<ClientPacket> l_Packet))
    {
        OpcodeHandler& ref = m_ClientOpcode[p_Opcode];
        ref.Name = p_Name;
        ref.Handler = p_Handler;
    }

    /// StoreServerPacket
    /// Store Server packet into our storage
    /// @p_Opcode : Opcode Id
    /// @p_Name : Name of Opcode
    /// @p_Handler : Handler Function which we will be accessing too
    void Opcodes::StoreServerPacket(const uint64& p_Opcode, char const* p_Name, void(ClientSocket::*p_Handler)(std::unique_ptr<ClientPacket> l_Packet))
    {
        OpcodeHandler& ref = m_ServerOpcode[p_Opcode];
        ref.Name = p_Name;
        ref.Handler = p_Handler;
    }

    /// GetClientPacket
    /// @p_Id : Id of client packet we are searching for
    OpcodeHandler const& Opcodes::GetClientPacket(const uint64& p_Id)
    {
        OpcodeMap::const_iterator l_Itr = m_ClientOpcode.find(p_Id);
        if (l_Itr != m_ClientOpcode.end())
            return l_Itr->second;
        return m_EmptyHandler;
    }

    /// GetServerPacket
    /// @p_Id : Id of server packet we are searching for
    OpcodeHandler const& Opcodes::GetServerPacket(const uint64& p_Id)
    {
        OpcodeMap::const_iterator l_Itr = m_ClientOpcode.find(p_Id);
        if (l_Itr != m_ServerOpcode.end())
            return l_Itr->second;
        return m_EmptyHandler;
    }
} ///< NAMESPACE STEERSTONE
