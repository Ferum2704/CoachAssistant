namespace Application.Emails
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Message message);
    }
}
