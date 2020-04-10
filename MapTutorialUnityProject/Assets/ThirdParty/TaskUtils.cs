using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class TaskUtils
{
    static TaskScheduler UnityScheduler;
    public static void Init()
    {
        UnityScheduler = TaskScheduler.FromCurrentSynchronizationContext();
    }


    private static Action<Task> DefaultExeptionHandler = task =>
    {
        try { task.Wait(); }
        catch { /* swallow exception */}
    };

    public static Task FireAndForget(Action action, Action<Exception> exceptionHandler = null)
    {
        if (action == null) { throw new ArgumentNullException(nameof(action)); }

        var task = new Task(action);

        Action<Task> handler = exceptionHandler != null ?
            new Action<Task>(t => exceptionHandler(t.Exception.GetBaseException())) :
            DefaultExeptionHandler;

        var continuation = task.ContinueWith(handler,
            TaskContinuationOptions.ExecuteSynchronously
            | TaskContinuationOptions.OnlyOnFaulted);

        task.Start();

        return continuation;
    }

    public static Task FireAndForgetUnity(Action action, Action actionAfter, Action<Exception> exceptionHandler = null)
    {
        if (action == null) { throw new ArgumentNullException(nameof(action)); }

        var task = new Task(action);

        Action<Task> handler = exceptionHandler != null ?
            new Action<Task>(t => exceptionHandler(t.Exception.GetBaseException())) :
            DefaultExeptionHandler;

        var continuation = task.ContinueWith((t) => actionAfter(), default, TaskContinuationOptions.OnlyOnRanToCompletion, UnityScheduler);
        task.ContinueWith(handler,TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.OnlyOnFaulted);
        task.Start();
        return continuation;
    }

    //public static Task MonitorQueueEmptyTask(string queueName, CancellationTokenSource tokenSource)
    //{
    //    return Task.Factory.StartNew<bool>(() =>
    //    {

    //    }, tokenSource.Token, TaskCreationOptions.LongRunning).ContinueWith(faultedTask =>
    //    {
    //        WriteExceptionToLog(faultedTask.Exception);
    //    }, TaskContinuationOptions.OnlyOnFaulted);
    //}

    //public static Task FireAndForget(this Task task, Action<Exception> exceptionHandler = null)
    //{
    //    Action<Task> handler = exceptionHandler != null ?
    //        new Action<Task>(t => exceptionHandler(t.Exception.GetBaseException())) :
    //        DefaultExeptionHandler;

    //    var continuation = task.ContinueWith(handler,
    //        TaskContinuationOptions.ExecuteSynchronously
    //        | TaskContinuationOptions.OnlyOnFaulted);
    //    task.Start();

    //    return continuation;
    //}
}
