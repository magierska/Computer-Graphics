using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor
{
    class IncompatibleTagsException : Exception
    {
        public IncompatibleTagsException()
        {
        }

        public IncompatibleTagsException(string message)
        : base(message)
        {
        }

        public IncompatibleTagsException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
