namespace Peddle.IdentityServer.Entities
{
    public class UserExternalProvider
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string ProviderName { get; set; }
        
        public string ProviderSubjectId { get; set; }
    }
}