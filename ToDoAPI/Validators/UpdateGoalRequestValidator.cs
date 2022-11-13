using FluentValidation;

namespace ToDoAPI.Validators
{
    public class UpdateGoalRequestValidator: AbstractValidator<Models.DTO.UpdateGoalRequest>
    {
        public UpdateGoalRequestValidator()
        {
            RuleFor(x => x.Topic).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Period).GreaterThan(0);
        }
    }
}
