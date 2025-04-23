namespace SmartPillMauiApp.Models
{
    public class MedicineInfoDto
    {
        public int MedicineID { get; set; }
        public string MedicineName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int CategoryID { get; set; }
        public DateTime updated_at { get; set; }
    }
}
