using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TaskManagement.API.DTOs;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Interfaces;
using TaskManagement.Service.Exceptions;

namespace TaskManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TaskItemDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TaskItemDto>>> GetAllTasks(
            [FromQuery] bool? isCompleted = null,
            [FromQuery] bool sortByDueDate = false)
        {
            var tasks = await _taskService.GetFilteredTasksAsync(isCompleted, sortByDueDate);
            var taskDtos = tasks.Select(MapToDto);
            return Ok(taskDtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TaskItemDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TaskItemDto>> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);

            if (task == null)
            {
                return NotFound(new { message = $"Task with ID {id} not found." });
            }

            return Ok(MapToDto(task));
        }

        [HttpPost]
        [ProducesResponseType(typeof(TaskItemDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TaskItemDto>> CreateTask([FromBody] CreateTaskDto createTaskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var taskItem = new TaskItem
                {
                    Title = createTaskDto.Title,
                    Description = createTaskDto.Description,
                    IsCompleted = createTaskDto.IsCompleted,
                    DueDate = createTaskDto.DueDate
                };

                var createdTask = await _taskService.CreateTaskAsync(taskItem);
                var taskDto = MapToDto(createdTask);

                return CreatedAtAction(
                    nameof(GetTaskById),
                    new { id = createdTask.Id },
                    taskDto);
            }
            catch (Service.Exceptions.ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TaskItemDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TaskItemDto>> UpdateTask(int id, [FromBody] UpdateTaskDto updateTaskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var taskItem = new TaskItem
                {
                    Title = updateTaskDto.Title,
                    Description = updateTaskDto.Description,
                    IsCompleted = updateTaskDto.IsCompleted,
                    DueDate = updateTaskDto.DueDate
                };

                var updatedTask = await _taskService.UpdateTaskAsync(id, taskItem);

                if (updatedTask == null)
                {
                    return NotFound(new { message = $"Task with ID {id} not found." });
                }

                return Ok(MapToDto(updatedTask));
            }
            catch (Service.Exceptions.ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var result = await _taskService.DeleteTaskAsync(id);

            if (!result)
            {
                return NotFound(new { message = $"Task with ID {id} not found." });
            }

            return NoContent();
        }

        private static TaskItemDto MapToDto(TaskItem task)
        {
            return new TaskItemDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                CreatedAt = task.CreatedAt,
                DueDate = task.DueDate
            };
        }
    }
}