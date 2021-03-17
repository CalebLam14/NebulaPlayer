namespace KpopBandDatabase
{
    partial class KpopBandDatabaseForm
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
            this.txtBandName = new System.Windows.Forms.TextBox();
            this.txtBandDebutDate = new System.Windows.Forms.TextBox();
            this.txtBandGender = new System.Windows.Forms.TextBox();
            this.txtBandNumOfMem = new System.Windows.Forms.TextBox();
            this.txtBandCompany = new System.Windows.Forms.TextBox();
            this.lblBandName = new System.Windows.Forms.Label();
            this.lblBandDebutDate = new System.Windows.Forms.Label();
            this.lblBandGender = new System.Windows.Forms.Label();
            this.lblBandNumOfMem = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.btnAddBand = new System.Windows.Forms.Button();
            this.btnRemoveBand = new System.Windows.Forms.Button();
            this.btnEditBand = new System.Windows.Forms.Button();
            this.btnAddFavBand = new System.Windows.Forms.Button();
            this.lblDisplayBand = new System.Windows.Forms.Label();
            this.lblDisplayFavBand = new System.Windows.Forms.Label();
            this.btnPreviousBand = new System.Windows.Forms.Button();
            this.btnNextBand = new System.Windows.Forms.Button();
            this.btnPreviousFavBand = new System.Windows.Forms.Button();
            this.btnNextFavBand = new System.Windows.Forms.Button();
            this.btnSortByAlpha = new System.Windows.Forms.Button();
            this.btnSortByDate = new System.Windows.Forms.Button();
            this.btnSortByGender = new System.Windows.Forms.Button();
            this.txtSearchBand = new System.Windows.Forms.TextBox();
            this.btnSearchBand = new System.Windows.Forms.Button();
            this.btnRemoveFavBand = new System.Windows.Forms.Button();
            this.btnDisplayBandSingers = new System.Windows.Forms.Button();
            this.tmrTest = new System.Windows.Forms.Timer(this.components);
            this.lblTest1 = new System.Windows.Forms.Label();
            this.lblTest2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.picBand = new System.Windows.Forms.PictureBox();
            this.uploadBandPfpDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnUploadBandPfp = new System.Windows.Forms.Button();
            this.picFavBand = new System.Windows.Forms.PictureBox();
            this.btnRecommendBand = new System.Windows.Forms.Button();
            this.lblRecommendBand = new System.Windows.Forms.Label();
            this.btnSort = new System.Windows.Forms.Button();
            this.lblDisplayMode = new System.Windows.Forms.Label();
            this.btnGoBackToBand = new System.Windows.Forms.Button();
            this.txtSingerName = new System.Windows.Forms.TextBox();
            this.lblSingerName = new System.Windows.Forms.Label();
            this.btnAddSinger = new System.Windows.Forms.Button();
            this.btnPreviousSinger = new System.Windows.Forms.Button();
            this.btnNextSinger = new System.Windows.Forms.Button();
            this.lblDisplaySinger = new System.Windows.Forms.Label();
            this.btnRemoveSinger = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFavBand)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBandName
            // 
            this.txtBandName.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtBandName.Location = new System.Drawing.Point(211, 63);
            this.txtBandName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBandName.Name = "txtBandName";
            this.txtBandName.Size = new System.Drawing.Size(83, 20);
            this.txtBandName.TabIndex = 0;
            // 
            // txtBandDebutDate
            // 
            this.txtBandDebutDate.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtBandDebutDate.Location = new System.Drawing.Point(211, 112);
            this.txtBandDebutDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBandDebutDate.Name = "txtBandDebutDate";
            this.txtBandDebutDate.Size = new System.Drawing.Size(83, 20);
            this.txtBandDebutDate.TabIndex = 1;
            // 
            // txtBandGender
            // 
            this.txtBandGender.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtBandGender.Location = new System.Drawing.Point(211, 163);
            this.txtBandGender.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBandGender.Name = "txtBandGender";
            this.txtBandGender.Size = new System.Drawing.Size(83, 20);
            this.txtBandGender.TabIndex = 2;
            // 
            // txtBandNumOfMem
            // 
            this.txtBandNumOfMem.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtBandNumOfMem.Location = new System.Drawing.Point(211, 209);
            this.txtBandNumOfMem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBandNumOfMem.Name = "txtBandNumOfMem";
            this.txtBandNumOfMem.Size = new System.Drawing.Size(83, 20);
            this.txtBandNumOfMem.TabIndex = 3;
            // 
            // txtBandCompany
            // 
            this.txtBandCompany.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtBandCompany.Location = new System.Drawing.Point(211, 254);
            this.txtBandCompany.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBandCompany.Name = "txtBandCompany";
            this.txtBandCompany.Size = new System.Drawing.Size(83, 20);
            this.txtBandCompany.TabIndex = 4;
            // 
            // lblBandName
            // 
            this.lblBandName.AutoSize = true;
            this.lblBandName.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblBandName.Location = new System.Drawing.Point(58, 65);
            this.lblBandName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBandName.Name = "lblBandName";
            this.lblBandName.Size = new System.Drawing.Size(78, 17);
            this.lblBandName.TabIndex = 5;
            this.lblBandName.Text = "Band Name:";
            // 
            // lblBandDebutDate
            // 
            this.lblBandDebutDate.AutoSize = true;
            this.lblBandDebutDate.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblBandDebutDate.Location = new System.Drawing.Point(58, 114);
            this.lblBandDebutDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBandDebutDate.Name = "lblBandDebutDate";
            this.lblBandDebutDate.Size = new System.Drawing.Size(110, 34);
            this.lblBandDebutDate.TabIndex = 6;
            this.lblBandDebutDate.Text = "Band Debut Date:\r\n(YYYYMMDD)";
            // 
            // lblBandGender
            // 
            this.lblBandGender.AutoSize = true;
            this.lblBandGender.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblBandGender.Location = new System.Drawing.Point(58, 164);
            this.lblBandGender.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBandGender.Name = "lblBandGender";
            this.lblBandGender.Size = new System.Drawing.Size(86, 17);
            this.lblBandGender.TabIndex = 7;
            this.lblBandGender.Text = "Band Gender:";
            // 
            // lblBandNumOfMem
            // 
            this.lblBandNumOfMem.AutoSize = true;
            this.lblBandNumOfMem.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblBandNumOfMem.Location = new System.Drawing.Point(58, 211);
            this.lblBandNumOfMem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBandNumOfMem.Name = "lblBandNumOfMem";
            this.lblBandNumOfMem.Size = new System.Drawing.Size(122, 17);
            this.lblBandNumOfMem.TabIndex = 8;
            this.lblBandNumOfMem.Text = "Band # of Members:";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblCompany.Location = new System.Drawing.Point(58, 255);
            this.lblCompany.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(96, 17);
            this.lblCompany.TabIndex = 9;
            this.lblCompany.Text = "Band Company:";
            // 
            // btnAddBand
            // 
            this.btnAddBand.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAddBand.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnAddBand.Location = new System.Drawing.Point(80, 296);
            this.btnAddBand.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddBand.Name = "btnAddBand";
            this.btnAddBand.Size = new System.Drawing.Size(192, 36);
            this.btnAddBand.TabIndex = 10;
            this.btnAddBand.Text = "Add Band";
            this.btnAddBand.UseVisualStyleBackColor = false;
            this.btnAddBand.Click += new System.EventHandler(this.btnAddBand_Click);
            // 
            // btnRemoveBand
            // 
            this.btnRemoveBand.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnRemoveBand.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnRemoveBand.Location = new System.Drawing.Point(485, 267);
            this.btnRemoveBand.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRemoveBand.Name = "btnRemoveBand";
            this.btnRemoveBand.Size = new System.Drawing.Size(108, 51);
            this.btnRemoveBand.TabIndex = 11;
            this.btnRemoveBand.Text = "Remove Band";
            this.btnRemoveBand.UseVisualStyleBackColor = false;
            this.btnRemoveBand.Click += new System.EventHandler(this.btnRemoveBand_Click);
            // 
            // btnEditBand
            // 
            this.btnEditBand.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnEditBand.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnEditBand.Location = new System.Drawing.Point(626, 267);
            this.btnEditBand.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEditBand.Name = "btnEditBand";
            this.btnEditBand.Size = new System.Drawing.Size(108, 51);
            this.btnEditBand.TabIndex = 12;
            this.btnEditBand.Text = "Edit Band";
            this.btnEditBand.UseVisualStyleBackColor = false;
            this.btnEditBand.Click += new System.EventHandler(this.btnEditBand_Click);
            // 
            // btnAddFavBand
            // 
            this.btnAddFavBand.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAddFavBand.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnAddFavBand.Location = new System.Drawing.Point(755, 267);
            this.btnAddFavBand.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddFavBand.Name = "btnAddFavBand";
            this.btnAddFavBand.Size = new System.Drawing.Size(108, 51);
            this.btnAddFavBand.TabIndex = 13;
            this.btnAddFavBand.Text = "Add Band To Favourite";
            this.btnAddFavBand.UseVisualStyleBackColor = false;
            this.btnAddFavBand.Click += new System.EventHandler(this.btnAddFavBand_Click);
            // 
            // lblDisplayBand
            // 
            this.lblDisplayBand.AutoSize = true;
            this.lblDisplayBand.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblDisplayBand.Location = new System.Drawing.Point(462, 74);
            this.lblDisplayBand.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisplayBand.Name = "lblDisplayBand";
            this.lblDisplayBand.Size = new System.Drawing.Size(77, 17);
            this.lblDisplayBand.TabIndex = 14;
            this.lblDisplayBand.Text = "DisplayBand";
            // 
            // lblDisplayFavBand
            // 
            this.lblDisplayFavBand.AutoSize = true;
            this.lblDisplayFavBand.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblDisplayFavBand.Location = new System.Drawing.Point(462, 353);
            this.lblDisplayFavBand.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisplayFavBand.Name = "lblDisplayFavBand";
            this.lblDisplayFavBand.Size = new System.Drawing.Size(96, 17);
            this.lblDisplayFavBand.TabIndex = 16;
            this.lblDisplayFavBand.Text = "DisplayFavBand";
            // 
            // btnPreviousBand
            // 
            this.btnPreviousBand.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnPreviousBand.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnPreviousBand.Location = new System.Drawing.Point(467, 14);
            this.btnPreviousBand.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPreviousBand.Name = "btnPreviousBand";
            this.btnPreviousBand.Size = new System.Drawing.Size(70, 34);
            this.btnPreviousBand.TabIndex = 17;
            this.btnPreviousBand.Text = "Previous";
            this.btnPreviousBand.UseVisualStyleBackColor = false;
            this.btnPreviousBand.Click += new System.EventHandler(this.btnPreviousBand_Click);
            // 
            // btnNextBand
            // 
            this.btnNextBand.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnNextBand.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnNextBand.Location = new System.Drawing.Point(823, 11);
            this.btnNextBand.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNextBand.Name = "btnNextBand";
            this.btnNextBand.Size = new System.Drawing.Size(65, 34);
            this.btnNextBand.TabIndex = 18;
            this.btnNextBand.Text = "Next";
            this.btnNextBand.UseVisualStyleBackColor = false;
            this.btnNextBand.Click += new System.EventHandler(this.btnNextBand_Click);
            // 
            // btnPreviousFavBand
            // 
            this.btnPreviousFavBand.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnPreviousFavBand.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnPreviousFavBand.Location = new System.Drawing.Point(467, 529);
            this.btnPreviousFavBand.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPreviousFavBand.Name = "btnPreviousFavBand";
            this.btnPreviousFavBand.Size = new System.Drawing.Size(70, 34);
            this.btnPreviousFavBand.TabIndex = 19;
            this.btnPreviousFavBand.Text = "Previous";
            this.btnPreviousFavBand.UseVisualStyleBackColor = false;
            this.btnPreviousFavBand.Click += new System.EventHandler(this.btnPreviousFavBand_Click);
            // 
            // btnNextFavBand
            // 
            this.btnNextFavBand.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnNextFavBand.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnNextFavBand.Location = new System.Drawing.Point(823, 529);
            this.btnNextFavBand.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNextFavBand.Name = "btnNextFavBand";
            this.btnNextFavBand.Size = new System.Drawing.Size(65, 34);
            this.btnNextFavBand.TabIndex = 20;
            this.btnNextFavBand.Text = "Next";
            this.btnNextFavBand.UseVisualStyleBackColor = false;
            this.btnNextFavBand.Click += new System.EventHandler(this.btnNextFavBand_Click);
            // 
            // btnSortByAlpha
            // 
            this.btnSortByAlpha.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSortByAlpha.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnSortByAlpha.Location = new System.Drawing.Point(761, 606);
            this.btnSortByAlpha.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSortByAlpha.Name = "btnSortByAlpha";
            this.btnSortByAlpha.Size = new System.Drawing.Size(158, 48);
            this.btnSortByAlpha.TabIndex = 21;
            this.btnSortByAlpha.Text = "Sort By Alphabetical Order (A - Z)";
            this.btnSortByAlpha.UseVisualStyleBackColor = false;
            this.btnSortByAlpha.Click += new System.EventHandler(this.btnSortByAlpha_Click);
            // 
            // btnSortByDate
            // 
            this.btnSortByDate.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSortByDate.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnSortByDate.Location = new System.Drawing.Point(928, 606);
            this.btnSortByDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSortByDate.Name = "btnSortByDate";
            this.btnSortByDate.Size = new System.Drawing.Size(158, 48);
            this.btnSortByDate.TabIndex = 22;
            this.btnSortByDate.Text = "Sort By Debut Date (Recent - Old)";
            this.btnSortByDate.UseVisualStyleBackColor = false;
            this.btnSortByDate.Click += new System.EventHandler(this.btnSortByDate_Click);
            // 
            // btnSortByGender
            // 
            this.btnSortByGender.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSortByGender.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnSortByGender.Location = new System.Drawing.Point(1090, 606);
            this.btnSortByGender.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSortByGender.Name = "btnSortByGender";
            this.btnSortByGender.Size = new System.Drawing.Size(158, 48);
            this.btnSortByGender.TabIndex = 23;
            this.btnSortByGender.Text = "2wd";
            this.btnSortByGender.UseVisualStyleBackColor = false;
            this.btnSortByGender.Click += new System.EventHandler(this.btnSortByGender_Click);
            // 
            // txtSearchBand
            // 
            this.txtSearchBand.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtSearchBand.Location = new System.Drawing.Point(52, 451);
            this.txtSearchBand.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearchBand.Name = "txtSearchBand";
            this.txtSearchBand.Size = new System.Drawing.Size(104, 20);
            this.txtSearchBand.TabIndex = 24;
            // 
            // btnSearchBand
            // 
            this.btnSearchBand.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSearchBand.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnSearchBand.Location = new System.Drawing.Point(187, 443);
            this.btnSearchBand.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearchBand.Name = "btnSearchBand";
            this.btnSearchBand.Size = new System.Drawing.Size(105, 31);
            this.btnSearchBand.TabIndex = 25;
            this.btnSearchBand.Text = "Search Band";
            this.btnSearchBand.UseVisualStyleBackColor = false;
            this.btnSearchBand.Click += new System.EventHandler(this.btnSearchBand_Click);
            // 
            // btnRemoveFavBand
            // 
            this.btnRemoveFavBand.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnRemoveFavBand.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnRemoveFavBand.Location = new System.Drawing.Point(626, 583);
            this.btnRemoveFavBand.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRemoveFavBand.Name = "btnRemoveFavBand";
            this.btnRemoveFavBand.Size = new System.Drawing.Size(108, 51);
            this.btnRemoveFavBand.TabIndex = 26;
            this.btnRemoveFavBand.Text = "Remove Band From Favourite";
            this.btnRemoveFavBand.UseVisualStyleBackColor = false;
            this.btnRemoveFavBand.Click += new System.EventHandler(this.btnRemoveFavBand_Click);
            // 
            // btnDisplayBandSingers
            // 
            this.btnDisplayBandSingers.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnDisplayBandSingers.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnDisplayBandSingers.Location = new System.Drawing.Point(936, 11);
            this.btnDisplayBandSingers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDisplayBandSingers.Name = "btnDisplayBandSingers";
            this.btnDisplayBandSingers.Size = new System.Drawing.Size(143, 49);
            this.btnDisplayBandSingers.TabIndex = 27;
            this.btnDisplayBandSingers.Text = "Display Band\'s Singers";
            this.btnDisplayBandSingers.UseVisualStyleBackColor = false;
            this.btnDisplayBandSingers.Click += new System.EventHandler(this.btnDisplayBandSingers_Click);
            // 
            // tmrTest
            // 
            this.tmrTest.Enabled = true;
            this.tmrTest.Interval = 10;
            this.tmrTest.Tick += new System.EventHandler(this.tmrTest_Tick);
            // 
            // lblTest1
            // 
            this.lblTest1.AutoSize = true;
            this.lblTest1.Location = new System.Drawing.Point(362, 127);
            this.lblTest1.Name = "lblTest1";
            this.lblTest1.Size = new System.Drawing.Size(44, 13);
            this.lblTest1.TabIndex = 28;
            this.lblTest1.Text = "lblTest1";
            // 
            // lblTest2
            // 
            this.lblTest2.AutoSize = true;
            this.lblTest2.Location = new System.Drawing.Point(362, 583);
            this.lblTest2.Name = "lblTest2";
            this.lblTest2.Size = new System.Drawing.Size(44, 13);
            this.lblTest2.TabIndex = 29;
            this.lblTest2.Text = "lblTest2";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnSave.Location = new System.Drawing.Point(36, 570);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 40);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnLoad.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnLoad.Location = new System.Drawing.Point(178, 570);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(104, 40);
            this.btnLoad.TabIndex = 31;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // picBand
            // 
            this.picBand.BackColor = System.Drawing.Color.Transparent;
            this.picBand.Location = new System.Drawing.Point(677, 74);
            this.picBand.Name = "picBand";
            this.picBand.Size = new System.Drawing.Size(230, 150);
            this.picBand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBand.TabIndex = 32;
            this.picBand.TabStop = false;
            // 
            // uploadBandPfpDialog
            // 
            this.uploadBandPfpDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnUploadBandPfp
            // 
            this.btnUploadBandPfp.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnUploadBandPfp.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnUploadBandPfp.Location = new System.Drawing.Point(102, 353);
            this.btnUploadBandPfp.Name = "btnUploadBandPfp";
            this.btnUploadBandPfp.Size = new System.Drawing.Size(135, 30);
            this.btnUploadBandPfp.TabIndex = 33;
            this.btnUploadBandPfp.Text = "Upload Band Picture";
            this.btnUploadBandPfp.UseVisualStyleBackColor = false;
            this.btnUploadBandPfp.Click += new System.EventHandler(this.btnUploadBandPfp_Click);
            // 
            // picFavBand
            // 
            this.picFavBand.BackColor = System.Drawing.Color.Transparent;
            this.picFavBand.Location = new System.Drawing.Point(677, 353);
            this.picFavBand.Name = "picFavBand";
            this.picFavBand.Size = new System.Drawing.Size(230, 150);
            this.picFavBand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFavBand.TabIndex = 34;
            this.picFavBand.TabStop = false;
            // 
            // btnRecommendBand
            // 
            this.btnRecommendBand.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnRecommendBand.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnRecommendBand.Location = new System.Drawing.Point(1106, 363);
            this.btnRecommendBand.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRecommendBand.Name = "btnRecommendBand";
            this.btnRecommendBand.Size = new System.Drawing.Size(143, 49);
            this.btnRecommendBand.TabIndex = 35;
            this.btnRecommendBand.Text = "Recommend Band";
            this.btnRecommendBand.UseVisualStyleBackColor = false;
            this.btnRecommendBand.Click += new System.EventHandler(this.btnRecommendBand_Click);
            // 
            // lblRecommendBand
            // 
            this.lblRecommendBand.AutoSize = true;
            this.lblRecommendBand.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblRecommendBand.Location = new System.Drawing.Point(1103, 443);
            this.lblRecommendBand.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecommendBand.Name = "lblRecommendBand";
            this.lblRecommendBand.Size = new System.Drawing.Size(161, 17);
            this.lblRecommendBand.TabIndex = 36;
            this.lblRecommendBand.Text = "Recommendation Message";
            // 
            // btnSort
            // 
            this.btnSort.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSort.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnSort.Location = new System.Drawing.Point(898, 363);
            this.btnSort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(143, 49);
            this.btnSort.TabIndex = 37;
            this.btnSort.Text = "General Sort";
            this.btnSort.UseVisualStyleBackColor = false;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // lblDisplayMode
            // 
            this.lblDisplayMode.AutoSize = true;
            this.lblDisplayMode.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblDisplayMode.Location = new System.Drawing.Point(896, 443);
            this.lblDisplayMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisplayMode.Name = "lblDisplayMode";
            this.lblDisplayMode.Size = new System.Drawing.Size(84, 17);
            this.lblDisplayMode.TabIndex = 38;
            this.lblDisplayMode.Text = "Display Mode";
            // 
            // btnGoBackToBand
            // 
            this.btnGoBackToBand.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnGoBackToBand.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnGoBackToBand.Location = new System.Drawing.Point(1093, 11);
            this.btnGoBackToBand.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGoBackToBand.Name = "btnGoBackToBand";
            this.btnGoBackToBand.Size = new System.Drawing.Size(143, 49);
            this.btnGoBackToBand.TabIndex = 39;
            this.btnGoBackToBand.Text = "Go back to bands";
            this.btnGoBackToBand.UseVisualStyleBackColor = false;
            this.btnGoBackToBand.Click += new System.EventHandler(this.btnGoBackToBand_Click);
            // 
            // txtSingerName
            // 
            this.txtSingerName.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtSingerName.Location = new System.Drawing.Point(1039, 95);
            this.txtSingerName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSingerName.Name = "txtSingerName";
            this.txtSingerName.Size = new System.Drawing.Size(83, 20);
            this.txtSingerName.TabIndex = 41;
            // 
            // lblSingerName
            // 
            this.lblSingerName.AutoSize = true;
            this.lblSingerName.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblSingerName.Location = new System.Drawing.Point(936, 95);
            this.lblSingerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSingerName.Name = "lblSingerName";
            this.lblSingerName.Size = new System.Drawing.Size(80, 17);
            this.lblSingerName.TabIndex = 42;
            this.lblSingerName.Text = "Singer Name";
            // 
            // btnAddSinger
            // 
            this.btnAddSinger.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAddSinger.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnAddSinger.Location = new System.Drawing.Point(1138, 88);
            this.btnAddSinger.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddSinger.Name = "btnAddSinger";
            this.btnAddSinger.Size = new System.Drawing.Size(94, 36);
            this.btnAddSinger.TabIndex = 43;
            this.btnAddSinger.Text = "Add Singer";
            this.btnAddSinger.UseVisualStyleBackColor = false;
            this.btnAddSinger.Click += new System.EventHandler(this.btnAddSinger_Click);
            // 
            // btnPreviousSinger
            // 
            this.btnPreviousSinger.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnPreviousSinger.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnPreviousSinger.Location = new System.Drawing.Point(940, 154);
            this.btnPreviousSinger.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPreviousSinger.Name = "btnPreviousSinger";
            this.btnPreviousSinger.Size = new System.Drawing.Size(70, 34);
            this.btnPreviousSinger.TabIndex = 44;
            this.btnPreviousSinger.Text = "Previous";
            this.btnPreviousSinger.UseVisualStyleBackColor = false;
            this.btnPreviousSinger.Click += new System.EventHandler(this.btnPreviousSinger_Click);
            // 
            // btnNextSinger
            // 
            this.btnNextSinger.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnNextSinger.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnNextSinger.Location = new System.Drawing.Point(1138, 154);
            this.btnNextSinger.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNextSinger.Name = "btnNextSinger";
            this.btnNextSinger.Size = new System.Drawing.Size(65, 34);
            this.btnNextSinger.TabIndex = 45;
            this.btnNextSinger.Text = "Next";
            this.btnNextSinger.UseVisualStyleBackColor = false;
            this.btnNextSinger.Click += new System.EventHandler(this.btnNextSinger_Click);
            // 
            // lblDisplaySinger
            // 
            this.lblDisplaySinger.AutoSize = true;
            this.lblDisplaySinger.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblDisplaySinger.Location = new System.Drawing.Point(942, 229);
            this.lblDisplaySinger.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisplaySinger.Name = "lblDisplaySinger";
            this.lblDisplaySinger.Size = new System.Drawing.Size(83, 17);
            this.lblDisplaySinger.TabIndex = 46;
            this.lblDisplaySinger.Text = "DisplaySinger";
            // 
            // btnRemoveSinger
            // 
            this.btnRemoveSinger.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnRemoveSinger.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnRemoveSinger.Location = new System.Drawing.Point(1026, 153);
            this.btnRemoveSinger.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRemoveSinger.Name = "btnRemoveSinger";
            this.btnRemoveSinger.Size = new System.Drawing.Size(94, 36);
            this.btnRemoveSinger.TabIndex = 47;
            this.btnRemoveSinger.Text = "Remove Singer";
            this.btnRemoveSinger.UseVisualStyleBackColor = false;
            this.btnRemoveSinger.Click += new System.EventHandler(this.btnRemoveSinger_Click);
            // 
            // KpopBandDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.BackgroundImage = global::KpopBandDatabase.Properties.Resources.KpopBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1345, 692);
            this.Controls.Add(this.btnRemoveSinger);
            this.Controls.Add(this.lblDisplaySinger);
            this.Controls.Add(this.btnNextSinger);
            this.Controls.Add(this.btnPreviousSinger);
            this.Controls.Add(this.btnAddSinger);
            this.Controls.Add(this.lblSingerName);
            this.Controls.Add(this.txtSingerName);
            this.Controls.Add(this.btnGoBackToBand);
            this.Controls.Add(this.lblDisplayMode);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.lblRecommendBand);
            this.Controls.Add(this.btnRecommendBand);
            this.Controls.Add(this.picFavBand);
            this.Controls.Add(this.btnUploadBandPfp);
            this.Controls.Add(this.picBand);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTest2);
            this.Controls.Add(this.lblTest1);
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
            this.Name = "KpopBandDatabaseForm";
            this.Text = "ffffff";
            ((System.ComponentModel.ISupportInitialize)(this.picBand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFavBand)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBandName;
        private System.Windows.Forms.TextBox txtBandDebutDate;
        private System.Windows.Forms.TextBox txtBandGender;
        private System.Windows.Forms.TextBox txtBandNumOfMem;
        private System.Windows.Forms.TextBox txtBandCompany;
        private System.Windows.Forms.Label lblBandName;
        private System.Windows.Forms.Label lblBandDebutDate;
        private System.Windows.Forms.Label lblBandGender;
        private System.Windows.Forms.Label lblBandNumOfMem;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Button btnAddBand;
        private System.Windows.Forms.Button btnRemoveBand;
        private System.Windows.Forms.Button btnEditBand;
        private System.Windows.Forms.Button btnAddFavBand;
        private System.Windows.Forms.Label lblDisplayBand;
        private System.Windows.Forms.Label lblDisplayFavBand;
        private System.Windows.Forms.Button btnPreviousBand;
        private System.Windows.Forms.Button btnNextBand;
        private System.Windows.Forms.Button btnPreviousFavBand;
        private System.Windows.Forms.Button btnNextFavBand;
        private System.Windows.Forms.Button btnSortByAlpha;
        private System.Windows.Forms.Button btnSortByDate;
        private System.Windows.Forms.Button btnSortByGender;
        private System.Windows.Forms.TextBox txtSearchBand;
        private System.Windows.Forms.Button btnSearchBand;
        private System.Windows.Forms.Button btnRemoveFavBand;
        private System.Windows.Forms.Button btnDisplayBandSingers;
        private System.Windows.Forms.Timer tmrTest;
        private System.Windows.Forms.Label lblTest1;
        private System.Windows.Forms.Label lblTest2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.PictureBox picBand;
        private System.Windows.Forms.OpenFileDialog uploadBandPfpDialog;
        private System.Windows.Forms.Button btnUploadBandPfp;
        private System.Windows.Forms.PictureBox picFavBand;
        private System.Windows.Forms.Button btnRecommendBand;
        private System.Windows.Forms.Label lblRecommendBand;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Label lblDisplayMode;
        private System.Windows.Forms.Button btnGoBackToBand;
        private System.Windows.Forms.TextBox txtSingerName;
        private System.Windows.Forms.Label lblSingerName;
        private System.Windows.Forms.Button btnAddSinger;
        private System.Windows.Forms.Button btnPreviousSinger;
        private System.Windows.Forms.Button btnNextSinger;
        private System.Windows.Forms.Label lblDisplaySinger;
        private System.Windows.Forms.Button btnRemoveSinger;
    }
}

