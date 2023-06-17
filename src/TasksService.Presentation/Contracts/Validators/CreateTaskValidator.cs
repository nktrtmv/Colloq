using TasksService.Contracts.Requests;

namespace TasksService.Contracts.Validators;

public static class CreateTaskValidator
{
    public static void ValidateName(CreateTaskRequest request)
    {
        if (request.Name.Length > 20)
        {
            throw new ArgumentException("Task name should have length less than 20 symbols.");
        }
    }

    public static void ValidateDescription(CreateTaskRequest request)
    {
        if (request.Description.Length > 100)
        {
            throw new ArgumentException("Task description should have length less than 100 symbols.");
        }
    }
}