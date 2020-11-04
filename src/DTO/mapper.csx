#load "entities.csx"
#load "DTO.csx"

public class ManualMeetingMapper
{
    public MeetingDTO CreateDTO(Meeting meeting)
    {
        if (meeting == null) throw new ArgumentNullException(nameof(meeting));

        return new MeetingDTO
        {
            GroupName = meeting.Organizer.Name,
            MeetingName = meeting.Name,
            ConfirmedAttendeeCount = meeting.ConfirmedAttendees.Count,
            UnconfirmedAttendeeCount = meeting.UnconfirmedAttendees.Count
        };
    }

    public Meeting CreateEntity(MeetingDTO meetingDTO)
    {
        if (meetingDTO == null) throw new ArgumentNullException(nameof(meetingDTO));

        throw new NotImplementedException();
    }
}
