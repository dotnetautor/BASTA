using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FeedReaderCore.Code.Utilities;

namespace FeedReaderWin8.Code.Utilites {
  internal class WindowsPlatformAdapter : PlatformAdapter {
    public override async Task<string> ReadResponseStream(HttpWebResponse response) {
      string result;

      using (var gzipStream =
        (string.Equals(response.Headers["Content-Encoding"], "gzip", StringComparison.CurrentCultureIgnoreCase))
          ? new GZipStream(response.GetResponseStream(), CompressionMode.Decompress)
          : response.GetResponseStream()) {

        using (var sr = new StreamReader(gzipStream)) {
          result = await sr.ReadToEndAsync();
        }
      }

      return result;
    }
  }
}
