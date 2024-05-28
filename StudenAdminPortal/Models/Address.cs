namespace StudenAdminPortal.Models
{
    public class Address
    {
       public int  id { get; set; } 
    public string PhysicalAddress { get; set; } 
    public string PostalAddress { get; set; }  

    public int StudentId { get; set; } 

    }
}