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

#ifndef _ENTITY_CLIENT_h
#define _ENTITY_CLIENT_h
#include "Common/SharedDefines.h"
#endif /* _ENTITY_CLIENT_h */

namespace SteerStone
{
    /// Holds information about client connecting to server
    class Client
    {
    public:
        friend class ClientSocket;
    public:
        /// Constructor
        Client();

        /// Deconstructor
        ~Client();

    public:
        uint32 GetId()              const       { return m_Id;       }
        std::string GetUsername()   const       { return m_Username; }
        std::string GetPassword()   const       { return m_Password; }

    private:
        uint32 m_Id;
        std::string m_Username;
        std::string m_Password;
    };
} ///< NAMESPACE STEERSTONE