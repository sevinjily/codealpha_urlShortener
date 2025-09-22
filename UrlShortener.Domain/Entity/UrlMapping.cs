namespace UrlShortener.Domain.Entity
{
    public class UrlMapping
    {
        public Guid Id { get; set; }
        public string OriginUrl { get; set; }=string.Empty;
        public string ShortCode { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
