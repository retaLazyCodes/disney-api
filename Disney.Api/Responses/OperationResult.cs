using System;

namespace Disney.Api.Responses
{
    public class OperationResult<TResult>
    {
        protected internal OperationResult()
        {
        }

        public bool Success { get; protected internal set; }
        public TResult Data { get; protected internal set; }
        public string NonSuccessMessage { get; protected set; }
        

        public static OperationResult<TResult> CreateSuccessResult(TResult result)
        {
            return new OperationResult<TResult> { Success = true, Data = result };
        }

        public static OperationResult<TResult> CreateFailure(string nonSuccessMessage)
        {
            return new OperationResult<TResult> { Success = false, NonSuccessMessage = nonSuccessMessage };
        }

        public static OperationResult<TResult> CreateFailure(Exception ex)
        {
            return new OperationResult<TResult>
            {
                Success = false,
                NonSuccessMessage = String.Format("{0}{1}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace),
            };
        }
    }
}