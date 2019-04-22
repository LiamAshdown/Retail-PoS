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

#pragma once
#include "Common/SharedDefines.h"
#include "ClientSocket.h"

namespace SteerStone
{
    namespace Packet
    { 
        namespace Login
        {
            /// SMSG_HELLO packet builder
            class VersionCheck final : public ServerPacket
            {
            public:
                /// Constructor 
                VersionCheck() : ServerPacket(SMSG_VERSION_CHECK) {}

            public:
                /// Write the packet
                StringBuffer const* Write();
            };
        } ///< NAMESPACE LOGIN
    } ///< NAMESPACE PACKET
} ///< NAMESPACE STEERSTONE