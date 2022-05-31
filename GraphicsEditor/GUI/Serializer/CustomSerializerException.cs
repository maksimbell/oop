using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Serializer
{
    public class CustomSerializerException: Exception
    {
        public CustomSerializerException(string message = "Serializer is down") : base(message){ }
    }
}
