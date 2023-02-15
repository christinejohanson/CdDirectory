using System.ComponentModel.DataAnnotations;

namespace CdDirectory.Models
{
    public class Cd
    {
        //properties
        public int Id { get; set; }

        //required för att fält är obligatoriska. lägg även till using system component
        //display för att skriva ut bättre namn 
        [Required(ErrorMessage = "Fyll i namn på skivan")]
        [Display(Name = "Namn på albumet:")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Fyll i årtal skivan släpptes")]
        [Display(Name = "År albumet släpptes:")]
        public int? Releaseyear { get; set; }

        [Display(Name = "Artist:")]
        public int ArtistId { get; set; }

        public Artist? Artist { get; set; }
    }

    public class Artist
    {
        public int ArtistId { get; set; }

        [Display(Name = "Artist:")]
        [Required(ErrorMessage = "Fyll i artistnamn")]
        public string? ArtistName { get; set; }

        public List<Cd>? Cd { get; set; }
    }

    public class Lender
    {
        public int LenderId { get; set; }

        public int LenderName { get; set; }
        public DateTime StartLend { get; set; }
        public DateTime EndLend { get; set; }
        public int Id { get; set; }
        public Cd? Cd { get; set; }
    }
}