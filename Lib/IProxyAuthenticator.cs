using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrotiNet
{
    /// <summary>
    /// Interface to allow for custom Authentication Implementations. 
    /// </summary>
    public interface IProxyAuthenticator
    {
        /// <summary>
        /// Authenticates the user with the specified username/password
        /// </summary>
        /// <param name="username">Username passed from the browser</param>
        /// <param name="password">Password passed from the browser</param>
        /// <returns>true if the supplied credentials are correct, otherwise false.</returns>
        bool Authenticate(string username, string password);
    }
}
