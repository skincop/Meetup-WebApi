using AutoMapper;
using Meetups.Application.Meetups.Commands.CreateMeetup;
using Meetups.Application.Meetups.Commands.DeleteMeetup;
using Meetups.Application.Meetups.Commands.UpdateMeetup;
using Meetups.Application.Meetups.Queries.GetMeetup;
using Meetups.Application.Meetups.Queries.GetMeetupList;
using Meetups.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meetups.WebApi.Contollers
{
    [Authorize]
    [Route("api/[controller]")]
    public class MeetupController : BaseController
    {
        private readonly IMapper _mapper;

        public MeetupController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<MeetupListVm>> GetAll()
        {
            Console.WriteLine("MEETUP GUID");
            Console.WriteLine(UserId);
            var query = new GetMeetupListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MeetupListVm>> Get(Guid id)
        {
            var query = new GetMeetupQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateMeetupDto createNoteDto)
        {
            var createCommand = _mapper.Map<CreateMeetupCommand>(createNoteDto);
            createCommand.UserId = UserId;
            var meetupId = await Mediator.Send(createCommand);
            return Ok(meetupId);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var command = new DeleteMeetupCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateMeetupDto updateMeetupDto)
        {
            Console.WriteLine("MEETUP GUID");
            Console.WriteLine(UserId);
            var updateCommand = _mapper.Map<UpdateMeetupCommand>(updateMeetupDto);
            updateCommand.UserId=UserId;
            await Mediator.Send(updateCommand);
            return NoContent();
        }
    }
}
