using TodoListApi.Models;

namespace TodoListApi.Services
{
    public class TodoService : ITodoService
    {
        private readonly List<TodoItem> todos = new();

        public List<TodoItem> GetAll() => todos;

        public void Add(TodoItem item) => todos.Add(item);

        public TodoItem? GetById(long id) => todos.Find(t => t.Id == id);

        public bool Remove(long id)
        {
            var todo = GetById(id);
            if (todo == null)
            {
                return false;
            }

            todos.Remove(todo);

            return true;
        }

        public bool Update(TodoItem item)
        {
            var index = todos.FindIndex(t => t.Id == item.Id);
            if (index == -1)
            {
                return false;
            }

            todos[index] = item;

            return true;
        }
    }
}