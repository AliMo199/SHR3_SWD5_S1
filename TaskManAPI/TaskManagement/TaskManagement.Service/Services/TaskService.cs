using System.ComponentModel.DataAnnotations;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Interfaces;
using TaskManagement.Service.Exceptions;

namespace TaskManagement.Service.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskItem?> GetTaskByIdAsync(int id)
        {
            return await _taskRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllAsync();
        }

        public async Task<IEnumerable<TaskItem>> GetFilteredTasksAsync(bool? isCompleted, bool sortByDueDate)
        {
            return await _taskRepository.GetFilteredAsync(isCompleted, sortByDueDate);
        }

        public async Task<TaskItem> CreateTaskAsync(TaskItem taskItem)
        {
            // Validation: Title is required
            if (string.IsNullOrWhiteSpace(taskItem.Title))
            {
                throw new Exceptions.ValidationException("Title is required.");
            }

            // Validation: Title max length
            if (taskItem.Title.Length > 100)
            {
                throw new Exceptions.ValidationException("Title cannot exceed 100 characters.");
            }

            // Validation: Description max length
            if (!string.IsNullOrEmpty(taskItem.Description) && taskItem.Description.Length > 500)
            {
                throw new Exceptions.ValidationException("Description cannot exceed 500 characters.");
            }

            // Validation: DueDate must be in the future
            if (taskItem.DueDate.HasValue && taskItem.DueDate.Value <= DateTime.UtcNow)
            {
                throw new Exceptions.ValidationException("DueDate must be in the future.");
            }

            return await _taskRepository.CreateAsync(taskItem);
        }

        public async Task<TaskItem?> UpdateTaskAsync(int id, TaskItem taskItem)
        {
            // Check if task exists
            var existingTask = await _taskRepository.GetByIdAsync(id);
            if (existingTask == null)
            {
                return null;
            }

            // Validation: Title is required
            if (string.IsNullOrWhiteSpace(taskItem.Title))
            {
                throw new Exceptions.ValidationException("Title is required.");
            }

            // Validation: Title max length
            if (taskItem.Title.Length > 100)
            {
                throw new Exceptions.ValidationException("Title cannot exceed 100 characters.");
            }

            // Validation: Description max length
            if (!string.IsNullOrEmpty(taskItem.Description) && taskItem.Description.Length > 500)
            {
                throw new Exceptions.ValidationException("Description cannot exceed 500 characters.");
            }

            // Validation: DueDate must be in the future (if being updated)
            if (taskItem.DueDate.HasValue && taskItem.DueDate.Value <= DateTime.UtcNow)
            {
                throw new Exceptions.ValidationException("DueDate must be in the future.");
            }

            taskItem.Id = id;
            return await _taskRepository.UpdateAsync(taskItem);
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            return await _taskRepository.DeleteAsync(id);
        }
    }
}