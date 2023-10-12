namespace ServiceStore.Api.Book.Models;

public class BookLibrary
{
    public Guid? BookId { get; set; }
    public string Title { get; set; }
    public DateTime? PublicationDate { get; set; }
    
    public Guid? BookAuthor { get; set; }
}