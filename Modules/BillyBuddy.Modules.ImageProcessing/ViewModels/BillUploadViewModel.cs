using Prism.Commands;
using BillBuddy.Core;
using System;
using System.ComponentModel;
using Prism.Navigation.Regions;
using Prism.Navigation;
using BillBuddy.Modules.ImageProcessing.Services;
using System.Collections.Generic;

namespace BillBuddy.Modules.ImageProcessing.ViewModels
{
    public class BillUploadViewModel : ViewModelBase
    {
        private readonly IRegionManager _regionManager;

        private Uri _billImageUri;
        public Uri BillImageUri
        {
            get { return _billImageUri; }
            set { SetProperty(ref _billImageUri, value); }
        }

        public string SelectedLanguage { get; set; }

        public List<string> SupportedLanguages => IOCRService.Languages.GetAllSupported();

        public DelegateCommand NextPageCommand { get; private set; }

        public BillUploadViewModel(IRegionManager regionManager, IOCRService OCRService) 
        {
            _regionManager = regionManager;

            NextPageCommand = new DelegateCommand(GoToNextPage, HasUploadedImage)
                .ObservesProperty(() => BillImageUri);
        }

        private void GoToNextPage()
        {
            var navParams = new NavigationParameters();
            navParams.Add(BillDataExtractViewModel.NavigationParamNames.BillImageURI, BillImageUri);
            navParams.Add(BillDataExtractViewModel.NavigationParamNames.BillLanguage, string.IsNullOrEmpty(SelectedLanguage) ? IOCRService.Languages.English : SelectedLanguage);

            _regionManager.RequestNavigate(RegionNames.ContentRegion, "BillDataExtractView", navParams);
        }

        private bool HasUploadedImage()
        {
            return BillImageUri != null && BillImageUri.IsFile;
        }
    }
}
