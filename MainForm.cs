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
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ToDoReminder
{
    /// <summary>
    /// Main form class for the ToDo Reminder application
    /// </summary>
    public partial class MainForm : Form
    {
        // Fields
        private TaskManager taskManager;
        private string fileName;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            taskManager = new TaskManager(); // Initialize taskManager
            fileName = string.Empty;         // Initialize fileName with a default value
            InitializeComponent();
            InitializeGUI();
        }

        /// <summary>
        /// Initialize GUI components and taskManager
        /// </summary>
        private void InitializeGUI()
        {
            // Initialize taskManager
            taskManager = new TaskManager();

            // Set default file name in application folder
            fileName = Application.StartupPath + "\\reminders.txt";

            // Set form title
            this.Text = "ToDo Reminder";

            // Set date time picker to current date and time
            dtpDate.Value = DateTime.Now;

            // Fill priority combo box with enum values
            cmbPriority.Items.Clear();
            foreach (PriorityType priority in Enum.GetValues(typeof(PriorityType)))
            {
                cmbPriority.Items.Add(priority.ToString().Replace('_', ' '));
            }
            cmbPriority.SelectedIndex = 2; // Default to Normal

            // Clear description text box
            txtDescription.Clear();

            // Clear task list box
            lstTasks.Items.Clear();

            // Set up timer for clock display
            clockTimer.Interval = 1000; // 1 second
            clockTimer.Enabled = true;
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");

            // Set tooltip for date time picker
            toolTip.SetToolTip(dtpDate, "Click to select date and time for the task");

            // Update button states
            UpdateButtonStates();
        }

        /// <summary>
        /// Update GUI based on current state
        /// </summary>
        private void UpdateGUI()
        {
            // Clear and refill task list box
            lstTasks.Items.Clear();
            string[] taskInfo = taskManager.GetTaskListInfo();
            lstTasks.Items.AddRange(taskInfo);

            // Update button states
            UpdateButtonStates();
        }

        /// <summary>
        /// Update button states based on list box selection
        /// </summary>
        private void UpdateButtonStates()
        {
            // Enable/disable change and delete buttons based on selection
            bool hasSelection = (lstTasks.SelectedIndex >= 0);
            btnChange.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
        }

        /// <summary>
        /// Create and add new task
        /// </summary>
        private void AddTask()
        {
            // Validate description
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Please enter a task description.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create new task
            Task task = new Task();
            task.Date = dtpDate.Value;
            task.Description = txtDescription.Text;
            task.Priority = (PriorityType)cmbPriority.SelectedIndex;

            // Add task to manager
            if (taskManager.AddTask(task))
            {
                // Update GUI
                UpdateGUI();

                // Clear description for next entry
                txtDescription.Clear();

                // Reset date time picker to current time
                dtpDate.Value = DateTime.Now;
            }
            else
            {
                MessageBox.Show("Failed to add task.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Change selected task
        /// </summary>
        private void ChangeTask()
        {
            // Check if a task is selected
            int index = lstTasks.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("Please select a task to change.", "Selection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate description
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Please enter a task description.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create updated task
            Task task = new Task();
            task.Date = dtpDate.Value;
            task.Description = txtDescription.Text;
            task.Priority = (PriorityType)cmbPriority.SelectedIndex;

            // Update task in manager
            if (taskManager.ChangeTask(index, task))
            {
                // Update GUI
                UpdateGUI();

                // Clear description
                txtDescription.Clear();

                // Reset date time picker to current time
                dtpDate.Value = DateTime.Now;
            }
            else
            {
                MessageBox.Show("Failed to change task.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete selected task
        /// </summary>
        private void DeleteTask()
        {
            // Check if a task is selected
            int index = lstTasks.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("Please select a task to delete.", "Selection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirm deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this task?",
                "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                // Delete task from manager
                if (taskManager.DeleteTask(index))
                {
                    // Update GUI
                    UpdateGUI();
                }
                else
                {
                    MessageBox.Show("Failed to delete task.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Handle Add button click
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddTask();
        }

        /// <summary>
        /// Handle Change button click
        /// </summary>
        private void btnChange_Click(object sender, EventArgs e)
        {
            ChangeTask();
        }

        /// <summary>
        /// Handle Delete button click
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteTask();
        }

        /// <summary>
        /// Handle File->New menu click
        /// </summary>
        private void menuFileNew_Click(object sender, EventArgs e)
        {
            // Reset the program to start-up state
            InitializeGUI();
        }

        /// <summary>
        /// Handle File->Open menu click
        /// </summary>
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

        /// <summary>
        /// Handle File->Save menu click
        /// </summary>
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

        /// <summary>
        /// Handle File->Exit menu click
        /// </summary>
        private void menuFileExit_Click(object sender, EventArgs e)
        {
            // Confirm exit
            DialogResult result = MessageBox.Show("Are you sure you want to exit?",
                "Confirm Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Handle Help->About menu click
        /// </summary>
        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
            // Show about box
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        /// <summary>
        /// Handle timer tick for clock display
        /// </summary>
        private void clockTimer_Tick(object sender, EventArgs e)
        {
            // Update clock display
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        /// <summary>
        /// Handle task selection change
        /// </summary>
        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update button states
            UpdateButtonStates();
        }
    }
}
