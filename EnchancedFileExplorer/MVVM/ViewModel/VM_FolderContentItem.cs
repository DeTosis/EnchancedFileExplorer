using EnchancedFileExplorer.MVVM.Utilities;
using System.Drawing;
using System.IO;
using System.Windows.Interop;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Reflection;

namespace EnchancedFileExplorer.MVVM.ViewModel; 
public class VM_FolderContentItem : ViewModelBase {
	private string fullItemName;
	public string FullItemName {
		get => fullItemName;
		set {
			fullItemName = value;
			ContentItemName = Path.GetFileName(value);
		}
	}


    private string contentItemName = "#Error#";
	public string ContentItemName{
		get => contentItemName;
		set { 
			contentItemName = value;
			OnPropertyChanged();
			SetIcon();
		}
	}

	private ImageSource itemIcon;
	public ImageSource ItemIcon {
		get => itemIcon;
		set {
            itemIcon = value;
			OnPropertyChanged();
		}
	}

	private void SetIcon() {
		Icon? icon = null;
		ImageSource? imageSource = null;

		if (File.Exists(FullItemName)) {
			icon = Icon.ExtractAssociatedIcon(FullItemName);
		} else {
			icon = new Icon($@".\Resources\folder.ico");
		}
		
		imageSource = Imaging.CreateBitmapSourceFromHIcon(
			icon.Handle,
			Int32Rect.Empty,
			BitmapSizeOptions.FromEmptyOptions());

        ItemIcon = imageSource;
	}
}
