namespace ITShopWindowsApp.Request
{
    partial class FormRequests
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonGetInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(426, 426);
            this.dataGridView.TabIndex = 14;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(444, 12);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(132, 31);
            this.buttonAdd.TabIndex = 10;
            this.buttonAdd.Text = "Новый запрос";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonGetInfo
            // 
            this.buttonGetInfo.Location = new System.Drawing.Point(444, 49);
            this.buttonGetInfo.Name = "buttonGetInfo";
            this.buttonGetInfo.Size = new System.Drawing.Size(132, 31);
            this.buttonGetInfo.TabIndex = 15;
            this.buttonGetInfo.Text = "Подробне о запросе";
            this.buttonGetInfo.UseVisualStyleBackColor = true;
            this.buttonGetInfo.Click += new System.EventHandler(this.buttonGetInfo_Click);
            // 
            // FormRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 450);
            this.Controls.Add(this.buttonGetInfo);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonAdd);
            this.Name = "FormRequests";
            this.Text = "Запросы";
            this.Load += new System.EventHandler(this.FormRequests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonGetInfo;
    }
}