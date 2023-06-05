namespace MiddleWarev03.Helpers
{
    public class ControlHelper
    {
        public static async Task HandleRequest(HttpContext context)
        {
            // Access the value of the custom header from the application pipeline
            if (context.Response.Headers.ContainsKey("X-Custom-Header"))
            {
                string headerValue = context.Response.Headers["X-Custom-Header"];
                // Use the header value as needed
            }

            await context.Response.WriteAsync("Hello, World!");
        }
    }
}
