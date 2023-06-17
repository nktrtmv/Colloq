using TasksService.Contracts.Requests;

namespace TasksService.Contracts.Validators;

public static class UpdateTaskValidator
{
    public static void ValidateName(UpdateTaskRequest request)
    {
        if (request.Name.Length > 20)
        {
            throw new ArgumentException("Task name should have length less than 20 symbols.");
        }
    }

    public static void ValidateDescription(UpdateTaskRequest request)
    {
        if (request.Description.Length > 100)
        {
            throw new ArgumentException("Task description should have length less than 100 symbols.");
        }
    }

    public static void ValidateStatus(UpdateTaskRequest request)
    {
        if (request.Status != "Not started" && request.Status != "In progress" && request.Status != "Finished")
        {
            throw new ArgumentException("Task status should be 'Not started' or 'In progress' or 'Finished'.");
        }
    }
}