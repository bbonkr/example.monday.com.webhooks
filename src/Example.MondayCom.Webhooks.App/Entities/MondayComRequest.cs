namespace Example.MondayCom.Webhooks.App.Entities;

public class MondayComRequest
{
    public Guid Id { get; set; }

    public string Headers { get; set; } = string.Empty;

    public string Payload { get; set; } = string.Empty;
}

