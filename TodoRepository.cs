namespace TodoApp
{
    public class TodoRepository
    {
        private readonly List<Todo> _todos;
        private readonly string _path = "todos.txt";
        private readonly int _nextId = 1;
        public TodoRepository()
        {
            _todos = [];
            LoadFromFile();
        }

        private void LoadFromFile()
        {
            if (!File.Exists(_path)) return;
            foreach( var line in File.ReadAllLines(_path))
            {
                _todos.Add(Todo.FromFileString(line));
            }
        }
    }
}