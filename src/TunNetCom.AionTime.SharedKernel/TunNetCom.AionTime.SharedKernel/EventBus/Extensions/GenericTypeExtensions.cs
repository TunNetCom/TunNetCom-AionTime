namespace TunNetCom.AionTime.SharedKernel.EventBus.Extensions;

public static class GenericTypeExtensions
{
    public static string GetGenericTypeName(this Type type)
    {
        string typeName;

        if (type.IsGenericType)
        {
            string genericTypes = string.Join(",", type.GetGenericArguments().Select(t => t.Name));
            typeName = $"{type.Name[..type.Name.IndexOf('`', StringComparison.Ordinal)]}<{genericTypes}>";
        }
        else
        {
            typeName = type.Name;
        }

        return typeName;
    }

    public static string GetGenericTypeName(this object obj)
    {
        return obj.GetType().GetGenericTypeName();
    }
}