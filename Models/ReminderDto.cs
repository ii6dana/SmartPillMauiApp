namespace SmartPillMauiApp.Models
{
    public class ReminderDto
    {
        public int ReminderID { get; set; }
        public int UserID { get; set; }
        public int MedicineID { get; set; }
        public DateTime ReminderTime { get; set; }
        public string Notes { get; set; }
    }
}
