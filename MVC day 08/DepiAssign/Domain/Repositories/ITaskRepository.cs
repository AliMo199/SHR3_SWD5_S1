using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ITaskRepository
    {
        List<TaskItem> GetAll();
        TaskItem GetbyId(int id);
        void Create(TaskItem task);
        void Update(TaskItem task);
        void Delete(TaskItem task);
    }
}
