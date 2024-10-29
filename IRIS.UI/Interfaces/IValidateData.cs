using System.ComponentModel.DataAnnotations;

namespace IRIS.UI.Interfaces
{
    public interface IValidateData
    {
        public Task<IEnumerable<ValidationResult>> ValidateDataAsync();
    }
}
