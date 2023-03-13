namespace Ltc.API.Domain;

public class Todo
{
    public long Id { get; set; }
    public string Title { get; private set; }

    public Todo(string title)
    {
        Title = title;
    }


    /// <summary>
    /// ?
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    public bool UpdateTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return false;
        }

        Title = title;

        return true;
    }
}