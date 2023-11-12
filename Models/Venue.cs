using System.Collections.Generic;

public class Venue
{
    public int VenueId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    // Mekan ile ilişkilendirilmiş etkinliklerin bir koleksiyonu
    public virtual ICollection<Event> Events { get; set; }
}
