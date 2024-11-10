using ScientificArticleSimplifier.Data.Enums;

namespace ScientificArticleSimplifier.Models
{
    public class Request
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string PathOfArchive { get; set; }
        public StatusRequest StatusRequest { get; set; }
        public string FailureMessage { get; set; }

        /* EF Relations */
        public User User { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}
