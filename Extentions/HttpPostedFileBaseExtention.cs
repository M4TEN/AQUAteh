using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ShopGiacomini.Extentions
{
    public static class HttpPostedFileBaseExtention
    {
        public static byte[] ToByteArray(this HttpPostedFileBase file)
        {
            var rdr = new BinaryReader(file.InputStream);
            var res = rdr.ReadBytes(file.ContentLength);
            return res;
        }
    }
}