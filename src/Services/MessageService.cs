using Data.Repository;
using Entities;
using Entities.Exceptions;

namespace Services;

public class MessageService
{
    private readonly MessageRepository _messageRepository;

    public MessageService(MessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public string SaveMessage(Message message)
    {
        try
        {
            _messageRepository.Save(message);
            return ("se ha guardado con exito su mensaje");
        }
        catch (MessageExeption e)
        {
            return (e.Message);
        }
    }
    public List<Message> GetAllMessage()
    {
        return _messageRepository.GetAll();
    }
}
