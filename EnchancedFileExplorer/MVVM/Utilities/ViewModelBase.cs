using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EnchancedFileExplorer.MVVM.Utilities; 
public class ViewModelBase : INotifyPropertyChanged {
    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string? name = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
