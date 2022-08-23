using Microsoft.AspNetCore.Identity;
namespace Role_Test
{
    public class MyRole : IdentityRole
    {
        public string? Description { get; set; }
        public string? Controller_Name { get; set; }
        public string? Action_Name { get; set; }
    }
}