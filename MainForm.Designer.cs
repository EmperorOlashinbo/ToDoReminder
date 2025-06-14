namespace ToDoReminder
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            dtpDate = new DateTimePicker();
            lblDate = new Label();
            lblPriority = new Label();
            cmbPriority = new ComboBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            btnAdd = new Button();
            btnChange = new Button();
            btnDelete = new Button();
            grpToDo = new GroupBox();
            lvTasks = new ListView();
            colDate = new ColumnHeader();
            colTime = new ColumnHeader();
            colPriority = new ColumnHeader();
            colDescription = new ColumnHeader();
            menuMain = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            menuFileNew = new ToolStripMenuItem();
            menuFileOpen = new ToolStripMenuItem();
            menuFileSave = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            menuFileExit = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            menuHelpAbout = new ToolStripMenuItem();
            toolTip = new ToolTip(components);
            clockTimer = new System.Windows.Forms.Timer(components);
            lblClock = new Label();
            grpToDo.SuspendLayout();
            menuMain.SuspendLayout();
            SuspendLayout();
            // 
            // dtpDate
            // 
            dtpDate.CustomFormat = "yyyy-MM-dd HH:mm";
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Location = new Point(102, 64);
            dtpDate.Margin = new Padding(4, 3, 4, 3);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(174, 23);
            dtpDate.TabIndex = 0;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(13, 64);
            lblDate.Margin = new Padding(4, 0, 4, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(81, 15);
            lblDate.TabIndex = 1;
            lblDate.Text = "Date and time";
            // 
            // lblPriority
            // 
            lblPriority.AutoSize = true;
            lblPriority.Location = new Point(341, 67);
            lblPriority.Margin = new Padding(4, 0, 4, 0);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new Size(45, 15);
            lblPriority.TabIndex = 2;
            lblPriority.Text = "Priority";
            // 
            // cmbPriority
            // 
            cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPriority.FormattingEnabled = true;
            cmbPriority.Location = new Point(394, 64);
            cmbPriority.Margin = new Padding(4, 3, 4, 3);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(174, 23);
            cmbPriority.TabIndex = 3;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(13, 106);
            lblDescription.Margin = new Padding(4, 0, 4, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(37, 15);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "To Do";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(66, 106);
            txtDescription.Margin = new Padding(4, 3, 4, 3);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(502, 23);
            txtDescription.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.ControlDark;
            btnAdd.Location = new Point(249, 146);
            btnAdd.Margin = new Padding(4, 3, 4, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(88, 27);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnChange
            // 
            btnChange.Enabled = false;
            btnChange.Location = new Point(18, 485);
            btnChange.Margin = new Padding(4, 3, 4, 3);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(88, 27);
            btnChange.TabIndex = 7;
            btnChange.Text = "Change";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click;
            // 
            // btnDelete
            // 
            btnDelete.Enabled = false;
            btnDelete.Location = new Point(117, 485);
            btnDelete.Margin = new Padding(4, 3, 4, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(88, 27);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // grpToDo
            // 
            grpToDo.Controls.Add(lvTasks);
            grpToDo.Location = new Point(18, 233);
            grpToDo.Margin = new Padding(4, 3, 4, 3);
            grpToDo.Name = "grpToDo";
            grpToDo.Padding = new Padding(4, 3, 4, 3);
            grpToDo.Size = new Size(713, 243);
            grpToDo.TabIndex = 10;
            grpToDo.TabStop = false;
            grpToDo.Text = "To Do";
            // 
            // lvTasks
            // 
            lvTasks.Columns.AddRange(new ColumnHeader[] { colDate, colTime, colPriority, colDescription });
            lvTasks.Dock = DockStyle.Fill;
            lvTasks.FullRowSelect = true;
            lvTasks.GridLines = true;
            lvTasks.Location = new Point(4, 19);
            lvTasks.Margin = new Padding(4, 3, 4, 3);
            lvTasks.Name = "lvTasks";
            lvTasks.Size = new Size(705, 221);
            lvTasks.TabIndex = 0;
            lvTasks.UseCompatibleStateImageBehavior = false;
            lvTasks.View = View.Details;
            lvTasks.SelectedIndexChanged += lvTasks_SelectedIndexChanged;
            // 
            // colDate
            // 
            colDate.Text = "Date";
            colDate.Width = 100;
            // 
            // colTime
            // 
            colTime.Text = "Time";
            // 
            // colPriority
            // 
            colPriority.Text = "Priority";
            colPriority.Width = 160;
            // 
            // colDescription
            // 
            colDescription.Text = "Description";
            colDescription.Width = 350;
            // 
            // menuMain
            // 
            menuMain.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Padding = new Padding(7, 2, 0, 2);
            menuMain.Size = new Size(784, 24);
            menuMain.TabIndex = 11;
            menuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuFileNew, menuFileOpen, menuFileSave, toolStripSeparator1, menuFileExit });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // menuFileNew
            // 
            menuFileNew.Name = "menuFileNew";
            menuFileNew.Size = new Size(167, 22);
            menuFileNew.Text = "New          Cntl+N";
            menuFileNew.Click += menuFileNew_Click;
            // 
            // menuFileOpen
            // 
            menuFileOpen.Name = "menuFileOpen";
            menuFileOpen.Size = new Size(167, 22);
            menuFileOpen.Text = "Open data file";
            menuFileOpen.Click += menuFileOpen_Click;
            // 
            // menuFileSave
            // 
            menuFileSave.Name = "menuFileSave";
            menuFileSave.Size = new Size(167, 22);
            menuFileSave.Text = "Save data file";
            menuFileSave.Click += menuFileSave_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(164, 6);
            // 
            // menuFileExit
            // 
            menuFileExit.Name = "menuFileExit";
            menuFileExit.Size = new Size(167, 22);
            menuFileExit.Text = "Exit           Alt+F4";
            menuFileExit.Click += menuFileExit_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuHelpAbout });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // menuHelpAbout
            // 
            menuHelpAbout.Name = "menuHelpAbout";
            menuHelpAbout.Size = new Size(116, 22);
            menuHelpAbout.Text = "About...";
            menuHelpAbout.Click += menuHelpAbout_Click;
            // 
            // clockTimer
            // 
            clockTimer.Interval = 1000;
            clockTimer.Tick += clockTimer_Tick;
            // 
            // lblClock
            // 
            lblClock.AutoSize = true;
            lblClock.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClock.ForeColor = SystemColors.Highlight;
            lblClock.Location = new Point(664, 490);
            lblClock.Margin = new Padding(4, 0, 4, 0);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(63, 16);
            lblClock.TabIndex = 12;
            lblClock.Text = "00:00:00";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 532);
            Controls.Add(lblClock);
            Controls.Add(grpToDo);
            Controls.Add(btnDelete);
            Controls.Add(btnChange);
            Controls.Add(btnAdd);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(cmbPriority);
            Controls.Add(lblPriority);
            Controls.Add(lblDate);
            Controls.Add(dtpDate);
            Controls.Add(menuMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuMain;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "ToDo Reminder by Ibrahim";
            grpToDo.ResumeLayout(false);
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox grpToDo;
        private System.Windows.Forms.ListView lvTasks;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colPriority;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuFileNew;
        private System.Windows.Forms.ToolStripMenuItem menuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem menuFileSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Timer clockTimer;
        private System.Windows.Forms.Label lblClock;
    }
}