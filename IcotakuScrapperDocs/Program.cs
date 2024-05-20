using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace IcotakuScrapperDocs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            
            await builder.Build().RunAsync();

            //Initialise la connexion à la base de données SQLite
            IcotakuScrapper.DatabaseHandler.InitializeConnexion(IcotakuScrapper.DatabaseHandler.TestDbFilePath);

            //Crée les tables de la base de données SQLite
            await IcotakuScrapper.DatabaseHandler.CreateTablesAsync();

            //Interdit l'accès au contenu adulte au sein de l'application
            IcotakuScrapper.Options.IsAccessingToAdultContent = false;

            //Autorise l'accès au contenu explicite au sein de l'application
            IcotakuScrapper.Options.IsAccessingToExplicitContent = true;
        }
    }
}
