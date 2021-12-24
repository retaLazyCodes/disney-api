using Disney.Core.CustomEntities;
using Disney.Core.Entities;

namespace Disney.Api.Responses
{
    public class ResponseWithMeta<TResult> : OperationResult<TResult>
    {
        public Metadata Metadata { get; set; }
        
        public static ResponseWithMeta<TResult> CreateSuccessResult(TResult result, Metadata meta)
        {
            return new ResponseWithMeta<TResult> { Success = true, Data = result , Metadata = meta};
        }
        
    }
}