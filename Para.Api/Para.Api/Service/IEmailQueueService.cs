namespace Para.Api.Services
{
    public interface IEmailQueueService
    {
        void QueueEmail(string email);
    }
}
