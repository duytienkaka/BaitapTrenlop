namespace TodoApp
{
    public class TodoUI
    {
        private readonly TodoService _service = new();
        public void ShowTodos()
        {
            var todos = _service.GetAllTodos();
            Console.WriteLine("Danh sách công việc");
            if (todos.Count == 0)
            {
                Console.WriteLine("Chưa có công việc nào");
                return;
            }
            foreach (var todo in todos)
            {
                Console.WriteLine(todo);
            }
        }
        public void ShowMenu()
        {
            Console.WriteLine("=== MENU ===");
            Console.WriteLine("1. Thêm công việc");
            Console.WriteLine("2. Xóa công việc");
            Console.WriteLine("3. Đánh dấu hoàn thành");
            Console.WriteLine("4. Cập nhật tiêu đề");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn chức năng: ");
        }
        public void Run()
        {
            while (true)
            {
                ShowMenu();
                var chs = Console.ReadLine();
                switch (chs)
                {
                    case "1":
                        Console.Write("Nhập tiêu đề: ");
                        var title = Console.ReadLine();
                        if (!string.IsNullOrEmpty(title))
                        {
                            var todos = _service.GetAllTodos();
                            if(todos.FirstOrDefault(t => t.Title.Equals(title)) != null)
                            {
                                Console.WriteLine("Đã tồn tại công việc với tiêu đề này");
                            }
                            else
                            {
                                var newTodo = _service.AddTodo(title);
                                Console.WriteLine($"Đã thêm công việc: {newTodo}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Tiêu đề không được để trống");
                        }
                        break;
                    case "2":
                        Console.Write("Nhập Id công việc cần xóa: ");
                        if (int.TryParse(Console.ReadLine(), out int idToRemove))
                        {
                            if (_service.RemoveTodo(idToRemove))
                            {
                                Console.WriteLine("Đã xóa công việc");
                            }
                            else
                            {
                                Console.WriteLine("Không tìm thấy công việc với Id đó");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Id không hợp lệ");
                        }
                        break;
                    case "3":
                        Console.Write("Nhập Id công việc cần đánh dấu hoàn thành: ");
                        if (int.TryParse(Console.ReadLine(), out int idToToggle))
                        {
                            if (_service.ToggleCompleted(idToToggle))
                            {
                                Console.WriteLine("Đã cập nhật trạng thái công việc");
                            }
                            else
                            {
                                Console.WriteLine("Không tìm thấy công việc với Id đó");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Id không hợp lệ");
                        }
                        break;
                    case "4":
                        Console.Write("Nhập Id công việc cần cập nhật tiêu đề: ");
                        if (int.TryParse(Console.ReadLine(), out int idToUpdate))
                        {
                            Console.Write("Nhập tiêu đề mới: ");
                            var newTitle = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newTitle))
                            {
                                if (_service.UpdateTodo(idToUpdate, newTitle))
                                {
                                    Console.WriteLine("Đã cập nhật tiêu đề công việc");
                                }
                                else
                                {
                                    Console.WriteLine("Không tìm thấy công việc với Id đó");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Tiêu đề không được để trống");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Id không hợp lệ");
                        }
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng thử lại.");
                }
            }
        }

    }
}