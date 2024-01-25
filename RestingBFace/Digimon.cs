using System.Text.Json.Serialization;

public class Digimon
{
    [JsonPropertyName("name")]
    public string Name { get; set; }


    [JsonPropertyName("id")]
    public int Id { get; set; }


}