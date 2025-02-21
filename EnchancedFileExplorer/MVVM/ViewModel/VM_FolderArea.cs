using EnchancedFileExplorer.MVVM.Model;
using EnchancedFileExplorer.MVVM.Utilities;
using EnchancedFileExplorer.MVVM.View.FolderBlock;
using System.Collections.ObjectModel;

namespace EnchancedFileExplorer.MVVM.ViewModel;
public class VM_FolderArea : ViewModelBase {
    private string adressBarText;
    public string AdressBarText {
        get => adressBarText;
        set {
            adressBarText = value;
            OnPropertyChanged();
            UpdateCollection();
        }
    }

    private ObservableCollection<FolderContentItem> contentItems = new();
    public ObservableCollection<FolderContentItem> ContentItems {
        get => contentItems;
        set {
            ContentItems = value;
            OnPropertyChanged();
        }
    }

    private void UpdateCollection() {
        DirectoryParser dp = new();
        if (!dp.ParseDirectory(AdressBarText)) return;
        ContentItems.Clear();

        foreach (var item in dp.directoryItems) {
            var newItem = new FolderContentItem();
            var dataContext = newItem.DataContext as VM_FolderContentItem;
            dataContext.FullItemName = item;

            ContentItems.Add(newItem);
        }
    }
}
