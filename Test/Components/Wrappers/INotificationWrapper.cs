namespace Demo.Test.Components.Wrappers;

public interface INotificationWrapper
{
    void ExecuteWithNotificationAsync(Func<Task> action);

    Task<T> ExecuteWithNotificationAsync<T>(Func<Task<T>> action);
}
