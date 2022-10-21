namespace AllSpiceV2.Models
{
    public class Profile
    {
        public string Id { get; set; }

        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string Name { get; set; }

        public string Picture { get; set; }

    }

    public class Account : Profile
    {
        public string Email { get; set; }
    }

}