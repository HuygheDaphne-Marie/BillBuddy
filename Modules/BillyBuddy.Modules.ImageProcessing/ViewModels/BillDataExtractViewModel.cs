using BillBuddy.Core;
using BillBuddy.Modules.ImageProcessing.Services;
using Prism.Navigation.Regions;
using System;

namespace BillBuddy.Modules.ImageProcessing.ViewModels
{
    public class BillDataExtractViewModel : ViewModelBase
    {
        public static class NavigationParamNames
        {
            public const string BillImageURI = "BillImageURI";
            public const string BillLanguage = "BillLanguage";
        }

        private readonly IOCRService _OCRService;

        public Uri BillImage { get; set; }
        public string BillLanguage { get; set; }
        public string BillText { get; set; } = "No text";

        public BillDataExtractViewModel(IOCRService OCRService)
        {
            _OCRService = OCRService;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            BillImage = navigationContext.Parameters.GetValue<Uri>(NavigationParamNames.BillImageURI);
            BillLanguage = navigationContext.Parameters.GetValue<string>(NavigationParamNames.BillLanguage);
            BillText = _OCRService.ProcessImage(BillImage, BillLanguage);
        }
    }
}
