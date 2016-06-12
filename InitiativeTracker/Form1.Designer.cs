namespace Table
{
    partial class Action
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
            this.Roll = new System.Windows.Forms.Button();
            this.NextTurn = new System.Windows.Forms.Button();
            this.CSV = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Roll
            // 
            this.Roll.Enabled = false;
            this.Roll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Roll.Location = new System.Drawing.Point(8, 12);
            this.Roll.Name = "Roll";
            this.Roll.Size = new System.Drawing.Size(244, 94);
            this.Roll.TabIndex = 0;
            this.Roll.Text = "Roll For Initiative";
            this.Roll.UseVisualStyleBackColor = true;
            this.Roll.Click += new System.EventHandler(this.Roll_Click);
            // 
            // NextTurn
            // 
            this.NextTurn.Enabled = false;
            this.NextTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextTurn.Location = new System.Drawing.Point(8, 112);
            this.NextTurn.Name = "NextTurn";
            this.NextTurn.Size = new System.Drawing.Size(244, 84);
            this.NextTurn.TabIndex = 1;
            this.NextTurn.Text = "Next Turn";
            this.NextTurn.UseVisualStyleBackColor = true;
            this.NextTurn.Click += new System.EventHandler(this.NextTurn_Click);
            // 
            // CSV
            // 
            this.CSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CSV.Location = new System.Drawing.Point(8, 202);
            this.CSV.Name = "CSV";
            this.CSV.Size = new System.Drawing.Size(244, 87);
            this.CSV.TabIndex = 2;
            this.CSV.Text = "Import CSV";
            this.CSV.UseVisualStyleBackColor = true;
            this.CSV.Click += new System.EventHandler(this.CSV_Click);
            // 
            // Action
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(267, 301);
            this.Controls.Add(this.CSV);
            this.Controls.Add(this.NextTurn);
            this.Controls.Add(this.Roll);
            this.Name = "Action";
            this.Text = "Action";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Roll;
        private System.Windows.Forms.Button NextTurn;
        private System.Windows.Forms.Button CSV;
    }
}

