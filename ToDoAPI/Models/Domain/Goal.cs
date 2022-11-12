namespace ToDoAPI.Models.Domain
{
    public class Goal
    {
        public int Id { get; set; }
        public string? Topic { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? Period { get; set; }
    }
}
