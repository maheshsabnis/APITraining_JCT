namespace Core_API.CustomMiddlewares
{
    public record ErrorInfo
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public DateTime ErrorDate { get; set; }
    }


    public class AppExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public AppExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        /// <summary>
        /// Logic for the Middleware
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context) 
        {
            try
            {
                // If no Error the Continue with next middleware in pipeline
                await _next(context);
            }
            catch (Exception ex)
            {
                // Catch the error and generate response
                // 1. Set the Error Code
                context.Response.StatusCode = 500;
                // 2. Store the Error INformation locally
                string errorMessage = ex.Message;
                // 3. Define a REsponse

                ErrorInfo errorInfo = new ErrorInfo()
                { 
                     ErrorCode = context.Response.StatusCode,
                     ErrorMessage = errorMessage,
                     ErrorDate = DateTime.Now
                };

                // Write the response in the Response Object
                await context.Response.WriteAsJsonAsync(errorInfo);
            }
        }
    }

    public static class ExceptionMiddlewareExtension
    {
        public static void UseAppException(this IApplicationBuilder app)
        {
            app.UseMiddleware<AppExceptionMiddleware>();
        }
    }
}
