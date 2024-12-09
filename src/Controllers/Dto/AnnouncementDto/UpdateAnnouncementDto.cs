namespace projekt.src.Controllers.Dto.AnnouncementDto;

public record UpdateAnnouncementDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? Amount { get; set; }
    public decimal? Cost { get; set; }
}