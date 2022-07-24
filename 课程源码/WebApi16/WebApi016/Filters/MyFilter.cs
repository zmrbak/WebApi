using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi016.Filters
{
    public class MyFilter : IAsyncActionFilter, IAsyncResultFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //对参数的验证
            //记录访问日志
            Console.WriteLine("[OnActionExecutionAsync] Before Action");

            await next();

            //数据格式化
            Console.WriteLine("[OnActionExecutionAsync] After Action");
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await next();
        }
    }
}
