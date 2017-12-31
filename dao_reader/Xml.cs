// (c) hikami, aka longod
using System;
using System.Collections.Generic;
using System.Text;

namespace xml {
    public class Xml {
        public static Type Read<Type>( string path ) {
            Type t;
            using ( System.IO.FileStream fs = new System.IO.FileStream( path, System.IO.FileMode.Open ) ) {
                System.Xml.Serialization.XmlSerializer seri = new System.Xml.Serialization.XmlSerializer( typeof( Type ) );
                t = (Type)seri.Deserialize( fs );
            }
            return t;
        }
        public static void Write<Type>( string path, Type t ) {
            using ( System.IO.FileStream fs = new System.IO.FileStream( path, System.IO.FileMode.Create ) ) {
                System.Xml.Serialization.XmlSerializer seri = new System.Xml.Serialization.XmlSerializer( typeof( Type ) );
                seri.Serialize( fs, t );
            }
        }
    }
}
