namespace ChatGPTModeration
{
    public class ModerationResponse
    {
        public string id { get; set; }
        public string model { get; set; }
        public Result[] results { get; set; }
    }

    public class Result
    {
        public bool flagged { get; set; }
        public Categories categories { get; set; }
        public Category_Scores category_scores { get; set; }
    }

    public class Categories
    {
        public bool sexual { get; set; }
        public bool hate { get; set; }
        public bool violence { get; set; }
        public bool selfharm { get; set; }
        public bool sexualminors { get; set; }
        public bool hatethreatening { get; set; }
        public bool violencegraphic { get; set; }
    }

    public class Category_Scores
    {
        public float sexual { get; set; }
        public float hate { get; set; }
        public float violence { get; set; }
        public float selfharm { get; set; }
        public float sexualminors { get; set; }
        public float hatethreatening { get; set; }
        public float violencegraphic { get; set; }
    }
}
