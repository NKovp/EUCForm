namespace EUCFormApp.Models.Data
{
    public class Applicant
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string? BirthNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = "";
        public string Email { get; set; } = "";
        public string Nationality { get; set; } = "";
        public bool GdprConsent { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}
