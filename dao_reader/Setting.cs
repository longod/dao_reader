// (c) hikami, aka longod
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dao_reader {
    public partial class Setting : Form {

        Config config = null;
        public class Config {
            public Config() {
                // default color
                Color.Empty.Odd.ForeColor = "GrayText";
                Color.Empty.Odd.BackColor = "Window";
                Color.Empty.Even.ForeColor = "GrayText";
                Color.Empty.Even.BackColor = "Window";

                Color.Base.UseCustom = false;
                Color.Base.ForeColor = "WindowText";
                Color.Base.BackColor = "Window";

                Color.Rim.Odd.UseCustom = false;
                Color.Rim.Odd.ForeColor = Color.Base.ForeColor;
                Color.Rim.Odd.BackColor = Color.Base.BackColor;
                Color.Rim.Even.UseCustom = true;
                Color.Rim.Even.ForeColor = Color.Base.ForeColor;
                Color.Rim.Even.BackColor = "230, 255, 240";

                Color.Dlg.Odd.UseCustom = false;
                Color.Dlg.Odd.ForeColor = Color.Base.ForeColor;
                Color.Dlg.Odd.BackColor = Color.Base.BackColor;
                Color.Dlg.Even.UseCustom = true;
                Color.Dlg.Even.ForeColor = Color.Base.ForeColor;
                Color.Dlg.Even.BackColor = "255, 240, 230";

                Color.Conv.Odd.UseCustom = false;
                Color.Conv.Odd.ForeColor = Color.Base.ForeColor;
                Color.Conv.Odd.BackColor = Color.Base.BackColor;
                Color.Conv.Even.UseCustom = false;
                Color.Conv.Even.ForeColor = Color.Base.ForeColor;
                Color.Conv.Even.BackColor = Color.Base.BackColor;

                Color.Empty.Odd.UseCustom = true;
                Color.Empty.Odd.ForeColor = "GrayText";
                Color.Empty.Odd.BackColor = Color.Base.BackColor;
                Color.Empty.Even.UseCustom = true;
                Color.Empty.Even.ForeColor = "GrayText";
                Color.Empty.Even.BackColor = Color.Base.BackColor;
            }
            public Config clone() {
                Config config = new Config();
                config.Color.Base.UseCustom = this.Color.Base.UseCustom;
                config.Color.Base.ForeColor = this.Color.Base.ForeColor.Clone() as string;
                config.Color.Base.BackColor = this.Color.Base.BackColor.Clone() as string;

                config.Color.Rim.Odd.UseCustom = this.Color.Rim.Odd.UseCustom;
                config.Color.Rim.Even.UseCustom = this.Color.Rim.Even.UseCustom;
                config.Color.Rim.Odd.ForeColor = this.Color.Rim.Odd.ForeColor.Clone() as string;
                config.Color.Rim.Odd.BackColor = this.Color.Rim.Odd.BackColor.Clone() as string;
                config.Color.Rim.Even.ForeColor = this.Color.Rim.Even.ForeColor.Clone() as string;
                config.Color.Rim.Even.BackColor = this.Color.Rim.Even.BackColor.Clone() as string;

                config.Color.Dlg.Odd.UseCustom = this.Color.Dlg.Odd.UseCustom;
                config.Color.Dlg.Even.UseCustom = this.Color.Dlg.Even.UseCustom;
                config.Color.Dlg.Odd.ForeColor = this.Color.Dlg.Odd.ForeColor.Clone() as string;
                config.Color.Dlg.Odd.BackColor = this.Color.Dlg.Odd.BackColor.Clone() as string;
                config.Color.Dlg.Even.ForeColor = this.Color.Dlg.Even.ForeColor.Clone() as string;
                config.Color.Dlg.Even.BackColor = this.Color.Dlg.Even.BackColor.Clone() as string;

                config.Color.Conv.Odd.UseCustom = this.Color.Conv.Odd.UseCustom;
                config.Color.Conv.Even.UseCustom = this.Color.Conv.Even.UseCustom;
                config.Color.Conv.Odd.ForeColor = this.Color.Conv.Odd.ForeColor.Clone() as string;
                config.Color.Conv.Odd.BackColor = this.Color.Conv.Odd.BackColor.Clone() as string;
                config.Color.Conv.Even.ForeColor = this.Color.Conv.Even.ForeColor.Clone() as string;
                config.Color.Conv.Even.BackColor = this.Color.Conv.Even.BackColor.Clone() as string;

                config.Color.Empty.Odd.UseCustom = this.Color.Empty.Odd.UseCustom;
                config.Color.Empty.Even.UseCustom = this.Color.Empty.Even.UseCustom;
                config.Color.Empty.Odd.ForeColor = this.Color.Empty.Odd.ForeColor.Clone() as string;
                config.Color.Empty.Odd.BackColor = this.Color.Empty.Odd.BackColor.Clone() as string;
                config.Color.Empty.Even.ForeColor = this.Color.Empty.Even.ForeColor.Clone() as string;
                config.Color.Empty.Even.BackColor = this.Color.Empty.Even.BackColor.Clone() as string;

                return config;
            }
            public class TreeColor {
                public class Color {
                    public bool UseCustom = true; // こっちにつけてバラでできるようにするかも
                    public string ForeColor = "WindowText";
                    public string BackColor = "Window";
                }
                public class NodeColor {
                    //public bool UseCustom = true;
                    public Color Odd = new Color();
                    public Color Even = new Color();
                }
                //public bool UseCustom = true;
                public Color Base = new Color();
                public NodeColor Rim = new NodeColor();
                public NodeColor Dlg = new NodeColor();
                public NodeColor Conv = new NodeColor();
                public NodeColor Empty = new NodeColor();
            }
            public TreeColor Color = new TreeColor();
        }

        // base colorはtextboxにも適用してもいいんじゃない？read onlyと思われ無さそうだが。

        public string[] range_name = {
            "RIM/ERF",
            "DLG",
            "Conversation",
            "Empty",
        };

        public Setting() {
            InitializeComponent();
        }
        public Setting( Config original ) {
            InitializeComponent();

            buttonFore.Click += new EventHandler( buttonBase_Click );
            buttonBack.Click += new EventHandler( buttonBase_Click );

            buttonForeOdd.Click += new EventHandler( buttonNode_Click );
            buttonForeEven.Click += new EventHandler( buttonNode_Click );
            buttonBackOdd.Click += new EventHandler( buttonNode_Click );
            buttonBackEven.Click += new EventHandler( buttonNode_Click );

            config = original;


            comboBoxNode.Items.AddRange( range_name );
            comboBoxNode.SelectedIndex = 0;
            comboBoxNode.SelectedIndexChanged += new EventHandler( comboBoxNode_SelectedIndexChanged );

            checkBoxBase.CheckedChanged += new EventHandler( checkBoxBase_CheckedChanged );
            checkBoxOdd.CheckedChanged += new EventHandler( checkBoxOdd_CheckedChanged );
            checkBoxEven.CheckedChanged += new EventHandler( checkBoxEven_CheckedChanged );

            refresh();
        }


        void checkBoxBase_CheckedChanged( object sender, EventArgs e ) {
            // refresh時が無駄気味だが
            config.Color.Base.UseCustom = checkBoxBase.Checked;
        }

        void checkBoxOdd_CheckedChanged( object sender, EventArgs e ) {
            // enable あたいの更新
            // refresh時が無駄気味だが
            Config.TreeColor.NodeColor node = getNodeColor();
            if ( node != null ) {
                node.Odd.UseCustom = checkBoxOdd.Checked;
            }
        }
        void checkBoxEven_CheckedChanged( object sender, EventArgs e ) {
            // enable あたいの更新
            // refresh時が無駄気味だが
            Config.TreeColor.NodeColor node = getNodeColor();
            if ( node != null ) {
                node.Even.UseCustom = checkBoxEven.Checked;
            }
        }

        void comboBoxNode_SelectedIndexChanged( object sender, EventArgs e ) {
            // 配色替えね
            refresh();
        }

        public void restore( ref Config original ) {
            original = config;
        }

        void refresh() {
            //this.SuspendLayout();
            System.Drawing.ColorConverter conv = new ColorConverter();
            labelBase.ForeColor = ( System.Drawing.Color )conv.ConvertFromString( config.Color.Base.ForeColor );
            labelBase.BackColor = ( System.Drawing.Color )conv.ConvertFromString( config.Color.Base.BackColor );
            checkBoxBase.Checked = config.Color.Base.UseCustom;

            Config.TreeColor.NodeColor node = getNodeColor();
            if ( node != null ) {
                labelOdd.ForeColor = ( System.Drawing.Color )conv.ConvertFromString( node.Odd.ForeColor );
                labelOdd.BackColor = ( System.Drawing.Color )conv.ConvertFromString( node.Odd.BackColor );
                labelEven.ForeColor = ( System.Drawing.Color )conv.ConvertFromString( node.Even.ForeColor );
                labelEven.BackColor = ( System.Drawing.Color )conv.ConvertFromString( node.Even.BackColor );
                checkBoxOdd.Checked = node.Odd.UseCustom;
                checkBoxEven.Checked = node.Even.UseCustom;
            }
            //this.ResumeLayout();
            //this.PerformLayout();

        }

        Config.TreeColor.NodeColor getNodeColor() {
            Config.TreeColor.NodeColor node = null;
            switch ( comboBoxNode.SelectedIndex ) {
                case 0: // rim
                    node = config.Color.Rim;
                    break;
                case 1: // dlg
                    node = config.Color.Dlg;
                    break;
                case 2: // conv
                    node = config.Color.Conv;
                    break;
                case 3: // empty
                    node = config.Color.Empty;
                    break;
                default:
                    break;
            }
            return node;
        }

        private void buttonNode_Click( object sender, EventArgs e ) {
            // 何個もイベント作りたくないのでtagあたりに埋め込む
            Button button = sender as Button;
            if ( button != null ) {

                Config.TreeColor.NodeColor node = getNodeColor();
                if ( node != null ) {

                    Config.TreeColor.Color color = node.Odd;
                    if ( button.Name.ToString().Contains( "Even" ) ) {
                        color = node.Even;
                    }

                    bool isFore = false;
                    if ( button.Name.ToString().Contains( "Fore" ) ) {
                        isFore = true;
                    }

                    ColorDialog cd = new ColorDialog();
                    cd.FullOpen = true;

                    System.Drawing.ColorConverter conv = new ColorConverter();
                    if ( isFore ) {
                        cd.Color = ( System.Drawing.Color )conv.ConvertFromString( color.ForeColor );
                    } else {
                        cd.Color = ( System.Drawing.Color )conv.ConvertFromString( color.BackColor );
                    }
                    DialogResult result = cd.ShowDialog( this );
                    if ( result == DialogResult.OK ) {
                        if ( isFore ) {
                            color.ForeColor = conv.ConvertToString( cd.Color );
                        } else {
                            color.BackColor = conv.ConvertToString( cd.Color );
                        }
                        refresh();
                    }
                }

            }
        }
        void buttonBase_Click( object sender, EventArgs e ) {
            Button button = sender as Button;
            if ( button != null ) {
                bool isFore = false;
                if ( button.Name.ToString().Contains( "Fore" ) ) {
                    isFore = true;
                }

                ColorDialog cd = new ColorDialog();
                cd.FullOpen = true;

                System.Drawing.ColorConverter conv = new ColorConverter();
                if ( isFore ) {
                    cd.Color = ( System.Drawing.Color )conv.ConvertFromString( config.Color.Base.ForeColor );
                } else {
                    cd.Color = ( System.Drawing.Color )conv.ConvertFromString( config.Color.Base.BackColor );
                }
                DialogResult result = cd.ShowDialog( this );
                if ( result == DialogResult.OK ) {
                    if ( isFore ) {
                        config.Color.Base.ForeColor = conv.ConvertToString( cd.Color );
                    } else {
                        config.Color.Base.BackColor = conv.ConvertToString( cd.Color );
                    }
                    refresh();
                }
            }
        }

        private void buttonOK_Click( object sender, EventArgs e ) {

            this.Close();
        }

        private void buttonCancel_Click( object sender, EventArgs e ) {
            this.Close();
        }

    }
}