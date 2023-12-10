using Newtonsoft.Json;

namespace WebAPI.Requests;

public record BaseRequest
{
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
