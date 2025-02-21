using System.Windows.Input;

namespace EnchancedFileExplorer.MVVM.Utilities; 
public class RelayCommandT<T> : ICommand {
    private Action<T> execute;
    private Func<T, bool>? canExecute;

    public RelayCommandT(Action<T> execute, Func<T, bool> canExecute = null) {
        if (execute == null) throw new ArgumentNullException();

        this.execute = execute;
        this.canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object? parameter) {
        return canExecute == null || canExecute((T)parameter);
    }

    public void Execute(object? parameter) {
        execute?.Invoke((T)parameter);
    }
}
