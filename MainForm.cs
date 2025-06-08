using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoReminder
{
    public partial class MainForm : Form
    {
        private TaskManager taskManager;
        private string fileName;

        public MainForm()
        {
            InitializeComponent();
            taskManager = new TaskManager();
            fileName = Application.StartupPath + "\\reminders.txt";
            InitializeGUI();

            this.Resize += MainForm_Resize;
        }

        private void InitializeGUI()
        {
            // Set form title with your name
            this.Text = "ToDo Reminder by Ibrahim";

            // Initialize task manager and file path
            taskManager = new TaskManager();
            fileName = Application.StartupPath + "\\reminders.txt";

            // Set up date time picker
            dtpDate.Value = DateTime.Now;
            dtpDate.CustomFormat = "yyyy-MM-dd HH:mm";
            dtpDate.Format = DateTimePickerFormat.Custom;

            // Set up priority combo box
            cmbPriority.Items.Clear();
            foreach (PriorityType priority in Enum.GetValues(typeof(PriorityType)))
            {
                cmbPriority.Items.Add(priority.ToString().Replace('_', ' '));
            }
            cmbPriority.SelectedIndex = (int)PriorityType.Normal;

            // Clear inputs
            txtDescription.Clear();
            lvTasks.Items.Clear();

            // Set up ListView columns
            colDate.Text = "Date";
            colTime.Text = "Time";
            colPriority.Text = "Priority";
            colDescription.Text = "Description";

            // Set column widths
            colDate.Width = 100;
            colTime.Width = 60;
            colPriority.Width = 80;
            colDescription.Width = 200;

            // Adjust Description column to fill remaining space
            lvTasks.Columns[3].Width = -2; // -2 makes it auto-size to content, -1 to header

            // Set up clock timer
            clockTimer.Interval = 1000;
            clockTimer.Enabled = true;
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");

            // Set tooltips
            toolTip.SetToolTip(dtpDate, "Click to select date and time for the task");
            toolTip.SetToolTip(cmbPriority, "Select task priority");
            toolTip.SetToolTip(txtDescription, "Enter task description here");
            toolTip.SetToolTip(btnAdd, "Add new task");
            toolTip.SetToolTip(btnChange, "Change selected task");
            toolTip.SetToolTip(btnDelete, "Delete selected task");

            UpdateButtonStates();
        }

        private void UpdateGUI()
        {
            lvTasks.Items.Clear();
            string[] taskInfo = taskManager.GetTaskListInfo();

            foreach (string task in taskInfo)
            {
                // Split into left and right of the first " - "
                string[] parts = task.Split(new[] { " - " }, 2, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    // The left part contains date, time, and priority (possibly multi-word)
                    string[] firstPart = parts[0].Split(' ');
                    if (firstPart.Length >= 3)
                    {
                        string date = firstPart[0];
                        string time = firstPart[1];
                        // Priority is everything after date and time, joined by space
                        string priority = string.Join(" ", firstPart.Skip(2));
                        string description = parts[1];

                        ListViewItem item = new ListViewItem(date); // Date
                        item.SubItems.Add(time); // Time
                        item.SubItems.Add(priority); // Priority (multi-word supported)
                        item.SubItems.Add(description); // Description
                        lvTasks.Items.Add(item);
                    }
                }
            }

            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = (lvTasks.SelectedItems.Count > 0);
            btnChange.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
        }

        private void AddTask()
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Please enter a task description.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Task task = new Task();
            task.Date = dtpDate.Value;
            task.Description = txtDescription.Text;
            task.Priority = (PriorityType)cmbPriority.SelectedIndex;

            if (taskManager.AddTask(task))
            {
                UpdateGUI();
                txtDescription.Clear();
                dtpDate.Value = DateTime.Now;
            }
            else
            {
                MessageBox.Show("Failed to add task.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeTask()
        {
            if (lvTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a task to change.", "Selection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Please enter a task description.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int index = lvTasks.SelectedIndices[0];
            Task task = new Task();
            task.Date = dtpDate.Value;
            task.Description = txtDescription.Text;
            task.Priority = (PriorityType)cmbPriority.SelectedIndex;

            if (taskManager.ChangeTask(index, task))
            {
                UpdateGUI();
                txtDescription.Clear();
                dtpDate.Value = DateTime.Now;
            }
            else
            {
                MessageBox.Show("Failed to change task.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteTask()
        {
            if (lvTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a task to delete.", "Selection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this task?",
                "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                int index = lvTasks.SelectedIndices[0];
                if (taskManager.DeleteTask(index))
                {
                    UpdateGUI();
                }
                else
                {
                    MessageBox.Show("Failed to delete task.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddTask();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            ChangeTask();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteTask();
        }

        private void menuFileNew_Click(object sender, EventArgs e)
        {
            InitializeGUI();
        }

        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            if (taskManager.OpenTaskListFromFile(fileName))
            {
                UpdateGUI();
            }
            else
            {
                MessageBox.Show("Failed to open file or file format is invalid.", "File Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuFileSave_Click(object sender, EventArgs e)
        {
            if (taskManager.SaveTaskListToFile(fileName))
            {
                MessageBox.Show("Tasks saved successfully.", "Save Successful",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to save tasks to file.", "File Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?",
                "Confirm Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void clockTimer_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void lvTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTasks.SelectedItems.Count > 0)
            {
                ListViewItem item = lvTasks.SelectedItems[0];
                try
                {
                    dtpDate.Value = DateTime.Parse(item.SubItems[0].Text + " " + item.SubItems[1].Text);
                    cmbPriority.SelectedIndex = (int)Enum.Parse(typeof(PriorityType), item.SubItems[2].Text.Replace(" ", "_"));
                    txtDescription.Text = item.SubItems[3].Text;
                }
                catch
                {
                    // Handle parsing errors if needed
                }
            }
            UpdateButtonStates();
        }

        private void MainForm_Resize(object? sender, EventArgs e)
        {
            // Adjust Description column to fill remaining space
            int otherColumnsWidth = lvTasks.Columns[0].Width + lvTasks.Columns[1].Width + lvTasks.Columns[2].Width;
            lvTasks.Columns[3].Width = lvTasks.ClientSize.Width - otherColumnsWidth - 4; // 4 for border
        }
    }
}