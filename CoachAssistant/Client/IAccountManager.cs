namespace CoachAssistant.Client
{
    public interface IAccountManager
    {
        void MarkUserAsLoggedOut();

        Task<bool> IsUserInRole(string role);
    }
}
