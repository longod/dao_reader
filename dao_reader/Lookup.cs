// (c) hikami, aka longod
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace dao_reader {
    //DAOzNumList.xlsを元に、日本語化プロジェクトに対応するファイル番号を表示するための対応テーブル
    [XmlType(@"dacr")]
    public class Lookup {
        //public Module module = new Module();

        public class Module {

            public class Set {
                public Set() { }
                public Set( string num, uint min, uint max ) {
                    file = num;
                    min_id = min;
                    max_id = max;
                }
                [XmlAttribute]
                public string file;
                [XmlAttribute]
                public uint min_id;
                [XmlAttribute]
                public uint max_id;
            }
            
            [XmlAttribute]
            public string name = @"singleplayer_en-us";
            [XmlElement( "pair" )]
            public List<Set> set = new List<Set>();

            // 並び順が昇順になっていない可能性（誰かが弄らない限りないが）
            // を考えると、idはmin,maxのレンジで管理されるべきだな
        }

        
        [XmlElement( "module" )]
        public List<Module> module = new List<Module>();
    }

}
