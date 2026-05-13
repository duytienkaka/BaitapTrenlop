namespace TodoApp
{
    public class TodoService
    {
        private readonly TodoRepository _repository;
        public TodoService()
        {
            _repository = new TodoRepository();
        }
        public List<Todo> GetAllTodos()
        {
            return _repository.GetAll();
        }
        public Todo AddTodo(string title)
        {
            return _repository.AddTodo(title);
        }
        public bool RemoveTodo(int id)
        {
            return _repository.RemoveTodo(id);
        }
        public bool ToggleCompleted(int id)
        {
            return _repository.ToggleCompleted(id);
        }
        public bool UpdateTodo(int id, string title)
        {
            return _repository.UpdateTodo(id, title);
        }
    }
}