namespace TodoApi.Models
{
    public class TodoItemDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsComplete { get; set; }
        public DateTime TargetDate { get; set; }

    }
}