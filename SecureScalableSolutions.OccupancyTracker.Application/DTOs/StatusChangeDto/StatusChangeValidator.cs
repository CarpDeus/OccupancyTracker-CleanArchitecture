using FluentValidation;
using SecureScalableSolutions.OccupancyTracker.Application.Models.Statuses;

namespace SecureScalableSolutions.OccupancyTracker.Application.DTOs.StatusChangeDto
{
    public class StatusChangeValidator : AbstractValidator<StatusChangeCommand>
    {
        public StatusChangeValidator()
        {
            RuleFor(x => x.CurrentStatus)
                .NotEmpty().WithMessage("Current status is required.")
                .InclusiveBetween(0, 3).WithMessage("Current status must be between 0 and 3.")
                .Must(BeAValidStatusChange).WithMessage("Invalid status change.");
            RuleFor(x => x.NewStatus)
                .NotEmpty().WithMessage("New status is required.")
                .Must(BeAValidStatusChange).WithMessage("Invalid status change.");
        }

        private bool BeAValidStatusChange(StatusChangeCommand command, int status)
        {
            return DataStatus.ValidChangeStates(command.CurrentStatus, command.NewStatus);
        }
    }
}
