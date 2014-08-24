using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedReaderCore.Utilities {
  public static class PlattformAdapter {
    public static bool DesignModeEnabled { get; set; }

    static PlattformAdapter() {
      DesignModeEnabled = true;
    }
  }
}
