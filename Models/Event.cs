namespace Prog7312_MunicipalityApp_ST10299399.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string? ImageUrl { get; set; }

        public DateTime PostedDate { get; set; }
    }
}
