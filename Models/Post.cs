using System.ComponentModel;

namespace ScientificArticleSimplifier.Models
{
    
    public class Post
    {
        public Guid Id { get; set; }
        
        public Guid RequestId { get; set; }

        [DisplayName("Título")]
        public string Title { get; set; }

        [DisplayName("Descrição")]
        public string Description { get; set; }

        [DisplayName("Conteúdo")]
        public string Content { get; set; }
        
    }

}
