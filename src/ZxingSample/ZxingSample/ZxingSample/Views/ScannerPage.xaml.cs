using System;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace ZxingSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScannerPage : ZXingScannerPage
    {
		public ScannerPage ()
		{
			InitializeComponent ();

            DefaultOverlayTopText = "バーコードを読み取ります";
            DefaultOverlayBottomText = "";

            this.OnScanResult += (result) =>
            {
                this.ScanFinished?.Invoke(this, new ScanFinishedEventArgs(result));
                this.IsScanning = false;
            };
        }
        public event EventHandler<ScanFinishedEventArgs> ScanFinished;
    }
}