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
        System.Collections.Hashtable repeat_table = new System.Collections.Hashtable();

        public class Module {
            public Module( string text_path, string dir_path ) {
                text = text_path;
                directory = dir_path;
            }
            public string text;
            public string directory;
            public System.Collections.Hashtable tlk;
            public System.Windows.Forms.TreeView tree;
            public System.Windows.Forms.TabPage tab;
            //public System.Windows.Forms.TreeNode root;
        }
        System.Collections.Hashtable module_map = new System.Collections.Hashtable();

        private void setStatus( string text ) {
            System.Console.Write( text + "\n" );
            toolStripStatusLabel.Text = text;
        }

        private Module getModule( string name ) {
            Module module = module_map[ name ] as Module;
            return module;
        }

        // new setup
        private bool setup( string text_path, string dir_path ) {
            if ( System.IO.File.Exists( text_path ) == false ) {
                return false;
            }
            if ( System.IO.Directory.Exists( dir_path ) == false ) {
                return false;
            }

            Module module = new Module( text_path, dir_path );
            
            // open tlk
            string[] tlk = System.IO.File.ReadAllLines( text_path );
            module.tlk = new System.Collections.Hashtable( tlk.Length );
         
            // setup
            uint id = 0;
            bool mode = false;
            for ( uint i = 0; i < tlk.Length; ++i ) {
                string line = tlk[ i ];
                if ( line.Length > 0 ) {
                    switch ( line[ 0 ] ) {
                        case '{':
                            int start = line.IndexOf( '{' );
                            int end = line.IndexOf( '}' ); // end が見つからなかった場合とかねえ
                            string sub = line.Substring( start + 1, end - start - 1 );
                            id = System.Convert.ToUInt32( sub );
                            mode = true;
                            break;
                        default:
                            if ( mode ) {
                                module.tlk.Add( id, line );
                                mode = false;
                            } else {
                                // ここにきたらデータがおかしい？
                                //System.Console.WriteLine( line );
                            }
                            break;
                    }
                }
            }

            TreeNode root = new TreeNode( module.directory );
            root.Tag = "dir";

            string[] rims = System.IO.Directory.GetDirectories( module.directory );

            // 中身のないディレクトリもあるので探しながら
            for ( int i = 0; i < rims.Length; ++i ) {
                System.IO.DirectoryInfo info = new System.IO.DirectoryInfo( rims[ i ] );
                System.IO.FileInfo[] dlgs = info.GetFiles( "*.txt" );
                if ( dlgs.Length > 0 ) {
                    TreeNode rim = new TreeNode( info.Name );
                    rim.Tag = "rim";

                    // file node
                    TreeNode[] filenodes = new TreeNode[ dlgs.Length ];
                    for ( int j = 0; j < filenodes.Length; ++j ) {
                        filenodes[ j ] = new TreeNode( System.IO.Path.GetFileNameWithoutExtension( dlgs[ j ].Name ) );

                        // とりあえずタグに DataPathとかいうのもあるとか
                        filenodes[ j ].Tag = "dlg";

                        // +マークつけるのってダミーのnodeでも挟んでいるのかね
                        TreeNode dummy = new TreeNode( "dummy" );
                        dummy.Tag = "dummy";
                        filenodes[ j ].Nodes.Add( dummy );

                        // color
#if false // old color
                        if ( j % 2 == 1 ) {
                            filenodes[ j ].BackColor = Color.FromArgb( 255, 240, 230 );
                        }
#endif
#if false
                        if ( config.Color.Dlg.UseCustom ) {
                            // 毎回newしなくても事前に1個つくるだけでいいんよ
                            System.Drawing.ColorConverter conv = new ColorConverter();
                            if ( j % 2 == 0 ) {
                                filenodes[ j ].ForeColor = ( System.Drawing.Color )conv.ConvertFromString( config.Color.Dlg.Odd.ForeColor );
                                filenodes[ j ].BackColor = ( System.Drawing.Color )conv.ConvertFromString( config.Color.Dlg.Odd.BackColor );
                            } else {
                                filenodes[ j ].ForeColor = ( System.Drawing.Color )conv.ConvertFromString( config.Color.Dlg.Even.ForeColor );
                                filenodes[ j ].BackColor = ( System.Drawing.Color )conv.ConvertFromString( config.Color.Dlg.Even.BackColor );
                            }
                        }
#endif
                    }

                    rim.Nodes.AddRange( filenodes );
                    root.Nodes.Add( rim );
                }
            }

            TreeNode[] roots = new TreeNode[ root.Nodes.Count ];
            for ( int i = 0; i < root.Nodes.Count; ++i ) {
                // color
#if false // old color
                if ( i % 2 == 1 ) {
                    root.Nodes[ i ].BackColor = Color.FromArgb( 230, 255, 240 );
                }
#endif
#if false
                if ( config.Color.Rim.UseCustom ) {
                    // 毎回newしなくても事前に1個つくるだけでいいんよ
                    System.Drawing.ColorConverter conv = new ColorConverter();
                    if ( i % 2 == 0 ) {
                        root.Nodes[ i ].ForeColor = ( System.Drawing.Color )conv.ConvertFromString( config.Color.Rim.Odd.ForeColor );
                        root.Nodes[ i ].BackColor = ( System.Drawing.Color )conv.ConvertFromString( config.Color.Rim.Odd.BackColor );
                    } else {
                        root.Nodes[ i ].ForeColor = ( System.Drawing.Color )conv.ConvertFromString( config.Color.Rim.Even.ForeColor );
                        root.Nodes[ i ].BackColor = ( System.Drawing.Color )conv.ConvertFromString( config.Color.Rim.Even.BackColor );
                    }
                }
#endif
                // collect array
                roots[ i ] = root.Nodes[ i ];
            }

            string name = System.IO.Path.GetFileNameWithoutExtension( module.text );
            module.tree = new TreeView();
            module.tree.SuspendLayout();
            module.tree.Dock = DockStyle.Fill;
            module.tree.Name = name;
            module.tree.PathSeparator = "/";
            module.tree.TabIndex = module_map.Count; // まだ適当
            module.tree.Nodes.AddRange( roots );
            module.tree.BeforeExpand += new TreeViewCancelEventHandler( treeView_BeforeExpand );
            module.tree.AfterSelect += new TreeViewEventHandler( treeView_AfterSelect );
            module.tree.MouseDown += new MouseEventHandler( treeView_MouseDown );

            ContextMenu context = new ContextMenu();

            //context.Items.Add( menuItemCopy ); // 複製しないと使いまわしできない複製しても面倒そうだなあ
            //ToolStripMenuItem menuCopy = new ToolStripMenuItem(  );
            MenuItem menuCopy = new MenuItem( menuItemCopy.Text, menuItemCopy_Click );

            MenuItem menuCopyAll = new MenuItem( menuItemCopyAll.Text, menuItemCopyAll_Click );
            MenuItem menuCopyAllTab = new MenuItem( menuItemCopyAllTab.Text, menuItemCopyTabAll_Click );

            //MenuItem menuExpand = new MenuItem( "展開", menuItemExpand_Click );
            MenuItem menuExpandAll = new MenuItem( menuItemExpandAll.Text, menuItemExpandAll_Click );
            //MenuItem menuCollapse = new MenuItem( "折り畳む", menuItemCollapse_Click );
            MenuItem menuCollapseAll = new MenuItem( menuItemCollapseAll.Text, menuItemCollapseAll_Click );

            // グレーオンオフがいる

            context.MenuItems.Add( menuCopy );
            context.MenuItems.Add( menuCopyAll );
            context.MenuItems.Add( menuCopyAllTab );
            context.MenuItems.Add( new MenuItem("-") );
            //context.MenuItems.Add( menuExpand );
            context.MenuItems.Add( menuExpandAll );
            //context.MenuItems.Add( menuCollapse );
            context.MenuItems.Add( menuCollapseAll );
            
            module.tree.ContextMenu = context;
            
            module.tab = new TabPage( name );
            module.tab.SuspendLayout();
            module.tab.Name = name;
            module.tab.UseVisualStyleBackColor = true;
            module.tab.Controls.Add( module.tree );

            tabControl.SuspendLayout(); // 複数あるのでもっと親で停止
            tabControl.TabPages.Add( module.tab );

            module.tree.ResumeLayout();
            module.tree.PerformLayout();
            module.tab.ResumeLayout();
            module.tab.PerformLayout();
            tabControl.ResumeLayout();
            tabControl.PerformLayout();

            // expand, 検索まわりの依存関係の除去
            // treeView, module_directory, tlk_table

            // tabpageのtextあたりから検索できるようにする
            module_map.Add( name, module );
            return true;
        }


        private string getTlk( uint id, System.Collections.Hashtable table ) {
            if ( table != null ) {
                string tlk = table[ id ] as string;
                //if ( tlk == null ) {
                    // 無いと問題ありだろう
                    //System.Console.WriteLine( "notfound id:" + id.ToString() );
                    // continue（プレイヤーの返答無し）の場合無いようだ
                    // あと台詞無しでなんらかの移動なりアクションしたりとかもそれっぽい
                    //return "(continue)";
                //    return null;
                //}
                return tlk;
            }
            return null;
        }



        private void createConversationTree( ConversationNode n, ConversationNode[] nodes ) {
            if ( n.children != null ) {
                if ( n.children.Length > 0 ) {

                    // indexなので重複していた場合は後の展開は同じはず
                    bool already = repeat_table.ContainsKey( n.index );
                    if ( already ) {
                        return;
                    }
                    // 自分だけを登録する
                    // メンバなので積み重ねできるはず
                    repeat_table.Add( n.index, n );

                    for ( int i = 0; i < n.children.Length; ++i ) {

                        // 多分るーぷしてるから
                        // 親まで辿って重複してないか
                        ConversationNode child = nodes[ n.children[ i ] ];

#if false
                        // 高速化のためにハッシュ探しより前に判断するぜ
                        // startindexならばrootを優先するのでこちらの枝の場合は切り捨てます
                        if ( child.parent ) {
                            continue;
                        }
#endif

                        bool has = repeat_table.ContainsKey( child.index );

                        if ( has == false ) {

                            ConversationNode clone = child.DeepClone();
                            // 足してから作成しないと詰まっていたが、積み重ねになったから大丈夫かも
                            n.Nodes.Add( clone );
                            createConversationTree( clone, nodes );

                            // color
                            if ( i % 2 == 1 ) {
                                //clone.BackColor = Color.FromArgb( 255, 240, 230 );
                            }
                        }
                    }

                }
            }
        }


        private uint[] getLineToUintArray( string line, string name ) {
            string[] splits = line.Split( ':' );
            // からの場合もあるよ
            if ( splits.Length == 2 ) {
                if ( splits[ 0 ] == name ) {
                    string[] array_str = splits[ 1 ].Split( ',' );
                    // いらん比較だが
                    if ( array_str.Length > 0 ) {
                        uint[] array = new uint[ array_str.Length ];
                        for ( int i = 0; i < array.Length; ++i ) {
                            array[ i ] = System.Convert.ToUInt32( array_str[ i ] );
                        }
                        return array;
                    }
                }
            }
            return null;
        }

        private uint getLineToUint( string line, string name ) {
            string[] splits = line.Split( ':' );
            if ( splits.Length == 2 ) {
                if ( splits[ 0 ] == name ) {
                    uint num = System.Convert.ToUInt32( splits[ 1 ] );
                    return num;
                }
            }
            // というかエラー
            return 0;
        }

        private void loadDlg( string path, ref uint[] start, ref ConversationNode[] nodes, Module module ) {

            // まだカレントディレクトリを考慮してない
            if ( System.IO.File.Exists( path ) == false ) {
                return;
            }
            string[] data = System.IO.File.ReadAllLines( path );

            // 変なファイルを検知したいな
            if ( data.Length < 2 ) {
                return;
            }

            string len_str = data[ 0 ];
            uint length = getLineToUint( len_str, "Length" );
            string start_str = data[ 1 ];
            start = getLineToUintArray( start_str, "StartIndex" );

            // 一旦チャンクを作成するか
            nodes = new ConversationNode[ length ];
            for ( uint i = 0; i < nodes.Length; ++i ) {
                nodes[ i ] = new ConversationNode();
                nodes[ i ].index = i;
            }

            // 0で大丈夫かな -1だと無い場合オーバーするが元がuintだしちゃんとチェックするしか
            uint index = 0;
            for ( int i = 2; i < data.Length; ++i ) {
                string line = data[ i ];
                if ( line.Length > 0 ) {
                    string[] splits = line.Split( ':' );
                    if ( splits.Length == 2 ) {
                        switch ( splits[ 0 ] ) {
                            case "Index":
                                index = System.Convert.ToUInt32( splits[ 1 ] );
                                break;
                            case "ID":
                                uint id = System.Convert.ToUInt32( splits[ 1 ] );

                                nodes[ index ].id = id;
                                nodes[ index ].conversation = getTlk( id, module.tlk );
                                nodes[ index ].Text = "[" + id.ToString() + "] ";
                                // nothing conversation
                                if ( nodes[ index ].conversation == null ||
                                    nodes[ index ].conversation == "" ) {
                                    nodes[ index ].ForeColor = System.Drawing.SystemColors.GrayText;
                                }
                                break;
                            case "Speaker":
                                string speaker = splits[ 1 ];
                                if ( speaker != null ) {
                                    if ( speaker.Length > 0 ) {
                                        nodes[ index ].speaker = speaker;
                                        nodes[ index ].Text += "(" + speaker + ")";
                                    }
                                }
                                break;
                            case "Listener":
                                string listener = splits[ 1 ];
                                if ( listener != null ) {
                                    if ( listener.Length > 0 ) {
                                        nodes[ index ].listener = listener;
                                        nodes[ index ].Text += "->(" + listener + ")";
                                    }
                                }
                                break;
                            case "Children":
                                if ( splits[ 1 ].Length > 0 ) {
                                    string[] array = splits[ 1 ].Split( ',' );
                                    if ( array.Length > 0 ) {
                                        uint[] children = new uint[ array.Length ];
                                        for ( int c = 0; c < children.Length; ++c ) {
                                            children[ c ] = System.Convert.ToUInt32( array[ c ] );

                                            //nodes[ index ].Text += children[ c ];
                                        }
                                        nodes[ index ].children = children;
                                    }
                                }

                                // こういう決めうちはあんまりよくないが
                                // まあエクスポートで定型にしたので多分大丈夫
                                if ( nodes[ index ].conversation != null ) {
                                    if ( nodes[ index ].conversation.Length > 0 ) {
                                        nodes[ index ].Text += " " + nodes[ index ].conversation;
                                    }
                                }
                                break;
                        }
                    }
                }
            }

        }

        // いくつかはrefでなくても大丈夫かも
        private void createDlgTree( ref uint[] start, ref ConversationNode[] nodes, ref TreeNode dlg ) {
            // 親が別枝で出た場合に親だけ重複してしかも１個だけの親が出来るのでとりあえず枝毎にやる方向で
            // さらにstartindexも調べることでに到達したかどうかが分かるので枝を中断できるのだが重そうだ

            // ここで真っ先にstartをrepeat_tableに登録すると重複しないんじゃね？
            // と思ったら自分も登録できない罠

            // repeat_tableをローカルにしてスレッドのこと考えた方がいいのかなあ

            dlg.Nodes.Clear();
            repeat_table.Clear(); // 念のため

            // 毎回startか調べるのは重いのでこれは親かどうかのフラグ付けを事前にやっとくのかなあ
            for ( int i = 0; i < start.Length; ++i ) {
                ConversationNode root = nodes[ start[ i ] ];
                root.start = true;
            }
            
            for ( int i = 0; i < start.Length; ++i ) {
                // startは優先しない、とにかく先に出た方を優先する
                // startも重複しないように切り捨てる
                bool has = repeat_table.ContainsKey( start[ i ] );
                if ( has ) {
                    continue;
                }

                ConversationNode root = nodes[ start[ i ] ];
                createConversationTree( root, nodes );
                dlg.Nodes.Add( root );

                //repeat_table.Clear(); // ここでクリアすると重複は親ごとか

                if ( i % 2 == 1 ) {
                    //root.BackColor = Color.FromArgb( 255, 240, 230 );
                }

            }
            //これはstartでstartrootを優先するとつかえんなあ
            repeat_table.Clear(); // dlg全体で1回です


            // startを優先するか、他の枝を優先するかで変わってきそうだ
            // 個人的にはstart至上にしたいが、startだけでは意味の通らない展開がなければいいのだが
            // start至上だとstart別になるのでその分重複ノード数増えるし
            // とりあえずstartを切り捨ててみるか、最初のknight1ってのはstart優先させると分かりにくいし
        }

        private TreeNode searchNext( SearchBox.Option option, TreeNode selected, Module module ) {
            if ( option.search_word != null && option.search_word.Length > 0 ) {

                // あまりないと思うが、状態によってはオプションが変更される可能性があるので
                SearchBox.Option new_option = new SearchBox.Option( option );
                TreeNode current = selected;
                // あんまり無いと思うが、何も選択されていなかったら頭から
                if ( current == null ) {
                    if ( module.tree.Nodes.Count < 1 ) {
                        return null;
                    }
                    current = module.tree.Nodes[ 0 ];
                    // 範囲は全検索に変更かな？
                    new_option.range = SearchBox.SearchRange.ByAll;
                }
                // 選択されていたらそのノードの次から

                // ALL 
                TreeNode end = null;
                // bydlgなのにないがな
                if ( new_option.range == SearchBox.SearchRange.ByDlg ) {
                    TreeNode dlg = current;
                    bool find = false;
                    while ( dlg != null ) {
                        if ( ( string )dlg.Tag == "dlg" ) {
                            // それでもnullなら親のrimのnext
                            if ( dlg.NextNode != null ) {
                                end = dlg.NextNode;
                            } else {
                                end = dlg.Parent.NextNode;
                            }
                            find = true;
                            break;
                        }
                        dlg = dlg.Parent;
                    }
                    // nullなら上位ノードか終端
                    // 終端なら検索する必要する必要があるが…そうでない場合はrimで指定がおかしいので検索すると最後までいっちゃう
                    // この辺はコンボボックスの中身変えたり事前に正当性チェックしたほうがいいんかねえ
                    //if ( dlg == null ) {
                    //}
                    if ( find == false ) {
                        return null;
                    }
                }
                // byrimなのにないがな
                if ( new_option.range == SearchBox.SearchRange.ByRim ) {
                    TreeNode rim = current;
                    while ( rim != null ) {
                        if ( ( string )rim.Tag == "rim" ) {
                            // それでもnullならこれは終端
                            end = rim.NextNode;
                            break;
                        }
                        rim = rim.Parent;
                    }
                }

                // bynode
                if ( new_option.range == SearchBox.SearchRange.ByNode ) {
                    TreeNode next = current;
                    while ( next != null ) {
                        if ( next.NextNode != null ) {
                            end = next.NextNode;
                            break;
                        }
                        next = next.Parent;
                    }
                }

                ConversationNode cn = current as ConversationNode;
                if ( cn != null ) {
                    // 選択ノード以下なのに子ノードがなかた
                    if ( current.Nodes.Count < 1 ) {
                        //if ( new_option.range == SearchBox.SearchRange.ByNode ) {
                        //    return null;
                        //}
                    }

                    // selectedは飛ばす
                    current = getNext( current );
                }
                //ConversationNode findnode = findNodeNext( current, new_option );

                // expandはチェックボックスにしたほうがいいいのかもなあ

                // loop
                ConversationNode findnode = findNode( current, end, true, new_option, module );

                if ( findnode == null && new_option.loop && selected != null && module.tree.Nodes.Count > 0 ) {
                    TreeNode start = module.tree.Nodes[ 0 ];
                    if ( new_option.range == SearchBox.SearchRange.ByDlg ) {
                        TreeNode dlg = current;
                        while ( dlg != null ) {
                            if ( ( string )dlg.Tag == "dlg" ) {
                                break;
                            }
                            dlg = dlg.Parent;
                        }
                        // nullなら上位ノードでした
                        // 検索する必要なし？
                        // まあ一応
                        //if ( dlg == null ) {
                        //    return null;
                        //}
                        start = dlg;
                    }
                    if ( new_option.range == SearchBox.SearchRange.ByRim ) {
                        TreeNode rim = current;
                        while ( rim != null ) {
                            if ( ( string )rim.Tag == "rim" ) {
                                break;
                            }
                            rim = rim.Parent;
                        }
                        //if ( rim == null ) {
                        //    return null;
                        //}
                        start = rim;
                    }
                    // これは成立せんよなあ?
                    if ( new_option.range == SearchBox.SearchRange.ByNode ) {
                        return null;
                    }
                    findnode = findNode( start, selected, true, new_option, module );
                }
                return findnode;

            }
            return null;
        }

        private TreeNode searchPrev( SearchBox.Option option, TreeNode selected, Module module ) {
            if ( option.search_word != null && option.search_word.Length > 0 ) {

                // あまりないと思うが、状態によってはオプションが変更される可能性があるので
                SearchBox.Option new_option = new SearchBox.Option( option );
                TreeNode current = selected;
                // あんまり無いと思うが、何も選択されていなかったら頭から
                // prevの場合はケツからかな？
                if ( current == null ) {
                    if ( module.tree.Nodes.Count < 1 ) {
                        return null;
                    }
                    current = module.tree.Nodes[ 0 ];
                    // 範囲は全検索に変更かな？
                    new_option.range = SearchBox.SearchRange.ByAll;
                }
                // 選択されていたらそのノードの前から

                // ALL 
                TreeNode end = null;
                // bydlgなのにないがな
                if ( new_option.range == SearchBox.SearchRange.ByDlg ) {
                    TreeNode dlg = current;
                    bool find = false;
                    while ( dlg != null ) {
                        if ( ( string )dlg.Tag == "dlg" ) {
                            // それでもnullなら親のrimのnext
                            if ( dlg.PrevNode != null ) {
                                end = dlg.PrevNode;
                            } else {
                                end = dlg.Parent.PrevNode;
                            }
                            find = true;
                            break;
                        }
                        dlg = dlg.Parent;
                    }
                    // nullなら上位ノードか終端
                    // 終端なら検索する必要する必要があるが…そうでない場合はrimで指定がおかしいので検索すると最後までいっちゃう
                    // この辺はコンボボックスの中身変えたり事前に正当性チェックしたほうがいいんかねえ
                    //if ( dlg == null ) {
                    //}
                    if ( find == false ) {
                        return null;
                    }
                }
                // byrimなのにないがな
                if ( new_option.range == SearchBox.SearchRange.ByRim ) {
                    TreeNode rim = current;
                    while ( rim != null ) {
                        if ( ( string )rim.Tag == "rim" ) {
                            // それでもnullならこれは終端
                            end = rim.PrevNode;
                            break;
                        }
                        rim = rim.Parent;
                    }
                }

                // bynode
                if ( new_option.range == SearchBox.SearchRange.ByNode ) {
                    TreeNode next = current;
                    while ( next != null ) {
                        if ( next.PrevNode != null ) {
                            end = next.PrevNode;
                            break;
                        }
                        next = next.Parent;
                    }
                }

                ConversationNode cn = current as ConversationNode;
                if ( cn != null ) {
                    // 選択ノード以下なのに子ノードがなかた
                    if ( current.Nodes.Count < 1 ) {
                        //if ( new_option.range == SearchBox.SearchRange.ByNode ) {
                        //    return null;
                        //}
                    }
                    // selectedは飛ばす
                    current = getPrev( current );
                }
                //ConversationNode findnode = findNodePrev( current, new_option );
                ConversationNode findnode = findNode( current, end, false, new_option, module );
                
                // loop editing
                if ( findnode == null && new_option.loop && selected != null && module.tree.Nodes.Count > 0 ) {
                    TreeNode start = module.tree.Nodes[ module.tree.Nodes.Count - 1 ];
                    if ( new_option.range == SearchBox.SearchRange.ByDlg ) {
                        TreeNode dlg = current;
                        while ( dlg != null ) {
                            if ( ( string )dlg.Tag == "dlg" ) {
                                break;
                            }
                            dlg = dlg.Parent;
                        }
                        // nullなら上位ノードでした
                        // 検索する必要なし？
                        // まあ一応
                        //if ( dlg == null ) {
                        //    return null;
                        //}
                        start = dlg;
                    }
                    if ( new_option.range == SearchBox.SearchRange.ByRim ) {
                        TreeNode rim = current;
                        while ( rim != null ) {
                            if ( ( string )rim.Tag == "rim" ) {
                                break;
                            }
                            rim = rim.Parent;
                        }
                        //if ( rim == null ) {
                        //    return null;
                        //}
                        start = rim;
                    }
                    // これは成立せんよなあ?
                    if ( new_option.range == SearchBox.SearchRange.ByNode ) {
                        return null;
                    }
                    findnode = findNode( start, selected, false, new_option, module );
                }
                return findnode;

            }
            return null;
        }

        // remake
        private ConversationNode findNode( TreeNode begin, TreeNode end, bool forward, SearchBox.Option option, Module module ) {

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            // delegate
            GetNode get_node = null;
            if ( forward ) {
                if ( option.expand ) {
                    get_node = new GetNode( getNextExpand );
                } else {
                    get_node = new GetNode( getNext );
                }
            } else {
                if ( option.expand ) {
                    get_node = new GetNode( getPrevExpand );
                } else {
                    get_node = new GetNode( getPrev );
                }
            }

            TreeNode current = begin;
            // ねんのためnullもチェック
            while ( current != end && current != null ) {
                ConversationNode cn = current as ConversationNode;
                if ( cn != null ) {
                    if ( findWord( cn, option ) ) {
                        sw.Stop();
                        System.Console.WriteLine( "time: " + sw.ElapsedMilliseconds.ToString() + "ms" );
                        return cn;
                    }
                    //current = getNext2( current );

                } else {
                    switch ( ( string )current.Tag ) {
                        case "dlg":
                            if ( current.Nodes.Count == 1 && ( string )current.Nodes[ 0 ].Tag == "dummy" ) {
                                // まだ読んでない
                                current.Nodes.Clear();

                                //string path = module_directory + "/" + current.Parent.Text + "/" + current.Text + ".txt";
                                string path = module.directory + "/" + current.FullPath + ".txt";

                                uint[] start = null;
                                ConversationNode[] nodes = null;

                                loadDlg( path, ref start, ref nodes, module );

                                // error?
                                if ( start == null || nodes == null ) {
                                    continue;
                                }

                                module.tree.SuspendLayout();
                                
                                createDlgTree( ref start, ref nodes, ref current );

                                module.tree.ResumeLayout();
                                module.tree.PerformLayout();

                            }
                            //current = getNext2( current );
                            break;
                        //case "rim":
                            // preloaded
                            //current = getNext2( current );
                            //break;
                        default:
                            break;
                    }
                }

                current = get_node( current ); // delegate
            }

            sw.Stop();
            System.Console.WriteLine( "time: " + sw.ElapsedMilliseconds.ToString() + "ms" );

            return null;

        }

        delegate TreeNode GetNode( TreeNode node );

        private TreeNode getNext( TreeNode node ) {
            if ( node.Nodes.Count > 0 ) {
                return node.Nodes[ 0 ];
            }
            while ( node != null ) {
                if ( node.NextNode != null ) {
                    return node.NextNode;
                }
                node = node.Parent;
            }
            return null;
        }
        private TreeNode getNextExpand( TreeNode node ) {
            if ( node.Nodes.Count > 0 && node.IsExpanded ) {
                return node.Nodes[ 0 ];
            }
            while ( node != null ) {
                if ( node.NextNode != null ) {
                    return node.NextNode;
                }
                node = node.Parent;
            }
            return null;
        }
        private TreeNode getPrev( TreeNode node ) {
            if ( node.Nodes.Count > 0 ) {
                return node.Nodes[ node.Nodes.Count - 1 ];
            }
            while ( node != null ) {
                if ( node.PrevNode != null ) {
                    return node.PrevNode;
                }
                node = node.Parent;
            }
            return null;
        }
        private TreeNode getPrevExpand( TreeNode node ) {
            if ( node.Nodes.Count > 0 && node.IsExpanded ) {
                return node.Nodes[ node.Nodes.Count - 1 ];
            }
            while ( node != null ) {
                if ( node.PrevNode != null ) {
                    return node.PrevNode;
                }
                node = node.Parent;
            }
            return null;
        }

        private bool findWord( ConversationNode node, SearchBox.Option option ) {
            string word = option.search_word;

            if ( option.id ) {
                // 有効かどうかはわからん0は普通に無いので0なら無効にするか？
                if ( node.id > 0 ) {
                    uint id = node.id;
                    bool find = findWord( id.ToString(), option );
                    if ( find ) {
                        return true;
                    }
                }
            }
            if ( option.speaker ) {
                if ( node.speaker != null ) {
                    bool find = findWord( node.speaker, option );
                    if ( find ) {
                        return true;
                    }
                }
            }
            if ( option.listener ) {
                if ( node.listener != null ) {
                    bool find = findWord( node.listener, option );
                    if ( find ) {
                        return true;
                    }
                }
            }

            // 一番長いのでそれまでに見つかっていたらいいな
            if ( option.text ) {
                if ( node.conversation != null ) {
                    bool find = findWord( node.conversation, option );
                    if ( find ) {
                        return true;
                    }
                }
            }

            return false;
        }

        bool findWord( string target_word, SearchBox.Option option ) {
            string target = target_word;
            string word = option.search_word;

            // 正規表現チェックが入っている場合は他のオプションをとりあえず無視する仕様で
            if ( option.regex ) {
                return findWordRegex( target, word );
            }

            // 大文字小文字を区別しない
            if ( option.charactor ) {
                target = target_word.ToLower();
                word = option.search_word.ToLower();
            }

            // 完全一致
            if ( option.complete ) {
                if ( target.Length != word.Length ) {
                    return false;
                }
            }

            return findWordNormal( target, word );
        }

        // 普通に探す
        bool findWordNormal( string target, string word ) {
            int pos = target.IndexOf( word );
            if ( pos > -1 ) {
                return true;
            }
            return false;
        }

        // 正規表現
        // このチェックを入れると他の要素は無視するか？
        // ワイルドカードだけとかはC#でやるめんどいのかね
        bool findWordRegex( string target, string word ) {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex( word );
            return regex.IsMatch( target );
        }

    }
}
