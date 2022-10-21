namespace AllSpiceV2.Models
{
    public class Ingredient
    {

        public int Id { get; set; }

        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string Name { get; set; }

        public string Quantity { get; set; }

        public int RecipeId { get; set; }

    }
}