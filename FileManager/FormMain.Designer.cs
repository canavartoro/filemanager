namespace FileManager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.notifyIconApp = new System.Windows.Forms.NotifyIcon(this.components);
            this.timerStartup = new System.Windows.Forms.Timer(this.components);
            this.pnlTrace = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTrace = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitter = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView = new System.Windows.Forms.ListView();
            this.chSira = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAdi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chBoyut = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTarih = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDurum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnuList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yenileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpd = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSend = new System.Windows.Forms.ToolStripMenuItem();
            this.bntOpenTrace = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLogClear = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.imgstatu = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnAyarlar = new System.Windows.Forms.ToolStripButton();
            this.timerJop = new System.Windows.Forms.Timer(this.components);
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            this.pnlTrace.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.mnuList.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.SynchronizingObject = this;
            this.fileSystemWatcher.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Changed);
            this.fileSystemWatcher.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Created);
            // 
            // notifyIconApp
            // 
            this.notifyIconApp.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIconApp.BalloonTipText = "Teknik Resim İzleme Servisi";
            this.notifyIconApp.BalloonTipTitle = "Uyumsoft";
            this.notifyIconApp.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconApp.Icon")));
            this.notifyIconApp.Text = "UyumSoft";
            this.notifyIconApp.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconApp_MouseDoubleClick);
            // 
            // timerStartup
            // 
            this.timerStartup.Enabled = true;
            this.timerStartup.Tick += new System.EventHandler(this.timerStartup_Tick);
            // 
            // pnlTrace
            // 
            this.pnlTrace.Controls.Add(this.panel1);
            this.pnlTrace.Controls.Add(this.toolStrip1);
            this.pnlTrace.Controls.Add(this.statusStrip1);
            this.pnlTrace.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTrace.Location = new System.Drawing.Point(0, 475);
            this.pnlTrace.Name = "pnlTrace";
            this.pnlTrace.Size = new System.Drawing.Size(939, 225);
            this.pnlTrace.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTrace);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(939, 178);
            this.panel1.TabIndex = 2;
            // 
            // richTrace
            // 
            this.richTrace.BackColor = System.Drawing.SystemColors.Info;
            this.richTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTrace.Location = new System.Drawing.Point(0, 0);
            this.richTrace.Name = "richTrace";
            this.richTrace.Size = new System.Drawing.Size(939, 178);
            this.richTrace.TabIndex = 0;
            this.richTrace.TabStop = false;
            this.richTrace.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(939, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.btnLogClear_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.bntOpenTrace_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 203);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(939, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitter
            // 
            this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter.Location = new System.Drawing.Point(0, 472);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(939, 3);
            this.splitter.TabIndex = 1;
            this.splitter.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listView);
            this.panel2.Controls.Add(this.toolStrip2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(939, 472);
            this.panel2.TabIndex = 2;
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSira,
            this.chAdi,
            this.chBoyut,
            this.chTarih,
            this.chDurum,
            this.chMail});
            this.listView.ContextMenuStrip = this.mnuList;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.LargeImageList = this.imgstatu;
            this.listView.Location = new System.Drawing.Point(0, 25);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(939, 447);
            this.listView.SmallImageList = this.imgstatu;
            this.listView.StateImageList = this.imgstatu;
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // chSira
            // 
            this.chSira.Text = "Sıra";
            this.chSira.Width = 74;
            // 
            // chAdi
            // 
            this.chAdi.Text = "Dosya Adı";
            this.chAdi.Width = 183;
            // 
            // chBoyut
            // 
            this.chBoyut.Text = "Boyut";
            this.chBoyut.Width = 145;
            // 
            // chTarih
            // 
            this.chTarih.Text = "Tarih";
            this.chTarih.Width = 199;
            // 
            // chDurum
            // 
            this.chDurum.Text = "Aktarım";
            this.chDurum.Width = 400;
            // 
            // chMail
            // 
            this.chMail.Text = "Mail";
            this.chMail.Width = 210;
            // 
            // mnuList
            // 
            this.mnuList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yenileToolStripMenuItem,
            this.btnDel,
            this.btnUpd,
            this.btnSend,
            this.bntOpenTrace,
            this.btnLogClear,
            this.btnSettings});
            this.mnuList.Name = "mnuList";
            this.mnuList.Size = new System.Drawing.Size(159, 158);
            this.mnuList.Opening += new System.ComponentModel.CancelEventHandler(this.mnuList_Opening);
            // 
            // yenileToolStripMenuItem
            // 
            this.yenileToolStripMenuItem.Name = "yenileToolStripMenuItem";
            this.yenileToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.yenileToolStripMenuItem.Text = "Yenile";
            this.yenileToolStripMenuItem.Click += new System.EventHandler(this.yenileToolStripMenuItem_Click);
            // 
            // btnDel
            // 
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(158, 22);
            this.btnDel.Text = "Kaydı Sil";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnUpd
            // 
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(158, 22);
            this.btnUpd.Text = "Gönderildi Yap";
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // btnSend
            // 
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(158, 22);
            this.btnSend.Text = "Yeniden Gönder";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // bntOpenTrace
            // 
            this.bntOpenTrace.Name = "bntOpenTrace";
            this.bntOpenTrace.Size = new System.Drawing.Size(158, 22);
            this.bntOpenTrace.Text = "Logları Aç";
            this.bntOpenTrace.Click += new System.EventHandler(this.bntOpenTrace_Click);
            // 
            // btnLogClear
            // 
            this.btnLogClear.Name = "btnLogClear";
            this.btnLogClear.Size = new System.Drawing.Size(158, 22);
            this.btnLogClear.Text = "Logları Temizle";
            this.btnLogClear.Click += new System.EventHandler(this.btnLogClear_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(158, 22);
            this.btnSettings.Text = "Ayarlar";
            this.btnSettings.Click += new System.EventHandler(this.btnAyarlar_Click);
            // 
            // imgstatu
            // 
            this.imgstatu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgstatu.ImageStream")));
            this.imgstatu.TransparentColor = System.Drawing.Color.Transparent;
            this.imgstatu.Images.SetKeyName(0, "flag-black.png");
            this.imgstatu.Images.SetKeyName(1, "flag-green.png");
            this.imgstatu.Images.SetKeyName(2, "flag-red.png");
            this.imgstatu.Images.SetKeyName(3, "flag-yellow.png");
            this.imgstatu.Images.SetKeyName(4, "flag-blue.png");
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAyarlar,
            this.toolStripButton3});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(939, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAyarlar.Image = ((System.Drawing.Image)(resources.GetObject("btnAyarlar.Image")));
            this.btnAyarlar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Size = new System.Drawing.Size(23, 22);
            this.btnAyarlar.Text = "Ayarlar";
            this.btnAyarlar.Click += new System.EventHandler(this.btnAyarlar_Click);
            // 
            // timerJop
            // 
            this.timerJop.Interval = 60000;
            this.timerJop.Tick += new System.EventHandler(this.timerJop_Tick);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Kodu Göster";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 700);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.pnlTrace);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Teknik Resim İzleme Servisi (Uyumsoft)";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            this.pnlTrace.ResumeLayout(false);
            this.pnlTrace.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.mnuList.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.FileSystemWatcher fileSystemWatcher;
        private System.Windows.Forms.NotifyIcon notifyIconApp;
        private System.Windows.Forms.Timer timerStartup;
        private System.Windows.Forms.Panel pnlTrace;
        private System.Windows.Forms.Splitter splitter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTrace;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ColumnHeader chSira;
        private System.Windows.Forms.ColumnHeader chAdi;
        private System.Windows.Forms.ColumnHeader chBoyut;
        private System.Windows.Forms.ColumnHeader chTarih;
        private System.Windows.Forms.ColumnHeader chDurum;
        private System.Windows.Forms.Timer timerJop;
        private System.Windows.Forms.ToolStripButton btnAyarlar;
        private System.Windows.Forms.ContextMenuStrip mnuList;
        private System.Windows.Forms.ToolStripMenuItem btnDel;
        private System.Windows.Forms.ToolStripMenuItem btnUpd;
        private System.Windows.Forms.ToolStripMenuItem btnSend;
        private System.Windows.Forms.ToolStripMenuItem bntOpenTrace;
        private System.Windows.Forms.ToolStripMenuItem btnLogClear;
        private System.Windows.Forms.ToolStripMenuItem btnSettings;
        private System.Windows.Forms.ImageList imgstatu;
        private System.Windows.Forms.ColumnHeader chMail;
        private System.Windows.Forms.ToolStripMenuItem yenileToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}