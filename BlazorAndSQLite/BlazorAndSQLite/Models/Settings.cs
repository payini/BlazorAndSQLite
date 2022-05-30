using System.ComponentModel.DataAnnotations;

namespace BlazorAndSQLite.Models
{
    public class Settings
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int SettingsPageVisitCounter { get; set; } = default;
        public DateTime SettingsPageLastVisitDate { get; set; } = DateTime.UtcNow;
        public bool ReceiveNotifications { get; set; } = default;
        public string Logs { get; set; } = string.Empty;
    }
}
