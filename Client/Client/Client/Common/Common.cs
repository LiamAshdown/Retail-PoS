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
        /// Max Header Id we can accept
        /// </summary>
        public const uint MaxHeaderId = 200;

        /// <summary>
        /// Initialize connetion between server and client
        /// </summary>
        public const int CLIENT_HELLO = 0x0;

        /// <summary>
        /// Sends Login details to server
        /// </summary>
        public const int CLIENT_LOGIN = 0x1;

        /// <summary>
        /// Check if client version matches with server expected version
        /// </summary>
        public const int SERVER_VERSION_CHECK = 0x0;
    }
}
