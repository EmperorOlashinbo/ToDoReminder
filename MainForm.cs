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
            lstTasks.Items.Clear();

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
            lstTasks.Items.Clear();
            string[] taskInfo = taskManager.GetTaskListInfo();
            if (taskInfo != null)
            {
                lstTasks.Items.AddRange(taskInfo);
            }
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = lstTasks.SelectedIndex >= 0;
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
            int index = lstTasks.SelectedIndex;
            if (index < 0)
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
            int index = lstTasks.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("Please select a task to delete.", "Selection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this task?",
                "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
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

        private void btnAdd_Click(object sender, EventArgs e) => AddTask();
        private void btnChange_Click(object sender, EventArgs e) => ChangeTask();
        private void btnDelete_Click(object sender, EventArgs e) => DeleteTask();

        private void menuFileNew_Click(object sender, EventArgs e) => InitializeGUI();

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

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }
    }
}