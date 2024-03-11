namespace TodoList.Services.Db.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException() 
    {
    }

    public EntityNotFoundException(string message)
        : base(message)
    {
    }
}
