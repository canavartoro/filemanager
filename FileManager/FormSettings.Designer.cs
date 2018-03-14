namespace FileManager
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.nmcoid = new System.Windows.Forms.NumericUpDown();
            this.nmTimeout = new System.Windows.Forms.NumericUpDown();
            this.nmbranchid = new System.Windows.Forms.NumericUpDown();
            this.nmoraport = new System.Windows.Forms.NumericUpDown();
            this.nmmailport = new System.Windows.Forms.NumericUpDown();
            this.nmuserid = new System.Windows.Forms.NumericUpDown();
            this.btnHedefFold = new System.Windows.Forms.Button();
            this.btnKaynakFolder = new System.Windows.Forms.Button();
            this.txtHedefKlasor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKaynakKlasor = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMailPass = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMailUser = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMailHost = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtServis = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkstatu = new System.Windows.Forms.CheckBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.chAdi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAdres = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chGonderim = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkTest = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmcoid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmbranchid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmoraport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmmailport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmuserid)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 494);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(756, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(415, 23);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(159, 48);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Kaydet";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(581, 23);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(159, 48);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Vazgeç";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(756, 494);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkTest);
            this.tabPage1.Controls.Add(this.nmcoid);
            this.tabPage1.Controls.Add(this.nmTimeout);
            this.tabPage1.Controls.Add(this.nmbranchid);
            this.tabPage1.Controls.Add(this.nmoraport);
            this.tabPage1.Controls.Add(this.nmmailport);
            this.tabPage1.Controls.Add(this.nmuserid);
            this.tabPage1.Controls.Add(this.btnHedefFold);
            this.tabPage1.Controls.Add(this.btnKaynakFolder);
            this.tabPage1.Controls.Add(this.txtHedefKlasor);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtKaynakKlasor);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtMailPass);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.txtMailUser);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.txtMailHost);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtServis);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtHost);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(748, 465);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ayarlar";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // nmcoid
            // 
            this.nmcoid.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::FileManager.Properties.Settings.Default, "coid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nmcoid.Location = new System.Drawing.Point(143, 143);
            this.nmcoid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nmcoid.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nmcoid.Name = "nmcoid";
            this.nmcoid.Size = new System.Drawing.Size(160, 22);
            this.nmcoid.TabIndex = 4;
            this.nmcoid.Value = global::FileManager.Properties.Settings.Default.coid;
            // 
            // nmTimeout
            // 
            this.nmTimeout.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::FileManager.Properties.Settings.Default, "sure", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nmTimeout.Location = new System.Drawing.Point(529, 81);
            this.nmTimeout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nmTimeout.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nmTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmTimeout.Name = "nmTimeout";
            this.nmTimeout.Size = new System.Drawing.Size(160, 22);
            this.nmTimeout.TabIndex = 14;
            this.nmTimeout.Value = global::FileManager.Properties.Settings.Default.sure;
            // 
            // nmbranchid
            // 
            this.nmbranchid.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::FileManager.Properties.Settings.Default, "branchid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nmbranchid.Location = new System.Drawing.Point(143, 111);
            this.nmbranchid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nmbranchid.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nmbranchid.Name = "nmbranchid";
            this.nmbranchid.Size = new System.Drawing.Size(160, 22);
            this.nmbranchid.TabIndex = 3;
            this.nmbranchid.Value = global::FileManager.Properties.Settings.Default.branchid;
            // 
            // nmoraport
            // 
            this.nmoraport.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::FileManager.Properties.Settings.Default, "oraport", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nmoraport.Location = new System.Drawing.Point(143, 79);
            this.nmoraport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nmoraport.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nmoraport.Name = "nmoraport";
            this.nmoraport.Size = new System.Drawing.Size(160, 22);
            this.nmoraport.TabIndex = 2;
            this.nmoraport.Value = global::FileManager.Properties.Settings.Default.oraport;
            // 
            // nmmailport
            // 
            this.nmmailport.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::FileManager.Properties.Settings.Default, "mailport", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nmmailport.Location = new System.Drawing.Point(143, 239);
            this.nmmailport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nmmailport.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nmmailport.Name = "nmmailport";
            this.nmmailport.Size = new System.Drawing.Size(160, 22);
            this.nmmailport.TabIndex = 7;
            this.nmmailport.Value = global::FileManager.Properties.Settings.Default.mailport;
            // 
            // nmuserid
            // 
            this.nmuserid.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::FileManager.Properties.Settings.Default, "userid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nmuserid.Location = new System.Drawing.Point(143, 175);
            this.nmuserid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nmuserid.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nmuserid.Name = "nmuserid";
            this.nmuserid.Size = new System.Drawing.Size(160, 22);
            this.nmuserid.TabIndex = 5;
            this.nmuserid.Value = global::FileManager.Properties.Settings.Default.userid;
            // 
            // btnHedefFold
            // 
            this.btnHedefFold.Location = new System.Drawing.Point(689, 428);
            this.btnHedefFold.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHedefFold.Name = "btnHedefFold";
            this.btnHedefFold.Size = new System.Drawing.Size(40, 25);
            this.btnHedefFold.TabIndex = 13;
            this.btnHedefFold.Text = "...";
            this.btnHedefFold.UseVisualStyleBackColor = true;
            this.btnHedefFold.Click += new System.EventHandler(this.btnHedefFold_Click);
            // 
            // btnKaynakFolder
            // 
            this.btnKaynakFolder.Location = new System.Drawing.Point(689, 398);
            this.btnKaynakFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnKaynakFolder.Name = "btnKaynakFolder";
            this.btnKaynakFolder.Size = new System.Drawing.Size(40, 25);
            this.btnKaynakFolder.TabIndex = 11;
            this.btnKaynakFolder.Text = "...";
            this.btnKaynakFolder.UseVisualStyleBackColor = true;
            this.btnKaynakFolder.Click += new System.EventHandler(this.btnKaynakFolder_Click);
            // 
            // txtHedefKlasor
            // 
            this.txtHedefKlasor.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FileManager.Properties.Settings.Default, "hedefklasor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtHedefKlasor.Location = new System.Drawing.Point(143, 430);
            this.txtHedefKlasor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtHedefKlasor.Name = "txtHedefKlasor";
            this.txtHedefKlasor.Size = new System.Drawing.Size(545, 22);
            this.txtHedefKlasor.TabIndex = 12;
            this.txtHedefKlasor.Text = global::FileManager.Properties.Settings.Default.hedefklasor;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(11, 433);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Hedef Klasör:";
            // 
            // txtKaynakKlasor
            // 
            this.txtKaynakKlasor.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FileManager.Properties.Settings.Default, "argeklasor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtKaynakKlasor.Location = new System.Drawing.Point(143, 398);
            this.txtKaynakKlasor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtKaynakKlasor.Name = "txtKaynakKlasor";
            this.txtKaynakKlasor.Size = new System.Drawing.Size(545, 22);
            this.txtKaynakKlasor.TabIndex = 10;
            this.txtKaynakKlasor.Text = global::FileManager.Properties.Settings.Default.argeklasor;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(11, 241);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 22);
            this.label9.TabIndex = 0;
            this.label9.Text = "Mail Port:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 401);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Arge Klasörü:";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(11, 177);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 22);
            this.label8.TabIndex = 0;
            this.label8.Text = "Oluşturan :";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(375, 84);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(147, 22);
            this.label15.TabIndex = 0;
            this.label15.Text = "Bekleme Süresi (dk):";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(11, 145);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 22);
            this.label7.TabIndex = 0;
            this.label7.Text = "İş Yeri Id:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(11, 113);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 22);
            this.label6.TabIndex = 0;
            this.label6.Text = "Firma Id:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(11, 81);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "Oracle Port:";
            // 
            // txtMailPass
            // 
            this.txtMailPass.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FileManager.Properties.Settings.Default, "mailpass", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtMailPass.Location = new System.Drawing.Point(143, 303);
            this.txtMailPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMailPass.Name = "txtMailPass";
            this.txtMailPass.PasswordChar = '*';
            this.txtMailPass.Size = new System.Drawing.Size(159, 22);
            this.txtMailPass.TabIndex = 9;
            this.txtMailPass.Text = global::FileManager.Properties.Settings.Default.mailpass;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(11, 306);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 22);
            this.label12.TabIndex = 0;
            this.label12.Text = "Mail Parola:";
            // 
            // txtMailUser
            // 
            this.txtMailUser.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FileManager.Properties.Settings.Default, "mailuser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtMailUser.Location = new System.Drawing.Point(143, 271);
            this.txtMailUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMailUser.Name = "txtMailUser";
            this.txtMailUser.Size = new System.Drawing.Size(159, 22);
            this.txtMailUser.TabIndex = 8;
            this.txtMailUser.Text = global::FileManager.Properties.Settings.Default.mailuser;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(11, 274);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 22);
            this.label11.TabIndex = 0;
            this.label11.Text = "Mail Adres:";
            // 
            // txtMailHost
            // 
            this.txtMailHost.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FileManager.Properties.Settings.Default, "mailhost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtMailHost.Location = new System.Drawing.Point(143, 207);
            this.txtMailHost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMailHost.Name = "txtMailHost";
            this.txtMailHost.Size = new System.Drawing.Size(159, 22);
            this.txtMailHost.TabIndex = 6;
            this.txtMailHost.Text = global::FileManager.Properties.Settings.Default.mailhost;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(11, 210);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 22);
            this.label10.TabIndex = 0;
            this.label10.Text = "Mail Host:";
            // 
            // txtServis
            // 
            this.txtServis.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FileManager.Properties.Settings.Default, "oraservis", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtServis.Location = new System.Drawing.Point(143, 46);
            this.txtServis.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtServis.Name = "txtServis";
            this.txtServis.Size = new System.Drawing.Size(199, 22);
            this.txtServis.TabIndex = 1;
            this.txtServis.Text = global::FileManager.Properties.Settings.Default.oraservis;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Oracle Servis:";
            // 
            // txtHost
            // 
            this.txtHost.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FileManager.Properties.Settings.Default, "orahost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtHost.Location = new System.Drawing.Point(143, 14);
            this.txtHost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(199, 22);
            this.txtHost.TabIndex = 0;
            this.txtHost.Text = global::FileManager.Properties.Settings.Default.orahost;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Oracle Host:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkstatu);
            this.tabPage2.Controls.Add(this.btnDel);
            this.tabPage2.Controls.Add(this.btnNew);
            this.tabPage2.Controls.Add(this.btnSave);
            this.tabPage2.Controls.Add(this.txtAdres);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.txtAd);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.listView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(748, 465);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mail Adresleri";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkstatu
            // 
            this.chkstatu.AutoSize = true;
            this.chkstatu.Location = new System.Drawing.Point(483, 193);
            this.chkstatu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkstatu.Name = "chkstatu";
            this.chkstatu.Size = new System.Drawing.Size(131, 21);
            this.chkstatu.TabIndex = 4;
            this.chkstatu.Text = "Mail Gönderilsin";
            this.chkstatu.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(491, 407);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(77, 31);
            this.btnDel.TabIndex = 3;
            this.btnDel.Text = "Sil";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(576, 407);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(77, 31);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "Yeni";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(657, 407);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 31);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAdres
            // 
            this.txtAdres.Location = new System.Drawing.Point(483, 150);
            this.txtAdres.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(251, 22);
            this.txtAdres.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(479, 118);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(256, 28);
            this.label14.TabIndex = 1;
            this.label14.Text = "Adres";
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(483, 86);
            this.txtAd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(251, 22);
            this.txtAd.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(479, 54);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(256, 28);
            this.label13.TabIndex = 1;
            this.label13.Text = "İsim";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chAdi,
            this.chAdres,
            this.chGonderim});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(11, 38);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(463, 399);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // chAdi
            // 
            this.chAdi.Text = "Adı";
            this.chAdi.Width = 110;
            // 
            // chAdres
            // 
            this.chAdres.Text = "Adres";
            this.chAdres.Width = 210;
            // 
            // chGonderim
            // 
            this.chGonderim.Text = "Gönderilsin";
            this.chGonderim.Width = 100;
            // 
            // chkTest
            // 
            this.chkTest.AutoSize = true;
            this.chkTest.Checked = global::FileManager.Properties.Settings.Default.test;
            this.chkTest.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::FileManager.Properties.Settings.Default, "test", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkTest.Location = new System.Drawing.Point(582, 131);
            this.chkTest.Name = "chkTest";
            this.chkTest.Size = new System.Drawing.Size(107, 21);
            this.chkTest.TabIndex = 15;
            this.chkTest.Text = "Test Sistemi";
            this.chkTest.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(756, 580);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FormSettings";
            this.Text = "Ayarlar";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmcoid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmbranchid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmoraport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmmailport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmuserid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtServis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKaynakKlasor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHedefKlasor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnHedefFold;
        private System.Windows.Forms.Button btnKaynakFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nmuserid;
        private System.Windows.Forms.NumericUpDown nmcoid;
        private System.Windows.Forms.NumericUpDown nmbranchid;
        private System.Windows.Forms.NumericUpDown nmoraport;
        private System.Windows.Forms.NumericUpDown nmmailport;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMailHost;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMailUser;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMailPass;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ColumnHeader chAdi;
        private System.Windows.Forms.ColumnHeader chAdres;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkstatu;
        private System.Windows.Forms.NumericUpDown nmTimeout;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ColumnHeader chGonderim;
        private System.Windows.Forms.CheckBox chkTest;
    }
}