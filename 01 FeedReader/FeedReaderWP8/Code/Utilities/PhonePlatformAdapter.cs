using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FeedReaderCore.Code.Utilities;

namespace FeedReaderWP8.Code.Utilities {
  public class PhonePlatformAdapter : PlatformAdapter {
    public override async Task<string> ReadResponseStream(HttpWebResponse response) {

      string result = "";
      Stream stream =
        (string.Equals(response.Headers[HttpRequestHeader.ContentEncoding], "gzip", StringComparison.OrdinalIgnoreCase))
#if !WP8
          ? await TaskEx.Run(() => (response.GetResponseStream().Decompress()))
#else
          ? await Task.Run(() => (response.GetResponseStream().Decompress()))
#endif
          : response.GetResponseStream();

      using (var reader = new StreamReader(stream)) {
        result = await reader.ReadToEndAsync();
      }

      return result;
    }
  }
}
