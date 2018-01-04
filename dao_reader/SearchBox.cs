// (c) hikami, aka longod
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dao_reader {
    public partial class SearchBox : Form {
        public enum SearchRange {
            ByAll = 0,
            ByRim,
            ByDlg,
            ByNode, // 先頭に戻るが成立しなくなるな
            //ByExpand,
        }
        public string[] range_name = {
            "全て",
            "現在のRIM/ERFのみ",
            "現在のDLGのみ",
            "選択しているノードの子のみ"
            //"展開しているノードのみ",
        };
        public class Option {
            public Option() {
            }
            public Option( Option option ) {
                this.search_word = option.search_word;
                this.range = option.range;
                this.id = option.id;
                this.text = option.text;
                this.speaker = option.speaker;
                this.listener = option.listener;
                this.expand = option.expand;
                this.complete = option.complete;
                this.charactor = option.charactor;
                this.loop = option.loop;
                this.regex = option.regex;
            }
            public string search_word = "";
            public SearchRange range = SearchRange.ByAll;
            public bool id = true;
            public bool text = false;
            public bool speaker = false;
            public bool listener = false;
            public bool expand = false;
            public bool complete = false;
            public bool charactor = false;
            public bool loop = false;
            public bool regex = false;
        };
        public SearchBox() {
            InitializeComponent();
        }
        public SearchBox( Option option ) {
            InitializeComponent();

            comboBoxRange.Items.AddRange( range_name );

            textBoxSearchWord.Text = option.search_word;
            comboBoxRange.SelectedIndex = ( int )option.range;
            checkBoxID.Checked = option.id;
            checkBoxText.Checked = option.text;
            checkBoxSpeaker.Checked = option.speaker;
            checkBoxListener.Checked = option.listener;
            checkBoxExpand.Checked = option.expand;
            checkBoxComplete.Checked = option.complete;
            checkBoxChar.Checked = option.charactor;
            checkBoxLoop.Checked = option.loop;
            checkBoxRegularExpression.Checked = option.regex;
        }

        public void restore( Option option ) {
            option.search_word = textBoxSearchWord.Text;
            option.range = ( SearchRange )comboBoxRange.SelectedIndex;
            option.id = checkBoxID.Checked;
            option.text = checkBoxText.Checked;
            option.speaker = checkBoxSpeaker.Checked;
            option.listener = checkBoxListener.Checked;
            option.expand = checkBoxExpand.Checked;
            option.complete = checkBoxComplete.Checked;
            option.charactor = checkBoxChar.Checked;
            option.loop = checkBoxLoop.Checked;
            option.regex = checkBoxRegularExpression.Checked;
        }

        private void buttonClose_Click( object sender, EventArgs e ) {
            this.Close();
        }

        public Button ButtonSearch {
            get { return buttonSearch; }
        }
        public Button ButtonSearchPrev {
            get { return buttonSearchPrev; }
        }
        public TextBox TextBoxSearchWord {
            get { return textBoxSearchWord; }
        }
    }
}