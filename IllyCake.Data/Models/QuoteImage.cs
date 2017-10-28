namespace IllyCake.Data.Models
{
    public class QuoteImage
    {
        public string QuoteId { get; set; }
        public Quote Quote { get; set; }

        public int ImageId { get; set; }
        public ImageFile Image { get; set; }
    }
}
