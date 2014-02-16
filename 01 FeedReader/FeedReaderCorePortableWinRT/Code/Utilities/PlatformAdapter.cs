using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FeedReaderCore.Code.Utilities {
  public abstract class PlatformAdapter {
    public static PlatformAdapter Current { get; set; }

    public abstract Task<string> ReadResponseStream(HttpWebResponse response);
  }
}
