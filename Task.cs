using System;
using ToDoReminder;

namespace ToDoReminder
{
    /// <summary>
    /// Class that handles all about a task
    /// Every reminder task becomes a separate object of this class
    /// </summary>
    public class Task
    {
        // Fields
        private string description;
        private DateTime date;
        private PriorityType priority;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Task()
        {
            description = string.Empty;
            date = DateTime.Now;
            priority = PriorityType.Normal;
        }

        /// <summary>
        /// Constructor with date parameter
        /// </summary>
        /// <param name="dateTime">Date and time for the task</param>
        public Task(DateTime dateTime) : this(dateTime, string.Empty, PriorityType.Normal)
        {
        }

        /// <summary>
        /// Constructor with all parameters
        /// </summary>
        /// <param name="dateTime">Date and time for the task</param>
        /// <param name="desc">Description of the task</param>
        /// <param name="prio">Priority of the task</param>
        public Task(DateTime dateTime, string desc, PriorityType prio)
        {
            date = dateTime;
            description = desc;
            priority = prio;
        }

        /// <summary>
        /// Property for description
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// Property for date
        /// </summary>
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        /// <summary>
        /// Property for priority
        /// </summary>
        public PriorityType Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        /// <summary>
        /// Returns priority as formatted string
        /// </summary>
        /// <returns>String representation of priority</returns>
        public string GetPriorityString()
        {
            // Replace underscore with space
            return priority.ToString().Replace('_', ' ');
        }

        /// <summary>
        /// Returns time as formatted string (hh:mm)
        /// </summary>
        /// <returns>Formatted time string</returns>
        public string GetTimeString()
        {
            return date.Hour.ToString("00") + ":" + date.Minute.ToString("00");
        }

        /// <summary>
        /// Returns formatted string representation of task
        /// </summary>
        /// <returns>String representation of the task</returns>
        public override string ToString()
        {
            return date.ToShortDateString() + " " + GetTimeString() + " " +
                   GetPriorityString() + " - " + description;
        }
    }
}
