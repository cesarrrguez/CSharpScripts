#load "entities.csx"
#load "DTO.csx"

public class ManualMeetingMapper
{
    public MeetingDTO CreateDTO(Meeting entity)
    {
        return new MeetingDTO
        {
            GroupName = entity.Organizer.Name,
            MeetingName = entity.Name,
            ConfirmedAttendeeCount = entity.ConfirmedAttendees.Count,
            UnconfirmedAttendeeCount = entity.UnconfirmedAttendees.Count
        };
    }

    public Meeting CreateEntity(MeetingDTO meetingDTO)
    {
        if (meetingDTO == null)
            throw new ArgumentNullException(nameof(meetingDTO));

        throw new NotImplementedException();
    }
}
