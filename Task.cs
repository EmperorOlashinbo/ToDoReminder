using System;

namespace ToDoReminder
{
    public class Task
    {
        private string description;
        private DateTime date;
        private PriorityType priority;

        public Task()
        {
            description = string.Empty;
            date = DateTime.Now;
            priority = PriorityType.Normal;
        }

        public Task(DateTime dateTime) : this(dateTime, string.Empty, PriorityType.Normal)
        {
        }

        public Task(DateTime dateTime, string desc, PriorityType prio)
        {
            date = dateTime;
            description = desc;
            priority = prio;
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public PriorityType Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        public string GetPriorityString()
        {
            return priority.ToString().Replace('_', ' ');
        }

        public string GetTimeString()
        {
            return date.Hour.ToString("00") + ":" + date.Minute.ToString("00");
        }

        public override string ToString()
        {
            return date.ToShortDateString() + " " + GetTimeString() + " " +
                   GetPriorityString() + " - " + description;
        }
    }
}