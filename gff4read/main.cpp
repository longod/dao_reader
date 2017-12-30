// http://social.bioware.com/wiki/datoolset/index.php/GFF

#define _CRTDBG_MAP_ALLOC
#include <cstdlib>
#include <crtdbg.h>
#include <tchar.h>

#ifdef _DEBUG
#define NEW new(_NORMAL_BLOCK, __FILE__, __LINE__)
#else
#define NEW new
#endif


#include <iostream>
#include <fstream>
#include <sstream>
#include <cassert>

using namespace std;


// namespace hosii
template <class T>
class GFF_List;

// win32
typedef unsigned char u8;
typedef char s8;
typedef unsigned short u16;
typedef short s16;
typedef unsigned int u32;
typedef int s32;
typedef unsigned long long u64;
typedef long long s64;
typedef float f32;
typedef double f64;
typedef GFF_List<wchar_t> String;


// null 無し版
namespace file {
    bool read( const char *file, char *&buff, size_t *size ) {
        assert(file);
        assert(size);
        assert(buff == NULL);

        ifstream infile( file, ifstream::binary );
        if ( infile.fail() ) {
            return false;
        }

        infile.seekg( 0, ifstream::end );
        size_t s = static_cast<size_t>(infile.tellg());
        infile.seekg( 0, ifstream::beg );
        buff = NEW char[s];
        infile.read( buff, static_cast<streamsize>(s) );
        infile.close();
        if ( size ) {
            *size = s;
        }

        return true;
    }
}


enum FieldDataTypes : unsigned short {
    UINT8       = 0,
    INT8        = 1,
    UINT16      = 2,
    INT16       = 3,
    UINT32      = 4,
    INT32       = 5,
    UINT64      = 6,
    INT64       = 7,
    FLOAT32     = 8,
    FLOAT64     = 9,
    Vector3f    = 10,
    Vector4f    = 12,
    Quaternionf = 13,
    ECString    = 14,
    Color4f     = 15,
    Matrix4x4f  = 16,
    TlkString   = 17,
    Generic     = 0xFFFF,
};

enum FieldFlag : unsigned short {
    LIST = 0x8000,
    STRUCT = 0x4000,
    REFERENCE  = 0x2000,
};


// header
struct GFF_Header {
    u32 GFFMagicNumber;
    u32 GFFVersion;
    u32 TargetPlatform;
    u32 FileType;
    u32 FileVersion;
    u32 StructCount;
    u32 DataOffset;
    //The first five fields are always in big endian and never byteswapped.
    //This keeps those fields human readable on any machine.
};

struct GFF_Struct {
    union{
        u32 StructType;
        s8 Type[ sizeof(u32) ];
    };
    u32 FieldCount;
    u32 FieldOffset;
    u32 StructSize;
};

struct GFF_Field {
    u32 Label;
    union {
        u32 FieldType;
        struct {
            u16 TypeID;
            u16 Flags;
        } Type;
    };
    u32 Index;
};

// 作ったはいいが全然使わなかった
template <class T>
class GFF_Array {
public:
    GFF_Array( u32 *length_address )
        : length( 0 ),
        p( NULL )
    {
        assert( length_address );
        length = *length_address;
        p = NEW T[ length ];
        // 念のためにファイルの最大値送って溢れないかみたいなあ
        u8* beg = reinterpret_cast<u8*>(length_address + 1);
        for ( u32 i = 0; i < length; ++i ) {
            T* element = reinterpret_cast<T*>( beg + i * sizeof(T) );
            p[ i ] = *element;
        }
    }
    ~GFF_Array() {
        if ( p ) {
            delete[] p;
            p = NULL;
        }
    }

public:
    const T operator[] ( u32 index ) {
        assert( index < length );
        return p[ index ];
    }

public:
    u32 length;
    T* p;

private:
    GFF_Array();
};

// string struct
template <class T>
class GFF_List {
public:
    GFF_List()
        : length( 0 ),
        p( NULL )
    {
    }
    ~GFF_List(){
        if ( p ) {
            delete[] p;
            p = NULL;
        }
    }
    u32 length;
    T* p;
};


class ConvList {
public:
    u32 id;
    GFF_List<wchar_t> speaker;
    GFF_List<wchar_t> listener;
    GFF_List<u32> children;    
};

int main( int argc, const char* argv[] ) {
#ifdef _DEBUG
    _CrtSetDbgFlag(_CRTDBG_ALLOC_MEM_DF | _CRTDBG_LEAK_CHECK_DF);
#endif

    setlocale(LC_ALL, "japanese" );
    std::locale::global(std::locale("japanese"));
    _wsetlocale(LC_ALL, L"japanese" );


    // カンマ区切りが入らないように数字だけCロケールに切り替える
    std::locale loc( std::locale( "japanese" ), "C",  std::locale::numeric );
    std::locale::global( loc );

    char* bin = NULL;
    size_t size = 0;

#if 1
    const char* path = "den510_cardplayers.dlg";
#else 
    const char* path = "den211_housekeeper.dlg";
#endif

#if 1
    if ( argc != 2 ) {
        return -1;
    }

    bool ret = file::read( argv[1], bin, &size );
    if ( !ret ) {
        return -2;
    }
#else
    bool ret = file::read( path, bin, &size );
#endif


    GFF_Header* header = reinterpret_cast<GFF_Header*>(bin);
    //todo header chack
#if 0
    if ( header->GFFMagicNumber == ' FFG' ) {
        cout << "GFF file" << endl;
    }
    if ( header->GFFVersion == '0.4V' ) {
        cout << "GFF Version 4.0" << endl;
    }
    if ( header->TargetPlatform == '  CP' ) {
        cout << "TargetPlatform PC" << endl;
    }
    if ( header->FileType == 'VNOC' ) {
        cout << "FileType CONVERSATION" << endl;
    }
    if ( header->FileVersion == '1.0V' ) {
        cout << "File Version 0.1" << endl;
    }

    cout << endl;
    cout << "StructCount: " << header->StructCount << ", ";
    cout << "DataOffset: " << hex << header->DataOffset << dec << endl;
    cout << endl;
#endif

    GFF_Struct* struct_array = reinterpret_cast<GFF_Struct*>(header + 1);


    // raw data blockの構成はfile typeごとに定義されているのか？
    // tlkの内部構成と大分違う
    u8* raw = reinterpret_cast<u8*>(bin + header->DataOffset);
    //char* p = raw;
    //u32* p32 = reinterpret_cast<u32*>(p);

    // top-field struct
    struct Top {
        u32 start;
        u32 list;
        u32 vobank;
    };
    Top *top = reinterpret_cast<Top*>(raw);
    
    // start index
    GFF_Array<u32> start( reinterpret_cast<u32*>(raw + top->start) );

    wstringstream output;

    unsigned *pl = reinterpret_cast<u32*>(raw + top->list);
    unsigned list_len = *( pl );
    pl++;
    assert( list_len );
    ConvList *list = NEW ConvList[list_len];

    output << L"Length:" << list_len << endl;

    output << L"StartIndex:";
    for ( u32 i = 0; i < start.length; ++i ) {
        if ( i < start.length - 1 ) {
            output << start.p[ i ] << L",";
        } else {
            output << start.p[ i ];
        }
    }
    output << endl;
    output << endl;

    for ( u32 i = 0; i < list_len; ++i ) {
        union {
            u32 FieldType;
            struct {
                u16 TypeID;
                u16 Flags;
            } Type;
        } type;

        type.FieldType = *pl;
        //todo check

        pl++;

        u32 offset = *pl;
        u8 *element = raw + offset;

        // 決めうちでも多分大丈夫だと思う
        const u8 index_id = 0;
        const u8 index_speaker = 8;
        const u8 index_listener = 12;
        const u8 index_children = 84;

        u32* id = reinterpret_cast<u32*>( element + index_id );
        list[ i ].id = *id;

        u32* offset_speaker = reinterpret_cast<u32*>( element + index_speaker );
        if ( *offset_speaker != 0xffffffff ) {
            u32* speaker = reinterpret_cast<u32*>( raw + *offset_speaker );
            list[ i ].speaker.length = *speaker;
            if ( list[ i ].speaker.length > 0 ) {
                list[ i ].speaker.p = NEW wchar_t[ list[ i ].speaker.length ]; // \0込みのサイズらしい
                wchar_t* p = reinterpret_cast<wchar_t*>( speaker + 1 );
                for ( u32 j = 0; j < list[ i ].speaker.length; ++j ) {
                    list[ i ].speaker.p[ j ] = p[ j ];
                }
            }
        }

        u32* offset_listener = reinterpret_cast<u32*>( element + index_listener );
        if ( *offset_listener != 0xffffffff ) {
            u32* listener = reinterpret_cast<u32*>( raw + *offset_listener );
            list[ i ].listener.length = *listener;
            if ( list[ i ].listener.length > 0 ) {
                list[ i ].listener.p = NEW wchar_t[ list[ i ].listener.length ]; // \0込みのサイズらしい
                wchar_t* p = reinterpret_cast<wchar_t*>( listener + 1 );
                for ( u32 j = 0; j < list[ i ].listener.length; ++j ) {
                    list[ i ].listener.p[ j ] = p[ j ];
                }
            }
        }

        u32* offset_children = reinterpret_cast<u32*>( element + index_children );
        if ( *offset_children != 0xffffffff ) {
            u32* children = reinterpret_cast<u32*>( raw + *offset_children );
            list[ i ].children.length = *children;
            if ( list[ i ].children.length > 0 ) {
                list[ i ].children.p = NEW u32[ list[ i ].children.length ];
                u32* p = reinterpret_cast<u32*>( children + 1 );
                for ( u32 j = 0; j < list[ i ].children.length; ++j ) {
                    assert( p[ j ] < list_len );
                    list[ i ].children.p[ j ] = p[ j ];
                }
            }
        }


        pl++;

    }

    //wstringstream
    for ( u32 i = 0; i < list_len; ++i ) {
        ConvList* c = &(list[ i ]);
        output << L"Index:" << i << endl;
        output << L"ID:" << c->id << endl;
        if ( c->speaker.length > 0 ) {
            output << L"Speaker:" << c->speaker.p << endl;
        } else {
            output << L"Speaker:" << endl;
        }
        if ( c->listener.length > 0 ) {
            output << L"Listener:" << c->listener.p << endl;
        } else {
            output << L"Listener:" << endl;
        }
        output << L"Children:";
        for ( u32 j = 0; j < c->children.length; ++j ) {
            if ( j < c->children.length - 1 ) {
                output << c->children.p[ j ] << ",";
            } else {
                output << c->children.p[ j ];
            }
        }

        output << endl;
        output << endl;

    }

    output << ends;

    wcout << output.str().c_str() << endl;


    delete[] list;

#if 0
    GFF_Field* f = NULL;
    //for ( u32 index = 0; index < header->StructCount; ++index ) {
    for ( u32 index = 0; index < 1; ++index ) { // top-struct only
        GFF_Struct* st = struct_array + index;
        cout << "Struct: " << index << ", ";
        //cout << "StructType: " << st->StructType << endl;
        cout << "StructType: " ;
        for ( u32 i = 0; i < sizeof(u32); ++i ) {
            cout << st->Type[ i ];
        }
        cout << endl;
        cout << "FieldCount: " << st->FieldCount << ", ";
        cout << "FieldOffset: " << hex << st->FieldOffset << dec << ", ";
        cout << "StructSize: " << st->StructSize << endl;
        
        u32 next = 0;
        GFF_Field* field_array = reinterpret_cast<GFF_Field*>( bin + st->FieldOffset );
        for ( u32 i = 0 ; i < st->FieldCount; ++i ) {
            GFF_Field* field = field_array + i;
            cout << "\tField: " << i << endl;
            cout << "\tLabel: " << field->Label << endl;
            //cout << "\tFieldType: " << field->FieldType << endl;
            cout << "\tTypeID: " << field->Type.TypeID << endl;
            //cout << "\tFlags: " << std::hex << std::showbase << field->Type.Flags << std::dec << endl;
            cout << "\tFlags: ";
            if ( field->Type.Flags & LIST ) {
                cout << "LIST ";
            }
            if ( field->Type.Flags & STRUCT ) {
                cout << "STRUCT ";
            }
            if ( field->Type.Flags & REFERENCE ) {
                cout << "REFERENCE";
            }
            cout << endl;
            cout << "\tIndex: " << field->Index << endl;

            cout << endl;

        }

        cout << endl;

    }
#endif
    // 最適化で構造体用意しとけとか言ってるあたりからしてindexを毎回引かなくてもずれることはないだろう多分

    if ( bin ) {
        delete[] bin;
        bin = NULL;
    }
    return 0;
}