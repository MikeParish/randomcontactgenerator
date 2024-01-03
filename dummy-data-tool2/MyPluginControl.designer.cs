
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
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSample = new System.Windows.Forms.ToolStripButton();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblStatusMessage = new System.Windows.Forms.Label();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.btnGenerateRandomNames = new System.Windows.Forms.Button();
            this.numNameCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.tsbClose,
            this.tssSeparator1,
            this.tsbSample});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(843, 34);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(129, 29);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // tsbSample
            // 
            this.tsbSample.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSample.Name = "tsbSample";
            this.tsbSample.Size = new System.Drawing.Size(68, 29);
            this.tsbSample.Text = "Try me";
            this.tsbSample.Click += new System.EventHandler(this.tsbSample_Click);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(63, 108);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(199, 26);
            this.txtFirstName.TabIndex = 5;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(299, 108);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(199, 26);
            this.txtLastName.TabIndex = 6;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(59, 82);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(86, 20);
            this.lblFirstName.TabIndex = 7;
            this.lblFirstName.Text = "First Name";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(295, 82);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(86, 20);
            this.lblLastName.TabIndex = 8;
            this.lblLastName.Text = "Last Name";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(669, 139);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(145, 50);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblStatusMessage
            // 
            this.lblStatusMessage.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.lblStatusMessage.Location = new System.Drawing.Point(135, 518);
            this.lblStatusMessage.Name = "lblStatusMessage";
            this.lblStatusMessage.Size = new System.Drawing.Size(447, 20);
            this.lblStatusMessage.TabIndex = 10;
            this.lblStatusMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerStatus
            // 
            this.timerStatus.Interval = 2500;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // btnGenerateRandomNames
            // 
            this.btnGenerateRandomNames.Location = new System.Drawing.Point(63, 309);
            this.btnGenerateRandomNames.Name = "btnGenerateRandomNames";
            this.btnGenerateRandomNames.Size = new System.Drawing.Size(145, 50);
            this.btnGenerateRandomNames.TabIndex = 11;
            this.btnGenerateRandomNames.Text = "Generate";
            this.btnGenerateRandomNames.UseVisualStyleBackColor = true;
            this.btnGenerateRandomNames.Click += new System.EventHandler(this.btnGenerateRandomNames_Click);
            // 
            // numNameCount
            // 
            this.numNameCount.Location = new System.Drawing.Point(63, 261);
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
            this.label1.Location = new System.Drawing.Point(59, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Random Contact Generator";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "(max is 25)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Manual Name Generator";
            // 
            // lvGeneratedNames
            // 
            this.lvGeneratedNames.HideSelection = false;
            this.lvGeneratedNames.Location = new System.Drawing.Point(328, 225);
            this.lvGeneratedNames.Name = "lvGeneratedNames";
            this.lvGeneratedNames.Size = new System.Drawing.Size(486, 255);
            this.lvGeneratedNames.TabIndex = 16;
            this.lvGeneratedNames.UseCompatibleStateImageBehavior = false;
            this.lvGeneratedNames.View = System.Windows.Forms.View.Details;
            // 
            // btnAddNamesToCRM
            // 
            this.btnAddNamesToCRM.Location = new System.Drawing.Point(586, 503);
            this.btnAddNamesToCRM.Name = "btnAddNamesToCRM";
            this.btnAddNamesToCRM.Size = new System.Drawing.Size(228, 50);
            this.btnAddNamesToCRM.TabIndex = 17;
            this.btnAddNamesToCRM.Text = "Add Contact(s) to Dataverse";
            this.btnAddNamesToCRM.UseVisualStyleBackColor = true;
            this.btnAddNamesToCRM.Click += new System.EventHandler(this.btnAddNamesToCrm_Click);
            // 
            // btnClearList
            // 
            this.btnClearList.Location = new System.Drawing.Point(586, 577);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(228, 50);
            this.btnClearList.TabIndex = 18;
            this.btnClearList.Text = "Clear List";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClearList);
            this.Controls.Add(this.btnAddNamesToCRM);
            this.Controls.Add(this.lvGeneratedNames);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numNameCount);
            this.Controls.Add(this.btnGenerateRandomNames);
            this.Controls.Add(this.lblStatusMessage);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(843, 662);
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
        private System.Windows.Forms.ToolStripButton tsbSample;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblStatusMessage;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.Button btnGenerateRandomNames;
        private System.Windows.Forms.NumericUpDown numNameCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvGeneratedNames;
        private System.Windows.Forms.Button btnAddNamesToCRM;
        private System.Windows.Forms.Button btnClearList;
    }
}
