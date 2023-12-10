using Newtonsoft.Json;

namespace Application.Middleware;

public partial class ExceptionMiddleware
{
    private class ErrorDetails
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
