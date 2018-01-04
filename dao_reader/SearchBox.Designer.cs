namespace dao_reader {
    partial class SearchBox {
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
            this.textBoxSearchWord = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonSearchPrev = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.comboBoxRange = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxListener = new System.Windows.Forms.CheckBox();
            this.checkBoxSpeaker = new System.Windows.Forms.CheckBox();
            this.checkBoxText = new System.Windows.Forms.CheckBox();
            this.checkBoxID = new System.Windows.Forms.CheckBox();
            this.checkBoxChar = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxLoop = new System.Windows.Forms.CheckBox();
            this.checkBoxRegularExpression = new System.Windows.Forms.CheckBox();
            this.checkBoxComplete = new System.Windows.Forms.CheckBox();
            this.checkBoxExpand = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSearchWord
            // 
            this.textBoxSearchWord.Location = new System.Drawing.Point( 104, 12 );
            this.textBoxSearchWord.Name = "textBoxSearchWord";
            this.textBoxSearchWord.Size = new System.Drawing.Size( 186, 19 );
            this.textBoxSearchWord.TabIndex = 0;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point( 303, 12 );
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size( 75, 23 );
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "次を検索(&S)";
            this.buttonSearch.UseVisualStyleBackColor = true;
            // 
            // buttonSearchPrev
            // 
            this.buttonSearchPrev.Location = new System.Drawing.Point( 303, 41 );
            this.buttonSearchPrev.Name = "buttonSearchPrev";
            this.buttonSearchPrev.Size = new System.Drawing.Size( 75, 23 );
            this.buttonSearchPrev.TabIndex = 2;
            this.buttonSearchPrev.Text = "前を検索(&P)";
            this.buttonSearchPrev.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point( 303, 147 );
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size( 75, 23 );
            this.buttonClose.TabIndex = 13;
            this.buttonClose.Text = "閉じる(&W)";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler( this.buttonClose_Click );
            // 
            // comboBoxRange
            // 
            this.comboBoxRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRange.FormattingEnabled = true;
            this.comboBoxRange.Location = new System.Drawing.Point( 104, 37 );
            this.comboBoxRange.Name = "comboBoxRange";
            this.comboBoxRange.Size = new System.Drawing.Size( 186, 20 );
            this.comboBoxRange.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.checkBoxListener );
            this.groupBox1.Controls.Add( this.checkBoxSpeaker );
            this.groupBox1.Controls.Add( this.checkBoxText );
            this.groupBox1.Controls.Add( this.checkBoxID );
            this.groupBox1.Location = new System.Drawing.Point( 14, 63 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 84, 110 );
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "検索対象";
            // 
            // checkBoxListener
            // 
            this.checkBoxListener.AutoSize = true;
            this.checkBoxListener.Location = new System.Drawing.Point( 7, 88 );
            this.checkBoxListener.Name = "checkBoxListener";
            this.checkBoxListener.Size = new System.Drawing.Size( 65, 16 );
            this.checkBoxListener.TabIndex = 8;
            this.checkBoxListener.Text = "&Listener";
            this.checkBoxListener.UseVisualStyleBackColor = true;
            // 
            // checkBoxSpeaker
            // 
            this.checkBoxSpeaker.AutoSize = true;
            this.checkBoxSpeaker.Location = new System.Drawing.Point( 7, 65 );
            this.checkBoxSpeaker.Name = "checkBoxSpeaker";
            this.checkBoxSpeaker.Size = new System.Drawing.Size( 65, 16 );
            this.checkBoxSpeaker.TabIndex = 7;
            this.checkBoxSpeaker.Text = "&Speaker";
            this.checkBoxSpeaker.UseVisualStyleBackColor = true;
            // 
            // checkBoxText
            // 
            this.checkBoxText.AutoSize = true;
            this.checkBoxText.Location = new System.Drawing.Point( 7, 42 );
            this.checkBoxText.Name = "checkBoxText";
            this.checkBoxText.Size = new System.Drawing.Size( 47, 16 );
            this.checkBoxText.TabIndex = 6;
            this.checkBoxText.Text = "&Text";
            this.checkBoxText.UseVisualStyleBackColor = true;
            // 
            // checkBoxID
            // 
            this.checkBoxID.AutoSize = true;
            this.checkBoxID.Location = new System.Drawing.Point( 7, 19 );
            this.checkBoxID.Name = "checkBoxID";
            this.checkBoxID.Size = new System.Drawing.Size( 35, 16 );
            this.checkBoxID.TabIndex = 5;
            this.checkBoxID.Text = "&ID";
            this.checkBoxID.UseVisualStyleBackColor = true;
            // 
            // checkBoxChar
            // 
            this.checkBoxChar.AutoSize = true;
            this.checkBoxChar.Location = new System.Drawing.Point( 104, 113 );
            this.checkBoxChar.Name = "checkBoxChar";
            this.checkBoxChar.Size = new System.Drawing.Size( 182, 16 );
            this.checkBoxChar.TabIndex = 11;
            this.checkBoxChar.Text = "大文字と小文字を区別しない(&C)";
            this.checkBoxChar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 12, 15 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 86, 12 );
            this.label1.TabIndex = 20;
            this.label1.Text = "検索する文字列:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 43, 40 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 55, 12 );
            this.label2.TabIndex = 21;
            this.label2.Text = "検索範囲:";
            // 
            // checkBoxLoop
            // 
            this.checkBoxLoop.AutoSize = true;
            this.checkBoxLoop.Location = new System.Drawing.Point( 104, 135 );
            this.checkBoxLoop.Name = "checkBoxLoop";
            this.checkBoxLoop.Size = new System.Drawing.Size( 175, 16 );
            this.checkBoxLoop.TabIndex = 12;
            this.checkBoxLoop.Text = "終端に到達したら先頭に戻る(&L)";
            this.checkBoxLoop.UseVisualStyleBackColor = true;
            // 
            // checkBoxRegularExpression
            // 
            this.checkBoxRegularExpression.AutoSize = true;
            this.checkBoxRegularExpression.Location = new System.Drawing.Point( 104, 157 );
            this.checkBoxRegularExpression.Name = "checkBoxRegularExpression";
            this.checkBoxRegularExpression.Size = new System.Drawing.Size( 116, 16 );
            this.checkBoxRegularExpression.TabIndex = 13;
            this.checkBoxRegularExpression.Text = "正規表現を使う(&R)";
            this.checkBoxRegularExpression.UseVisualStyleBackColor = true;
            // 
            // checkBoxComplete
            // 
            this.checkBoxComplete.AutoSize = true;
            this.checkBoxComplete.Location = new System.Drawing.Point( 104, 91 );
            this.checkBoxComplete.Name = "checkBoxComplete";
            this.checkBoxComplete.Size = new System.Drawing.Size( 124, 16 );
            this.checkBoxComplete.TabIndex = 10;
            this.checkBoxComplete.Text = "完全一致（ID用）(&M)";
            this.checkBoxComplete.UseVisualStyleBackColor = true;
            // 
            // checkBoxExpand
            // 
            this.checkBoxExpand.AutoSize = true;
            this.checkBoxExpand.Location = new System.Drawing.Point( 104, 69 );
            this.checkBoxExpand.Name = "checkBoxExpand";
            this.checkBoxExpand.Size = new System.Drawing.Size( 148, 16 );
            this.checkBoxExpand.TabIndex = 9;
            this.checkBoxExpand.Text = "展開しているノードのみ(&E)";
            this.checkBoxExpand.UseVisualStyleBackColor = true;
            // 
            // SearchBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 390, 180 );
            this.Controls.Add( this.checkBoxExpand );
            this.Controls.Add( this.checkBoxComplete );
            this.Controls.Add( this.checkBoxRegularExpression );
            this.Controls.Add( this.checkBoxLoop );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.checkBoxChar );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.comboBoxRange );
            this.Controls.Add( this.buttonClose );
            this.Controls.Add( this.buttonSearchPrev );
            this.Controls.Add( this.buttonSearch );
            this.Controls.Add( this.textBoxSearchWord );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchBox";
            this.ShowInTaskbar = false;
            this.Text = "検索";
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSearchWord;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonSearchPrev;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ComboBox comboBoxRange;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxListener;
        private System.Windows.Forms.CheckBox checkBoxSpeaker;
        private System.Windows.Forms.CheckBox checkBoxText;
        private System.Windows.Forms.CheckBox checkBoxID;
        private System.Windows.Forms.CheckBox checkBoxChar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxLoop;
        private System.Windows.Forms.CheckBox checkBoxRegularExpression;
        private System.Windows.Forms.CheckBox checkBoxComplete;
        private System.Windows.Forms.CheckBox checkBoxExpand;
    }
}