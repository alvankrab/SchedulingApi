using System;
using System.Collections.Generic;

namespace SchedulingApi.Model;

public partial class MeetingParticipant
{
    public int MeetingId { get; set; }

    public int UserId { get; set; }

    public virtual Meeting Meeting { get; set; } = null!;

    public virtual User MeetingNavigation { get; set; } = null!;
}
