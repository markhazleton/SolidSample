using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ArdalisRatingWebApi
{
    /// <summary>
    /// 
    /// </summary>
    public class RawJsonBodyInputFormatter : InputFormatter
    {
        /// <summary>
        /// 
        /// </summary>
        public RawJsonBodyInputFormatter()
        {
            this.SupportedMediaTypes.Add("application/json");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            var request = context.HttpContext.Request;
            using (var reader = new StreamReader(request.Body))
            {
                var content = await reader.ReadToEndAsync();
                return await InputFormatterResult.SuccessAsync(content);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected override bool CanReadType(Type type)
        {
            return type == typeof(string);
        }
    }
}
