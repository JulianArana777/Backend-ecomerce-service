namespace API.ERRORS
{
    public class ApiResponse
    {
       
       
        public ApiResponse(int statusCode,String Message = null)
        {
         statuscode=statuscode;
         message=Message ?? GetDefaultMessage(statuscode);
        }      
        public int statuscode{get;set;}
        public String message{get;set;}
        
        private string GetDefaultMessage(int statuscode)
        {
            return statuscode switch
            {
                400 => "Bad request",
                401 => " Not authorized",
                405 => "Resource not found",
                500 => "Bad request",
                _ => "Generic"
            };
        }
    }
}