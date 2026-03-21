using System.Threading.Tasks;

namespace ElectricVehicleTrackerAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(KeyNotFoundException ke)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(ke.Message);
            }
            catch(Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Internal server error!");
            }
        }
    }
}
