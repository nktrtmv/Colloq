using System.Text.Json;
using TasksService.Extensions;

namespace TasksService.NamingPolicies;

public sealed class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        return name.ToSnakeCase();
    }
}