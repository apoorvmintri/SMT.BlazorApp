using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT.BlazorApp.Data
{
    public class BaseResponseResult
    {
        public bool IsSuccess { get; set; }

        public bool HasWarnings { get; set; }

        [JsonIgnore]
        public dynamic? Metadata { get; set; }

        private List<Error>? _errors;

        public List<Error>? Errors
        {
            get => _errors;
            set
            {
                _errors = value;
                if (value == null)
                    IsSuccess = true;
                else
                    IsSuccess = false;
            }
        }

        private List<string>? _warnings;

        public List<string>? Warnings
        {
            get => _warnings;
            set
            {
                _warnings = value;
                if (value == null)
                    HasWarnings = false;
                else
                    HasWarnings = true;
            }
        }

        public BaseResponseResult()
        {

        }

        public BaseResponseResult(string? errorMessage = null)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                if (Errors == null)
                    Errors = new List<Error>();

                Errors.Add(new Error(errorMessage));
            }
        }

        public BaseResponseResult(Error error)
        {
            if (Errors == null)
                Errors = new List<Error>();

            Errors.Add(error);
        }

        public BaseResponseResult(List<Error> errors)
        {
            if (Errors == null)
                Errors = new List<Error>();

            Errors.AddRange(errors);
        }

        public void AddError(Error error)
        {
            if (Errors == null)
                Errors = new List<Error>();

            Errors.Add(error);
        }

        public void AddErrors(List<Error> errors)
        {
            if (Errors == null)
                Errors = new List<Error>();

            Errors.AddRange(errors);
        }

        public void AddWarning(string warning)
        {
            if (Warnings == null)
                Warnings = new List<string>();

            Warnings.Add(warning);
        }

        public void AddWarnings(List<string> warnings)
        {
            if (Warnings == null)
                Warnings = new List<string>();

            Warnings.AddRange(warnings);
        }
    }
}
