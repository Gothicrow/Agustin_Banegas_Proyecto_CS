namespace SistemaGestionUI
{
    partial class Grilla
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
            button1 = new Button();
            label1 = new Label();
            dgvGrilla = new DataGridView();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(694, 409);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Volver";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F);
            label1.Location = new Point(52, 31);
            label1.Name = "label1";
            label1.Size = new Size(130, 54);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // dgvGrilla
            // 
            dgvGrilla.AllowUserToAddRows = false;
            dgvGrilla.AllowUserToDeleteRows = false;
            dgvGrilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrilla.Location = new Point(52, 99);
            dgvGrilla.Name = "dgvGrilla";
            dgvGrilla.ReadOnly = true;
            dgvGrilla.RowHeadersWidth = 51;
            dgvGrilla.Size = new Size(693, 298);
            dgvGrilla.TabIndex = 3;
            dgvGrilla.CellClick += dgvGrilla_CellClick;
            // 
            // button2
            // 
            button2.Location = new Point(594, 409);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 4;
            button2.Text = "Crear";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Grilla
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(dgvGrilla);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Grilla";
            Text = "Grilla";
            ((System.ComponentModel.ISupportInitialize)dgvGrilla).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private DataGridView dgvGrilla;
        private Button button2;
    }
}