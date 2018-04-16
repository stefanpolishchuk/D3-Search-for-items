namespace D3_Search_for_items
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPage = new System.Windows.Forms.TabControl();
            this.activeSkills = new System.Windows.Forms.TabPage();
            this.labelLoadingImages = new System.Windows.Forms.Label();
            this.passiveSkills = new System.Windows.Forms.TabPage();
            this.labelSkillName = new System.Windows.Forms.Label();
            this.labelSkillDescription = new System.Windows.Forms.Label();
            this.metkaCharacter = new System.Windows.Forms.Label();
            this.metkaActiveSkill = new System.Windows.Forms.Label();
            this.metkaPassiveSkill = new System.Windows.Forms.Label();
            this.tabPage.SuspendLayout();
            this.activeSkills.SuspendLayout();
            this.passiveSkills.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.activeSkills);
            this.tabPage.Controls.Add(this.passiveSkills);
            this.tabPage.Location = new System.Drawing.Point(2, 82);
            this.tabPage.Name = "tabPage";
            this.tabPage.SelectedIndex = 0;
            this.tabPage.Size = new System.Drawing.Size(509, 316);
            this.tabPage.TabIndex = 8;
            // 
            // activeSkills
            // 
            this.activeSkills.Controls.Add(this.metkaActiveSkill);
            this.activeSkills.Controls.Add(this.labelLoadingImages);
            this.activeSkills.Location = new System.Drawing.Point(4, 22);
            this.activeSkills.Name = "activeSkills";
            this.activeSkills.Padding = new System.Windows.Forms.Padding(3);
            this.activeSkills.Size = new System.Drawing.Size(501, 290);
            this.activeSkills.TabIndex = 0;
            this.activeSkills.Text = "Активные скилы";
            this.activeSkills.UseVisualStyleBackColor = true;
            // 
            // labelLoadingImages
            // 
            this.labelLoadingImages.AutoSize = true;
            this.labelLoadingImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLoadingImages.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelLoadingImages.Location = new System.Drawing.Point(138, 130);
            this.labelLoadingImages.Name = "labelLoadingImages";
            this.labelLoadingImages.Size = new System.Drawing.Size(218, 22);
            this.labelLoadingImages.TabIndex = 11;
            this.labelLoadingImages.Text = "Загрузка изображений...";
            // 
            // passiveSkills
            // 
            this.passiveSkills.Controls.Add(this.metkaPassiveSkill);
            this.passiveSkills.Location = new System.Drawing.Point(4, 22);
            this.passiveSkills.Name = "passiveSkills";
            this.passiveSkills.Padding = new System.Windows.Forms.Padding(3);
            this.passiveSkills.Size = new System.Drawing.Size(501, 285);
            this.passiveSkills.TabIndex = 1;
            this.passiveSkills.Text = "Пассивные скилы";
            this.passiveSkills.UseVisualStyleBackColor = true;
            // 
            // labelSkillName
            // 
            this.labelSkillName.AutoSize = true;
            this.labelSkillName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSkillName.Location = new System.Drawing.Point(513, 9);
            this.labelSkillName.Name = "labelSkillName";
            this.labelSkillName.Size = new System.Drawing.Size(0, 20);
            this.labelSkillName.TabIndex = 9;
            // 
            // labelSkillDescription
            // 
            this.labelSkillDescription.AutoSize = true;
            this.labelSkillDescription.Location = new System.Drawing.Point(517, 44);
            this.labelSkillDescription.MaximumSize = new System.Drawing.Size(350, 0);
            this.labelSkillDescription.Name = "labelSkillDescription";
            this.labelSkillDescription.Size = new System.Drawing.Size(0, 13);
            this.labelSkillDescription.TabIndex = 10;
            // 
            // metkaCharacter
            // 
            this.metkaCharacter.BackColor = System.Drawing.SystemColors.Highlight;
            this.metkaCharacter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metkaCharacter.Location = new System.Drawing.Point(688, 372);
            this.metkaCharacter.Name = "metkaCharacter";
            this.metkaCharacter.Size = new System.Drawing.Size(64, 5);
            this.metkaCharacter.TabIndex = 11;
            this.metkaCharacter.Visible = false;
            // 
            // metkaActiveSkill
            // 
            this.metkaActiveSkill.BackColor = System.Drawing.Color.Lime;
            this.metkaActiveSkill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metkaActiveSkill.Location = new System.Drawing.Point(418, 259);
            this.metkaActiveSkill.Name = "metkaActiveSkill";
            this.metkaActiveSkill.Size = new System.Drawing.Size(64, 5);
            this.metkaActiveSkill.TabIndex = 14;
            this.metkaActiveSkill.Visible = false;
            // 
            // metkaPassiveSkill
            // 
            this.metkaPassiveSkill.BackColor = System.Drawing.Color.Lime;
            this.metkaPassiveSkill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metkaPassiveSkill.Location = new System.Drawing.Point(408, 254);
            this.metkaPassiveSkill.Name = "metkaPassiveSkill";
            this.metkaPassiveSkill.Size = new System.Drawing.Size(64, 5);
            this.metkaPassiveSkill.TabIndex = 15;
            this.metkaPassiveSkill.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 400);
            this.Controls.Add(this.metkaCharacter);
            this.Controls.Add(this.labelSkillDescription);
            this.Controls.Add(this.labelSkillName);
            this.Controls.Add(this.tabPage);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tabPage.ResumeLayout(false);
            this.activeSkills.ResumeLayout(false);
            this.activeSkills.PerformLayout();
            this.passiveSkills.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label labelSkillName;
        public System.Windows.Forms.TabPage activeSkills;
        public System.Windows.Forms.TabPage passiveSkills;
        public System.Windows.Forms.TabControl tabPage;
        private System.Windows.Forms.Label labelLoadingImages;
        private System.Windows.Forms.Label labelSkillDescription;
        private System.Windows.Forms.Label metkaCharacter;
        private System.Windows.Forms.Label metkaActiveSkill;
        private System.Windows.Forms.Label metkaPassiveSkill;
    }
}

