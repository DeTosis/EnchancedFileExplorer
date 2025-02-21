using System.Windows.Input;
using System.Windows;

namespace EnchancedFileExplorer.MVVM.Utilities; 
class MouseBehavior {
    #region MouseDownCommandProperty
    public static readonly DependencyProperty MouseDownCommandProperty = DependencyProperty.RegisterAttached(
    "MouseDownCommand", typeof(ICommand), typeof(MouseBehavior),
    new PropertyMetadata(MouseDownCommandPropertyChanged));

    private static void MouseDownCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        if (d == null) return;
        var element = d as UIElement;
        element.MouseDown += (sender, args) => {
            GetMouseDownCommand(element).Execute(args);
            args.Handled = true;
        };
    }

    public static void SetMouseDownCommand(UIElement element, ICommand command)
        => element.SetValue(MouseDownCommandProperty, command);
    public static ICommand GetMouseDownCommand(UIElement element)
        => (ICommand)element.GetValue(MouseDownCommandProperty);
    #endregion
    //---------------------
    #region MouseEnterCommandProperty
    public static readonly DependencyProperty MouseEnterCommandProperty = DependencyProperty.RegisterAttached(
    "MouseEnterCommand", typeof(ICommand), typeof(MouseBehavior),
    new PropertyMetadata(MouseEnterCommandPropertyChanged));

    private static void MouseEnterCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        if (d == null) return;
        var element = d as UIElement;
        element.MouseEnter += (sender, args) => {
            GetMouseEnterCommand(element).Execute(args);
            args.Handled = true;
        };
    }

    public static void SetMouseEnterCommand(UIElement element, ICommand command)
        => element.SetValue(MouseEnterCommandProperty, command);
    public static ICommand GetMouseEnterCommand(UIElement element)
        => (ICommand)element.GetValue(MouseEnterCommandProperty);
    #endregion
    //---------------------
    #region MouseExitCommandProperty
    public static readonly DependencyProperty MouseExitCommandProperty = DependencyProperty.RegisterAttached(
    "MouseExitCommand", typeof(ICommand), typeof(MouseBehavior),
    new PropertyMetadata(MouseExitCommandPropertyChanged));

    private static void MouseExitCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        if (d == null) return;
        var element = d as UIElement;
        element.MouseLeave += (sender, args) => {
            GetMouseExitCommand(element).Execute(args);
            args.Handled = true;
        };
    }

    public static void SetMouseExitCommand(UIElement element, ICommand command)
        => element.SetValue(MouseExitCommandProperty, command);
    public static ICommand GetMouseExitCommand(UIElement element)
        => (ICommand)element.GetValue(MouseExitCommandProperty);
    #endregion
}
