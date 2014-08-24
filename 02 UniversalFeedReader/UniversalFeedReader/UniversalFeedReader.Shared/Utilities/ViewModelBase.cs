using System.ComponentModel;
using System.Runtime.CompilerServices;
#if !WIN8_PORTABLE
using Windows.ApplicationModel;
#else
using FeedReaderCore.Utilities;
#endif

namespace UniversalFeedReader.Utilities {
  public class ViewModelBase : INotifyPropertyChanged {
    public static bool IsInDesignMode {
      #if !WIN8_PORTABLE
      get { return DesignMode.DesignModeEnabled; }
      #else
      get { return PlattformAdapter.DesignModeEnabled ; }
      #endif
    }
    
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
      PropertyChangedEventHandler handler = PropertyChanged;
      if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
