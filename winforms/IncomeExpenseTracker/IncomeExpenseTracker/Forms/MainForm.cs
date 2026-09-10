using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using IncomeExpenseTracker.Models;

namespace IncomeExpenseTracker.Forms
{
    public class MainForm : Form
    {
        // ---------- Data ----------
        private List<Transaction> transactions = new List<Transaction>();
        private int nextId = 1;

        private static readonly string[] IncomeCategories = { "Salary", "Business", "Interest", "Gift", "Other" };
        private static readonly string[] ExpenseCategories = { "Food", "Travel", "Rent", "Shopping", "Other" };
        private static readonly string[] Months =
            { "January","February","March","April","May","June","July","August","September","October","November","December" };

        // ---------- Menu ----------
        private MenuStrip menuStrip;

        // ---------- Input group ----------
        private GroupBox grpInput;
        private Label lblDate;
        private DateTimePicker dtpDate;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblType;
        private RadioButton rbIncome;
        private RadioButton rbExpense;
        private Label lblCategory;
        private ComboBox cmbIncomeCategory;
        private ListBox lstExpenseCategory;
        private Label lblAmount;
        private NumericUpDown numAmount;
        private Label lblMonth;
        private DomainUpDown domainMonth;

        // ---------- List of records ----------
        private ListView lvTransactions;

        // ---------- Filter ----------
        private CheckBox chkFilterCategory;
        private ComboBox cmbFilterCategory;

        // ---------- Summary ----------
        private GroupBox grpSummary;
        private Label lblIncomeValue;
        private ProgressBar pbIncome;
        private Label lblExpenseValue;
        private ProgressBar pbExpense;
        private Label lblBalanceValue;
        private ProgressBar pbBalance;

        // ---------- Graph ----------
        private PictureBox picGraph;

        public MainForm()
        {
            BuildMenu();
            BuildInputGroup();
            BuildListView();
            BuildFilterControls();
            BuildSummaryGroup();
            BuildGraphControl();
            FinishFormSetup();

            RefreshListView();
            UpdateSummaryAndGraph();
        }

        // =========================================================
        // 1. MENU STRIP
        // =========================================================
        private void BuildMenu()
        {
            menuStrip = new MenuStrip();

            // ---- File ----
            var fileMenu = new ToolStripMenuItem("File");
            var miImport = new ToolStripMenuItem("Import Records", null, MiImport_Click);
            var miExport = new ToolStripMenuItem("Export Records", null, MiExport_Click);
            var miExit = new ToolStripMenuItem("Exit", null, (s, e) => this.Close());
            fileMenu.DropDownItems.Add(miImport);
            fileMenu.DropDownItems.Add(miExport);
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            fileMenu.DropDownItems.Add(miExit);

            // ---- Transaction (Add / Update / Delete happen directly, no extra window) ----
            var transactionMenu = new ToolStripMenuItem("Transaction");
            transactionMenu.DropDownItems.Add(new ToolStripMenuItem("Add", null, MiAdd_Click));
            transactionMenu.DropDownItems.Add(new ToolStripMenuItem("Update", null, MiUpdate_Click));
            transactionMenu.DropDownItems.Add(new ToolStripMenuItem("Delete", null, MiDelete_Click));

            // ---- View ----
            var viewMenu = new ToolStripMenuItem("View");
            viewMenu.DropDownItems.Add(new ToolStripMenuItem("Show All", null, (s, e) => RefreshListView()));
            viewMenu.DropDownItems.Add(new ToolStripMenuItem("Show Income", null, (s, e) => RefreshListView("Income")));
            viewMenu.DropDownItems.Add(new ToolStripMenuItem("Show Expense", null, (s, e) => RefreshListView("Expense")));
            viewMenu.DropDownItems.Add(new ToolStripSeparator());
            viewMenu.DropDownItems.Add(new ToolStripMenuItem("Summary", null, (s, e) => UpdateSummaryAndGraph()));
            viewMenu.DropDownItems.Add(new ToolStripMenuItem("Graph", null, (s, e) => UpdateSummaryAndGraph()));

            // ---- Settings ----
            var settingsMenu = new ToolStripMenuItem("Settings");
            settingsMenu.DropDownItems.Add(new ToolStripMenuItem("Change Font", null, MiChangeFont_Click));
            settingsMenu.DropDownItems.Add(new ToolStripMenuItem("Change Color", null, MiChangeColor_Click));

            menuStrip.Items.Add(fileMenu);
            menuStrip.Items.Add(transactionMenu);
            menuStrip.Items.Add(viewMenu);
            menuStrip.Items.Add(settingsMenu);
        }

        // =========================================================
        // 2. INPUT GROUP (GroupBox holding Date, Description, Type, Category, Amount, Month)
        // =========================================================
        private void BuildInputGroup()
        {
            grpInput = new GroupBox
            {
                Text = "Income / Expense Entry",
                Location = new Point(12, 30),
                Size = new Size(960, 140)
            };

            // Date
            lblDate = new Label { Text = "Date:", Location = new Point(10, 25), Size = new Size(70, 20) };
            dtpDate = new DateTimePicker
            {
                Location = new Point(85, 22),
                Size = new Size(150, 20),
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Today // defaults to today's date
            };

            // Description
            lblDescription = new Label { Text = "Description:", Location = new Point(260, 25), Size = new Size(80, 20) };
            txtDescription = new TextBox { Location = new Point(345, 22), Size = new Size(220, 20) };

            // Type (Income / Expense)
            lblType = new Label { Text = "Type:", Location = new Point(590, 25), Size = new Size(45, 20) };
            rbIncome = new RadioButton { Text = "Income", Location = new Point(640, 23), Size = new Size(70, 20), Checked = true };
            rbExpense = new RadioButton { Text = "Expense", Location = new Point(715, 23), Size = new Size(75, 20) };
            rbIncome.CheckedChanged += RbType_CheckedChanged;
            rbExpense.CheckedChanged += RbType_CheckedChanged;

            // Category (ComboBox for Income, ListBox for Expense - only one shown at a time)
            lblCategory = new Label { Text = "Category:", Location = new Point(10, 60), Size = new Size(70, 20) };
            cmbIncomeCategory = new ComboBox
            {
                Location = new Point(85, 57),
                Size = new Size(150, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbIncomeCategory.Items.AddRange(IncomeCategories);
            cmbIncomeCategory.SelectedIndex = 0;

            lstExpenseCategory = new ListBox
            {
                Location = new Point(85, 57),
                Size = new Size(150, 60),
                Visible = false
            };
            lstExpenseCategory.Items.AddRange(ExpenseCategories);
            lstExpenseCategory.SelectedIndex = 0;

            // Amount
            lblAmount = new Label { Text = "Amount:", Location = new Point(260, 60), Size = new Size(80, 20) };
            numAmount = new NumericUpDown
            {
                Location = new Point(345, 57),
                Size = new Size(120, 20),
                Minimum = 0,
                Maximum = 1000000,
                DecimalPlaces = 2,
                ThousandsSeparator = true
            };

            // Month (used to filter Summary / Graph, DomainUpDown per specification)
            lblMonth = new Label { Text = "Month:", Location = new Point(500, 60), Size = new Size(60, 20) };
            domainMonth = new DomainUpDown
            {
                Location = new Point(565, 57),
                Size = new Size(140, 20),
                ReadOnly = true
            };
            foreach (var m in Months) domainMonth.Items.Add(m);
            domainMonth.SelectedIndex = DateTime.Today.Month - 1;
            domainMonth.SelectedItemChanged += (s, e) => UpdateSummaryAndGraph();

            grpInput.Controls.Add(lblDate);
            grpInput.Controls.Add(dtpDate);
            grpInput.Controls.Add(lblDescription);
            grpInput.Controls.Add(txtDescription);
            grpInput.Controls.Add(lblType);
            grpInput.Controls.Add(rbIncome);
            grpInput.Controls.Add(rbExpense);
            grpInput.Controls.Add(lblCategory);
            grpInput.Controls.Add(cmbIncomeCategory);
            grpInput.Controls.Add(lstExpenseCategory);
            grpInput.Controls.Add(lblAmount);
            grpInput.Controls.Add(numAmount);
            grpInput.Controls.Add(lblMonth);
            grpInput.Controls.Add(domainMonth);
        }

        private void RbType_CheckedChanged(object sender, EventArgs e)
        {
            // Show ComboBox for Income category, ListBox for Expense category.
            cmbIncomeCategory.Visible = rbIncome.Checked;
            lstExpenseCategory.Visible = rbExpense.Checked;
        }

        // =========================================================
        // 3. LIST VIEW (transaction records)
        // =========================================================
        private void BuildListView()
        {
            lvTransactions = new ListView
            {
                Location = new Point(12, 180),
                Size = new Size(960, 200),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                MultiSelect = false
            };
            lvTransactions.Columns.Add("ID", 40);
            lvTransactions.Columns.Add("Date", 90);
            lvTransactions.Columns.Add("Description", 260);
            lvTransactions.Columns.Add("Type", 80);
            lvTransactions.Columns.Add("Category", 120);
            lvTransactions.Columns.Add("Amount", 110);

            // Selecting a row loads it into the input fields, ready for Update or Delete.
            lvTransactions.SelectedIndexChanged += LvTransactions_SelectedIndexChanged;
        }

        private void LvTransactions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTransactions.SelectedItems.Count == 0) return;

            int id = int.Parse(lvTransactions.SelectedItems[0].SubItems[0].Text);
            var t = transactions.FirstOrDefault(x => x.Id == id);
            if (t == null) return;

            dtpDate.Value = t.Date;
            txtDescription.Text = t.Description;

            if (t.Type == "Income")
            {
                rbIncome.Checked = true;
                cmbIncomeCategory.SelectedItem = t.Category;
            }
            else
            {
                rbExpense.Checked = true;
                lstExpenseCategory.SelectedItem = t.Category;
            }

            numAmount.Value = t.Amount;
        }

        // =========================================================
        // 4. FILTER (CheckBox + ComboBox)
        // =========================================================
        private void BuildFilterControls()
        {
            chkFilterCategory = new CheckBox
            {
                Text = "Filter by category:",
                Location = new Point(12, 388),
                Size = new Size(140, 20)
            };
            chkFilterCategory.CheckedChanged += (s, e) => RefreshListView();

            cmbFilterCategory = new ComboBox
            {
                Location = new Point(155, 386),
                Size = new Size(160, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbFilterCategory.Items.AddRange(IncomeCategories.Concat(ExpenseCategories).Distinct().ToArray());
            cmbFilterCategory.SelectedIndex = 0;
            cmbFilterCategory.SelectedIndexChanged += (s, e) => RefreshListView();
        }

        // =========================================================
        // 5. SUMMARY (ProgressBar, month-wise)
        // =========================================================
        private void BuildSummaryGroup()
        {
            grpSummary = new GroupBox
            {
                Text = "Summary (Month wise)",
                Location = new Point(12, 420),
                Size = new Size(470, 160)
            };

            lblIncomeValue = new Label { Text = "Income: 0", Location = new Point(10, 25), Size = new Size(430, 20) };
            pbIncome = new ProgressBar { Location = new Point(10, 45), Size = new Size(440, 18) };

            lblExpenseValue = new Label { Text = "Expense: 0", Location = new Point(10, 68), Size = new Size(430, 20) };
            pbExpense = new ProgressBar { Location = new Point(10, 88), Size = new Size(440, 18) };

            lblBalanceValue = new Label
            {
                Text = "Balance: 0",
                Location = new Point(10, 111),
                Size = new Size(430, 20),
                Font = new Font(this.Font, FontStyle.Bold)
            };
            pbBalance = new ProgressBar { Location = new Point(10, 131), Size = new Size(440, 18) };

            grpSummary.Controls.Add(lblIncomeValue);
            grpSummary.Controls.Add(pbIncome);
            grpSummary.Controls.Add(lblExpenseValue);
            grpSummary.Controls.Add(pbExpense);
            grpSummary.Controls.Add(lblBalanceValue);
            grpSummary.Controls.Add(pbBalance);
        }

        // =========================================================
        // 6. GRAPH (PictureBox, month-wise)
        // =========================================================
        private void BuildGraphControl()
        {
            picGraph = new PictureBox
            {
                Location = new Point(500, 420),
                Size = new Size(472, 160),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };
        }

        // =========================================================
        // 7. FORM SETUP
        // =========================================================
        private void FinishFormSetup()
        {
            this.Text = "Income & Expense Tracker";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(985, 600);
            this.MainMenuStrip = menuStrip;

            this.Controls.Add(grpInput);
            this.Controls.Add(lvTransactions);
            this.Controls.Add(chkFilterCategory);
            this.Controls.Add(cmbFilterCategory);
            this.Controls.Add(grpSummary);
            this.Controls.Add(picGraph);
            this.Controls.Add(menuStrip); // added last so the menu stays docked at the very top
        }

        // =========================================================
        // TRANSACTION MENU ACTIONS: Add / Update / Delete
        // =========================================================
        private void MiAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var t = new Transaction
            {
                Id = nextId++,
                Date = dtpDate.Value.Date,
                Description = txtDescription.Text.Trim(),
                Type = rbIncome.Checked ? "Income" : "Expense",
                Category = rbIncome.Checked ? (string)cmbIncomeCategory.SelectedItem : (string)lstExpenseCategory.SelectedItem,
                Amount = numAmount.Value
            };

            transactions.Add(t);
            RefreshListView();
            UpdateSummaryAndGraph();
            ClearInputFields();
        }

        private void MiUpdate_Click(object sender, EventArgs e)
        {
            if (lvTransactions.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a record in the list first.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ValidateInput()) return;

            int id = int.Parse(lvTransactions.SelectedItems[0].SubItems[0].Text);
            var t = transactions.FirstOrDefault(x => x.Id == id);
            if (t == null) return;

            t.Date = dtpDate.Value.Date;
            t.Description = txtDescription.Text.Trim();
            t.Type = rbIncome.Checked ? "Income" : "Expense";
            t.Category = rbIncome.Checked ? (string)cmbIncomeCategory.SelectedItem : (string)lstExpenseCategory.SelectedItem;
            t.Amount = numAmount.Value;

            RefreshListView();
            UpdateSummaryAndGraph();
            ClearInputFields();
        }

        private void MiDelete_Click(object sender, EventArgs e)
        {
            if (lvTransactions.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a record in the list first.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = int.Parse(lvTransactions.SelectedItems[0].SubItems[0].Text);
            var t = transactions.FirstOrDefault(x => x.Id == id);
            if (t == null) return;

            var confirm = MessageBox.Show($"Delete record #{t.Id}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            transactions.Remove(t);
            RefreshListView();
            UpdateSummaryAndGraph();
            ClearInputFields();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Description is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (numAmount.Value <= 0)
            {
                MessageBox.Show("Amount must be greater than zero.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (rbIncome.Checked && cmbIncomeCategory.SelectedItem == null)
            {
                MessageBox.Show("Select an income category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (rbExpense.Checked && lstExpenseCategory.SelectedItem == null)
            {
                MessageBox.Show("Select an expense category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearInputFields()
        {
            txtDescription.Clear();
            numAmount.Value = 0;
            dtpDate.Value = DateTime.Today;
            rbIncome.Checked = true;
        }

        // =========================================================
        // VIEW: Show All / Show Income / Show Expense (+ optional category filter)
        // =========================================================
        private void RefreshListView(string typeFilter = null)
        {
            lvTransactions.Items.Clear();

            IEnumerable<Transaction> data = transactions;

            if (typeFilter != null)
                data = data.Where(t => t.Type == typeFilter);

            if (chkFilterCategory.Checked && cmbFilterCategory.SelectedItem != null)
                data = data.Where(t => t.Category == (string)cmbFilterCategory.SelectedItem);

            foreach (var t in data.OrderBy(t => t.Id))
            {
                var item = new ListViewItem(t.Id.ToString());
                item.SubItems.Add(t.Date.ToShortDateString());
                item.SubItems.Add(t.Description);
                item.SubItems.Add(t.Type);
                item.SubItems.Add(t.Category);
                item.SubItems.Add(t.Amount.ToString("N2"));
                lvTransactions.Items.Add(item);
            }
        }

        // =========================================================
        // VIEW: Summary + Graph (month wise, based on DomainUpDown selection)
        // =========================================================
        private void UpdateSummaryAndGraph()
        {
            string selectedMonth = domainMonth.SelectedItem?.ToString() ?? Months[DateTime.Today.Month - 1];
            int monthIndex = Array.IndexOf(Months, selectedMonth) + 1;

            var monthData = transactions.Where(t => t.Date.Month == monthIndex);

            decimal income = monthData.Where(t => t.Type == "Income").Sum(t => t.Amount);
            decimal expense = monthData.Where(t => t.Type == "Expense").Sum(t => t.Amount);
            decimal balance = income - expense;

            lblIncomeValue.Text = $"Income ({selectedMonth}): {income:N2}";
            lblExpenseValue.Text = $"Expense ({selectedMonth}): {expense:N2}";
            lblBalanceValue.Text = $"Balance ({selectedMonth}): {balance:N2}";

            // Scale the progress bars against the larger of income/expense so both fit.
            decimal maxValue = Math.Max(income, expense);
            pbIncome.Maximum = maxValue > 0 ? (int)maxValue : 1;
            pbExpense.Maximum = maxValue > 0 ? (int)maxValue : 1;
            pbBalance.Maximum = maxValue > 0 ? (int)maxValue : 1;

            pbIncome.Value = Clamp((int)income, pbIncome.Maximum);
            pbExpense.Value = Clamp((int)expense, pbExpense.Maximum);
            pbBalance.Value = Clamp((int)Math.Abs(balance), pbBalance.Maximum);

            DrawGraph(income, expense, balance);
        }

        private int Clamp(int value, int max) => value < 0 ? 0 : (value > max ? max : value);

        private void DrawGraph(decimal income, decimal expense, decimal balance)
        {
            int width = picGraph.Width;
            int height = picGraph.Height;
            var bmp = new Bitmap(Math.Max(width, 1), Math.Max(height, 1));

            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                decimal maxValue = new[] { income, expense, Math.Abs(balance), 1m }.Max();
                int chartBottom = height - 30;
                int chartTop = 20;
                int chartHeight = chartBottom - chartTop;

                int barWidth = 70;
                int gap = 60;
                int startX = 40;

                DrawBar(g, startX, chartBottom, chartHeight, barWidth, income, maxValue, Color.SeaGreen, "Income");
                DrawBar(g, startX + (barWidth + gap), chartBottom, chartHeight, barWidth, expense, maxValue, Color.IndianRed, "Expense");
                DrawBar(g, startX + 2 * (barWidth + gap), chartBottom, chartHeight, barWidth, Math.Abs(balance), maxValue,
                        balance >= 0 ? Color.SteelBlue : Color.Orange, "Balance");
            }

            picGraph.Image?.Dispose();
            picGraph.Image = bmp;
        }

        private void DrawBar(Graphics g, int x, int baseline, int chartHeight, int barWidth,
                              decimal value, decimal maxValue, Color color, string label)
        {
            int barHeight = maxValue > 0 ? (int)(chartHeight * (double)(value / maxValue)) : 0;
            var rect = new Rectangle(x, baseline - barHeight, barWidth, barHeight);

            using (var brush = new SolidBrush(color))
                g.FillRectangle(brush, rect);
            g.DrawRectangle(Pens.Black, rect);

            g.DrawString(label, this.Font, Brushes.Black, x, baseline + 5);
            g.DrawString(value.ToString("N0"), this.Font, Brushes.Black, x, baseline - barHeight - 18);
        }

        // =========================================================
        // FILE: Import Records / Export Records
        // =========================================================
        private void MiImport_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog { Filter = "CSV files (*.csv)|*.csv" };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                var lines = File.ReadAllLines(dlg.FileName);
                // Skip the header row (line 0) if present.
                for (int i = 1; i < lines.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(lines[i])) continue;
                    var t = Transaction.FromCsvLine(lines[i]);
                    transactions.Add(t);
                    if (t.Id >= nextId) nextId = t.Id + 1;
                }

                RefreshListView();
                UpdateSummaryAndGraph();
                MessageBox.Show("Import completed.", "Import Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not import file: " + ex.Message, "Import Records", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MiExport_Click(object sender, EventArgs e)
        {
            using var dlg = new SaveFileDialog { Filter = "CSV files (*.csv)|*.csv", FileName = "transactions.csv" };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                using var writer = new StreamWriter(dlg.FileName);
                writer.WriteLine("Id,Date,Description,Type,Category,Amount");
                foreach (var t in transactions.OrderBy(t => t.Id))
                    writer.WriteLine(t.ToCsvLine());

                MessageBox.Show("Export completed.", "Export Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not export file: " + ex.Message, "Export Records", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SETTINGS: Change Font / Change Color
        // =========================================================
        private void MiChangeFont_Click(object sender, EventArgs e)
        {
            using var dlg = new FontDialog { Font = lvTransactions.Font };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                lvTransactions.Font = dlg.Font;
            }
        }

        private void MiChangeColor_Click(object sender, EventArgs e)
        {
            using var dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                lvTransactions.ForeColor = dlg.Color;
            }
        }
    }
}
