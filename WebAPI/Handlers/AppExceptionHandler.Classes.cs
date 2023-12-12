using Newtonsoft.Json;

namespace WebAPI.Handlers;

internal partial class AppExceptionHandler
{
    private record ErrorDetails
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
