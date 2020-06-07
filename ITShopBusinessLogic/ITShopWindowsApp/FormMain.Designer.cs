namespace ITShopWindowsApp
{
    partial class FormMain
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
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.справочникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.КомпонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запросыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.движениеКомпонентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonUpd = new System.Windows.Forms.Button();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.buttonFinalOrder = new System.Windows.Forms.Button();
            this.запросВФорматеWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запросВФорматеExelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(595, 27);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(157, 21);
            this.buttonCreateOrder.TabIndex = 10;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 27);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(577, 411);
            this.dataGridView.TabIndex = 9;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникToolStripMenuItem,
            this.отчетыToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(765, 24);
            this.menuStrip2.TabIndex = 8;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // справочникToolStripMenuItem
            // 
            this.справочникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.КомпонентыToolStripMenuItem,
            this.изделияToolStripMenuItem,
            this.клиентыToolStripMenuItem,
            this.запросыToolStripMenuItem});
            this.справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
            this.справочникToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.справочникToolStripMenuItem.Text = "Справочник";
            // 
            // КомпонентыToolStripMenuItem
            // 
            this.КомпонентыToolStripMenuItem.Name = "КомпонентыToolStripMenuItem";
            this.КомпонентыToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.КомпонентыToolStripMenuItem.Text = "Компоненты";
            this.КомпонентыToolStripMenuItem.Click += new System.EventHandler(this.КомпонентыToolStripMenuItem_Click);
            // 
            // изделияToolStripMenuItem
            // 
            this.изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
            this.изделияToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.изделияToolStripMenuItem.Text = "Изделия";
            this.изделияToolStripMenuItem.Click += new System.EventHandler(this.изделияToolStripMenuItem_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // запросыToolStripMenuItem
            // 
            this.запросыToolStripMenuItem.Name = "запросыToolStripMenuItem";
            this.запросыToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.запросыToolStripMenuItem.Text = "Запросы";
            this.запросыToolStripMenuItem.Click += new System.EventHandler(this.запросыToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.движениеКомпонентовToolStripMenuItem,
            this.запросВФорматеWordToolStripMenuItem,
            this.запросВФорматеExelToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // движениеКомпонентовToolStripMenuItem
            // 
            this.движениеКомпонентовToolStripMenuItem.Name = "движениеКомпонентовToolStripMenuItem";
            this.движениеКомпонентовToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.движениеКомпонентовToolStripMenuItem.Text = "Движение компонентов";
            this.движениеКомпонентовToolStripMenuItem.Click += new System.EventHandler(this.движениеКомпонентовToolStripMenuItem_Click);
            // 
            // buttonUpd
            // 
            this.buttonUpd.Location = new System.Drawing.Point(595, 83);
            this.buttonUpd.Name = "buttonUpd";
            this.buttonUpd.Size = new System.Drawing.Size(157, 23);
            this.buttonUpd.TabIndex = 11;
            this.buttonUpd.Text = "Обновить";
            this.buttonUpd.UseVisualStyleBackColor = true;
            this.buttonUpd.Click += new System.EventHandler(this.buttonUpd_Click);
            // 
            // buttonInfo
            // 
            this.buttonInfo.Location = new System.Drawing.Point(595, 54);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(157, 23);
            this.buttonInfo.TabIndex = 12;
            this.buttonInfo.Text = "Подробней о заказе.";
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // buttonFinalOrder
            // 
            this.buttonFinalOrder.Location = new System.Drawing.Point(595, 112);
            this.buttonFinalOrder.Name = "buttonFinalOrder";
            this.buttonFinalOrder.Size = new System.Drawing.Size(157, 21);
            this.buttonFinalOrder.TabIndex = 13;
            this.buttonFinalOrder.Text = "Заказ оплачен";
            this.buttonFinalOrder.UseVisualStyleBackColor = true;
            this.buttonFinalOrder.Click += new System.EventHandler(this.buttonFinalOrder_Click);
            // 
            // запросВФорматеWordToolStripMenuItem
            // 
            this.запросВФорматеWordToolStripMenuItem.Name = "запросВФорматеWordToolStripMenuItem";
            this.запросВФорматеWordToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.запросВФорматеWordToolStripMenuItem.Text = "Запрос в формате word";
            this.запросВФорматеWordToolStripMenuItem.Click += new System.EventHandler(this.запросВФорматеWordToolStripMenuItem_Click);
            // 
            // запросВФорматеExelToolStripMenuItem
            // 
            this.запросВФорматеExelToolStripMenuItem.Name = "запросВФорматеExelToolStripMenuItem";
            this.запросВФорматеExelToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.запросВФорматеExelToolStripMenuItem.Text = "Запрос в формате exel";
            this.запросВФорматеExelToolStripMenuItem.Click += new System.EventHandler(this.запросВФорматеExelToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 447);
            this.Controls.Add(this.buttonFinalOrder);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.buttonUpd);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip2);
            this.Name = "FormMain";
            this.Text = "Главное меню";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem справочникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem КомпонентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изделияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.Button buttonUpd;
        private System.Windows.Forms.ToolStripMenuItem запросыToolStripMenuItem;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.Button buttonFinalOrder;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem движениеКомпонентовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запросВФорматеWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запросВФорматеExelToolStripMenuItem;
    }
}