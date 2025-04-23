namespace SmartPillMauiApp.Models
{
    public class AdminDto
    {
        public int AdminID { get; set; }
        public string AccountName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Permissions { get; set; }
        public DateTime updated_at { get; set; }
        public bool IsActive { get; set; }
        public string ImagePath { get; set; }
    }
}
