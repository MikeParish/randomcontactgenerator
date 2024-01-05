
namespace RandomContactGenerator
{
    partial class RandomContactGeneratorControl
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
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.btnGenerateRandomContacts = new System.Windows.Forms.Button();
            this.numNameCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lvGeneratedContacts = new System.Windows.Forms.ListView();
            this.btnCreateContactsInDataverse = new System.Windows.Forms.Button();
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
            this.toolStripMenu.Size = new System.Drawing.Size(875, 29);
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
            // btnGenerateRandomContacts
            // 
            this.btnGenerateRandomContacts.Location = new System.Drawing.Point(44, 146);
            this.btnGenerateRandomContacts.Name = "btnGenerateRandomContacts";
            this.btnGenerateRandomContacts.Size = new System.Drawing.Size(242, 50);
            this.btnGenerateRandomContacts.TabIndex = 11;
            this.btnGenerateRandomContacts.Text = "Generate Contact(s)";
            this.btnGenerateRandomContacts.UseVisualStyleBackColor = true;
            this.btnGenerateRandomContacts.Click += new System.EventHandler(this.BtnGenerateRandomContacts_Click);
            // 
            // numNameCount
            // 
            this.numNameCount.Location = new System.Drawing.Point(44, 104);
            this.numNameCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNameCount.Name = "numNameCount";
            this.numNameCount.Size = new System.Drawing.Size(68, 26);
            this.numNameCount.TabIndex = 12;
            this.numNameCount.Value = new decimal(new int[] {
            1,
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
            this.label2.Location = new System.Drawing.Point(117, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "(max is 100)";
            // 
            // lvGeneratedContacts
            // 
            this.lvGeneratedContacts.HideSelection = false;
            this.lvGeneratedContacts.Location = new System.Drawing.Point(335, 68);
            this.lvGeneratedContacts.Name = "lvGeneratedContacts";
            this.lvGeneratedContacts.Size = new System.Drawing.Size(486, 255);
            this.lvGeneratedContacts.TabIndex = 16;
            this.lvGeneratedContacts.UseCompatibleStateImageBehavior = false;
            this.lvGeneratedContacts.View = System.Windows.Forms.View.Details;
            // 
            // btnCreateContactsInDataverse
            // 
            this.btnCreateContactsInDataverse.Location = new System.Drawing.Point(579, 346);
            this.btnCreateContactsInDataverse.Name = "btnCreateContactsInDataverse";
            this.btnCreateContactsInDataverse.Size = new System.Drawing.Size(242, 50);
            this.btnCreateContactsInDataverse.TabIndex = 17;
            this.btnCreateContactsInDataverse.Text = "Create Contact(s) in Dataverse";
            this.btnCreateContactsInDataverse.UseVisualStyleBackColor = true;
            this.btnCreateContactsInDataverse.Click += new System.EventHandler(this.BtnCreateContactsInDataverse_Click);
            // 
            // btnClearList
            // 
            this.btnClearList.Location = new System.Drawing.Point(579, 420);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(242, 50);
            this.btnClearList.TabIndex = 18;
            this.btnClearList.Text = "Clear List";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.BtnClearList_Click);
            // 
            // RandomContactGeneratorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClearList);
            this.Controls.Add(this.btnCreateContactsInDataverse);
            this.Controls.Add(this.lvGeneratedContacts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numNameCount);
            this.Controls.Add(this.btnGenerateRandomContacts);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RandomContactGeneratorControl";
            this.Size = new System.Drawing.Size(875, 512);
            this.Load += new System.EventHandler(this.RandomContactGeneratorControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNameCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.Button btnGenerateRandomContacts;
        private System.Windows.Forms.NumericUpDown numNameCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvGeneratedContacts;
        private System.Windows.Forms.Button btnCreateContactsInDataverse;
        private System.Windows.Forms.Button btnClearList;
    }
}
