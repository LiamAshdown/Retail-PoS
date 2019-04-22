using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteerStone.SharedDefines
{
    /// <summary>
    /// Class which holds global variables
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// Size of our buffer to read
        /// </summary>
        public const int BufferSize = 4096;

        /// <summary>
        /// Secret key to decrypt RC4 data
        /// </summary>
        public const string SecretKey = "XGZH2J4M5N6Q8R9SBUCVDXFYGZJ3K4M6P7Q8SATBUCWEXFYH2J3K5N6P7R";

        /// <summary>
        /// Initialize connetion between server and client
        /// </summary>
        public const int SERVER_HELLO = 0x0;

        /// <summary>
        /// Sends Login details to server
        /// </summary>
        public const int SERVER_LOGIN = 0x1;
    }
}
