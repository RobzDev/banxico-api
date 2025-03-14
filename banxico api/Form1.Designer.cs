namespace banxico_api
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dtviewData = new DataGridView();
            YearColumn = new DataGridViewTextBoxColumn();
            DolarValueColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dtviewData).BeginInit();
            SuspendLayout();
            // 
            // dtviewData
            // 
            dtviewData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtviewData.Columns.AddRange(new DataGridViewColumn[] { YearColumn, DolarValueColumn });
            dtviewData.Location = new Point(78, 73);
            dtviewData.Name = "dtviewData";
            dtviewData.Size = new Size(238, 342);
            dtviewData.TabIndex = 3;
            // 
            // YearColumn
            // 
            YearColumn.HeaderText = "Year";
            YearColumn.Name = "YearColumn";
            // 
            // DolarValueColumn
            // 
            DolarValueColumn.HeaderText = "Dolar price in Peso(MXN)";
            DolarValueColumn.Name = "DolarValueColumn";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dtviewData);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dtviewData).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dtviewData;
        private DataGridViewTextBoxColumn YearColumn;
        private DataGridViewTextBoxColumn DolarValueColumn;
    }
}
