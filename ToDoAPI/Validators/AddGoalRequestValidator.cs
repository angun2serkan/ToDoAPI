using FluentValidation;

namespace ToDoAPI.Validators
{
    public class AddGoalRequestValidator : AbstractValidator<Models.DTO.AddGoalRequest>
    {
        public AddGoalRequestValidator()
        {
            RuleFor(x => x.Topic).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Period).GreaterThan(0);
        }
    }
}
