using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.ChainOfResponsibility.UserValidation
{
    internal class Request
    {
        public string Username { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool HasPermission { get; set; }
        public bool IsWithinLimit { get; set; }

        public Request(string username, bool isAuthenticated, bool hasPermission, bool isWithinLimit)
        {
            Username = username;
            IsAuthenticated = isAuthenticated;
            HasPermission = hasPermission;
            IsWithinLimit = isWithinLimit;
        }
    }
}
