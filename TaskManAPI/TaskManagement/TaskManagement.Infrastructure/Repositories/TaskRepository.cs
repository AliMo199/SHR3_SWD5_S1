using Microsoft.EntityFrameworkCore;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Interfaces;
using TaskManagement.Infrastructure.Data;

namespace TaskManagement.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<IEnumerable<TaskItem>> GetFilteredAsync(bool? isCompleted, bool sortByDueDate)
        {
            var query = _context.Tasks.AsQueryable();

            // Filter by completion status if specified
            if (isCompleted.HasValue)
            {
                query = query.Where(t => t.IsCompleted == isCompleted.Value);
            }

            // Sort by DueDate if requested
            if (sortByDueDate)
            {
                query = query.OrderBy(t => t.DueDate);
            }
            else
            {
                query = query.OrderByDescending(t => t.CreatedAt);
            }

            return await query.ToListAsync();
        }

        public async Task<TaskItem> CreateAsync(TaskItem taskItem)
        {
            taskItem.CreatedAt = DateTime.UtcNow;
            _context.Tasks.Add(taskItem);
            await _context.SaveChangesAsync();
            return taskItem;
        }

        public async Task<TaskItem?> UpdateAsync(TaskItem taskItem)
        {
            var existingTask = await _context.Tasks.FindAsync(taskItem.Id);
            if (existingTask == null)
            {
                return null;
            }

            existingTask.Title = taskItem.Title;
            existingTask.Description = taskItem.Description;
            existingTask.IsCompleted = taskItem.IsCompleted;
            existingTask.DueDate = taskItem.DueDate;

            _context.Tasks.Update(existingTask);
            await _context.SaveChangesAsync();
            return existingTask;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return false;
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Tasks.AnyAsync(t => t.Id == id);
        }
    }
}