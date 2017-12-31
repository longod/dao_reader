// (c) hikami, aka longod
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dao_reader {
    public partial class Form1 : Form {
        string version = "0.8.1";
        string exe_path;
        string exe_dir;
        string config_path;
        string lookup_path;
        Loockup lookup;
        Setting.Config config = new Setting.Config();
        SearchBox search;
        SearchBox.Option search_option = new SearchBox.Option();
 
        public Form1() {
            InitializeComponent();

            this.Text += " " + version;


            setStatus( "" );

            //setStatus( "Loading..." );

            //System.Reflection.Assembly assem = System.Reflection.Assembly.GetExecutingAssembly();
            //string exe_path = assem.Location;

            exe_path = Application.ExecutablePath;
            exe_dir = System.IO.Path.GetDirectoryName( exe_path );
            config_path = exe_dir + @"\config.xml";
            lookup_path = exe_dir + @"\loockup.xml";

            if ( System.IO.File.Exists( config_path ) ) {
                Setting.Config temp = xml.Xml.Read<Setting.Config>( config_path );
                if ( temp != null ) { // おそもそも失敗したら例外でおちそう InvalidOperationException
                    config = temp;
                }
            } else {
                xml.Xml.Write<Setting.Config>( config_path, config );
            }
            
            
            // カレントにするか実行ファイルにするか悩む デバッグ時はカレントが楽なんだけど
            //string exe_dir = System.IO.Directory.GetCurrentDirectory();
            System.IO.DirectoryInfo info = new System.IO.DirectoryInfo( exe_dir );
            System.IO.FileInfo[] files = info.GetFiles("*.txt");
            System.IO.DirectoryInfo[] dirs = info.GetDirectories();
            List<string> match_list = new List<string>();
            foreach ( System.IO.FileInfo fi in files ) {
                string name = System.IO.Path.GetFileNameWithoutExtension( fi.Name ); // どっちもinfoにする必要なさそう でもstring取得って中でinfo作ってそうなんだが
                foreach ( System.IO.DirectoryInfo di in dirs ) {
                    if ( name == di.Name ) {
                        match_list.Add( fi.Name );
                        // listもなにもここでロードすりゃおｋ
                        setup( fi.FullName, di.FullName );
                    }
                }
            }

            if ( System.IO.File.Exists( lookup_path ) ) {
                lookup = xml.Xml.Read<Loockup>( lookup_path );
            }
            // 影響は無いが例外が出る
            //http://yk.tea-nifty.com/netdev/2009/03/xmlserializer-a.html

            // 色々な部分でSuspendLayout/ResumeLayoutでロード中の画面構築を止めて高速化できそうなんだが
            //System.IO.Directory.GetDirectories();
            // gffreadも同梱して、toolsetインストール者前提のお手軽中間ファイル構築コマンド作ってもいいかなあ

            //color
            setColor();


            // add handler
            toolStripMenuItemEdit.DropDownOpening += new EventHandler( toolStripMenuItemEdit_DropDownOpening );

        }

        TreeView getSelectedTree() {
            TreeView tree = null;
            if ( tabControl.SelectedTab != null ) {
                TabPage tab = tabControl.SelectedTab;
                tree = tab.Controls[ tab.Name ] as TreeView; // 同一名ならという前提だが
            }
            return tree;
        }
        TreeNode getSelectedNode() {
            TreeNode node = null;
            TreeView tree = getSelectedTree();
            if ( tree != null ) {
                node = tree.SelectedNode;
            }
            return node;
        }

        void toolStripMenuItemEdit_DropDownOpening( object sender, EventArgs e ) {
            // あるいは無い場合でもクリップボードにある場合はそれを使うとか？
            if ( search_option.search_word != null && search_option.search_word.Length > 0 ) {
                menuItemSearchNext.Enabled = true;
                menuItemSearchPrev.Enabled = true;
            } else {
                menuItemSearchNext.Enabled = false;
                menuItemSearchPrev.Enabled = false;
            }

            TreeNode node = getSelectedNode();
            if ( node != null ) {
                menuItemCopy.Enabled = true;
                menuItemCopyAll.Enabled = true;
                menuItemCopyAllTab.Enabled = true;
                menuItemExpand.Enabled = true;
                menuItemExpandAll.Enabled = true;
                menuItemCollapse.Enabled = true;
                menuItemCollapseAll.Enabled = true;
            } else {
                menuItemCopy.Enabled = false;
                menuItemCopyAll.Enabled = false;
                menuItemCopyAllTab.Enabled = false;
                menuItemExpand.Enabled = false;
                menuItemExpandAll.Enabled = false;
                menuItemCollapse.Enabled = false;
                menuItemCollapseAll.Enabled = false;
            }
        }

        void treeView_MouseDown( object sender, MouseEventArgs e ) {
            // 左右どちらでも挙動は同じにしよう
            if ( e.Button == MouseButtons.Left || e.Button == MouseButtons.Right ) {
                TreeView tree = sender as TreeView;
                if ( tree != null ) {
                    Point p = tree.PointToClient( Cursor.Position );
                    //TreeNode node = tree.GetNodeAt( p );
                    TreeViewHitTestInfo info = tree.HitTest( p );
                    //info.Location == TreeViewHitTestLocations.Label;

                    if ( info.Node != null ) {
                        tree.SelectedNode = info.Node;
                    }
                }
            }
        }

        void treeView_AfterSelect( object sender, TreeViewEventArgs e ) {
            // conversationの場合は上に反映する
            TreeNode node = e.Node;
            ConversationNode conv = node as ConversationNode;
            string status = "";
            if ( conv != null ) {
                //textBoxID.Text = conv.id.ToString();
                uint id = conv.id;

                string jpfile = null;
                if ( lookup != null && tabControl.SelectedTab.Name != null ) {
                    foreach ( Loockup.Module mod in lookup.module ) {
                        if ( mod.name == tabControl.SelectedTab.Name ) {
                            foreach ( Loockup.Module.Set set in mod.set ) {
                                if ( set.min_id <= id ) {
                                    // 終端は0にとりあえず、さらにmax_idは含めない
                                    if ( set.max_id == 0 || id < set.max_id ) {
                                        jpfile = set.file;
                                        break;
                                    }
                                }
                            }
                            if ( jpfile != null ) {
                                break;
                            }
                        }
                    }
                }

                textBoxID.Text = id.ToString();
                if ( jpfile != null && conv.conversation != null ) {
                    textBoxID.Text += " : " + jpfile;
                }
                textBoxSpeaker.Text = conv.speaker;
                textBoxListener.Text = conv.listener;
                textBoxConversation.Text = conv.conversation;

                status = id.ToString();
            }

            while ( node != null ) {
                if ( node.GetType() == typeof(ConversationNode) ) {
                } else {
                    if ( status.Length > 0 ) {
                        status = node.Text + " > " + status;
                    } else {
                        status = node.Text;
                    }
                }
                node = node.Parent;
            }
            setStatus( status );
        }

        void treeView_BeforeExpand( object sender, TreeViewCancelEventArgs e ) {
            TreeNode node = e.Node;

            TreeView tree = sender as TreeView;
            if ( tree == null ) {
                return;
            }

            Module module = getModule( tree.Name );
            if ( module == null ) {
                return;
            }

            // キャンセルしないと死ぬが開けぬ '*'ボタンを封印するしか
            // 全部表示されないのは閉じればいいのだが、閉じても重さは多分かわらん
            if ( node == module.tree.Nodes[ 0 ] ) {
                //e.Cancel = true;
            }

            if ( ( string )node.Tag == "dlg" ) {
                if ( node.Nodes.Count == 1 ) {
                    if ( ( string )node.Nodes[ 0 ].Tag == "dummy" ) {

                        // load dlg reftext
                        node.Nodes.Clear();
                        //string path = module_directory + "/" + node.Parent.Text + "/" + node.Text + ".txt";
                        string path = module.directory + "/" + node.FullPath + ".txt";

                        setStatus( "Loading: " + node.FullPath );
                        this.Update(); // updateしないと上のが反映されない やりすぎると重いはずなのでピンポイントで

                        uint[] start = null;
                        ConversationNode[] nodes = null;


                        //Module module = module_map[];
                        loadDlg( path, ref start, ref nodes, module );

                        // error?
                        // クリアーしておかないと失敗した場合にダミーが見えちゃうかも
                        if ( start == null || nodes == null ) {
                            return;
                        }

                        module.tree.SuspendLayout();

                        createDlgTree( ref start, ref nodes, ref node );

                        module.tree.ResumeLayout();
                        module.tree.PerformLayout();

                        //setStatus( "Done." );

                    }

                }
#if false
                // 毎回色つけて重いよー
                if ( config.Color.Conv.UseCustom ) {
                    // 再帰的にやらんとなあ というか変更後の反映で根っこからやりなおす場合は根っこから全部再起でいけるからそれつくればいけるだろ
                    for ( int i = 0; i < node.Nodes.Count; ++i ) {
                        ConversationNode cn = node.Nodes[ i ] as ConversationNode;
                        if ( cn != null && cn.conversation != null ) {
                            // 毎回newしなくても事前に1個つくるだけでいいんよ
                            System.Drawing.ColorConverter conv = new ColorConverter();
                            if ( i % 2 == 0 ) {
                                node.Nodes[ i ].ForeColor = ( System.Drawing.Color )conv.ConvertFromString( config.Color.Conv.Odd.ForeColor );
                                node.Nodes[ i ].BackColor = ( System.Drawing.Color )conv.ConvertFromString( config.Color.Conv.Odd.BackColor );
                            } else {
                                node.Nodes[ i ].ForeColor = ( System.Drawing.Color )conv.ConvertFromString( config.Color.Conv.Even.ForeColor );
                                node.Nodes[ i ].BackColor = ( System.Drawing.Color )conv.ConvertFromString( config.Color.Conv.Even.BackColor );
                            }
                        }
                    }
                }
#endif

                // dlg開閉する度に毎回色つけて重いよー
                for ( int i = 0; i < node.Nodes.Count; ++i ) {
                    setColor( node.Nodes[ i ], i );
                }
            }
        }

        private void menuItemExit_Click( object sender, EventArgs e ) {
            this.Close();
        }

        private void menuItemSearch_Click( object sender, EventArgs e ) {
            if ( search != null && search.Visible ) {
                search.Focus();
            } else {
                // クリップボードから反映
                string word = System.Windows.Forms.Clipboard.GetText();
                if ( word != null ) {
                    word = word.Replace( "\r", "" );
                    word = word.Replace( "\n", "" );
                    search_option.search_word = word;
                }
                search = new SearchBox( search_option ); // 作り直さないとインスタンスあっても破棄されてるとかいいやがる復帰させるには？
                search.FormClosing += new FormClosingEventHandler(search_FormClosing);
                search.ButtonSearch.Click += new EventHandler( ButtonSearch_Click );
                search.ButtonSearchPrev.Click += new EventHandler( ButtonSearchPrev_Click );
                search.TextBoxSearchWord.KeyDown += new KeyEventHandler( TextBoxSearchWord_KeyDown );
                // 良い感じの位置に出したいのだが、画面外に出ると詰むしなあそれを検知する処理いれるのは後だ
                search.Show( this );
                // あとLocationのセットは表示後じゃないと有効にならないよゴミが見えるかも
            }

        }

        void search_FormClosing( object sender, FormClosingEventArgs e ) {
            search.restore( search_option );
        }

        void TextBoxSearchWord_KeyDown( object sender, KeyEventArgs e ) {
            if ( e.KeyCode == System.Windows.Forms.Keys.Enter ) {
                ButtonSearch_Click( sender, null );
            }
        }

        void ButtonSearch_Click( object sender, EventArgs e ) {
            search.restore( search_option );
            menuItemSearchNext_Click( sender, e );
        }

        void ButtonSearchPrev_Click( object sender, EventArgs e ) {
            search.restore( search_option );
            menuItemSearchPrev_Click( sender, e );
        }


        private void menuItemSearchNext_Click( object sender, EventArgs e ) {
            if ( search_option.search_word != null && search_option.search_word.Length > 0 ) {
                TreeView tree = getSelectedTree();
                if ( tree == null ) {
                    return;
                }

                Module module = getModule( tree.Name );
                if ( module == null ) {
                    return;
                }

                setStatus( "searching: " + search_option.search_word );
                this.Update(); // updateしないと上のが反映されない やりすぎると重いはずなのでピンポイントで
                TreeNode node = searchNext( search_option, getSelectedNode(), module );

                if ( node != null ) {
                    tree.Focus();
                    tree.SelectedNode = node;
                } else {
                    // notfound
                    setStatus( "not found: " + search_option.search_word );
                }
            }
        }

        private void menuItemSearchPrev_Click( object sender, EventArgs e ) {
            if ( search_option.search_word != null && search_option.search_word.Length > 0 ) {
                TreeView tree = getSelectedTree();
                if ( tree == null ) {
                    return;
                }

                Module module = getModule( tree.Name );
                if ( module == null ) {
                    return;
                }
                
                setStatus( "searching: " + search_option.search_word );
                this.Update(); // updateしないと上のが反映されない やりすぎると重いはずなのでピンポイントで
                TreeNode node = searchPrev( search_option, getSelectedNode(), module );

                if ( node != null ) {
                    tree.Focus();
                    tree.SelectedNode = node;
                } else {
                    // notfound
                    setStatus( "not found: " + search_option.search_word );
                }
            }
        }

        private void menuItemCopy_Click( object sender, EventArgs e ) {
            TreeView tree = getSelectedTree();
            // tabにフォーカスがあっても有効にする？
            if ( tree != null && tree.Focused ) {
                
                TreeNode node = getSelectedNode();

                // beforeexpandとsearchとで似たようなコードがあるからまとめたいのだが
                if ( node != null ) {
                    // 普通のコピー
                    // conversation nodeの場合はちゃんと情報とりたいな

                    ConversationNode cn = node as ConversationNode;
                    string text = "";
                    if ( cn != null ) {

                        // コピペ
                        uint id = cn.id;
                        string jpfile = null;
                        if ( lookup != null && tabControl.SelectedTab.Name != null ) {
                            foreach ( Loockup.Module mod in lookup.module ) {
                                if ( mod.name == tabControl.SelectedTab.Name ) {
                                    foreach ( Loockup.Module.Set set in mod.set ) {
                                        if ( set.min_id <= id ) {
                                            // 終端は0にとりあえず、さらにmax_idは含めない
                                            if ( set.max_id == 0 || id < set.max_id ) {
                                                jpfile = set.file;
                                                break;
                                            }
                                        }
                                    }
                                    if ( jpfile != null ) {
                                        break;
                                    }
                                }
                            }
                        }

                        text += "[" + cn.id + " : " + jpfile + "]";
                        text += " (" + cn.speaker + ")";
                        text += "->(" + cn.listener + ")";
                        text += "\r\n";
                        text += cn.conversation;
                        text += "\r\n";
                    } else {
                        text = node.Text;
                    }

                    System.Windows.Forms.Clipboard.SetText( text );
                }
                return;
            }
            if ( textBoxID.Focused ) {
                textBoxID.Copy();
                return;
            }
            if ( textBoxConversation.Focused ) {
                textBoxConversation.Copy();
                return;
            }
            if ( textBoxSpeaker.Focused ) {
                textBoxSpeaker.Copy();
                return;
            }
            if ( textBoxListener.Focused ) {
                textBoxListener.Copy();
                return;
            }
        }

        private void menuItemCopyAll_Click( object sender, EventArgs e ) {

            TreeView tree = getSelectedTree();
            if ( tree != null && tree.Focused ) {
                Module module = getModule( tree.Name );
                if ( module == null ) {
                    return; // gdgd
                }
                TreeNode node = getSelectedNode();
                if ( node != null ) {
                    // "rim"なら直下のよんでいないやつ全読みしないと
                    if ( ( string )node.Tag == "rim" ) {
                        for ( int i = 0; i < node.Nodes.Count; ++i ) {
                            TreeNode dlg = node.Nodes[ i ];
                            if ( ( string )dlg.Tag == "dlg" ) {
                                if ( dlg.Nodes.Count == 1 ) {
                                    if ( ( string )dlg.Nodes[ 0 ].Tag == "dummy" ) {

                                        // load dlg reftext
                                        dlg.Nodes.Clear();
                                        //string path = module_directory + "/" + node.Parent.Text + "/" + node.Text + ".txt";
                                        string path = module.directory + "/" + dlg.FullPath + ".txt";

                                        setStatus( "Loading: " + dlg.FullPath );
                                        this.Update(); // updateしないと上のが反映されない やりすぎると重いはずなのでピンポイントで

                                        uint[] start = null;
                                        ConversationNode[] nodes = null;


                                        //Module module = module_map[];
                                        loadDlg( path, ref start, ref nodes, module );

                                        // error?
                                        // クリアーしておかないと失敗した場合にダミーが見えちゃうかも
                                        if ( start == null || nodes == null ) {
                                            return;
                                        }

                                        module.tree.SuspendLayout();

                                        createDlgTree( ref start, ref nodes, ref dlg );
                                        //node.Nodes[ i ] = dlg; // 反映する

                                        module.tree.ResumeLayout();
                                        module.tree.PerformLayout();

                                        //setStatus( "Done." );

                                    }

                                }
                            }

                        }
                    }
                    if ( ( string )node.Tag == "dlg" ) {
                        if ( node.Nodes.Count == 1 ) {
                            if ( ( string )node.Nodes[ 0 ].Tag == "dummy" ) {

                                // load dlg reftext
                                node.Nodes.Clear();
                                //string path = module_directory + "/" + node.Parent.Text + "/" + node.Text + ".txt";
                                string path = module.directory + "/" + node.FullPath + ".txt";

                                setStatus( "Loading: " + node.FullPath );
                                this.Update(); // updateしないと上のが反映されない やりすぎると重いはずなのでピンポイントで

                                uint[] start = null;
                                ConversationNode[] nodes = null;


                                //Module module = module_map[];
                                loadDlg( path, ref start, ref nodes, module );

                                // error?
                                // クリアーしておかないと失敗した場合にダミーが見えちゃうかも
                                if ( start == null || nodes == null ) {
                                    return;
                                }

                                module.tree.SuspendLayout();

                                createDlgTree( ref start, ref nodes, ref node );

                                module.tree.ResumeLayout();
                                module.tree.PerformLayout();

                                //setStatus( "Done." );

                            }

                        }
                    }
                    setStatus( "Copy..." );
                    statusStrip.Refresh();

                    // 再起でコンバイン
                    string text = "";
                    convineText( ref text, node, -1 );

                    //System.Console.WriteLine( text );
                    System.Windows.Forms.Clipboard.SetText( text );

                    setStatus( "Done." );

                }
            }
        }
        private void menuItemCopyTabAll_Click( object sender, EventArgs e ) {

            TreeView tree = getSelectedTree();
            if ( tree != null && tree.Focused ) {
                Module module = getModule( tree.Name );
                if ( module == null ) {
                    return; // gdgd
                }
                TreeNode node = getSelectedNode();
                if ( node != null ) {
                    // "rim"なら直下のよんでいないやつ全読みしないと
                    if ( ( string )node.Tag == "rim" ) {
                        for ( int i = 0; i < node.Nodes.Count; ++i ) {
                            TreeNode dlg = node.Nodes[ i ];
                            if ( ( string )dlg.Tag == "dlg" ) {
                                if ( dlg.Nodes.Count == 1 ) {
                                    if ( ( string )dlg.Nodes[ 0 ].Tag == "dummy" ) {

                                        // load dlg reftext
                                        dlg.Nodes.Clear();
                                        //string path = module_directory + "/" + node.Parent.Text + "/" + node.Text + ".txt";
                                        string path = module.directory + "/" + dlg.FullPath + ".txt";

                                        setStatus( "Loading: " + dlg.FullPath );
                                        this.Update(); // updateしないと上のが反映されない やりすぎると重いはずなのでピンポイントで

                                        uint[] start = null;
                                        ConversationNode[] nodes = null;


                                        //Module module = module_map[];
                                        loadDlg( path, ref start, ref nodes, module );

                                        // error?
                                        // クリアーしておかないと失敗した場合にダミーが見えちゃうかも
                                        if ( start == null || nodes == null ) {
                                            return;
                                        }

                                        module.tree.SuspendLayout();

                                        createDlgTree( ref start, ref nodes, ref dlg );
                                        //node.Nodes[ i ] = dlg; // 反映する

                                        module.tree.ResumeLayout();
                                        module.tree.PerformLayout();

                                        //setStatus( "Done." );

                                    }

                                }
                            }

                        }
                    }
                    if ( ( string )node.Tag == "dlg" ) {
                        if ( node.Nodes.Count == 1 ) {
                            if ( ( string )node.Nodes[ 0 ].Tag == "dummy" ) {

                                // load dlg reftext
                                node.Nodes.Clear();
                                //string path = module_directory + "/" + node.Parent.Text + "/" + node.Text + ".txt";
                                string path = module.directory + "/" + node.FullPath + ".txt";

                                setStatus( "Loading: " + node.FullPath );
                                this.Update(); // updateしないと上のが反映されない やりすぎると重いはずなのでピンポイントで

                                uint[] start = null;
                                ConversationNode[] nodes = null;


                                //Module module = module_map[];
                                loadDlg( path, ref start, ref nodes, module );

                                // error?
                                // クリアーしておかないと失敗した場合にダミーが見えちゃうかも
                                if ( start == null || nodes == null ) {
                                    return;
                                }

                                module.tree.SuspendLayout();

                                createDlgTree( ref start, ref nodes, ref node );

                                module.tree.ResumeLayout();
                                module.tree.PerformLayout();

                                //setStatus( "Done." );

                            }

                        }
                    }

                    setStatus( "Copy..." );
                    statusStrip.Refresh();

                    // 再起でコンバイン
                    string text = "";
                    convineText( ref text, node, node.Level );

                    //System.Console.WriteLine( text );
                    System.Windows.Forms.Clipboard.SetText( text );
                    setStatus( "Done." );

                }
            }
        }

        // 移動させよう
        void convineText( ref string text, TreeNode node, int level ) {
            // 最初のレベルが-1ならインデント無し
            // ありならそれを基準とする
            string tab = "";
            if ( level > -1 ) {
                for ( int i = 0; i < node.Level - level; ++i ) {
                    tab += "\t";
                }
            }

            ConversationNode cn = node as ConversationNode;
            text += tab;
            if ( cn != null ) {

                // コピペ
                uint id = cn.id; // コピーだと問題無いのかー？たしかにnodeが消えた場合は値だし危ないよな
                string jpfile = null;
                if ( lookup != null && tabControl.SelectedTab.Name != null ) {
                    foreach ( Loockup.Module mod in lookup.module ) {
                        if ( mod.name == tabControl.SelectedTab.Name ) {
                            foreach ( Loockup.Module.Set set in mod.set ) {
                                if ( set.min_id <= id ) {
                                    // 終端は0にとりあえず、さらにmax_idは含めない
                                    if ( set.max_id == 0 || id < set.max_id ) {
                                        jpfile = set.file;
                                        break;
                                    }
                                }
                            }
                            if ( jpfile != null ) {
                                break;
                            }
                        }
                    }
                }

                text += "[" + cn.id + " : " + jpfile + "]";
                text += " (" + cn.speaker + ")";
                text += "->(" + cn.listener + ")";
                text += "\r\n";
                text += tab;
                text += cn.conversation;
            } else {
                text += node.Text;
            }

            text += "\r\n";
            
            for( int i = 0; i < node.Nodes.Count; ++i ) {
                convineText( ref text, node.Nodes[i], level );
            }
            //text += "\r\n";
        }

        private void menuItemExpandAll_Click( object sender, EventArgs e ) {
            TreeNode node = getSelectedNode();
            if ( node != null ) {
                node.ExpandAll();
            }
        }

        private void menuItemExpand_Click( object sender, EventArgs e ) {
            TreeNode node = getSelectedNode();
            if ( node != null ) {
                node.Expand();
            }
        }

        private void menuItemCollapseAll_Click( object sender, EventArgs e ) {
            TreeNode node = getSelectedNode();
            if ( node != null ) {
                node.Collapse();
            }
        }

        private void menuItemCollapse_Click( object sender, EventArgs e ) {
            TreeNode node = getSelectedNode();
            if ( node != null ) {
                node.Collapse(true);
            }
        }

        private void menuItemVersion_Click( object sender, EventArgs e ) {
            About about = new About( version );
            about.ShowDialog( this );
        }

        private void menuItemSetting_Click( object sender, EventArgs e ) {
            Setting.Config temp = config.clone();
            Setting setting = new Setting( temp );
            DialogResult result = setting.ShowDialog( this );
            if ( result == DialogResult.OK ) {
                setting.restore( ref config );
                xml.Xml.Write<Setting.Config>( config_path, config );

                // デフォルトカラーに戻すにはノード作ってつなぎ替えとかしないと駄目かもなので再起動推奨ですかね
                //setColor();
            }
        }

        void setColor() {

            ColorConverter conv = new ColorConverter();
            // textbox
            if ( config.Color.Base.UseCustom ) {
                textBoxID.ForeColor = ( Color )conv.ConvertFromString( config.Color.Base.ForeColor );
                textBoxID.BackColor = ( Color )conv.ConvertFromString( config.Color.Base.BackColor );
                textBoxSpeaker.ForeColor = textBoxID.ForeColor;
                textBoxSpeaker.BackColor = textBoxID.BackColor;
                textBoxListener.ForeColor = textBoxID.ForeColor;
                textBoxListener.BackColor = textBoxID.BackColor;
                textBoxConversation.ForeColor = textBoxID.ForeColor;
                textBoxConversation.BackColor = textBoxID.BackColor;
            }

            foreach ( Module mod in module_map.Values ) {
                if ( config.Color.Base.UseCustom ) {
                    mod.tree.ForeColor = ( Color )conv.ConvertFromString( config.Color.Base.ForeColor );
                    mod.tree.BackColor = ( Color )conv.ConvertFromString( config.Color.Base.BackColor );
                }
                for ( int i = 0; i < mod.tree.Nodes.Count; ++i ) {
                    setColor( mod.tree.Nodes[ i ], i );
                }
            }
        }
        // おもい colorconverterはmemberで用意しておいても罰はあたらんような
        // というか変換済みカラーね
        void setColor( TreeNode node, int index ) {
            ColorConverter conv = new ColorConverter();
            if ( config.Color.Base.UseCustom ) {
                node.ForeColor = ( Color )conv.ConvertFromString( config.Color.Base.ForeColor );
                node.BackColor = ( Color )conv.ConvertFromString( config.Color.Base.BackColor );
            }
            ConversationNode n = node as ConversationNode;
            if ( n != null ) {
                if ( index % 2 == 0 ) {
                    if ( config.Color.Conv.Odd.UseCustom ) {
                        node.ForeColor = ( Color )conv.ConvertFromString( config.Color.Conv.Odd.ForeColor );
                        node.BackColor = ( Color )conv.ConvertFromString( config.Color.Conv.Odd.BackColor );
                    }
                    if ( n.conversation == null && config.Color.Empty.Odd.UseCustom ) {
                        node.ForeColor = ( Color )conv.ConvertFromString( config.Color.Empty.Odd.ForeColor );
                        node.BackColor = ( Color )conv.ConvertFromString( config.Color.Empty.Odd.BackColor );
                    }
                } else {
                    if ( config.Color.Conv.Even.UseCustom ) {
                        node.ForeColor = ( Color )conv.ConvertFromString( config.Color.Conv.Even.ForeColor );
                        node.BackColor = ( Color )conv.ConvertFromString( config.Color.Conv.Even.BackColor );
                    }
                    if ( n.conversation == null && config.Color.Empty.Odd.UseCustom ) {
                        node.ForeColor = ( Color )conv.ConvertFromString( config.Color.Empty.Even.ForeColor );
                        node.BackColor = ( Color )conv.ConvertFromString( config.Color.Empty.Even.BackColor );
                    }
                }
            } else {
                string tag = node.Tag as string;
                switch ( tag ) {
                    case "rim":
                        if ( index % 2 == 0 ) {
                            if ( config.Color.Rim.Odd.UseCustom ) {
                                node.ForeColor = ( Color )conv.ConvertFromString( config.Color.Rim.Odd.ForeColor );
                                node.BackColor = ( Color )conv.ConvertFromString( config.Color.Rim.Odd.BackColor );
                            }
                        } else {
                            if ( config.Color.Rim.Even.UseCustom ) {
                                node.ForeColor = ( Color )conv.ConvertFromString( config.Color.Rim.Even.ForeColor );
                                node.BackColor = ( Color )conv.ConvertFromString( config.Color.Rim.Even.BackColor );
                            }
                        }
                        break;
                    case "dlg":
                        if ( index % 2 == 0 ) {
                            if ( config.Color.Dlg.Odd.UseCustom ) {
                                node.ForeColor = ( Color )conv.ConvertFromString( config.Color.Dlg.Odd.ForeColor );
                                node.BackColor = ( Color )conv.ConvertFromString( config.Color.Dlg.Odd.BackColor );
                            }
                        } else {
                            if ( config.Color.Dlg.Even.UseCustom ) {
                                node.ForeColor = ( Color )conv.ConvertFromString( config.Color.Dlg.Even.ForeColor );
                                node.BackColor = ( Color )conv.ConvertFromString( config.Color.Dlg.Even.BackColor );
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            // 再帰
            for ( int i = 0; i < node.Nodes.Count; ++i ) {
                // なくてもはじいてくれるはずだが
                if ( ( string )node.Nodes[ i ].Tag != "dummy" ) {
                    setColor( node.Nodes[ i ], i );
                }
            }
        }


    }
}