using System.ComponentModel.DataAnnotations;

namespace TunNetCom.AionTime.AzureDevopsService.API.Clients.Settings;

public sealed class UrlAttribute : ValidationAttribute
{
    public UrlAttribute()
    {
    }

    public override bool IsValid(object? value)
    {
        Regex regex = new(@"(https://)?(www\.)?\w+\.(com|net|edu|org)");

        if (value is null)
        {
            return false;
        }

        string? stringValue = value.ToString();

        if (stringValue is null)
        {
            return false;
        }

        if (!regex.IsMatch(stringValue))
        {
            return false;
        }

        return true;
    }
}