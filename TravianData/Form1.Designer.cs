namespace TravianData
{
    partial class Form1
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
            this.lvLinks = new System.Windows.Forms.ListView();
            this.lbNatarianos = new System.Windows.Forms.Label();
            this.lbSalvos = new System.Windows.Forms.Label();
            this.lbPendentes = new System.Windows.Forms.Label();
            this.btnGerarLinks = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvLinks
            // 
            this.lvLinks.FullRowSelect = true;
            this.lvLinks.GridLines = true;
            this.lvLinks.LabelWrap = false;
            this.lvLinks.Location = new System.Drawing.Point(235, 12);
            this.lvLinks.MultiSelect = false;
            this.lvLinks.Name = "lvLinks";
            this.lvLinks.ShowGroups = false;
            this.lvLinks.Size = new System.Drawing.Size(762, 216);
            this.lvLinks.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvLinks.TabIndex = 0;
            this.lvLinks.UseCompatibleStateImageBehavior = false;
            this.lvLinks.View = System.Windows.Forms.View.List;
            this.lvLinks.ItemActivate += new System.EventHandler(this.lvLinks_ItemActivate);
            // 
            // lbNatarianos
            // 
            this.lbNatarianos.AutoSize = true;
            this.lbNatarianos.Location = new System.Drawing.Point(12, 12);
            this.lbNatarianos.Name = "lbNatarianos";
            this.lbNatarianos.Size = new System.Drawing.Size(58, 17);
            this.lbNatarianos.TabIndex = 1;
            this.lbNatarianos.Text = "Natares";
            // 
            // lbSalvos
            // 
            this.lbSalvos.AutoSize = true;
            this.lbSalvos.Location = new System.Drawing.Point(12, 59);
            this.lbSalvos.Name = "lbSalvos";
            this.lbSalvos.Size = new System.Drawing.Size(50, 17);
            this.lbSalvos.TabIndex = 2;
            this.lbSalvos.Text = "Salvos";
            // 
            // lbPendentes
            // 
            this.lbPendentes.AutoSize = true;
            this.lbPendentes.Location = new System.Drawing.Point(12, 112);
            this.lbPendentes.Name = "lbPendentes";
            this.lbPendentes.Size = new System.Drawing.Size(76, 17);
            this.lbPendentes.TabIndex = 3;
            this.lbPendentes.Text = "Pendentes";
            // 
            // btnGerarLinks
            // 
            this.btnGerarLinks.Location = new System.Drawing.Point(71, 145);
            this.btnGerarLinks.Name = "btnGerarLinks";
            this.btnGerarLinks.Size = new System.Drawing.Size(105, 33);
            this.btnGerarLinks.TabIndex = 4;
            this.btnGerarLinks.Text = "Gerar Links";
            this.btnGerarLinks.UseVisualStyleBackColor = true;
            this.btnGerarLinks.Click += new System.EventHandler(this.btnGerarLinks_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1009, 235);
            this.Controls.Add(this.btnGerarLinks);
            this.Controls.Add(this.lbPendentes);
            this.Controls.Add(this.lbSalvos);
            this.Controls.Add(this.lbNatarianos);
            this.Controls.Add(this.lvLinks);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvLinks;
        private System.Windows.Forms.Label lbNatarianos;
        private System.Windows.Forms.Label lbSalvos;
        private System.Windows.Forms.Label lbPendentes;
        private System.Windows.Forms.Button btnGerarLinks;
    }
}

