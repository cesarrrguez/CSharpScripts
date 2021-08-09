public record MeetingDto
{
    public Guid MeetingId { get; set; }
    public string MeetingName { get; set; }
    public string GroupName { get; set; }
    public int ConfirmedAttendeeCount { get; set; }
    public int UnconfirmedAttendeeCount { get; set; }
}
