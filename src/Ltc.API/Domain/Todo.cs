namespace Ltc.API.Domain;

public class Todo
{
    public long Id { get; set; }
    public string Title { get; private set; }

    public Todo(string title)
    {
        Title = title;
    }


    public bool UpdateTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return false;
        }

        Title = title;

        return true;
    }

    
    
    
    
    
    
    
    
    
    
    
    
    
    

    public Todo Find(long dtoId)
    {
        throw new NotImplementedException();
    }
}