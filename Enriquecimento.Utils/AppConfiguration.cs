using Microsoft.Extensions.Configuration;
using System.IO;

namespace Enriquecimento.Utils
{
    public class AppConfiguration
    {
        private static IConfiguration configuration = null;

        public static IConfiguration GetAppConfiguration(int origemAppsettingsJson)
        {
            string profilePath = string.Empty;
            if (origemAppsettingsJson == (int)Models.Enumeradores.OrigemAppsettingsJson.WebApp)
            {
                profilePath = Directory.GetCurrentDirectory();
            }
            else if (origemAppsettingsJson == (int)Models.Enumeradores.OrigemAppsettingsJson.ServiceBackground)
            {
                profilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                profilePath = profilePath.Replace("Enriquecimento.Data.dll", "");
                profilePath = profilePath.Replace("Enriquecimento.Models.dll", "");
                profilePath = profilePath.Replace("Enriquecimento.Service.dll", "");
                profilePath = profilePath.Replace("Enriquecimento.Utils.dll", "");
                profilePath = profilePath.Replace("Enriquecimento.WebSite.dll", "");
                profilePath = profilePath.Replace("Enriquecimento.WinService.dll", "");
            }
            configuration = new ConfigurationBuilder()
              .SetBasePath(profilePath)//Directory where the json files are located
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .Build();
            return (configuration);
        }
    }
}