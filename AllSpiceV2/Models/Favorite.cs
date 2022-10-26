namespace AllSpiceV2.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public string AccountId { get; set; }

        public int RecipeId { get; set; }

        public Profile Creator { get; set; }


    }
}