using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace ZxingSample.ViewModels
{
    public class ScannerPageViewModel : ViewModelBase
    {
        INavigationService _navigationService;
        IDeviceService _deviceService;
        IPageDialogService _pageDialogService;

        public Command<ZXing.Result> ScanResultCommand => new Command<ZXing.Result>(result => {
            _deviceService.BeginInvokeOnMainThread(() =>
            {
                _navigationService.GoBackAsync();
                _pageDialogService.DisplayAlertAsync("スキャン完了", result.Text, "OK");
            });
        });

        public ScannerPageViewModel(INavigationService navigationService, IDeviceService deviceService, IPageDialogService pageDialogService)
            : base(navigationService)
        {
            Title = "Scanner Page";
            _navigationService = navigationService;
            _deviceService = deviceService;
            _pageDialogService = pageDialogService;
        }
    }
}
