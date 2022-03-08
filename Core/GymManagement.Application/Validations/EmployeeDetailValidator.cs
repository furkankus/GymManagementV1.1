using FluentValidation;
using GymManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Validations
{
    public class EmployeeDetailValidator : AbstractValidator<EmployeeDetail>
    {
        public EmployeeDetailValidator()
        {
            RuleFor(e => e.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(e => e.LastName).NotEmpty();
            RuleFor(e => e.InsuranceNumber).Length(11);
            RuleFor(e => e.Salary).GreaterThan(4200);
        }
    }
}
