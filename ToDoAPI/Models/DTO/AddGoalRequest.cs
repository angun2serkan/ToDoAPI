namespace ToDoAPI.Models.DTO
{
    public class AddGoalRequest
    {
        public int Id { get; set; }
        public string? Topic { get; set; }
        public string? Description { get; set; }
        public int? Period { get; set; }
    }
}
