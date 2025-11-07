using TaskManagement.Core.Entities;

namespace TaskManagement.Core.Interfaces
{
    public interface ITaskService
    {
        Task<TaskItem?> GetTaskByIdAsync(int id);
        Task<IEnumerable<TaskItem>> GetAllTasksAsync();
        Task<IEnumerable<TaskItem>> GetFilteredTasksAsync(bool? isCompleted, bool sortByDueDate);
        Task<TaskItem> CreateTaskAsync(TaskItem taskItem);
        Task<TaskItem?> UpdateTaskAsync(int id, TaskItem taskItem);
        Task<bool> DeleteTaskAsync(int id);
    }
}