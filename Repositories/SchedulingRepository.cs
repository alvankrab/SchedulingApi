using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using SchedulingApi.Model;

namespace SchedulingApi.Repositories {
    public class SchedulingRepository : ISchedulingRepository
    {
        private readonly SchedulingContext _context;
        public SchedulingRepository(SchedulingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Meeting>> GetScheduleByUserId(int userId) {
            var meetingList = await _context.MeetingParticipants.Where(m => m.UserId.Equals(userId)).Select(m => m.Meeting).ToListAsync(); 
            if (meetingList == null){
                throw new ArgumentNullException("User not found", nameof(userId));
            }
            return meetingList;
        }

        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<Meeting> CreateMeeting(Meeting meeting)
        {
            try{
                _context.Meetings.Add(meeting);
                await _context.SaveChangesAsync();
            } catch (Exception e)
            {
                var x = e.Message;
            }
                return meeting;
        }

        public async Task<Meeting> SaveParticipantsList(List<MeetingParticipant> participants)
        {
            if (participants == null) {
                throw new NullReferenceException();
            }
            var meeting = new Meeting();
            var meetingId = participants.FirstOrDefault().MeetingId;
            try{
                foreach(var participant in participants)
                {
                    _context.MeetingParticipants.Add(participant);
                }
                
                await _context.SaveChangesAsync();
                meeting = await _context.Meetings.Where(m => m.MeetingId == meetingId)
                    .Include(m => m.MeetingParticipants)
                    .FirstOrDefaultAsync();
            } catch (Exception e)
            {
                var x = e.Message;
            }
                return meeting;
        }

        public async Task<List<User>> GetUsersByUserIdListAsync(List<int> userIdList){
            return _context.Users.Where(u => userIdList.Contains(u.UserId)).ToList();
        }
    }
}