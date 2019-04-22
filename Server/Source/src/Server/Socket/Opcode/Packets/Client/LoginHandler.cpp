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
#include "Opcode/Packets/Server/LoginPackets.h"

namespace SteerStone
{
    void ClientSocket::HandleHello(std::unique_ptr<ClientPacket> p_Packet)
    {
        Packet::Login::VersionCheck l_Packet;
        SendPacket(l_Packet.Write());
    }

    void ClientSocket::HandleUserLogin(std::unique_ptr<ClientPacket> p_Packet)
    {
        std::string l_Username = p_Packet->ReadString();
        std::string l_Password = p_Packet->ReadString();
        int i = 0;
    }
    
} ///< NAMESPACE STEERSTONE
