namespace IllyCake.Data.Models
{
    public class ProductDiscountCoupon
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int DiscountCouponId { get; set; }
        public DiscountCoupon DiscountCoupon { get; set; }
    }
}
