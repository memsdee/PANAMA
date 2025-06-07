namespace PANAMA.Features.Contact.GetContact
{
    public class GetContactResponse
    {
        public Social Social { get; set; } = null!;
        public Address Address { get; set; } = null!;
        public About About { get; set; } = null!;
    }

    public class Social
    {
        public string Facebook { get; set; } = null!;
        public string Youtube { get; set; } = null!;
    }

    public class Address
    {
        public Studio Studio { get; set; } = null!;
        public Main Main { get; set; } = null!;
    }

    public class Studio
    {
        public string Address { get; set; } = null!;
        public string Number { get; set; } = null!;
        public string NameFanpage { get; set; } = null!;
        public string LinkFanpage { get; set; } = null!;
    }

    public class Main
    {
        public string Address { get; set; } = null!;
        public string Number { get; set; } = null!;
    }

    public class About
    {
        public string Text1 { get; set; } = null!;
        public string Text2 { get; set; } = null!;
        public string Text3 { get; set; } = null!;
    }
}
