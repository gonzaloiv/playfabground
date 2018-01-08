using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TaskSystem : Singleton<TaskSystem> {

    #region Fields / Properties

    private static readonly Dictionary<Type, Task> tasks = new Dictionary<Type, Task>();

    #endregion

    #region Public Behaviour

    public static void Run (Task task) {
        tasks.Add(task.GetType(), task);
        task.Run();
    }

    public static void RunOne (Task task) {
        Task currentTask;
        tasks.TryGetValue(task.GetType(), out currentTask);
        if (currentTask != null) {
            if (!currentTask.IsRunning)
                tasks[task.GetType()].Run();
        } else {
            tasks.Add(task.GetType(), task);
            task.Run();
        }
    }

    #endregion

}
