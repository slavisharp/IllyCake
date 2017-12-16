namespace IllyCake.Data.Models
{
    public class ApplicationUserAddress
    {
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}
