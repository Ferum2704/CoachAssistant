namespace CoachAssistant.Shared.Models
{
    public class IdentityModel
    {
        public TokenModel Tokens { get; set; }

        public Guid? DomainUserId { get; set; }
    }
}
