using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace SchedulingApi.Model;

public partial class Meeting
{
    public int MeetingId { get; set; }

    public string MeetingSubject { get; set; } = null!;
    
    public string Date { get; set; } = null!;

    public string Time { get; set; } = null!;
    public string? EndTime { get; set; }

    public virtual ICollection<MeetingParticipant> MeetingParticipants { get; set; } = new List<MeetingParticipant>();
}
