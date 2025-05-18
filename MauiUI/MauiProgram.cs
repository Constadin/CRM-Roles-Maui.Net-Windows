
using CRM.Infrastructure.Configuration.Services;
using CRM.Infrastructure.Repositories;
using Microsoft.Extensions.Logging; // Εισάγει την υποστήριξη για logging.
using Prism; // Εισάγει τη βιβλιοθήκη Prism για την υποστήριξη MVVM.
using Prism.Navigation; // Εισάγει τις λειτουργίες πλοήγησης της Prism.
using DevExpress.Maui;
using MauiUI.Main.Login.Views;
using MauiUI.Main.Login.ViewModels;
using MauiUI.Main.Initializer.Views;
using MauiUI.Main.Initializer.ViewModels;
using MauiUI.UiLevel.CallCenters.Administrator.ViewModels;
using MauiUI.UiLevel.CallCenters.Administrator.Views;
using MauiUI.UiLevel.Dashboards.Views;
using MauiUI.UiLevel.Dashboards.ViewModels;
using MauiUI.Main.MainMenuNavi.Views;
using MauiUI.Main.MainMenuNavi.ViewModels;




namespace MauiUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder(); // Δημιουργεί έναν builder για την εφαρμογή.
            builder
                .UseMauiApp<App>() // Καθορίζει την κύρια εφαρμογή.
                .UseDevExpressControls()
                .UseDevExpress(useLocalization: false)
                .UseDevExpressCollectionView()
                .UsePrism((prismBuilder) => // Ενσωματώνει τη βιβλιοθήκη Prism.
                {
                    prismBuilder.RegisterTypes((registry) => // Καταχωρεί τύπους για πλοήγηση.
                    {
                        registry
                            .RegisterUiServices() // Καταχωρεί τις υπηρεσίες UI.

                            .RegisterForNavigation<InitializerViewPage, InitializerViewModel>()
                            .RegisterForNavigation<LoginViewPage, LoginViewModel>()
                            .RegisterForNavigation<MainMenuHubView, MainMenuViewModel>()
                            .RegisterForNavigation<DashboardViewPage, DashboardViewModel>()
                            .RegisterForNavigation<CallCenterViewPage, CallCenterViewModel>()
                            .RegisterForNavigation<MainPage>();
                    });

                    prismBuilder.CreateWindow(async (navigation) => // Δημιουργεί ένα παράθυρο και διαχειρίζεται την πλοήγηση.
                    {
                        await navigation.CreateBuilder() // Δημιουργεί έναν builder για την πλοήγηση.

                            .AddSegment<LoginViewPage>() // Προσθέτει τη σελίδα σύνδεσης στην πλοήγηση.
                            .NavigateAsync(); // Εκκινεί την πλοήγηση.
                    });
                })
                .ConfigureFonts(fonts => // Ρυθμίζει τις γραμματοσειρές.
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG // Αν η εφαρμογή είναι σε κατάσταση ανάπτυξης.
            builder.Logging.AddDebug(); // Προσθέτει logging για debugging.
#endif

            return builder.Build();
        }
    }
}
