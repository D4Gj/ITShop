namespace ITShopWindowsApp.Orders
{
    partial class FormCreateOrder
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
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.comboBoxProduct = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSumm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(70, 3);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(101, 21);
            this.comboBoxClient.TabIndex = 0;
            // 
            // comboBoxProduct
            // 
            this.comboBoxProduct.FormattingEnabled = true;
            this.comboBoxProduct.Location = new System.Drawing.Point(70, 30);
            this.comboBoxProduct.Name = "comboBoxProduct";
            this.comboBoxProduct.Size = new System.Drawing.Size(101, 21);
            this.comboBoxProduct.TabIndex = 1;
            this.comboBoxProduct.SelectedIndexChanged += new System.EventHandler(this.comboBoxProduct_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Клиент";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Продукт";
            // 
            // textBoxSumm
            // 
            this.textBoxSumm.Location = new System.Drawing.Point(98, 83);
            this.textBoxSumm.Name = "textBoxSumm";
            this.textBoxSumm.Size = new System.Drawing.Size(73, 20);
            this.textBoxSumm.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Стоимость";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(98, 57);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(73, 20);
            this.textBoxCount.TabIndex = 6;
            this.textBoxCount.TextChanged += new System.EventHandler(this.textBoxCount_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Количество";
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(4, 112);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(167, 23);
            this.buttonCreateOrder.TabIndex = 8;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(4, 141);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(167, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormCreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(173, 167);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSumm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxProduct);
            this.Controls.Add(this.comboBoxClient);
            this.Name = "FormCreateOrder";
            this.Text = "FormCreateOrder";
            this.Load += new System.EventHandler(this.FormCreateOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxClient;
        private System.Windows.Forms.ComboBox comboBoxProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSumm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonCancel;
    }
}