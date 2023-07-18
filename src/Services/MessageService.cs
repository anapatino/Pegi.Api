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
            return ("Se ha guardado con exito su mensaje");
        }
        catch (MessageExeption e)
        {
            return (e.Message);
        }
    }

    public string UpdateMessage(Message message)
    {
        try
        {
            _messageRepository.Save(message);
            return ("Se ha actulizado con exito su mensaje");
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

    public Message GetMessageCode(string code)
    {
        return _messageRepository.Find(message => message.Code == code);
    }
}
