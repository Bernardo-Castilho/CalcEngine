namespace CalcEngineDemo
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this._formulaBar = new System.Windows.Forms.Panel();
            this._txtFormula = new System.Windows.Forms.TextBox();
            this._lblFunctions = new System.Windows.Forms.Label();
            this._lblAddress = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this._lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this._grid = new CalcEngineDemo.DataGridCalc();
            this._formulaBar.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // _formulaBar
            // 
            this._formulaBar.Controls.Add(this._txtFormula);
            this._formulaBar.Controls.Add(this._lblFunctions);
            this._formulaBar.Controls.Add(this._lblAddress);
            this._formulaBar.Dock = System.Windows.Forms.DockStyle.Top;
            this._formulaBar.Location = new System.Drawing.Point(0, 0);
            this._formulaBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._formulaBar.Name = "_formulaBar";
            this._formulaBar.Size = new System.Drawing.Size(693, 27);
            this._formulaBar.TabIndex = 1;
            // 
            // _txtFormula
            // 
            this._txtFormula.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtFormula.Location = new System.Drawing.Point(166, 0);
            this._txtFormula.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._txtFormula.Name = "_txtFormula";
            this._txtFormula.Size = new System.Drawing.Size(527, 31);
            this._txtFormula.TabIndex = 5;
            // 
            // _lblFunctions
            // 
            this._lblFunctions.Dock = System.Windows.Forms.DockStyle.Left;
            this._lblFunctions.Font = new System.Drawing.Font("Times New Roman", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblFunctions.Location = new System.Drawing.Point(117, 0);
            this._lblFunctions.Name = "_lblFunctions";
            this._lblFunctions.Size = new System.Drawing.Size(49, 27);
            this._lblFunctions.TabIndex = 4;
            this._lblFunctions.Text = "fx";
            this._lblFunctions.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _lblAddress
            // 
            this._lblAddress.BackColor = System.Drawing.SystemColors.Window;
            this._lblAddress.Dock = System.Windows.Forms.DockStyle.Left;
            this._lblAddress.Location = new System.Drawing.Point(0, 0);
            this._lblAddress.Name = "_lblAddress";
            this._lblAddress.Size = new System.Drawing.Size(117, 27);
            this._lblAddress.TabIndex = 3;
            this._lblAddress.Text = "A1";
            this._lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this._lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 357);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(693, 23);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(627, 18);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // _lblStatus
            // 
            this._lblStatus.Name = "_lblStatus";
            this._lblStatus.Size = new System.Drawing.Size(49, 18);
            this._lblStatus.Text = "Ready";
            // 
            // _grid
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.DataContext = null;
            this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._grid.Location = new System.Drawing.Point(0, 27);
            this._grid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._grid.Name = "_grid";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._grid.RowHeadersWidth = 50;
            this._grid.Size = new System.Drawing.Size(693, 330);
            this._grid.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 380);
            this.Controls.Add(this._grid);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._formulaBar);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataGridView + Calculation Engine";
            this._formulaBar.ResumeLayout(false);
            this._formulaBar.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridCalc _grid;
        private System.Windows.Forms.Panel _formulaBar;
        private System.Windows.Forms.TextBox _txtFormula;
        private System.Windows.Forms.Label _lblFunctions;
        private System.Windows.Forms.Label _lblAddress;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel _lblStatus;

    }
}

