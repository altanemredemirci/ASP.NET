namespace _15_Action_Filters.Models
{
    public class User
    {
        public string UserName { get; set; }

        public string Role { get; set; }

        public List<string> Permissions { get; set; } = new();
    }
}
