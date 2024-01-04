
namespace dummy_data_tool2
{
    partial class MyPluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.lblStatusMessage = new System.Windows.Forms.Label();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.btnGenerateRandomNames = new System.Windows.Forms.Button();
            this.numNameCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lvGeneratedNames = new System.Windows.Forms.ListView();
            this.btnAddNamesToCRM = new System.Windows.Forms.Button();
            this.btnClearList = new System.Windows.Forms.Button();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNameCount)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(844, 29);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(112, 24);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.TsbClose_Click);
            // 
            // lblStatusMessage
            // 
            this.lblStatusMessage.ForeColor = System.Drawing.Color.Lime;
            this.lblStatusMessage.Location = new System.Drawing.Point(199, 361);
            this.lblStatusMessage.Name = "lblStatusMessage";
            this.lblStatusMessage.Size = new System.Drawing.Size(351, 20);
            this.lblStatusMessage.TabIndex = 10;
            this.lblStatusMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerStatus
            // 
            this.timerStatus.Interval = 7500;
            this.timerStatus.Tick += new System.EventHandler(this.TimerStatus_Tick);
            // 
            // btnGenerateRandomNames
            // 
            this.btnGenerateRandomNames.Location = new System.Drawing.Point(44, 152);
            this.btnGenerateRandomNames.Name = "btnGenerateRandomNames";
            this.btnGenerateRandomNames.Size = new System.Drawing.Size(145, 50);
            this.btnGenerateRandomNames.TabIndex = 11;
            this.btnGenerateRandomNames.Text = "Generate";
            this.btnGenerateRandomNames.UseVisualStyleBackColor = true;
            this.btnGenerateRandomNames.Click += new System.EventHandler(this.BtnGenerateRandomNames_Click);
            // 
            // numNameCount
            // 
            this.numNameCount.Location = new System.Drawing.Point(44, 104);
            this.numNameCount.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numNameCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNameCount.Name = "numNameCount";
            this.numNameCount.Size = new System.Drawing.Size(62, 26);
            this.numNameCount.TabIndex = 12;
            this.numNameCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Random Contact Generator";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "(max is 25)";
            // 
            // lvGeneratedNames
            // 
            this.lvGeneratedNames.HideSelection = false;
            this.lvGeneratedNames.Location = new System.Drawing.Point(309, 68);
            this.lvGeneratedNames.Name = "lvGeneratedNames";
            this.lvGeneratedNames.Size = new System.Drawing.Size(486, 255);
            this.lvGeneratedNames.TabIndex = 16;
            this.lvGeneratedNames.UseCompatibleStateImageBehavior = false;
            this.lvGeneratedNames.View = System.Windows.Forms.View.Details;
            // 
            // btnAddNamesToCRM
            // 
            this.btnAddNamesToCRM.Location = new System.Drawing.Point(553, 346);
            this.btnAddNamesToCRM.Name = "btnAddNamesToCRM";
            this.btnAddNamesToCRM.Size = new System.Drawing.Size(242, 50);
            this.btnAddNamesToCRM.TabIndex = 17;
            this.btnAddNamesToCRM.Text = "Create Contact(s) in Dataverse";
            this.btnAddNamesToCRM.UseVisualStyleBackColor = true;
            this.btnAddNamesToCRM.Click += new System.EventHandler(this.BtnAddNamesToCrm_Click);
            // 
            // btnClearList
            // 
            this.btnClearList.Location = new System.Drawing.Point(553, 420);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(242, 50);
            this.btnClearList.TabIndex = 18;
            this.btnClearList.Text = "Clear List";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.BtnClearList_Click);
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClearList);
            this.Controls.Add(this.btnAddNamesToCRM);
            this.Controls.Add(this.lvGeneratedNames);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numNameCount);
            this.Controls.Add(this.btnGenerateRandomNames);
            this.Controls.Add(this.lblStatusMessage);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(844, 525);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNameCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.Label lblStatusMessage;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.Button btnGenerateRandomNames;
        private System.Windows.Forms.NumericUpDown numNameCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvGeneratedNames;
        private System.Windows.Forms.Button btnAddNamesToCRM;
        private System.Windows.Forms.Button btnClearList;
    }
}
