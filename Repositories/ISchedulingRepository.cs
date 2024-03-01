using Microsoft.AspNetCore.Mvc;
using SchedulingApi.Model;

namespace SchedulingApi.Repositories {
    public interface ISchedulingRepository 
    {
        Task<IEnumerable<Meeting>> GetScheduleByUserId(int userId);
        Task<User> CreateUser(User user);
        Task<Meeting> CreateMeeting(Meeting meeting);
        Task<Meeting> SaveParticipantsList(List<MeetingParticipant> participants);
        Task<List<User>> GetUsersByUserIdListAsync(List<int> userIdList);
    }
}