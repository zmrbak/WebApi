using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text;

namespace WebApi47.Formatters
{
    public class CustomSerializerOutputFormatter : TextOutputFormatter
    {
        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            throw new NotImplementedException();
        }
    }
}
