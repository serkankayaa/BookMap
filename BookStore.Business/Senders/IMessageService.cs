using System.Threading.Tasks;
using static BookStore.Business.Senders.EmailService;

namespace BookStore.Business.Senders
{
    public interface IMessageService
    {
        MessageStates MessageState { get; }

        Task SendAsync(EmailModel message, params string[] contacts);
        void Send(EmailModel message, params string[] contacts);
    }
}