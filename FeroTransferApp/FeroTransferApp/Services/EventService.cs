using FeroTransferApp.Models;
using Prism.Events;

namespace FeroTransferApp.Services
{
    public class RecipientAddedEvent : PubSubEvent<Recipient>
    {
    }

    public class TransferCompletedEvent : PubSubEvent<TransferModel>
    {
    }
}
