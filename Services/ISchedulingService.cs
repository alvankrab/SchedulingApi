using SchedulingApi.Model;

namespace SchedulingApi.Services
{
    public interface ISchedulingService 
    {
        Task<IEnumerable<Meeting>> GetScheduleByUserId(int userId);
        Task<User> CreateUser(User user);
        Task<Meeting> CreateMeeting(CreateMeetingModel model);
    }
}