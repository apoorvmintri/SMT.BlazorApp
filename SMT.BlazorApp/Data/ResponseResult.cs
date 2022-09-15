using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT.BlazorApp.Data
{
    public class ResponseResult<TDto> : BaseResponseResult
    {
        private TDto? _model;

        public TDto? Model
        {
            get => _model;
            set
            {
                _model = value;
                if (value == null)
                    IsSuccess = false;
                else
                    IsSuccess = true;
            }
        }

        public ResponseResult()
        {

        }

        public ResponseResult(string? errorMessage = null)
            : base(errorMessage)
        {
        }

        public ResponseResult(Error error)
            : base(error)
        {
        }

        public ResponseResult(TDto dtoObject)
        {
            Model = dtoObject;
        }

        public ResponseResult(List<Error> errors)
            : base(errors)
        {
        }
    }
}
