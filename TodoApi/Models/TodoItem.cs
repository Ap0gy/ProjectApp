namespace TodoApi.Models
{
    public record ToDoItem
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime? Target { get; set; }
        public bool IsComplete { get; set; }
        public string? Secret { get; set; }
    }
}