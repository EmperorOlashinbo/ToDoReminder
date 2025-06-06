using System;
using System.Collections.Generic;
using System.IO;

namespace ToDoReminder
{
    /// <summary>
    /// Class for handling reading and writing operations using text files
    /// </summary>
    public class FileManager
    {
        // File version token to identify files created by this application
        private const string FileVersionToken = "ToDoReminder_1.0";

        /// <summary>
        /// Save task list to specified file
        /// </summary>
        /// <param name="taskList">List of tasks to save</param>
        /// <param name="fileName">File name to save to</param>
        /// <returns>True if successful</returns>
        public static bool SaveTaskListToFile(List<Task> taskList, string fileName)
        {
            bool ok = true;

            try
            {
                // Create StreamWriter for writing to file
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    // Write file version token
                    writer.WriteLine(FileVersionToken);

                    // Write number of tasks
                    writer.WriteLine(taskList.Count);

                    // Write each task
                    foreach (Task task in taskList)
                    {
                        writer.WriteLine(task.Description);
                        writer.WriteLine((int)task.Priority);
                        writer.WriteLine(task.Date.ToString());
                    }
                }
            }
            catch (Exception)
            {
                ok = false;
            }

            return ok;
        }

        /// <summary>
        /// Open task list from specified file
        /// </summary>
        /// <param name="taskList">List to populate with tasks</param>
        /// <param name="fileName">File name to open from</param>
        /// <returns>True if successful</returns>
        public static bool OpenTaskListFromFile(List<Task> taskList, string fileName)
        {
            bool ok = true;

            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    // Read and verify file version token
                    string? versionTest = reader.ReadLine();
                    if (string.IsNullOrEmpty(versionTest) || versionTest != FileVersionToken)
                    {
                        return false;
                    }

                    // Read number of tasks
                    string? countLine = reader.ReadLine();
                    if (string.IsNullOrEmpty(countLine) || !int.TryParse(countLine, out int count))
                    {
                        return false;
                    }

                    // Read each task
                    for (int i = 0; i < count; i++)
                    {
                        string? description = reader.ReadLine();
                        string? priorityLine = reader.ReadLine();
                        string? dateLine = reader.ReadLine();

                        if (string.IsNullOrEmpty(description) ||
                            string.IsNullOrEmpty(priorityLine) ||
                            string.IsNullOrEmpty(dateLine) ||
                            !int.TryParse(priorityLine, out int priorityValue) ||
                            !DateTime.TryParse(dateLine, out DateTime date))
                        {
                            return false;
                        }

                        PriorityType priority = (PriorityType)priorityValue;
                        Task task = new Task(date, description, priority);
                        taskList.Add(task);
                    }
                }
            }
            catch (Exception)
            {
                ok = false;
            }

            return ok;
        }
    }
}
