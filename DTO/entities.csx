using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Attendee")]
public class Attendee
{
    public Guid AttendeeId { get; set; }

    [Required]
    public Guid MeettingId { get; set; }
    public Meeting Meeting { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }
}

[Table("Group")]
public class Group
{
    public Guid GroupId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    public List<Meeting> Meetings { get; set; }
}


[Table("Meeting")]
public class Meeting
{
    public Guid MeetingId { get; set; }

    [Required]
    public Guid GroupId { get; set; }
    public Group Organizer { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    public List<Attendee> ConfirmedAttendees { get; set; }
    public List<Attendee> UnconfirmedAttendees { get; set; }
}
