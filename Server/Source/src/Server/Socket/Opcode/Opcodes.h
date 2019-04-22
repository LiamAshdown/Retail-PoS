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

#ifndef _OPCODE_OPCODES_h
#define _OPCODE_OPCODES_h
#include "Common/SharedDefines.h"
#include "Network/ClientPacket.h"
#endif /* _OPCODE_OPCODES_h */

enum ClientPacketHeader
{

};

enum ServerPacketHeader
{

};

namespace SteerStone
{
    class ClientSocket;

    struct OpcodeHandler
    {
        char const* Name;
        void (ClientSocket::*Handler)(std::unique_ptr<ClientPacket> l_Packet);
    };

    typedef std::map<uint64, OpcodeHandler> OpcodeMap;

    /// Stores Opcodes handler for server and client
    class Opcodes
    {
    public:
        static Opcodes* instance();

    public:
        /// Constructor
        Opcodes() {}

        /// Deconstructor
        ~Opcodes() {}

    public:
        /// InitializePackets
        /// Load our packets into storages to be accessed later
        void InitializePackets();

        /// GetClientPacket
        /// @p_Id : Id of client packet we are searching for
        OpcodeHandler const& GetClientPacket(const uint64& p_Id);

        /// GetServerPacket
        /// @p_Id : Id of server packet we are searching for
        OpcodeHandler const& GetServerPacket(const uint64& p_Id);

    private:
        /// StoreClientPacket
        /// Store Client packet into our storage
        /// @p_Opcode : Opcode Id
        /// @p_Name : Name of Opcode
        /// @p_Handler : Handler Function which we will be accessing too
        void StoreClientPacket(const uint64& p_OpCode, char const* p_Name, void (ClientSocket::*p_Handler)(std::unique_ptr<ClientPacket> l_Packet));

        /// StoreServerPacket
        /// Store Server packet into our storage
        /// @p_Opcode : Opcode Id
        /// @p_Name : Name of Opcode
        /// @p_Handler : Handler Function which we will be accessing too
        void StoreServerPacket(const uint64& p_OpCode, char const* p_Name, void (ClientSocket::*p_Handler)(std::unique_ptr<ClientPacket> l_Packet));

    private:
        static OpcodeHandler const m_EmptyHandler;      ///< Empty handler if our client packet has not been given a handler yet
        OpcodeMap m_ClientOpcode;                       ///< Holds our client packets
        OpcodeMap m_ServerOpcode;                       ///< Holds our server packets
    };
} ///< NAMESPACE STEERSTONE

#define sOpcode SteerStone::Opcodes::instance()