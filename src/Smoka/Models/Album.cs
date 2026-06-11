using System.Text.Json.Serialization;

namespace Smoka.Models
{
public class Album
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; } = "";

    [JsonPropertyName("genre")]
    public string Genre { get; set; } = "";

    [JsonPropertyName("releaseDate")]
    public int ReleaseDate { get; set; }

    public Album() { }
    public Album(int id, string title, string genre, int releaseDate)
    {
        Id = id;
        Title = title;
        Genre = genre;
        ReleaseDate = releaseDate;
    }
}
}