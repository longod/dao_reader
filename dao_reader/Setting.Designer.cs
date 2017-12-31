namespace dao_reader {
    partial class Setting {
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBoxEven = new System.Windows.Forms.CheckBox();
            this.comboBoxNode = new System.Windows.Forms.ComboBox();
            this.buttonBackEven = new System.Windows.Forms.Button();
            this.checkBoxOdd = new System.Windows.Forms.CheckBox();
            this.labelOdd = new System.Windows.Forms.Label();
            this.buttonForeEven = new System.Windows.Forms.Button();
            this.buttonForeOdd = new System.Windows.Forms.Button();
            this.buttonBackOdd = new System.Windows.Forms.Button();
            this.labelEven = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonFore = new System.Windows.Forms.Button();
            this.labelBase = new System.Windows.Forms.Label();
            this.checkBoxBase = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point( 163, 180 );
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size( 75, 23 );
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler( this.buttonOK_Click );
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point( 244, 180 );
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size( 75, 23 );
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler( this.buttonCancel_Click );
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add( this.checkBoxEven );
            this.groupBox5.Controls.Add( this.comboBoxNode );
            this.groupBox5.Controls.Add( this.buttonBackEven );
            this.groupBox5.Controls.Add( this.checkBoxOdd );
            this.groupBox5.Controls.Add( this.labelOdd );
            this.groupBox5.Controls.Add( this.buttonForeEven );
            this.groupBox5.Controls.Add( this.buttonForeOdd );
            this.groupBox5.Controls.Add( this.buttonBackOdd );
            this.groupBox5.Controls.Add( this.labelEven );
            this.groupBox5.Location = new System.Drawing.Point( 12, 67 );
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size( 311, 107 );
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Node Color";
            // 
            // checkBoxEven
            // 
            this.checkBoxEven.AutoSize = true;
            this.checkBoxEven.Location = new System.Drawing.Point( 249, 77 );
            this.checkBoxEven.Name = "checkBoxEven";
            this.checkBoxEven.Size = new System.Drawing.Size( 58, 16 );
            this.checkBoxEven.TabIndex = 8;
            this.checkBoxEven.Text = "Enable";
            this.checkBoxEven.UseVisualStyleBackColor = true;
            // 
            // comboBoxNode
            // 
            this.comboBoxNode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNode.FormattingEnabled = true;
            this.comboBoxNode.Location = new System.Drawing.Point( 6, 18 );
            this.comboBoxNode.Name = "comboBoxNode";
            this.comboBoxNode.Size = new System.Drawing.Size( 121, 20 );
            this.comboBoxNode.TabIndex = 0;
            // 
            // buttonBackEven
            // 
            this.buttonBackEven.Location = new System.Drawing.Point( 168, 73 );
            this.buttonBackEven.Name = "buttonBackEven";
            this.buttonBackEven.Size = new System.Drawing.Size( 75, 23 );
            this.buttonBackEven.TabIndex = 7;
            this.buttonBackEven.Text = "背景色";
            this.buttonBackEven.UseVisualStyleBackColor = true;
            // 
            // checkBoxOdd
            // 
            this.checkBoxOdd.AutoSize = true;
            this.checkBoxOdd.Location = new System.Drawing.Point( 249, 48 );
            this.checkBoxOdd.Name = "checkBoxOdd";
            this.checkBoxOdd.Size = new System.Drawing.Size( 58, 16 );
            this.checkBoxOdd.TabIndex = 4;
            this.checkBoxOdd.Text = "Enable";
            this.checkBoxOdd.UseVisualStyleBackColor = true;
            // 
            // labelOdd
            // 
            this.labelOdd.BackColor = System.Drawing.SystemColors.Window;
            this.labelOdd.Location = new System.Drawing.Point( 6, 48 );
            this.labelOdd.Name = "labelOdd";
            this.labelOdd.Size = new System.Drawing.Size( 75, 23 );
            this.labelOdd.TabIndex = 1;
            this.labelOdd.Text = "奇数ノード";
            this.labelOdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonForeEven
            // 
            this.buttonForeEven.Location = new System.Drawing.Point( 87, 73 );
            this.buttonForeEven.Name = "buttonForeEven";
            this.buttonForeEven.Size = new System.Drawing.Size( 75, 23 );
            this.buttonForeEven.TabIndex = 6;
            this.buttonForeEven.Text = "文字色";
            this.buttonForeEven.UseVisualStyleBackColor = true;
            // 
            // buttonForeOdd
            // 
            this.buttonForeOdd.Location = new System.Drawing.Point( 87, 44 );
            this.buttonForeOdd.Name = "buttonForeOdd";
            this.buttonForeOdd.Size = new System.Drawing.Size( 75, 23 );
            this.buttonForeOdd.TabIndex = 2;
            this.buttonForeOdd.Text = "文字色";
            this.buttonForeOdd.UseVisualStyleBackColor = true;
            // 
            // buttonBackOdd
            // 
            this.buttonBackOdd.Location = new System.Drawing.Point( 168, 44 );
            this.buttonBackOdd.Name = "buttonBackOdd";
            this.buttonBackOdd.Size = new System.Drawing.Size( 75, 23 );
            this.buttonBackOdd.TabIndex = 3;
            this.buttonBackOdd.Text = "背景色";
            this.buttonBackOdd.UseVisualStyleBackColor = true;
            // 
            // labelEven
            // 
            this.labelEven.BackColor = System.Drawing.Color.FromArgb( ( ( int )( ( ( byte )( 255 ) ) ) ), ( ( int )( ( ( byte )( 192 ) ) ) ), ( ( int )( ( ( byte )( 192 ) ) ) ) );
            this.labelEven.Location = new System.Drawing.Point( 6, 71 );
            this.labelEven.Name = "labelEven";
            this.labelEven.Size = new System.Drawing.Size( 75, 23 );
            this.labelEven.TabIndex = 5;
            this.labelEven.Text = "偶数ノード";
            this.labelEven.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add( this.buttonBack );
            this.groupBox6.Controls.Add( this.buttonFore );
            this.groupBox6.Controls.Add( this.labelBase );
            this.groupBox6.Controls.Add( this.checkBoxBase );
            this.groupBox6.Location = new System.Drawing.Point( 12, 12 );
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size( 311, 49 );
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Base Color";
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point( 168, 15 );
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size( 75, 23 );
            this.buttonBack.TabIndex = 2;
            this.buttonBack.Text = "背景色";
            this.buttonBack.UseVisualStyleBackColor = true;
            // 
            // buttonFore
            // 
            this.buttonFore.Location = new System.Drawing.Point( 87, 15 );
            this.buttonFore.Name = "buttonFore";
            this.buttonFore.Size = new System.Drawing.Size( 75, 23 );
            this.buttonFore.TabIndex = 1;
            this.buttonFore.Text = "文字色";
            this.buttonFore.UseVisualStyleBackColor = true;
            // 
            // labelBase
            // 
            this.labelBase.BackColor = System.Drawing.SystemColors.Window;
            this.labelBase.Location = new System.Drawing.Point( 6, 15 );
            this.labelBase.Name = "labelBase";
            this.labelBase.Size = new System.Drawing.Size( 75, 23 );
            this.labelBase.TabIndex = 0;
            this.labelBase.Text = "ノードテキスト";
            this.labelBase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxBase
            // 
            this.checkBoxBase.AutoSize = true;
            this.checkBoxBase.Location = new System.Drawing.Point( 249, 19 );
            this.checkBoxBase.Name = "checkBoxBase";
            this.checkBoxBase.Size = new System.Drawing.Size( 58, 16 );
            this.checkBoxBase.TabIndex = 3;
            this.checkBoxBase.Text = "Enable";
            this.checkBoxBase.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 28, 185 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 111, 12 );
            this.label1.TabIndex = 2;
            this.label1.Text = "※変更後は要再起動";
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 336, 215 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.groupBox6 );
            this.Controls.Add( this.groupBox5 );
            this.Controls.Add( this.buttonCancel );
            this.Controls.Add( this.buttonOK );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Setting";
            this.Text = "Setting";
            this.groupBox5.ResumeLayout( false );
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout( false );
            this.groupBox6.PerformLayout();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox comboBoxNode;
        private System.Windows.Forms.Button buttonBackEven;
        private System.Windows.Forms.Button buttonForeEven;
        private System.Windows.Forms.Label labelEven;
        private System.Windows.Forms.Button buttonBackOdd;
        private System.Windows.Forms.Button buttonForeOdd;
        private System.Windows.Forms.Label labelOdd;
        private System.Windows.Forms.CheckBox checkBoxOdd;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonFore;
        private System.Windows.Forms.Label labelBase;
        private System.Windows.Forms.CheckBox checkBoxBase;
        private System.Windows.Forms.CheckBox checkBoxEven;
        private System.Windows.Forms.Label label1;

    }
}