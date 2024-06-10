namespace API.Minimal.Utilities
{
    public class CustomExceptionResponse : Exception
    {
        public CustomExceptionResponse(string msg) : base(msg) 
        {
            
        }
    }
}
