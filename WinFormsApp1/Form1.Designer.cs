namespace LabReservation
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            saveButton = new Button();
            labsRoom = new ComboBox();
            groupBox1 = new GroupBox();
            deleteButton = new Button();
            updateButton = new Button();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            nameTxtBox = new TextBox();
            dateTxt = new TextBox();
            startTimeTxt = new TextBox();
            endTimeTxt = new TextBox();
            showReservations = new Button();
            dataGridView1 = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();

            // saveButton
            saveButton.Location = new Point(79, 167);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(170, 35);
            saveButton.TabIndex = 0;
            saveButton.Text = "SAVE RESERVATION";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click_1;

            // labsRoom
            labsRoom.FormattingEnabled = true;
            labsRoom.Items.AddRange(new object[] { "Lab 1", "Lab 2", "Lab 3" });
            labsRoom.Location = new Point(79, 22);
            labsRoom.Name = "labsRoom";
            labsRoom.Size = new Size(217, 23);
            labsRoom.TabIndex = 2;
            labsRoom.SelectedIndexChanged += labsRoom_SelectedIndexChanged_1;

            // groupBox1
            groupBox1.Controls.Add(deleteButton);
            groupBox1.Controls.Add(updateButton);
            groupBox1.Controls.Add(textBox6);
            groupBox1.Controls.Add(saveButton);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(nameTxtBox);
            groupBox1.Controls.Add(endTimeTxt);
            groupBox1.Controls.Add(startTimeTxt);
            groupBox1.Controls.Add(dateTxt);
            groupBox1.Controls.Add(labsRoom);
            groupBox1.Location = new Point(26, 25);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(344, 290);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "CCS LAB RESERVATION";

            // deleteButton
            deleteButton.Location = new Point(79, 235);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(170, 35);
            deleteButton.TabIndex = 13;
            deleteButton.Text = "DELETE RESERVATION";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;

            // updateButton
            updateButton.Location = new Point(79, 201);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(170, 35);
            updateButton.TabIndex = 12;
            updateButton.Text = "UPDATE RESERVATION";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;

            // textBox6 (Name label)
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.Location = new Point(6, 138);
            textBox6.Name = "textBox6";
            textBox6.ReadOnly = true;
            textBox6.Size = new Size(67, 16);
            textBox6.TabIndex = 11;
            textBox6.Text = "Name";

            // textBox5 (End Time label)
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Location = new Point(6, 109);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(67, 16);
            textBox5.TabIndex = 10;
            textBox5.Text = "End Time";

            // textBox4 (Start Time label)
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Location = new Point(6, 80);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(67, 16);
            textBox4.TabIndex = 9;
            textBox4.Text = "Start Time";

            // textBox3 (Date label)
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Location = new Point(6, 51);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(67, 16);
            textBox3.TabIndex = 8;
            textBox3.Text = "Date";

            // textBox2 (Lab Rooms label)
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Location = new Point(6, 22);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(67, 16);
            textBox2.TabIndex = 7;
            textBox2.Text = "Lab Rooms";
            textBox2.TextChanged += textBox2_TextChanged;

            // nameTxtBox
            nameTxtBox.Location = new Point(79, 138);
            nameTxtBox.Name = "nameTxtBox";
            nameTxtBox.Size = new Size(217, 23);
            nameTxtBox.TabIndex = 6;
            nameTxtBox.TextChanged += nameTxtBox_TextChanged_1;

            // dateTxt — replaces DateTimePicker, readonly shows today
            dateTxt.Location = new Point(79, 51);
            dateTxt.Name = "dateTxt";
            dateTxt.Size = new Size(217, 23);
            dateTxt.TabIndex = 3;
            dateTxt.ReadOnly = true;
            dateTxt.Text = DateTime.Today.ToString("dddd, MMMM d, yyyy");

            // startTimeTxt — replaces startTime DateTimePicker
            startTimeTxt.Location = new Point(79, 80);
            startTimeTxt.Name = "startTimeTxt";
            startTimeTxt.Size = new Size(217, 23);
            startTimeTxt.TabIndex = 4;
            startTimeTxt.Text = "08:00 AM";
            startTimeTxt.TextChanged += startTimeTxt_TextChanged;

            // endTimeTxt — replaces endTime DateTimePicker
            endTimeTxt.Location = new Point(79, 109);
            endTimeTxt.Name = "endTimeTxt";
            endTimeTxt.Size = new Size(217, 23);
            endTimeTxt.TabIndex = 5;
            endTimeTxt.Text = "09:00 AM";

            // showReservations
            showReservations.Location = new Point(387, 260);
            showReservations.Name = "showReservations";
            showReservations.Size = new Size(114, 53);
            showReservations.TabIndex = 5;
            showReservations.Text = "SHOW ALL RESERVATIONS";
            showReservations.UseVisualStyleBackColor = true;
            showReservations.Click += showReservations_Click;

            // dataGridView1
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(387, 37);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(510, 217);
            dataGridView1.TabIndex = 8;

            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 554);
            Controls.Add(dataGridView1);
            Controls.Add(showReservations);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        private Button saveButton;
        private ComboBox labsRoom;
        private GroupBox groupBox1;
        private TextBox nameTxtBox;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox dateTxt;
        private TextBox startTimeTxt;
        private TextBox endTimeTxt;
        private Button deleteButton;
        private Button updateButton;
        private Button showReservations;
        private DataGridView dataGridView1;
    }
}