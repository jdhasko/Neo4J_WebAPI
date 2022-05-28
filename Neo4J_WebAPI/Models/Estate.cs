
namespace RealEstate_MongoDB_WebAPI.Models
{
    public class Estate 
    {

        public string? Id { get; set; }

        public string? Address { get; set; } = null!;
        public string? City { get; set; } = null!;

        public double PlotSize { get; set; }
        public double BuildingSize { get; set; }
        public int Rooms { get; set; }
        public string? Comment { get; set; }
        public double TargetPrice { get; set; }
        public double MinimumPrice { get; set; }
        public bool ForSale { get; set; }
        public bool ForRent { get; set; }
        public double Deposit { get; set; }
        public double RentPrice { get; set; }

    }
}
