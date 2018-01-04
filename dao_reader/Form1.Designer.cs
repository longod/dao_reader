namespace dao_reader {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form1 ) );
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCopyAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCopyAllTab = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemSearchNext = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSearchPrev = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExpand = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExpandAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCollapse = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOption = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxConversation = new System.Windows.Forms.TextBox();
            this.textBoxListener = new System.Windows.Forms.TextBox();
            this.textBoxSpeaker = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.toolStripMenuItemEdit,
            this.toolStripMenuItemView,
            this.toolStripMenuItemHelp} );
            this.menuStrip1.Location = new System.Drawing.Point( 0, 0 );
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size( 792, 24 );
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.menuItemOpen,
            this.toolStripSeparator2,
            this.menuItemExit} );
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size( 36, 20 );
            this.toolStripMenuItemFile.Text = "&File";
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Image = ( ( System.Drawing.Image )( resources.GetObject( "menuItemOpen.Image" ) ) );
            this.menuItemOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuItemOpen.Name = "menuItemOpen";
            this.menuItemOpen.ShortcutKeys = ( ( System.Windows.Forms.Keys )( ( System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O ) ) );
            this.menuItemOpen.Size = new System.Drawing.Size( 134, 22 );
            this.menuItemOpen.Text = "&Open";
            this.menuItemOpen.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size( 131, 6 );
            this.toolStripSeparator2.Visible = false;
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.ShortcutKeys = ( ( System.Windows.Forms.Keys )( ( System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q ) ) );
            this.menuItemExit.Size = new System.Drawing.Size( 134, 22 );
            this.menuItemExit.Text = "&Exit";
            this.menuItemExit.Click += new System.EventHandler( this.menuItemExit_Click );
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCopy,
            this.menuItemCopyAll,
            this.menuItemCopyAllTab,
            this.toolStripSeparator1,
            this.menuItemSearch,
            this.toolStripSeparator3,
            this.menuItemSearchNext,
            this.menuItemSearchPrev,
            this.toolStripSeparator4,
            this.menuItemExpand,
            this.menuItemExpandAll,
            this.menuItemCollapse,
            this.menuItemCollapseAll} );
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size( 37, 20 );
            this.toolStripMenuItemEdit.Text = "&Edit";
            // 
            // menuItemCopy
            // 
            this.menuItemCopy.Image = ( ( System.Drawing.Image )( resources.GetObject( "menuItemCopy.Image" ) ) );
            this.menuItemCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuItemCopy.Name = "menuItemCopy";
            this.menuItemCopy.ShortcutKeys = ( ( System.Windows.Forms.Keys )( ( System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C ) ) );
            this.menuItemCopy.Size = new System.Drawing.Size( 231, 22 );
            this.menuItemCopy.Text = "&Copy";
            this.menuItemCopy.Click += new System.EventHandler( this.menuItemCopy_Click );
            // 
            // menuItemCopyAll
            // 
            this.menuItemCopyAll.Name = "menuItemCopyAll";
            this.menuItemCopyAll.ShortcutKeys = ( ( System.Windows.Forms.Keys )( ( ( System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift )
                        | System.Windows.Forms.Keys.C ) ) );
            this.menuItemCopyAll.Size = new System.Drawing.Size( 231, 22 );
            this.menuItemCopyAll.Text = "Copy &All";
            this.menuItemCopyAll.Click += new System.EventHandler( this.menuItemCopyAll_Click );
            // 
            // menuItemCopyAllTab
            // 
            this.menuItemCopyAllTab.Name = "menuItemCopyAllTab";
            this.menuItemCopyAllTab.ShortcutKeys = ( ( System.Windows.Forms.Keys )( ( ( ( System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt )
                        | System.Windows.Forms.Keys.Shift )
                        | System.Windows.Forms.Keys.C ) ) );
            this.menuItemCopyAllTab.Size = new System.Drawing.Size( 231, 22 );
            this.menuItemCopyAllTab.Text = "Co&py All (&tab)";
            this.menuItemCopyAllTab.Click += new System.EventHandler( this.menuItemCopyTabAll_Click );
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size( 228, 6 );
            // 
            // menuItemSearch
            // 
            this.menuItemSearch.Name = "menuItemSearch";
            this.menuItemSearch.ShortcutKeys = ( ( System.Windows.Forms.Keys )( ( System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F ) ) );
            this.menuItemSearch.Size = new System.Drawing.Size( 231, 22 );
            this.menuItemSearch.Text = "&Search";
            this.menuItemSearch.Click += new System.EventHandler( this.menuItemSearch_Click );
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size( 228, 6 );
            // 
            // menuItemSearchNext
            // 
            this.menuItemSearchNext.Name = "menuItemSearchNext";
            this.menuItemSearchNext.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.menuItemSearchNext.Size = new System.Drawing.Size( 231, 22 );
            this.menuItemSearchNext.Text = "Search &Next";
            this.menuItemSearchNext.Click += new System.EventHandler( this.menuItemSearchNext_Click );
            // 
            // menuItemSearchPrev
            // 
            this.menuItemSearchPrev.Name = "menuItemSearchPrev";
            this.menuItemSearchPrev.ShortcutKeys = ( ( System.Windows.Forms.Keys )( ( System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F3 ) ) );
            this.menuItemSearchPrev.Size = new System.Drawing.Size( 231, 22 );
            this.menuItemSearchPrev.Text = "Search &Preview";
            this.menuItemSearchPrev.Click += new System.EventHandler( this.menuItemSearchPrev_Click );
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size( 228, 6 );
            // 
            // menuItemExpand
            // 
            this.menuItemExpand.Name = "menuItemExpand";
            this.menuItemExpand.ShortcutKeys = ( ( System.Windows.Forms.Keys )( ( System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E ) ) );
            this.menuItemExpand.Size = new System.Drawing.Size( 231, 22 );
            this.menuItemExpand.Text = "&Expand";
            this.menuItemExpand.Click += new System.EventHandler( this.menuItemExpand_Click );
            // 
            // menuItemExpandAll
            // 
            this.menuItemExpandAll.Name = "menuItemExpandAll";
            this.menuItemExpandAll.ShortcutKeys = ( ( System.Windows.Forms.Keys )( ( ( System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift )
                        | System.Windows.Forms.Keys.E ) ) );
            this.menuItemExpandAll.Size = new System.Drawing.Size( 231, 22 );
            this.menuItemExpandAll.Text = "E&xpand All";
            this.menuItemExpandAll.Click += new System.EventHandler( this.menuItemExpandAll_Click );
            // 
            // menuItemCollapse
            // 
            this.menuItemCollapse.Name = "menuItemCollapse";
            this.menuItemCollapse.ShortcutKeys = ( ( System.Windows.Forms.Keys )( ( System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W ) ) );
            this.menuItemCollapse.Size = new System.Drawing.Size( 231, 22 );
            this.menuItemCollapse.Text = "C&ollapse";
            this.menuItemCollapse.Click += new System.EventHandler( this.menuItemCollapse_Click );
            // 
            // menuItemCollapseAll
            // 
            this.menuItemCollapseAll.Name = "menuItemCollapseAll";
            this.menuItemCollapseAll.ShortcutKeys = ( ( System.Windows.Forms.Keys )( ( ( System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift )
                        | System.Windows.Forms.Keys.W ) ) );
            this.menuItemCollapseAll.Size = new System.Drawing.Size( 231, 22 );
            this.menuItemCollapseAll.Text = "Co&llapse All";
            this.menuItemCollapseAll.Click += new System.EventHandler( this.menuItemCollapseAll_Click );
            // 
            // toolStripMenuItemView
            // 
            this.toolStripMenuItemView.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.menuItemOption} );
            this.toolStripMenuItemView.Name = "toolStripMenuItemView";
            this.toolStripMenuItemView.Size = new System.Drawing.Size( 42, 20 );
            this.toolStripMenuItemView.Text = "&View";
            // 
            // menuItemOption
            // 
            this.menuItemOption.Name = "menuItemOption";
            this.menuItemOption.Size = new System.Drawing.Size( 106, 22 );
            this.menuItemOption.Text = "&Setting";
            this.menuItemOption.Click += new System.EventHandler( this.menuItemSetting_Click );
            // 
            // toolStripMenuItemHelp
            // 
            this.toolStripMenuItemHelp.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.menuItemVersion} );
            this.toolStripMenuItemHelp.Name = "toolStripMenuItemHelp";
            this.toolStripMenuItemHelp.Size = new System.Drawing.Size( 40, 20 );
            this.toolStripMenuItemHelp.Text = "&Help";
            // 
            // menuItemVersion
            // 
            this.menuItemVersion.Name = "menuItemVersion";
            this.menuItemVersion.Size = new System.Drawing.Size( 100, 22 );
            this.menuItemVersion.Text = "&About";
            this.menuItemVersion.Click += new System.EventHandler( this.menuItemVersion_Click );
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.textBoxConversation );
            this.panel1.Controls.Add( this.textBoxListener );
            this.panel1.Controls.Add( this.textBoxSpeaker );
            this.panel1.Controls.Add( this.textBoxID );
            this.panel1.Controls.Add( this.label3 );
            this.panel1.Controls.Add( this.label2 );
            this.panel1.Controls.Add( this.label1 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point( 0, 24 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 792, 79 );
            this.panel1.TabIndex = 3;
            // 
            // textBoxConversation
            // 
            this.textBoxConversation.Location = new System.Drawing.Point( 173, 3 );
            this.textBoxConversation.Multiline = true;
            this.textBoxConversation.Name = "textBoxConversation";
            this.textBoxConversation.ReadOnly = true;
            this.textBoxConversation.Size = new System.Drawing.Size( 607, 72 );
            this.textBoxConversation.TabIndex = 3;
            // 
            // textBoxListener
            // 
            this.textBoxListener.Location = new System.Drawing.Point( 67, 56 );
            this.textBoxListener.Name = "textBoxListener";
            this.textBoxListener.ReadOnly = true;
            this.textBoxListener.Size = new System.Drawing.Size( 100, 19 );
            this.textBoxListener.TabIndex = 5;
            // 
            // textBoxSpeaker
            // 
            this.textBoxSpeaker.Location = new System.Drawing.Point( 67, 31 );
            this.textBoxSpeaker.Name = "textBoxSpeaker";
            this.textBoxSpeaker.ReadOnly = true;
            this.textBoxSpeaker.Size = new System.Drawing.Size( 100, 19 );
            this.textBoxSpeaker.TabIndex = 4;
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point( 67, 6 );
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.ReadOnly = true;
            this.textBoxID.Size = new System.Drawing.Size( 100, 19 );
            this.textBoxID.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 3, 59 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 58, 12 );
            this.label3.TabIndex = 2;
            this.label3.Text = "LISTENER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 5, 34 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 56, 12 );
            this.label2.TabIndex = 1;
            this.label2.Text = "SPEAKER";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 45, 9 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 16, 12 );
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point( 0, 103 );
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size( 792, 3 );
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            this.splitter1.Visible = false;
            // 
            // statusStrip
            // 
            this.statusStrip.AutoSize = false;
            this.statusStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel} );
            this.statusStrip.Location = new System.Drawing.Point( 0, 551 );
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size( 792, 22 );
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size( 65, 17 );
            this.toolStripStatusLabel.Text = "StatusLabel";
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point( 0, 106 );
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size( 792, 445 );
            this.tabControl.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 792, 573 );
            this.Controls.Add( this.tabControl );
            this.Controls.Add( this.splitter1 );
            this.Controls.Add( this.panel1 );
            this.Controls.Add( this.statusStrip );
            this.Controls.Add( this.menuStrip1 );
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Dragon Age Conversation Reader";
            this.menuStrip1.ResumeLayout( false );
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout( false );
            this.panel1.PerformLayout();
            this.statusStrip.ResumeLayout( false );
            this.statusStrip.PerformLayout();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem menuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemView;
        private System.Windows.Forms.ToolStripMenuItem menuItemOption;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem menuItemVersion;
        private System.Windows.Forms.TextBox textBoxConversation;
        private System.Windows.Forms.TextBox textBoxListener;
        private System.Windows.Forms.TextBox textBoxSpeaker;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem menuItemSearch;
        private System.Windows.Forms.ToolStripMenuItem menuItemSearchNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemSearchPrev;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem menuItemExpandAll;
        private System.Windows.Forms.ToolStripMenuItem menuItemExpand;
        private System.Windows.Forms.ToolStripMenuItem menuItemCollapseAll;
        private System.Windows.Forms.ToolStripMenuItem menuItemCollapse;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ToolStripMenuItem menuItemCopyAll;
        private System.Windows.Forms.ToolStripMenuItem menuItemCopyAllTab;
    }
}

