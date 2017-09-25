namespace IllyCake.Data.Models
{
    public class CakeImage
    {
        public int CakeId { get; set; }
        public Cake Cake { get; set; }

        public int ImageId { get; set; }
        public ImageFile Image { get; set; }
    }
}
