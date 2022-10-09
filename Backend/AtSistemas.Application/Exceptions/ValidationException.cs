using FluentValidation.Results;

namespace AtSistemas.Application.Exceptions
{
    public class ValidationException: ApplicationException
    {
        public ValidationException():base("There are errors validator")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures
                        .GroupBy(failure => failure.PropertyName, failure => failure.ErrorMessage)
                        .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }


    }
}
