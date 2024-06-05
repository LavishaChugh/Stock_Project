namespace Project.Models
{
    public class Person
    {

        public int Id { get; set; }

        public  string Username { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; }  = new byte[0];

        public byte[] PasswordSalt { get; set; } = new byte[0];

        public List<Items>? Items { get; set; }

    }
}
