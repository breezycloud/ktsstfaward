using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ktsstfportal.Util
{
    public interface IConverter
    {
        public Task<byte[]> ConvertImageToByte(string fileNumber);
        public Task<byte[]> GetImageByte(string value);
    }
}
