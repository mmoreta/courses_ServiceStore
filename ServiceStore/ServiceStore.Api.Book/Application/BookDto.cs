namespace ServiceStore.Api.Book.Application;

public class BookDto
{
    public string Title { get; set; }
    public DateTime? PublicationDate { get; set; }
    public Guid? BookAuthor { get; set; }
}