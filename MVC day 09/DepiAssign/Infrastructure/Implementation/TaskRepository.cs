using Domain.Models;
using Domain.Repositories;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementation
{
    public class TaskRepository : ITaskRepository
    {
        public ApplicationDBContext _Context;
        public TaskRepository(ApplicationDBContext context)
        {
            _Context = context;
        }
        public List<TaskItem> GetAll()
        {
            return _Context.TaskItems.ToList();
        }
        public TaskItem GetbyId(int id)
        {
            return _Context.TaskItems
                .FirstOrDefault(t=>t.id == id);
        }
        public void Create(TaskItem Task)
        {
            _Context.TaskItems.Add(Task);
            _Context.SaveChanges();
        }
        public void Delete(TaskItem Task)
        {
            _Context.TaskItems.Remove(Task);
            _Context.SaveChanges();
        }
        public void Update(TaskItem Task)
        {
            _Context.TaskItems.Update(Task);
            _Context.SaveChanges();
        }
    }
}
