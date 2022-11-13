namespace ToDoAPI.Models.DTO
{
    public class UpdateGoalRequest
    {
        public string? Topic { get; set; }
        public string? Description { get; set; }
        public int? Period { get; set; }
    }
}
