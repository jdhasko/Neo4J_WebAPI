

namespace RealEstate_MongoDB_WebAPI.Models
{
    public class User
    {

        public string? Id { get; set; }

        public string Firstname { get; set; } = null!;

        public string? Surename { get; set; }

        public string? PhoneNr { get; set; }

        public string? Address { get; set; }
        public string? City { get; set; }

        public string Role { get; set; } = null!;
        public string? TaxNr { get; set; }

        public string? Ssn { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

    }

}
