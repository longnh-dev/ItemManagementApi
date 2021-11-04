using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemManagement.BackendApi.Exceptions
{
    public class ItemManagementException : Exception
    {
        public ItemManagementException()
        {
        }

        public ItemManagementException(string message) : base(message)
        {
        }

        public ItemManagementException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}