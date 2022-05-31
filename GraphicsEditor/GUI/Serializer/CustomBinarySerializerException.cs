using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Serializer
{
    public class CustomBinarySerializerException: Exception
    {
        public CustomBinarySerializerException(string message = "Serializer is down") : base(message){ }
    }
}
