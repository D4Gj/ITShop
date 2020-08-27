using AcroPDFLib;
using AxAcroPDFLib;

namespace ITShopClientView
{
    partial class FormReportOrders
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportOrders));
            this.buttonSend = new System.Windows.Forms.Button();
            this.ReportDealMoneyViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pdfWindow = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDealMoneyViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdfWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(500, 46);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(168, 34);
            this.buttonSend.TabIndex = 0;
            this.buttonSend.Text = "Отправить";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // ReportDealMoneyViewModelBindingSource
            // 
            this.ReportDealMoneyViewModelBindingSource.DataSource = typeof(ITShopBusinessLogic.ViewModels.OrderViewModel);
            // 
            // pdfWindow
            // 
            this.pdfWindow.Location = new System.Drawing.Point(12, 58);
            this.pdfWindow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pdfWindow.Name = "pdfWindow";
            this.pdfWindow.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pdfWindow.OcxState")));
            this.pdfWindow.Size = new System.Drawing.Size(878, 439);
            this.pdfWindow.TabIndex = 2;
            // 
            // FormReportOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 783);
            this.Controls.Add(this.pdfWindow);
            this.Controls.Add(this.buttonSend);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormReportOrders";
            this.Text = "Отправка всех заказов";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportDealMoneyViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdfWindow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.BindingSource ReportDealMoneyViewModelBindingSource;
        private AxAcroPDF pdfWindow;
    }
}