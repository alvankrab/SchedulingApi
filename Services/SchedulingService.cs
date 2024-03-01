using SchedulingApi.Repositories;
using SchedulingApi.Model;

namespace SchedulingApi.Services
{
    public class SchedulingService : ISchedulingService
    {
        private readonly ISchedulingRepository _repository;
        public SchedulingService(ISchedulingRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Meeting>> GetScheduleByUserId(int userId) {
            return await _repository.GetScheduleByUserId(userId);
        }

        public async Task<User> CreateUser(User user){
            return await _repository.CreateUser(user);
        }

        public async Task<Meeting> CreateMeeting(CreateMeetingModel model)
        {
            var meeting = MapMeetingModel(model);
            meeting = await _repository.CreateMeeting(meeting);
            
            return await AddParticipantsToMeeting(meeting, model.ParticipantsUserId); 
        }

        private Meeting MapMeetingModel(CreateMeetingModel model)
        {
            return new Meeting {
                MeetingSubject = model.MeetingSubject,
                Time = model.DateAndTime.ToString("HH:00"),
                EndTime = model.DateAndTime.AddHours(1).ToString("HH:00"),
                Date = model.DateAndTime.ToString("yyyy/MM/dd")
            };
        }

        private async Task<Meeting> AddParticipantsToMeeting(Meeting meeting, List<int> participantsIds)
        {
            var users = await _repository.GetUsersByUserIdListAsync(participantsIds);
            var participants = new List<MeetingParticipant>();
            foreach(var participant in users) {
                participants.Add(new MeetingParticipant{
                    Meeting = meeting,
                    MeetingId = meeting.MeetingId,
                    MeetingNavigation = participant,
                    UserId = participant.UserId
                });
            }
            return await _repository.SaveParticipantsList(participants);
        }

    }
}