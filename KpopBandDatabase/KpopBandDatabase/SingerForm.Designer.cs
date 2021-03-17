namespace KpopBandDatabase
{
    partial class SingerForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDisplayBandSingers = new System.Windows.Forms.Button();
            this.btnRemoveFavSinger = new System.Windows.Forms.Button();
            this.btnSearchBand = new System.Windows.Forms.Button();
            this.txtSearchSinger = new System.Windows.Forms.TextBox();
            this.btnSortByGender = new System.Windows.Forms.Button();
            this.btnSortByDate = new System.Windows.Forms.Button();
            this.btnSortByAlpha = new System.Windows.Forms.Button();
            this.btnNextFavSinger = new System.Windows.Forms.Button();
            this.btnPreviousFavSinger = new System.Windows.Forms.Button();
            this.btnNextSinger = new System.Windows.Forms.Button();
            this.btnPreviousSinger = new System.Windows.Forms.Button();
            this.lblDisplayFavSinger = new System.Windows.Forms.Label();
            this.lblDisplaySinger = new System.Windows.Forms.Label();
            this.btnAddFavSinger = new System.Windows.Forms.Button();
            this.btnEditSinger = new System.Windows.Forms.Button();
            this.btnRemoveBand = new System.Windows.Forms.Button();
            this.btnAddBand = new System.Windows.Forms.Button();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblBandNumOfMem = new System.Windows.Forms.Label();
            this.lblBandGender = new System.Windows.Forms.Label();
            this.lblBandDebutDate = new System.Windows.Forms.Label();
            this.lblBandName = new System.Windows.Forms.Label();
            this.txtBandCompany = new System.Windows.Forms.TextBox();
            this.txtBandNumOfMem = new System.Windows.Forms.TextBox();
            this.txtBandGender = new System.Windows.Forms.TextBox();
            this.txtBandDebutDate = new System.Windows.Forms.TextBox();
            this.txtBandName = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(473, 618);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(473, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "label1";
            // 
            // btnDisplayBandSingers
            // 
            this.btnDisplayBandSingers.Location = new System.Drawing.Point(965, 259);
            this.btnDisplayBandSingers.Margin = new System.Windows.Forms.Padding(2);
            this.btnDisplayBandSingers.Name = "btnDisplayBandSingers";
            this.btnDisplayBandSingers.Size = new System.Drawing.Size(105, 49);
            this.btnDisplayBandSingers.TabIndex = 56;
            this.btnDisplayBandSingers.Text = "Display Band\'s Singers";
            this.btnDisplayBandSingers.UseVisualStyleBackColor = true;
            // 
            // btnRemoveFavBand
            // 
            this.btnRemoveFavBand.Location = new System.Drawing.Point(961, 409);
            this.btnRemoveFavBand.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveFavBand.Name = "btnRemoveFavBand";
            this.btnRemoveFavBand.Size = new System.Drawing.Size(108, 51);
            this.btnRemoveFavBand.TabIndex = 55;
            this.btnRemoveFavBand.Text = "Remove Band From Favourite";
            this.btnRemoveFavBand.UseVisualStyleBackColor = true;
            // 
            // btnSearchBand
            // 
            this.btnSearchBand.Location = new System.Drawing.Point(298, 478);
            this.btnSearchBand.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearchBand.Name = "btnSearchBand";
            this.btnSearchBand.Size = new System.Drawing.Size(105, 31);
            this.btnSearchBand.TabIndex = 54;
            this.btnSearchBand.Text = "Search Band";
            this.btnSearchBand.UseVisualStyleBackColor = true;
            // 
            // txtSearchBand
            // 
            this.txtSearchBand.Location = new System.Drawing.Point(163, 486);
            this.txtSearchBand.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearchBand.Name = "txtSearchBand";
            this.txtSearchBand.Size = new System.Drawing.Size(104, 20);
            this.txtSearchBand.TabIndex = 53;
            // 
            // btnSortByGender
            // 
            this.btnSortByGender.Location = new System.Drawing.Point(941, 193);
            this.btnSortByGender.Margin = new System.Windows.Forms.Padding(2);
            this.btnSortByGender.Name = "btnSortByGender";
            this.btnSortByGender.Size = new System.Drawing.Size(138, 48);
            this.btnSortByGender.TabIndex = 52;
            this.btnSortByGender.Text = "Sort By Gender (Male, Female, Others)";
            this.btnSortByGender.UseVisualStyleBackColor = true;
            // 
            // btnSortByDate
            // 
            this.btnSortByDate.Location = new System.Drawing.Point(941, 127);
            this.btnSortByDate.Margin = new System.Windows.Forms.Padding(2);
            this.btnSortByDate.Name = "btnSortByDate";
            this.btnSortByDate.Size = new System.Drawing.Size(138, 48);
            this.btnSortByDate.TabIndex = 51;
            this.btnSortByDate.Text = "Sort By Debut Date (Recent - Old)";
            this.btnSortByDate.UseVisualStyleBackColor = true;
            // 
            // btnSortByAlpha
            // 
            this.btnSortByAlpha.Location = new System.Drawing.Point(941, 60);
            this.btnSortByAlpha.Margin = new System.Windows.Forms.Padding(2);
            this.btnSortByAlpha.Name = "btnSortByAlpha";
            this.btnSortByAlpha.Size = new System.Drawing.Size(138, 48);
            this.btnSortByAlpha.TabIndex = 50;
            this.btnSortByAlpha.Text = "Sort By Alphabetical Order (A - Z)";
            this.btnSortByAlpha.UseVisualStyleBackColor = true;
            // 
            // btnNextFavBand
            // 
            this.btnNextFavBand.Location = new System.Drawing.Point(849, 515);
            this.btnNextFavBand.Margin = new System.Windows.Forms.Padding(2);
            this.btnNextFavBand.Name = "btnNextFavBand";
            this.btnNextFavBand.Size = new System.Drawing.Size(65, 34);
            this.btnNextFavBand.TabIndex = 49;
            this.btnNextFavBand.Text = "Next";
            this.btnNextFavBand.UseVisualStyleBackColor = true;
            // 
            // btnPreviousFavBand
            // 
            this.btnPreviousFavBand.Location = new System.Drawing.Point(578, 515);
            this.btnPreviousFavBand.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreviousFavBand.Name = "btnPreviousFavBand";
            this.btnPreviousFavBand.Size = new System.Drawing.Size(70, 34);
            this.btnPreviousFavBand.TabIndex = 48;
            this.btnPreviousFavBand.Text = "Previous";
            this.btnPreviousFavBand.UseVisualStyleBackColor = true;
            // 
            // btnNextBand
            // 
            this.btnNextBand.Location = new System.Drawing.Point(849, 49);
            this.btnNextBand.Margin = new System.Windows.Forms.Padding(2);
            this.btnNextBand.Name = "btnNextBand";
            this.btnNextBand.Size = new System.Drawing.Size(65, 34);
            this.btnNextBand.TabIndex = 47;
            this.btnNextBand.Text = "Next";
            this.btnNextBand.UseVisualStyleBackColor = true;
            // 
            // btnPreviousBand
            // 
            this.btnPreviousBand.Location = new System.Drawing.Point(578, 49);
            this.btnPreviousBand.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreviousBand.Name = "btnPreviousBand";
            this.btnPreviousBand.Size = new System.Drawing.Size(70, 34);
            this.btnPreviousBand.TabIndex = 46;
            this.btnPreviousBand.Text = "Previous";
            this.btnPreviousBand.UseVisualStyleBackColor = true;
            // 
            // lblDisplayFavBand
            // 
            this.lblDisplayFavBand.AutoSize = true;
            this.lblDisplayFavBand.Location = new System.Drawing.Point(698, 465);
            this.lblDisplayFavBand.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisplayFavBand.Name = "lblDisplayFavBand";
            this.lblDisplayFavBand.Size = new System.Drawing.Size(84, 13);
            this.lblDisplayFavBand.TabIndex = 45;
            this.lblDisplayFavBand.Text = "DisplayFavBand";
            // 
            // lblDisplayBand
            // 
            this.lblDisplayBand.AutoSize = true;
            this.lblDisplayBand.Location = new System.Drawing.Point(703, 95);
            this.lblDisplayBand.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisplayBand.Name = "lblDisplayBand";
            this.lblDisplayBand.Size = new System.Drawing.Size(66, 13);
            this.lblDisplayBand.TabIndex = 44;
            this.lblDisplayBand.Text = "DisplayBand";
            // 
            // btnAddFavBand
            // 
            this.btnAddFavBand.Location = new System.Drawing.Point(819, 252);
            this.btnAddFavBand.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddFavBand.Name = "btnAddFavBand";
            this.btnAddFavBand.Size = new System.Drawing.Size(108, 51);
            this.btnAddFavBand.TabIndex = 43;
            this.btnAddFavBand.Text = "Add Band To Favourite";
            this.btnAddFavBand.UseVisualStyleBackColor = true;
            // 
            // btnEditBand
            // 
            this.btnEditBand.Location = new System.Drawing.Point(690, 252);
            this.btnEditBand.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditBand.Name = "btnEditBand";
            this.btnEditBand.Size = new System.Drawing.Size(108, 51);
            this.btnEditBand.TabIndex = 42;
            this.btnEditBand.Text = "Edit Band";
            this.btnEditBand.UseVisualStyleBackColor = true;
            // 
            // btnRemoveBand
            // 
            this.btnRemoveBand.Location = new System.Drawing.Point(549, 252);
            this.btnRemoveBand.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveBand.Name = "btnRemoveBand";
            this.btnRemoveBand.Size = new System.Drawing.Size(108, 51);
            this.btnRemoveBand.TabIndex = 41;
            this.btnRemoveBand.Text = "Remove Band";
            this.btnRemoveBand.UseVisualStyleBackColor = true;
            // 
            // btnAddBand
            // 
            this.btnAddBand.Location = new System.Drawing.Point(191, 374);
            this.btnAddBand.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddBand.Name = "btnAddBand";
            this.btnAddBand.Size = new System.Drawing.Size(192, 36);
            this.btnAddBand.TabIndex = 40;
            this.btnAddBand.Text = "Add Band";
            this.btnAddBand.UseVisualStyleBackColor = true;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(169, 290);
            this.lblCompany.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(82, 13);
            this.lblCompany.TabIndex = 39;
            this.lblCompany.Text = "Band Company:";
            // 
            // lblBandNumOfMem
            // 
            this.lblBandNumOfMem.AutoSize = true;
            this.lblBandNumOfMem.Location = new System.Drawing.Point(169, 246);
            this.lblBandNumOfMem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBandNumOfMem.Name = "lblBandNumOfMem";
            this.lblBandNumOfMem.Size = new System.Drawing.Size(103, 13);
            this.lblBandNumOfMem.TabIndex = 38;
            this.lblBandNumOfMem.Text = "Band # of Members:";
            // 
            // lblBandGender
            // 
            this.lblBandGender.AutoSize = true;
            this.lblBandGender.Location = new System.Drawing.Point(169, 199);
            this.lblBandGender.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBandGender.Name = "lblBandGender";
            this.lblBandGender.Size = new System.Drawing.Size(73, 13);
            this.lblBandGender.TabIndex = 37;
            this.lblBandGender.Text = "Band Gender:";
            // 
            // lblBandDebutDate
            // 
            this.lblBandDebutDate.AutoSize = true;
            this.lblBandDebutDate.Location = new System.Drawing.Point(169, 149);
            this.lblBandDebutDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBandDebutDate.Name = "lblBandDebutDate";
            this.lblBandDebutDate.Size = new System.Drawing.Size(93, 26);
            this.lblBandDebutDate.TabIndex = 36;
            this.lblBandDebutDate.Text = "Band Debut Date:\r\n(YYYYMMDD)";
            // 
            // lblBandName
            // 
            this.lblBandName.AutoSize = true;
            this.lblBandName.Location = new System.Drawing.Point(169, 100);
            this.lblBandName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBandName.Name = "lblBandName";
            this.lblBandName.Size = new System.Drawing.Size(66, 13);
            this.lblBandName.TabIndex = 35;
            this.lblBandName.Text = "Band Name:";
            // 
            // txtBandCompany
            // 
            this.txtBandCompany.Location = new System.Drawing.Point(322, 289);
            this.txtBandCompany.Margin = new System.Windows.Forms.Padding(2);
            this.txtBandCompany.Name = "txtBandCompany";
            this.txtBandCompany.Size = new System.Drawing.Size(83, 20);
            this.txtBandCompany.TabIndex = 34;
            // 
            // txtBandNumOfMem
            // 
            this.txtBandNumOfMem.Location = new System.Drawing.Point(322, 244);
            this.txtBandNumOfMem.Margin = new System.Windows.Forms.Padding(2);
            this.txtBandNumOfMem.Name = "txtBandNumOfMem";
            this.txtBandNumOfMem.Size = new System.Drawing.Size(83, 20);
            this.txtBandNumOfMem.TabIndex = 33;
            // 
            // txtBandGender
            // 
            this.txtBandGender.Location = new System.Drawing.Point(322, 198);
            this.txtBandGender.Margin = new System.Windows.Forms.Padding(2);
            this.txtBandGender.Name = "txtBandGender";
            this.txtBandGender.Size = new System.Drawing.Size(83, 20);
            this.txtBandGender.TabIndex = 32;
            // 
            // txtBandDebutDate
            // 
            this.txtBandDebutDate.Location = new System.Drawing.Point(322, 147);
            this.txtBandDebutDate.Margin = new System.Windows.Forms.Padding(2);
            this.txtBandDebutDate.Name = "txtBandDebutDate";
            this.txtBandDebutDate.Size = new System.Drawing.Size(83, 20);
            this.txtBandDebutDate.TabIndex = 31;
            // 
            // txtBandName
            // 
            this.txtBandName.Location = new System.Drawing.Point(322, 98);
            this.txtBandName.Margin = new System.Windows.Forms.Padding(2);
            this.txtBandName.Name = "txtBandName";
            this.txtBandName.Size = new System.Drawing.Size(83, 20);
            this.txtBandName.TabIndex = 30;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            // 
            // SingerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 680);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDisplayBandSingers);
            this.Controls.Add(this.btnRemoveFavBand);
            this.Controls.Add(this.btnSearchBand);
            this.Controls.Add(this.txtSearchBand);
            this.Controls.Add(this.btnSortByGender);
            this.Controls.Add(this.btnSortByDate);
            this.Controls.Add(this.btnSortByAlpha);
            this.Controls.Add(this.btnNextFavBand);
            this.Controls.Add(this.btnPreviousFavBand);
            this.Controls.Add(this.btnNextBand);
            this.Controls.Add(this.btnPreviousBand);
            this.Controls.Add(this.lblDisplayFavBand);
            this.Controls.Add(this.lblDisplayBand);
            this.Controls.Add(this.btnAddFavBand);
            this.Controls.Add(this.btnEditBand);
            this.Controls.Add(this.btnRemoveBand);
            this.Controls.Add(this.btnAddBand);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblBandNumOfMem);
            this.Controls.Add(this.lblBandGender);
            this.Controls.Add(this.lblBandDebutDate);
            this.Controls.Add(this.lblBandName);
            this.Controls.Add(this.txtBandCompany);
            this.Controls.Add(this.txtBandNumOfMem);
            this.Controls.Add(this.txtBandGender);
            this.Controls.Add(this.txtBandDebutDate);
            this.Controls.Add(this.txtBandName);
            this.Name = "SingerForm";
            this.Text = "SingerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDisplayBandSingers;
        private System.Windows.Forms.Button btnRemoveFavBand;
        private System.Windows.Forms.Button btnSearchBand;
        private System.Windows.Forms.TextBox txtSearchBand;
        private System.Windows.Forms.Button btnSortByGender;
        private System.Windows.Forms.Button btnSortByDate;
        private System.Windows.Forms.Button btnSortByAlpha;
        private System.Windows.Forms.Button btnNextFavBand;
        private System.Windows.Forms.Button btnPreviousFavBand;
        private System.Windows.Forms.Button btnNextBand;
        private System.Windows.Forms.Button btnPreviousBand;
        private System.Windows.Forms.Label lblDisplayFavBand;
        private System.Windows.Forms.Label lblDisplayBand;
        private System.Windows.Forms.Button btnAddFavBand;
        private System.Windows.Forms.Button btnEditBand;
        private System.Windows.Forms.Button btnRemoveBand;
        private System.Windows.Forms.Button btnAddBand;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblBandNumOfMem;
        private System.Windows.Forms.Label lblBandGender;
        private System.Windows.Forms.Label lblBandDebutDate;
        private System.Windows.Forms.Label lblBandName;
        private System.Windows.Forms.TextBox txtBandCompany;
        private System.Windows.Forms.TextBox txtBandNumOfMem;
        private System.Windows.Forms.TextBox txtBandGender;
        private System.Windows.Forms.TextBox txtBandDebutDate;
        private System.Windows.Forms.TextBox txtBandName;
        private System.Windows.Forms.Timer timer1;
    }
}