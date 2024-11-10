using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ScientificArticleSimplifier.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Numero { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Request> Requests { get; set; }

    }

}
