using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivage
{
    class SendErrorToUserEventArgs : EventArgs
    {

        public string Error { set; get; }

        public SendErrorToUserEventArgs(string inError)
        {
            Error = inError;
        }
    }
}
