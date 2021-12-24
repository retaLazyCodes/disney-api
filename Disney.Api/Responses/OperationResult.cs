using System;
using Disney.Core.CustomEntities;

namespace Disney.Api.Responses
{
    public class OperationResult<TResult>
    {
        private OperationResult()
        {
        }

        public bool Success { get; private set; }
        public TResult Data { get; private set; }
        public string NonSuccessMessage { get; private set; }
        public Exception Exception { get; private set; }

        public Metadata Metadata { get; set; }

        public static OperationResult<TResult> CreateSuccessResult(TResult result)
        {
            return new OperationResult<TResult> { Success = true, Data = result };
        }

        public static OperationResult<TResult> CreateSuccessResult(TResult result, Metadata meta)
        {
            return new OperationResult<TResult> { Success = true, Data = result , Metadata = meta};
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
                Exception = ex
            };
        }
    }
}