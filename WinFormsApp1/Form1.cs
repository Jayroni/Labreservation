using LabReservation.controller;
using LabReservation.model;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LabReservation
{
    public partial class Form1 : Form
    {
        private controller.ReservationController reservationController = new controller.ReservationController();
        private string currentUpdatingName = "";

        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen gridPen = new Pen(Color.FromArgb(18, 0, 200, 255), 1))
            {
                for (int x = 0; x < this.Width; x += 32)
                    e.Graphics.DrawLine(gridPen, x, 0, x, this.Height);
                for (int y = 0; y < this.Height; y += 32)
                    e.Graphics.DrawLine(gridPen, 0, y, this.Width, y);
            }
        }

        private string ShowInputDialog(string text)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Search Reservation",
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.FromArgb(10, 22, 40),
                ForeColor = Color.FromArgb(0, 200, 255)
            };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = text, Width = 350, ForeColor = Color.FromArgb(0, 200, 255) };
            TextBox textBox = new TextBox()
            {
                Left = 20,
                Top = 50,
                Width = 340,
                BackColor = Color.FromArgb(10, 15, 30),
                ForeColor = Color.FromArgb(180, 220, 255),
                BorderStyle = BorderStyle.FixedSingle
            };
            Button confirmation = new Button()
            {
                Text = "SEARCH",
                Left = 260,
                Top = 100,
                Width = 100,
                DialogResult = DialogResult.OK,
                BackColor = Color.FromArgb(0, 200, 255),
                ForeColor = Color.FromArgb(0, 20, 40),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold)
            };
            confirmation.FlatAppearance.BorderSize = 0;
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private void StyleTextBox(TextBox tb, bool readOnly = false)
        {
            tb.BackColor = Color.FromArgb(10, 20, 42);
            tb.ForeColor = readOnly ? Color.FromArgb(0, 180, 220) : Color.FromArgb(180, 220, 255);
            tb.BorderStyle = BorderStyle.FixedSingle;
            tb.Font = new Font("Segoe UI", 10f);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            


            // Set today's date in the readonly textbox
            dateTxt.Text = DateTime.Today.ToString("dddd, MMMM d, yyyy");

            // === FORM ===
            this.BackColor = Color.FromArgb(8, 18, 38);
            this.ForeColor = Color.FromArgb(0, 200, 255);
            this.Font = new Font("Segoe UI", 9f);

            // === GROUP BOX ===
            groupBox1.BackColor = Color.FromArgb(12, 24, 48);
            groupBox1.ForeColor = Color.FromArgb(0, 200, 255);
            groupBox1.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            groupBox1.Text = "CCS LAB RESERVATION";

            // === READONLY LABEL TEXTBOXES ===
            foreach (Control c in groupBox1.Controls)
            {
                if (c is TextBox tb && tb.ReadOnly)
                {
                    tb.BackColor = Color.FromArgb(12, 24, 48);
                    tb.ForeColor = Color.FromArgb(0, 180, 220);
                    tb.BorderStyle = BorderStyle.None;
                    tb.Font = new Font("Segoe UI", 8f, FontStyle.Bold);
                }
            }

            // === INPUT TEXTBOXES ===
            StyleTextBox(dateTxt, readOnly: true);
            StyleTextBox(startTimeTxt);
            StyleTextBox(endTimeTxt);
            StyleTextBox(nameTxtBox);

            // === COMBOBOX ===
            labsRoom.BackColor = Color.FromArgb(10, 20, 42);
            labsRoom.ForeColor = Color.FromArgb(180, 220, 255);
            labsRoom.Font = new Font("Segoe UI", 10f);

            // === BUTTONS ===
            Color btnBg = Color.FromArgb(12, 24, 48);
            Color btnFg = Color.FromArgb(0, 200, 255);
            Color btnBorder = Color.FromArgb(0, 150, 200);

            foreach (Button btn in new[] { saveButton, updateButton, deleteButton })
            {
                btn.BackColor = btnBg;
                btn.ForeColor = btnFg;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = btnBorder;
                btn.FlatAppearance.BorderSize = 1;
                btn.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
            }

            showReservations.BackColor = Color.FromArgb(10, 40, 70);
            showReservations.ForeColor = Color.FromArgb(0, 200, 255);
            showReservations.FlatStyle = FlatStyle.Flat;
            showReservations.FlatAppearance.BorderColor = Color.FromArgb(0, 180, 220);
            showReservations.FlatAppearance.BorderSize = 1;
            showReservations.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            showReservations.Cursor = Cursors.Hand;

            // === DATA GRID ===
            dataGridView1.BackgroundColor = Color.FromArgb(10, 20, 42);
            dataGridView1.GridColor = Color.FromArgb(0, 60, 90);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(10, 20, 42);
            dataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(180, 220, 255);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 80, 120);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 200, 255);
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
            dataGridView1.DefaultCellStyle.Padding = new Padding(4, 6, 4, 6);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(8, 18, 38);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(0, 200, 255);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8f, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Padding = new Padding(4, 8, 4, 8);
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.ColumnHeadersHeight = 36;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(14, 26, 52);
            dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(180, 220, 255);
        }

        private void startTimeTxt_TextChanged(object sender, EventArgs e)
        {
            // Auto-set end time to 1 hour after start time
            if (DateTime.TryParse(startTimeTxt.Text, out DateTime parsed))
                endTimeTxt.Text = parsed.AddHours(1).ToString("hh:mm tt");
        }

        private bool ValidateTimes(out DateTime parsedStart, out DateTime parsedEnd)
        {
            parsedStart = DateTime.MinValue;
            parsedEnd = DateTime.MinValue;

            if (!DateTime.TryParse(startTimeTxt.Text, out parsedStart))
            {
                MessageBox.Show("Invalid Start Time. Use format like: 08:00 AM", "Time Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!DateTime.TryParse(endTimeTxt.Text, out parsedEnd))
            {
                MessageBox.Show("Invalid End Time. Use format like: 09:00 AM", "Time Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void nameTxtBox_TextChanged(object sender, EventArgs e) { }

        private void saveButton_Click_1(object sender, EventArgs e)
        {
            if (!ValidateTimes(out _, out _)) return;

            Reservation newReservation = new Reservation
            {
                LabRoom = labsRoom.Text,
                Date = DateTime.Today,
                StartTime = startTimeTxt.Text,
                EndTime = endTimeTxt.Text,
                Name = nameTxtBox.Text
            };

            ReservationController controller = new ReservationController();
            bool isSaved = controller.SaveReservation(newReservation);

            if (isSaved)
            {
                MessageBox.Show("Reservation saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (currentUpdatingName == "")
            {
                string searchName = ShowInputDialog("Enter the Name of the reservation you want to update:");
                if (string.IsNullOrWhiteSpace(searchName)) return;

                Reservation foundRes = reservationController.GetReservationForUpdate(searchName);

                if (foundRes != null)
                {
                    labsRoom.Text = foundRes.LabRoom;
                    dateTxt.Text = foundRes.Date.ToString("dddd, MMMM d, yyyy");
                    startTimeTxt.Text = foundRes.StartTime;
                    endTimeTxt.Text = foundRes.EndTime;
                    nameTxtBox.Text = foundRes.Name;

                    currentUpdatingName = foundRes.Name;
                    updateButton.Text = "SAVE CHANGES";
                    updateButton.BackColor = Color.FromArgb(0, 60, 40);
                    updateButton.ForeColor = Color.FromArgb(0, 255, 150);
                    updateButton.FlatAppearance.BorderColor = Color.FromArgb(0, 200, 100);
                }
                else
                {
                    MessageBox.Show("No reservation found for that name.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (!ValidateTimes(out _, out _)) return;

                Reservation updatedReservation = new Reservation
                {
                    LabRoom = labsRoom.Text,
                    Date = DateTime.Today,
                    StartTime = startTimeTxt.Text,
                    EndTime = endTimeTxt.Text,
                    Name = nameTxtBox.Text
                };

                bool isUpdated = reservationController.UpdateReservation(currentUpdatingName, updatedReservation);

                if (isUpdated)
                {
                    MessageBox.Show("Reservation updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    currentUpdatingName = "";
                    updateButton.Text = "UPDATE RESERVATION";
                    updateButton.BackColor = Color.FromArgb(12, 24, 48);
                    updateButton.ForeColor = Color.FromArgb(0, 200, 255);
                    updateButton.FlatAppearance.BorderColor = Color.FromArgb(0, 150, 200);
                    ClearFields();
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string searchName = ShowInputDialog("Enter the Name of the reservation you want to delete:");
            if (string.IsNullOrWhiteSpace(searchName)) return;

            Reservation foundRes = reservationController.GetReservationForUpdate(searchName);

            if (foundRes != null)
            {
                DialogResult dialogResult = MessageBox.Show(
                    $"Are you sure you want to permanently delete the reservation for {foundRes.Name} in {foundRes.LabRoom}?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    bool isDeleted = reservationController.DeleteReservation(searchName);
                    if (isDeleted)
                    {
                        MessageBox.Show("Reservation deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                    }
                }
            }
            else
            {
                MessageBox.Show("No reservation found for that name.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void labsRoom_SelectedIndexChanged_1(object sender, EventArgs e) { }
        private void nameTxtBox_TextChanged_1(object sender, EventArgs e) { }

        private void ClearFields()
        {
            labsRoom.SelectedIndex = -1;
            startTimeTxt.Text = "08:00 AM";
            endTimeTxt.Text = "09:00 AM";
            dateTxt.Text = DateTime.Today.ToString("dddd, MMMM d, yyyy");
            nameTxtBox.Clear();
        }

        private void showReservations_Click(object sender, EventArgs e)
        {
            System.Data.DataTable data = reservationController.GetAllReservations();
            dataGridView1.DataSource = data;

            if (dataGridView1.Columns.Contains("id"))
                dataGridView1.Columns["id"].Visible = false;
            if (dataGridView1.Columns.Contains("lab_room"))
                dataGridView1.Columns["lab_room"].HeaderText = "LAB ROOM";
            if (dataGridView1.Columns.Contains("reservation_date"))
                dataGridView1.Columns["reservation_date"].HeaderText = "DATE";
            if (dataGridView1.Columns.Contains("start_time"))
                dataGridView1.Columns["start_time"].HeaderText = "START";
            if (dataGridView1.Columns.Contains("end_time"))
                dataGridView1.Columns["end_time"].HeaderText = "END";
            if (dataGridView1.Columns.Contains("reserver_name"))
                dataGridView1.Columns["reserver_name"].HeaderText = "NAME";

            dataGridView1.RowHeadersVisible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}