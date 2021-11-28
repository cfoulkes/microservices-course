using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommandsService.Data.Models;
using CommandsService.Data.Repositories;
using CommandsService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [ApiController]
    [Route("api/commands/platforms/{platformId}/[controller]")]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepository _commandRepository;
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepository commandRepository, IMapper mapper)
        {
            _commandRepository = commandRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetCommandsForPlatform(int platformId)
        {
            if (!_commandRepository.PlaformExits(platformId))
            {
                return NotFound();
            }
            var commands = _commandRepository.GetCommandsForPlatform(platformId);
            var commandDtos = _mapper.Map<IEnumerable<CommandReadDto>>(commands);
            return Ok(commandDtos);
        }

        [HttpGet("commandId", Name = "GetCommandForPlatform")]
        public ActionResult<CommandReadDto> GetCommandForPlatform(int platformId, int commandId)
        {
            if (!_commandRepository.PlaformExits(platformId))
            {
                return NotFound();
            }
            var command = _commandRepository.GetCommand(platformId, commandId);
            if (command == null)
            {
                return NotFound();
            }
            var commandDto = _mapper.Map<CommandReadDto>(command);
            return Ok(commandDto);
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommandForPlatform(int platformId, CommandCreateDto commandCreateDto)
        {
            if (!_commandRepository.PlaformExits(platformId))
            {
                return NotFound();
            }

            var command = _mapper.Map<Command>(commandCreateDto);
            _commandRepository.CreateCommand(platformId, command);
            _commandRepository.SaveChanges();
            var commandReadDto = _mapper.Map<CommandReadDto>(command);
            return CreatedAtRoute(nameof(GetCommandForPlatform),
                new { platformId = platformId, commandId = commandReadDto.Id},
                commandReadDto);
        }
    }
}
