using System.ComponentModel.DataAnnotations;

namespace CoreWebAPIDemo.Validators
{
    public class PastDueDateValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dueDate = Convert.ToDateTime(value);
            return dueDate >= DateTime.Now;
        }
    }
}
