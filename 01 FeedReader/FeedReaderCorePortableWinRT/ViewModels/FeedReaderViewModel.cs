using System.Collections.ObjectModel;
using FeedReaderCore.Code;
using FeedReaderCore.Models;

namespace FeedReaderCore.ViewModels {
  public class FeedReaderViewModel : ViewModelBase {
    private ObservableCollection<FeedItem> _feedItems;

    public FeedReaderViewModel() {
      RefreshCommand = new DelegateCommand(async arg => {
        var res = await DataManager.Instance.UpdateFeed("http://dotnetautor.de/GetRssFeed");
        FeedItems = new ObservableCollection<FeedItem>(res);
      });
    }

    public ObservableCollection<FeedItem> FeedItems {
      get { return _feedItems; }
      set {
        if (_feedItems == value) return;
        _feedItems = value;
        OnPropertyChanged();
      }
    }

    public DelegateCommand RefreshCommand { get; protected set; }
  }
}
