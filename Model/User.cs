using System;
using System.Collections.Generic;

namespace SchedulingApi.Model;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<MeetingParticipant> MeetingParticipants { get; set; } = new List<MeetingParticipant>();
}
