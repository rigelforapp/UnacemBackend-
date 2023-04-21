using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class Users : AuditFields, IAuditFields
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public int? ExpireIn { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
