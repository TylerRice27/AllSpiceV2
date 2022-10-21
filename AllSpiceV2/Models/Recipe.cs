namespace AllSpiceV2.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string Title { get; set; }

        public string Img { get; set; }

        public string Instructions { get; set; }

        public string Category { get; set; }



    }
}