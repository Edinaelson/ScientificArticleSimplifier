namespace ScientificArticleSimplifier.Models
{
    
    public class Post
    {
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
     
        public string Title { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }

        /* EF Relations */
        public Request Request { get; set; }

    }

}
