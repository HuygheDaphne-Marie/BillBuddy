using BillBuddy.Core.Services;
using System;
using System.Collections.Generic;
using Tesseract;
using static BillBuddy.Modules.ImageProcessing.Services.IOCRService;

namespace BillBuddy.Modules.ImageProcessing.Services
{
    public interface IOCRService
    {
        public static class Languages
        {
            public const string English = "eng";
            public const string Dutch = "nld";

            public static List<string> GetAllSupported()
            {
                return new List<string> { English, Dutch };
            }
        }

        string ProcessImage(Uri ImageUri, string lang = Languages.English);
    }

    public class OCRService : IOCRService
    {
        private readonly IConfigService _configService;

        public OCRService(IConfigService configService) 
        {
            _configService = configService;
        }

        public string ProcessImage(Uri ImageUri, string lang = Languages.English)
        {
            try
            {
                using (var engine = new TesseractEngine(@"./tessdata", lang, EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(ImageUri.LocalPath))
                    {
                        using (var page = engine.Process(img))
                        {
                            return page.GetText();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Unexpected Error: " + e.Message);
                Console.Error.WriteLine("Details: ");
                Console.Error.WriteLine(e.ToString());

                throw;
            }
        }
    }
}
