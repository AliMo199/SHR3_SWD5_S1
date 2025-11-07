using TaskManagement.Core.Entities;

namespace TaskManagement.Core.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskItem?> GetByIdAsync(int id);
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<IEnumerable<TaskItem>> GetFilteredAsync(bool? isCompleted, bool sortByDueDate);
        Task<TaskItem> CreateAsync(TaskItem taskItem);
        Task<TaskItem?> UpdateAsync(TaskItem taskItem);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}