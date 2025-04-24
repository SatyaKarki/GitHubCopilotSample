namespace Blog.API.Model;

/// <summary>
/// Represents an article with various properties such as title, content, author, and more.
/// </summary>
public record Article
{
    /// <summary>
    /// Gets or sets the unique identifier for the article.
    /// </summary>
    public int Id { get; set; } = 0;

    /// <summary>
    /// Gets or sets the title of the article.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the content of the article.
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the author of the article.
    /// </summary>
    public string Author { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date and time when the article was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets or sets the date and time when the article was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets or sets a value indicating whether the article is published.
    /// </summary>
    public bool IsPublished { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating whether the article is deleted.
    /// </summary>
    public bool IsDeleted { get; set; } = false;

    /// <summary>
    /// Gets or sets the list of tags associated with the article.
    /// </summary>
    public List<string> Tags { get; set; } = new List<string>();

    /// <summary>
    /// Gets or sets the category of the article.
    /// </summary>
    public string? Category { get; set; } 
}
