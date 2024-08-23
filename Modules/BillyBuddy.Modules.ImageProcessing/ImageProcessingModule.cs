using BillBuddy.Modules.ImageProcessing.Views;
using Prism.Ioc;
using Prism.Modularity;
using BillBuddy.Core;
using Prism.Navigation.Regions;
using BillBuddy.Modules.ImageProcessing.ViewModels;
using BillBuddy.Modules.ImageProcessing.Services;

namespace BillBuddy.Modules.ImageProcessing
{
    public class ImageProcessingModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ImageProcessingModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(BillUploadView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IOCRService, OCRService>();

            containerRegistry.RegisterForNavigation<BillDataExtractView, BillDataExtractViewModel>();
        }
    }
}