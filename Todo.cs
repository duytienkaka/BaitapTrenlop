using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public class Todo
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public bool IsCompleted { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, IsCompleted: {IsCompleted}";
        }
        public string ToFileString()
        {
            return $"{Id},{Title},{IsCompleted}";
        }
        public static Todo FromFileString(string line)
        {
            var parts = line.Split(",");
            
            return new Todo
            {
                Id = int.Parse(parts[0]),
                Title = parts[1],
                IsCompleted = bool.Parse(parts[2])
            };
        }
    }
}