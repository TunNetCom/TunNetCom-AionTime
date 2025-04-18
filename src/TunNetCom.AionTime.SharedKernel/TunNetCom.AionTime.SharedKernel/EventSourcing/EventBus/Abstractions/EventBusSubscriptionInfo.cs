namespace TunNetCom.AionTime.SharedKernel.EventBus.Abstractions;

public class EventBusSubscriptionInfo
{
    internal static readonly JsonSerializerOptions DefaultSerializerOptions = new()
    {
        TypeInfoResolver = JsonSerializer.IsReflectionEnabledByDefault ? CreateDefaultTypeResolver() : JsonTypeInfoResolver.Combine(),
    };

    public Dictionary<string, Type> EventTypes { get; } = [];

    public JsonSerializerOptions JsonSerializerOptions { get; } = new(DefaultSerializerOptions);

    private static IJsonTypeInfoResolver CreateDefaultTypeResolver()
    {
        return new DefaultJsonTypeInfoResolver();
    }
}