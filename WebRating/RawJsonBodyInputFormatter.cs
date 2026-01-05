using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WebRating
{

    public class RawJsonBodyInputFormatter : TextInputFormatter
    {
        public RawJsonBodyInputFormatter()
        {
            SupportedMediaTypes.Add("application/json");
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanReadType(Type type)
        {
            return type == typeof(string);
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(
            InputFormatterContext context,
            Encoding encoding)
        {
            ArgumentNullException.ThrowIfNull(context);
            ArgumentNullException.ThrowIfNull(encoding);

            var request = context.HttpContext.Request;
            
            using var reader = new StreamReader(
                request.Body,
                encoding,
                detectEncodingFromByteOrderMarks: false,
                bufferSize: 1024,
                leaveOpen: true);

            try
            {
                var content = await reader.ReadToEndAsync();
                return await InputFormatterResult.SuccessAsync(content);
            }
            catch (Exception ex)
            {
                context.ModelState.TryAddModelError(
                    context.ModelName,
                    $"Error reading request body: {ex.Message}");
                return await InputFormatterResult.FailureAsync();
            }
        }
    }
}
