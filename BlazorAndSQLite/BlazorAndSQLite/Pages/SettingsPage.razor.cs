using BlazorAndSQLite.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorAndSQLite.Pages
{
    public partial class SettingsPage : IDisposable
    {
        [Inject]
        IDbContextFactory<ApplicationDbContext>? DbFactory { get; set; }

        public ApplicationDbContext? DbContext { get; private set; }
        public Settings? SettingsViewModel { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            DbContext = DbFactory?.CreateDbContext();

            if (DbContext?.Settings != null)
            {
                var settings = await DbContext.Settings.SingleOrDefaultAsync(c => c.Id == 1);

                if (settings == null)
                {
                    settings = new Settings { Id = 1, SettingsPageVisitCounter = 1, Logs = $"{DateTime.UtcNow}: Initial settings record added." };
                    DbContext.Settings.Add(settings);
                }
                else
                {
                    settings.SettingsPageVisitCounter += 1;
                    settings.Logs += $"\r\n{DateTime.UtcNow}: Settings loaded.";
                }

                await DbContext.SaveChangesAsync();
                SettingsViewModel = settings;
            }

            await base.OnInitializedAsync();
        }

        private void SaveSettings()
        {
            if (SettingsViewModel != null)
            {
                SettingsViewModel.Logs += $"\r\n{DateTime.UtcNow}: Settings saved.";
            }

            DbContext?.SaveChangesAsync();
        }

        public void Dispose() => DbContext?.Dispose();
    }
}
