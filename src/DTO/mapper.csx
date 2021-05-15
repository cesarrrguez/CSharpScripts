#load "entities.csx"
#load "dtos.csx"

public class ManualMeetingMapper
{
    public MeetingDto CreateDto(Meeting meeting)
    {
        if (meeting == null) throw new ArgumentNullException(nameof(meeting));

        return new MeetingDto
        {
            GroupName = meeting.Organizer.Name,
            MeetingName = meeting.Name,
            ConfirmedAttendeeCount = meeting.ConfirmedAttendees.Count,
            UnconfirmedAttendeeCount = meeting.UnconfirmedAttendees.Count
        };
    }

    public Meeting CreateEntity(MeetingDto meetingDto)
    {
        if (meetingDto == null) throw new ArgumentNullException(nameof(meetingDto));

        throw new NotImplementedException();
    }
}
