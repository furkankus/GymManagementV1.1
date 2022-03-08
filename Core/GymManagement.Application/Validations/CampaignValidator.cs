using FluentValidation;
using GymManagement.Application.ViewModels.CampaignViewModel;
using System;


namespace GymManagement.Application.Validations
{
    public class CampaignValidator : AbstractValidator<CampaignCommandViewModel>
    {
        public CampaignValidator()
        {
            RuleFor(c => c.CampaignName).NotEmpty().MinimumLength(3).MaximumLength(150);
            RuleFor(c => c.Price).GreaterThan(0);
            RuleFor(c => c.MonthlyPeriod).GreaterThan(Convert.ToInt16(0));
            
        }
    }
}
