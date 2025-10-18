

using System.Net;

namespace RealERP.Application.Exceptions
{
    public abstract class BaseException:Exception
    {
        public abstract HttpStatusCode StatusCode { get; }
        protected BaseException(string message):base(message)
        {
            
        }
    }
}
