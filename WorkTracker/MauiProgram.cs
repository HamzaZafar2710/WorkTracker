using Microsoft.Extensions.Logging;

#if ANDROID
using Android.Content.Res;
#endif

namespace WorkTracker
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

#if ANDROID
            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("BorderlessPicker", (handler, view) =>
            {
                if (view is WorkTracker.Controls.BorderlessPicker)
                {
                    handler.PlatformView.BackgroundTintList =
                        ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
                }
            });
#endif

            return builder.Build();
        }
    }
}
