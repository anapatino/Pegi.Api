using Entities;
using Data.Repository.shared;
namespace Data.Repository;

public class MessageRepository : Repository<Message>
{
    public MessageRepository(PegiDbContext context) : base(context)
    {
    }
}
