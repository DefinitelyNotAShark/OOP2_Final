namespace ClassLibraryFinal
{
    public interface IShippingLocation
    {
        uint StartZipCode { get; set; }//why can't I set this. If I can't set this, the WPF won't work. I gotta add a setter
        uint DestinationZipCode { get; set; }
    }
}