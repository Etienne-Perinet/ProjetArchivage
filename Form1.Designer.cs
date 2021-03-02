namespace Archivage
{
    partial class Myform
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstArchivage = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnMerge = new System.Windows.Forms.Button();
            this.btnEmploye = new System.Windows.Forms.Button();
            this.comboBoxSecond = new System.Windows.Forms.ComboBox();
            this.combotxtStorageContainer = new System.Windows.Forms.ComboBox();
            this.comboTypeFile = new System.Windows.Forms.ComboBox();
            this.comboBoxFirst = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnVerification = new System.Windows.Forms.Button();
            this.numBox = new System.Windows.Forms.NumericUpDown();
            this.numContainer = new System.Windows.Forms.NumericUpDown();
            this.numDevice = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtLettre = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.comboMonths = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.checkFlag = new System.Windows.Forms.CheckBox();
            this.comboEmployeSearch = new System.Windows.Forms.ComboBox();
            this.comboDeviceTypeSearch = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.numBoxSearch = new System.Windows.Forms.NumericUpDown();
            this.numContainerSearch = new System.Windows.Forms.NumericUpDown();
            this.numDeviceSearch = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDevice)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numContainerSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDeviceSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // lstArchivage
            // 
            this.lstArchivage.FormattingEnabled = true;
            this.lstArchivage.Location = new System.Drawing.Point(20, 19);
            this.lstArchivage.Name = "lstArchivage";
            this.lstArchivage.Size = new System.Drawing.Size(591, 433);
            this.lstArchivage.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstArchivage);
            this.groupBox1.Location = new System.Drawing.Point(17, 298);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 464);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Liste de fichier liée avec votre recherche";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnMerge);
            this.groupBox2.Controls.Add(this.btnEmploye);
            this.groupBox2.Controls.Add(this.comboBoxSecond);
            this.groupBox2.Controls.Add(this.combotxtStorageContainer);
            this.groupBox2.Controls.Add(this.comboTypeFile);
            this.groupBox2.Controls.Add(this.comboBoxFirst);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnVerification);
            this.groupBox2.Controls.Add(this.numBox);
            this.groupBox2.Controls.Add(this.numContainer);
            this.groupBox2.Controls.Add(this.numDevice);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtFileName);
            this.groupBox2.Controls.Add(this.txtLettre);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(671, 821);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Archiver de nouvelles données";
            this.groupBox2.UseCompatibleTextRendering = true;
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(473, 20);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(179, 52);
            this.btnMerge.TabIndex = 8;
            this.btnMerge.Text = "Fusionner 2 bases de données";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // btnEmploye
            // 
            this.btnEmploye.Location = new System.Drawing.Point(580, 224);
            this.btnEmploye.Name = "btnEmploye";
            this.btnEmploye.Size = new System.Drawing.Size(72, 58);
            this.btnEmploye.TabIndex = 7;
            this.btnEmploye.Text = "Afficher la liste d\'employé";
            this.btnEmploye.UseVisualStyleBackColor = true;
            this.btnEmploye.Click += new System.EventHandler(this.btnEmploye_Click);
            // 
            // comboBoxSecond
            // 
            this.comboBoxSecond.FormattingEnabled = true;
            this.comboBoxSecond.Location = new System.Drawing.Point(306, 260);
            this.comboBoxSecond.Name = "comboBoxSecond";
            this.comboBoxSecond.Size = new System.Drawing.Size(268, 21);
            this.comboBoxSecond.TabIndex = 6;
            // 
            // combotxtStorageContainer
            // 
            this.combotxtStorageContainer.FormattingEnabled = true;
            this.combotxtStorageContainer.Location = new System.Drawing.Point(300, 193);
            this.combotxtStorageContainer.Name = "combotxtStorageContainer";
            this.combotxtStorageContainer.Size = new System.Drawing.Size(176, 21);
            this.combotxtStorageContainer.Sorted = true;
            this.combotxtStorageContainer.TabIndex = 6;
            // 
            // comboTypeFile
            // 
            this.comboTypeFile.FormattingEnabled = true;
            this.comboTypeFile.Location = new System.Drawing.Point(153, 194);
            this.comboTypeFile.Name = "comboTypeFile";
            this.comboTypeFile.Size = new System.Drawing.Size(111, 21);
            this.comboTypeFile.Sorted = true;
            this.comboTypeFile.TabIndex = 6;
            // 
            // comboBoxFirst
            // 
            this.comboBoxFirst.FormattingEnabled = true;
            this.comboBoxFirst.Location = new System.Drawing.Point(19, 260);
            this.comboBoxFirst.Name = "comboBoxFirst";
            this.comboBoxFirst.Size = new System.Drawing.Size(268, 21);
            this.comboBoxFirst.Sorted = true;
            this.comboBoxFirst.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(552, 768);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 36);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Enregistrer";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnVerification
            // 
            this.btnVerification.Location = new System.Drawing.Point(17, 768);
            this.btnVerification.Name = "btnVerification";
            this.btnVerification.Size = new System.Drawing.Size(100, 36);
            this.btnVerification.TabIndex = 1;
            this.btnVerification.Text = "Lire";
            this.btnVerification.UseVisualStyleBackColor = true;
            this.btnVerification.Click += new System.EventHandler(this.btnVerification_Click);
            // 
            // numBox
            // 
            this.numBox.Location = new System.Drawing.Point(20, 123);
            this.numBox.Name = "numBox";
            this.numBox.Size = new System.Drawing.Size(104, 20);
            this.numBox.TabIndex = 5;
            // 
            // numContainer
            // 
            this.numContainer.Location = new System.Drawing.Point(153, 123);
            this.numContainer.Name = "numContainer";
            this.numContainer.Size = new System.Drawing.Size(111, 20);
            this.numContainer.TabIndex = 5;
            // 
            // numDevice
            // 
            this.numDevice.Location = new System.Drawing.Point(291, 123);
            this.numDevice.Name = "numDevice";
            this.numDevice.Size = new System.Drawing.Size(111, 20);
            this.numDevice.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(268, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 29);
            this.label6.TabIndex = 4;
            this.label6.Text = ".";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(128, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = ".";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(286, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Numéros du l\'appareille";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(297, 178);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Support de stockage";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(150, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Type de fichier";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(303, 244);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(201, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Nom de la personne faisant la vérification";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 244);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(264, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Nom de la personne ayant fait la première récupération";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 178);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Nom du fichier";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Numéros du contenant";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Numéros de la boîte";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lettre de disque amovible (E, F, G, ...)";
            // 
            // txtFileName
            // 
            this.txtFileName.AcceptsReturn = true;
            this.txtFileName.AcceptsTab = true;
            this.txtFileName.Location = new System.Drawing.Point(17, 194);
            this.txtFileName.MaxLength = 15;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(107, 20);
            this.txtFileName.TabIndex = 2;
            // 
            // txtLettre
            // 
            this.txtLettre.Location = new System.Drawing.Point(17, 63);
            this.txtLettre.MaxLength = 1;
            this.txtLettre.Name = "txtLettre";
            this.txtLettre.Size = new System.Drawing.Size(185, 20);
            this.txtLettre.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.checkFlag);
            this.groupBox3.Controls.Add(this.comboEmployeSearch);
            this.groupBox3.Controls.Add(this.comboDeviceTypeSearch);
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Controls.Add(this.numBoxSearch);
            this.groupBox3.Controls.Add(this.numContainerSearch);
            this.groupBox3.Controls.Add(this.numDeviceSearch);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.txtKeyword);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Location = new System.Drawing.Point(705, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(494, 821);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Recherche dans les Archives";
            this.groupBox3.UseCompatibleTextRendering = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.txtYear);
            this.groupBox5.Controls.Add(this.comboMonths);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.txtDay);
            this.groupBox5.Location = new System.Drawing.Point(16, 432);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(440, 161);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Date";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 98);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 13);
            this.label16.TabIndex = 3;
            this.label16.Text = "Jours";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(62, 34);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(253, 20);
            this.txtYear.TabIndex = 2;
            // 
            // comboMonths
            // 
            this.comboMonths.FormattingEnabled = true;
            this.comboMonths.Location = new System.Drawing.Point(62, 64);
            this.comboMonths.Name = "comboMonths";
            this.comboMonths.Size = new System.Drawing.Size(253, 21);
            this.comboMonths.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Année";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 69);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "Mois";
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(63, 94);
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(252, 20);
            this.txtDay.TabIndex = 2;
            // 
            // checkFlag
            // 
            this.checkFlag.AutoSize = true;
            this.checkFlag.Location = new System.Drawing.Point(34, 774);
            this.checkFlag.Name = "checkFlag";
            this.checkFlag.Size = new System.Drawing.Size(234, 17);
            this.checkFlag.TabIndex = 4;
            this.checkFlag.Text = "Inclure les support de stockage avec un tag";
            this.checkFlag.UseVisualStyleBackColor = true;
            // 
            // comboEmployeSearch
            // 
            this.comboEmployeSearch.FormattingEnabled = true;
            this.comboEmployeSearch.Location = new System.Drawing.Point(15, 132);
            this.comboEmployeSearch.Name = "comboEmployeSearch";
            this.comboEmployeSearch.Size = new System.Drawing.Size(302, 21);
            this.comboEmployeSearch.TabIndex = 6;
            // 
            // comboDeviceTypeSearch
            // 
            this.comboDeviceTypeSearch.FormattingEnabled = true;
            this.comboDeviceTypeSearch.Location = new System.Drawing.Point(15, 207);
            this.comboDeviceTypeSearch.Name = "comboDeviceTypeSearch";
            this.comboDeviceTypeSearch.Size = new System.Drawing.Size(302, 21);
            this.comboDeviceTypeSearch.Sorted = true;
            this.comboDeviceTypeSearch.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(283, 758);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(173, 46);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Rechercher";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // numBoxSearch
            // 
            this.numBoxSearch.Location = new System.Drawing.Point(29, 351);
            this.numBoxSearch.Name = "numBoxSearch";
            this.numBoxSearch.Size = new System.Drawing.Size(104, 20);
            this.numBoxSearch.TabIndex = 5;
            // 
            // numContainerSearch
            // 
            this.numContainerSearch.Location = new System.Drawing.Point(162, 351);
            this.numContainerSearch.Name = "numContainerSearch";
            this.numContainerSearch.Size = new System.Drawing.Size(111, 20);
            this.numContainerSearch.TabIndex = 5;
            // 
            // numDeviceSearch
            // 
            this.numDeviceSearch.Location = new System.Drawing.Point(300, 351);
            this.numDeviceSearch.Name = "numDeviceSearch";
            this.numDeviceSearch.Size = new System.Drawing.Size(111, 20);
            this.numDeviceSearch.TabIndex = 5;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(277, 341);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(19, 29);
            this.label25.TabIndex = 4;
            this.label25.Text = ".";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(137, 341);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(19, 29);
            this.label24.TabIndex = 4;
            this.label24.Text = ".";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Mot clé";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(295, 331);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(116, 13);
            this.label23.TabIndex = 3;
            this.label23.Text = "Numéros du l\'appareille";
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(15, 52);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(253, 20);
            this.txtKeyword.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 116);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(308, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Nom d\'une personne impliqué dans la récupération d\'un appareil";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(159, 331);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(115, 13);
            this.label21.TabIndex = 3;
            this.label21.Text = "Numéros du contenant";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 192);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(106, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "Support de stockage";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(28, 331);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(103, 13);
            this.label20.TabIndex = 3;
            this.label20.Text = "Numéros de la boîte";
            // 
            // Myform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 845);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Myform";
            this.Text = "Archive de données";
            this.Load += new System.EventHandler(this.Myform_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDevice)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numContainerSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDeviceSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstArchivage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numDevice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLettre;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnVerification;
        private System.Windows.Forms.NumericUpDown numBox;
        private System.Windows.Forms.NumericUpDown numContainer;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnEmploye;
        private System.Windows.Forms.ComboBox comboBoxSecond;
        private System.Windows.Forms.ComboBox comboBoxFirst;
        private System.Windows.Forms.ComboBox combotxtStorageContainer;
        private System.Windows.Forms.ComboBox comboTypeFile;
        private System.Windows.Forms.CheckBox checkFlag;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.ComboBox comboEmployeSearch;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboMonths;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.NumericUpDown numBoxSearch;
        private System.Windows.Forms.NumericUpDown numContainerSearch;
        private System.Windows.Forms.NumericUpDown numDeviceSearch;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.ComboBox comboDeviceTypeSearch;
        private System.Windows.Forms.Label label17;
    }
}

