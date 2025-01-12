using CommunityToolkit.Mvvm.ComponentModel;

namespace ContactsAppWPF.ViewModels;
public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableObject _currentViewModel = null!;

}
