namespace Domain.Interfaces
{
    public interface IEmailSender
    {
        void SendEmailAsync(string to,string subject,string body);
    }
}
