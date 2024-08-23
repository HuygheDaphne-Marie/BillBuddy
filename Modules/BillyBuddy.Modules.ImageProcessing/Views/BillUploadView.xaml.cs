using BillBuddy.Modules.ImageProcessing.ViewModels;
using HandyControl.Controls;
using System.Windows;
using System.Windows.Controls;

namespace BillBuddy.Modules.ImageProcessing.Views
{
    /// <summary>
    /// Interaction logic for BillUploadView.xaml
    /// </summary>
    public partial class BillUploadView : UserControl
    {
        public BillUploadView()
        {
            InitializeComponent();
        }

        private void ImageSelector_ImageSelected(object sender, RoutedEventArgs e)
        {
            var vm = ((BillUploadViewModel)DataContext);
            var selector = (ImageSelector)sender;

            vm.BillImageUri = selector.Uri;
        }
    }
}
