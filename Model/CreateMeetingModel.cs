
using System.ComponentModel.DataAnnotations;

namespace SchedulingApi.Model;

public class CreateMeetingModel
{

    public string MeetingSubject { get; set; } = null!;

    
    public DateTime DateAndTime { get; set; }
    public List<int> ParticipantsUserId { get; set; } = null!;
}