using FluentValidation.Results;
using System.Text;

namespace IRIS.Conecta.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> Errors { get; set; }
        public StringBuilder errorMessages { get; set; }

        public ValidationException(ValidationResult validationResult)
        {
            Errors = [];         

            errorMessages = new StringBuilder();

            foreach (var error in validationResult.Errors)
            {
                errorMessages.Append("Code #" + error.ErrorCode + "\n" +
                    "Message: " + error.ErrorMessage + "\n");
            }
            
        }
    }
}
