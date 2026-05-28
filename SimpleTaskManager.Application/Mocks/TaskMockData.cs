using SimpleTaskManager.Application.Entities;
using SimpleTaskManager.Communication.Enums;
using TaskStatus = SimpleTaskManager.Communication.Enums.TaskStatus;

namespace SimpleTaskManager.Application.Mocks;

public static class TaskMockData
{
    public static List<TaskItem> Tasks { get; } =
    [
        new TaskItem
        {
            Id = Guid.Parse("58ec3f81-7612-4ff7-890b-ab8add8d40f1"),
            Name = "Task existente 1",
            Description = "Descrição atual da primeira task",
            Priority = TaskPriority.High,
            DueDate = new DateOnly(2026, 5, 26),
            Status = TaskStatus.Pending,
            CreatedAt = DateTime.UtcNow.AddDays(-2),
            UpdatedAt = DateTime.UtcNow.AddDays(-2)
        },
        new TaskItem
        {
            Id = Guid.Parse("7f2e7f60-2d74-4f98-9e5f-9f0a7f5c2b11"),
            Name = "Task existente 2",
            Description = "Descrição atual da segunda task",
            Priority = TaskPriority.Medium,
            DueDate = new DateOnly(2026, 1, 28),
            Status = TaskStatus.InProgress,
            CreatedAt = DateTime.UtcNow.AddDays(-1),
            UpdatedAt = DateTime.UtcNow.AddDays(-2)
        }
    ];
}
