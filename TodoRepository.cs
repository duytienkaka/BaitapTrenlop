using System.Runtime.CompilerServices;

namespace TodoApp
{
    public class TodoRepository
    {
        private readonly List<Todo> _todos = [];
        private readonly string _path = "todos.txt";
        private int _nextId = 1;
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
                var item = Todo.FromFileString(line);
                _todos.Add(item);
                if(item.Id >= _nextId)
                {
                    _nextId = item.Id + 1;
                }
            }
        }
        private void SaveToFile()
        {
            var lines = _todos.Select(t => t.ToFileString()).ToArray();
            File.WriteAllLines(_path, lines);
        }
        public List<Todo> GetAll()
        {
            return _todos;
        }
        public Todo AddTodo(string title)
        {
            var item = new Todo
            {
                Id = _nextId++,
                Title = title,
                IsCompleted = false
            };
            _todos.Add(item);
            SaveToFile();
            return item;
        }
        public bool RemoveTodo(int id)
        {
            var item = _todos.FirstOrDefault(t => t.Id == id);
            if (item != null)
            {
                _todos.Remove(item);
                SaveToFile();
                return true;
            }
            return false;
        }
        public bool ToggleCompleted(int id)
        {
            var item = _todos.FirstOrDefault(t => t.Id == id);
            if (item != null)
            {
                item.IsCompleted = !item.IsCompleted;
                SaveToFile();
                return true;
            }
            return false;
        }
        public bool UpdateTodo(int id, string title)
        {
            var item = _todos.FirstOrDefault(t => t.Id == id);
            if (item != null)
            {
                item.Title = title;
                SaveToFile();
                return true;
            }
            return false;
        }
    }
}