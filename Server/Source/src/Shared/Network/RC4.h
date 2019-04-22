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

#ifndef _NETWORK_RC4_h
#define _NETWORK_RC4_h
#include "../Common/SharedDefines.h"
#endif /* _NETWORK_RC4_h */

namespace SteerStone
{
    /// Encrypts/Decrypts the given data
    class RC4
    {
    public:
        /// Constructor
        RC4();

        /// Deconstructor
        ~RC4();

    public:
        /// Initialize
        /// Begin our KSA initialization
        void Initialize();

        /// SetKey
        /// @p_Key : The key we will use to encrypt/decrypt with
        bool SetKey(std::string const p_Key);

        /// Encrypt 
        /// Return our encrypted data
        /// @p_Data : Set data to be encrypted
        std::string Encrypt(std::string p_Data);

        /// Decrypt
        /// Return our decrypted data
        /// @p_Data : Set data to be decrypted
        std::string Decrypt(std::string p_Data);

    private:
        unsigned char m_S[256];
        std::string m_Key;
    };
}
