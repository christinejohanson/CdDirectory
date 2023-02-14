using System.ComponentModel.DataAnnotations;

namespace CdDirectory.Models
{
    public class Cd
    {
        //properties 
        // cd can only have one lender, but a cd can only belong to one artist.
        public int Id { get; set; }

        //required för att fält är obligatoriska. lägg även till using system component
        [Required(ErrorMessage = "Fyll i namn på skivan")]
        [Display(Name = "Namn på albumet:")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Fyll i årtal skivan släpptes")]
        [Display(Name = "År albumet släpptes:")]
        public int? Releaseyear { get; set; }

        [Display(Name = "Artist:")]
        public int ArtistId { get; set; }
        public Artist? Artist { get; set; }
        public List<Lender>? Lender { get; set; }

    }

    public class Artist
    {
        //artist can have many cds
        public int ArtistId { get; set; }

        [Display(Name = "Artist:")]
        [Required(ErrorMessage = "Fyll i artistnamn")]
        public string? ArtistName { get; set; }

        public List<Cd>? Cd { get; set; }
    }

    public class Lender
    {
        // a lender can lend many cds
        public int LenderId { get; set; }

        public string? LenderName { get; set; }

        public DateTime LoanDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int Id { get; set; }
        public Cd? Cd { get; set; }

    }
}