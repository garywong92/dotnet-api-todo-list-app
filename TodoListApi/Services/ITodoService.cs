using TodoListApi.Models;

namespace TodoListApi.Services
{
    public interface ITodoService
    {
        public List<TodoItem> GetAll();

        public void Add(TodoItem item);

        public bool Update(TodoItem item);

        public bool Remove(long id);
    }
}