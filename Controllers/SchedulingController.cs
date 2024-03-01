using Microsoft.AspNetCore.Mvc;
using SchedulingApi.Services;
using SchedulingApi.Model;

namespace SchedulingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SchedulingController : ControllerBase
{

    private readonly ISchedulingService _service;

    public SchedulingController(ISchedulingService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("GetMeetingsByUserId")]
    public async Task<ActionResult<IEnumerable<Meeting>>> GetMeetingsByUserId(int userId)
    {
        var meetings = await _service.GetScheduleByUserId(userId);
        return Ok(meetings); 
    }


    [HttpPost]
    [Route("CreateUser")]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        var userCreated = await _service.CreateUser(user);

        return Ok(userCreated);
    }

    [HttpPost]
    [Route("CreateMeeting")]
    public async Task<ActionResult<Meeting>> CreateMeeting(CreateMeetingModel model)
    {
        try
        {
            var result = await _service.CreateMeeting(model);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
        
        
    }


}
