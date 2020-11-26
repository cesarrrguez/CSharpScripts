#load "entities.csx"
#load "DTO.csx"
#load "mapper.csx"
#load "utils.csx"

// Create domain model entities
var group = new Group
{
    GroupId = new Guid(),
    Name = "Group A",
    Description = "Group A Description",
    Meetings = new List<Meeting>()
};

var meeting = new Meeting
{
    MeetingId = new Guid(),
    GroupId = group.GroupId,
    Organizer = group,
    Name = "meeting A",
    Description = "meeting A Description",
    ConfirmedAttendees = new List<Attendee>(),
    UnconfirmedAttendees = new List<Attendee>()
};
group.Meetings.Add(meeting);

var attendee = new Attendee
{
    AttendeeId = new Guid(),
    MeettingId = meeting.MeetingId,
    Meeting = meeting,
    FirstName = "James",
    LastName = "Brown"
};
meeting.ConfirmedAttendees.Add(attendee);

// Mapping domain model entity to DTO
var manualMeetingMapper = new ManualMeetingMapper();
var meetingDTO = manualMeetingMapper.CreateDTO(meeting);

// Print DTO
WriteLine(meetingDTO.PropertyList());
