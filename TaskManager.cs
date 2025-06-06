using System;
using System.Collections.Generic;
using ToDoReminder;

namespace ToDoReminder
{
    /// <summary>
    /// Class responsible for maintaining a list of Task objects
    /// </summary>
    public class TaskManager
    {
        // Fields
        private List<Task> taskList;

        /// <summary>
        /// Constructor
        /// </summary>
        public TaskManager()
        {
            taskList = new List<Task>();
        }

        /// <summary>
        /// Add task to taskList
        /// </summary>
        /// <param name="task">Task to add</param>
        /// <returns>True if successful</returns>
        public bool AddTask(Task task)
        {
            if (task != null)
            {
                taskList.Add(task);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Change task at specified index
        /// </summary>
        /// <param name="index">Index of task to change</param>
        /// <param name="task">New task data</param>
        /// <returns>True if successful</returns>
        public bool ChangeTask(int index, Task task)
        {
            if (task != null && index >= 0 && index < taskList.Count)
            {
                taskList[index] = task;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete task at specified index
        /// </summary>
        /// <param name="index">Index of task to delete</param>
        /// <returns>True if successful</returns>
        public bool DeleteTask(int index)
        {
            if (index >= 0 && index < taskList.Count)
            {
                taskList.RemoveAt(index);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Return array of task information strings for display
        /// </summary>
        /// <returns>Array of task strings</returns>
        public string[] GetTaskListInfo()
        {
            string[] taskInfo = new string[taskList.Count];

            for (int i = 0; i < taskList.Count; i++)
            {
                taskInfo[i] = taskList[i].ToString();
            }

            return taskInfo;
        }

        /// <summary>
        /// Save tasks to file using FileManager
        /// </summary>
        /// <param name="fileName">File name to save to</param>
        /// <returns>True if successful</returns>
        public bool SaveTaskListToFile(string fileName)
        {
            return FileManager.SaveTaskListToFile(taskList, fileName);
        }

        /// <summary>
        /// Open tasks from file using FileManager
        /// </summary>
        /// <param name="fileName">File name to open from</param>
        /// <returns>True if successful</returns>
        public bool OpenTaskListFromFile(string fileName)
        {
            // Clear existing tasks
            taskList.Clear();
            return FileManager.OpenTaskListFromFile(taskList, fileName);
        }
    }
}
