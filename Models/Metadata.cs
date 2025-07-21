namespace ASPNET_006_Book_Vault.Models
{
    public class Metadata
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}