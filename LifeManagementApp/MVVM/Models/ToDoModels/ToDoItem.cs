namespace LifeManagementApp.MVVM.Models.ToDoModels
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
