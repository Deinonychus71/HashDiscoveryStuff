using System.Collections.Generic;

namespace BruteForceHash.GUI
{
    public static class Charsets
    {
        public const string SmashCommon = "etainoshrdlucmfwygpbvkqjxz_0123456789.-１’";
        public const string ASCIILowerCase = "etainoshrdlucmfwygpbvkqjxz";
        public const string ASCIIUpperCase = "ETAINOSHRDLUCMFWYGPBVKQJXZ";
        public const string ASCIIDigits = "0123456789";
        public const string ASCIISpecials = "!#$%&' ()*+,-./:;<=>?@[\\]\"^_`{|}~";
        public const string Latin1Accents = "àáâãäåæçèéêëìíîïðñòóôõöùúûüýńň";
        public const string Latin1Quotes = "¨´‘’“”‟„‛ ‚";
        public const string Latin1Dashes = "_-‑‒–——―";
        public const string Latin1Specials = "Øø€¢£¤¥©®™§¶¬°±µ¼½¾×÷∅∼÷≅≈≠≤≥′″⁰¹²³⁴⁵⁶⁷⁸⁹₀₁₂₃₄₅₆₇₈₉∀∃∞⊥¡¿«»¯‐‑‒–—―•…⌘○�⁓";
        public const string RomanjiAccents = "äāéēèīïûūōôð";
        public const string RomanjiSpecials = "ʲɕɯɲŋɸçʑ~β♭'";
        public const string JPNFullWidthDigits = "０１２３４５６７８９";
        public const string JPNFullWidthSpecials = "（）＊－〓「」［］。．、＋，；：？！＃＄％＆＂＇／・々〈〉＜＝＞［＼］＠《》ー＾＿｀｛｜｝～｟｠☆";
        public const string JPNFullWidthLatin = "ＡＢＣＤＥＦＧＨＩＪＫＬＭＮＯＰＱＲＳＴＵＶＷＸＹＺａｂｃｄｅｆｇｈｉｊｋｌｍｎｏｐｑｒｓｔｕｖｗｘｙｚ";
        public const string JPNKatakana = "゠ァアィイゥウェエォオカガキギクグケゲコゴサザシジスズセゼソゾタダチヂッツヅテデトドナニヌネノハバパヒビピフブプヘベペホボポマミムメモャヤュユョヨラリルレロヮワヰヱヲンヴヵヶヷヸヹヺ・ーヽヾヿ";
        public const string JPNHiragana = "぀ぁあぃいぅうぇえぉおかがきぎくぐけげこごさざしじすずせぜそぞただちぢっつづてでとどなにぬねのはばぱひびぴふぶぷへべぺほぼぽまみむめもゃやゅゆょよらりるれろゎわゐゑをんゔゕ゗゘゙゚゛゜ゝゞゟ";
        public const string JPNPhonetic = "ㇰㇱㇲㇳㇴㇵㇶㇷㇸㇹㇺㇻㇼㇽㇾㇿ";
        public const string JPNKanbun = "㆐㆑㆒㆓㆔㆕㆖㆗㆘㆙㆚㆛㆜㆝㆞㆟";
        public const string JPNHalfwidth = "＀｡｢｣､･ｦｧｨｩｪｫｬｭｮｯｰｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾅﾆﾇﾈﾉﾊﾋﾌﾍﾎﾏﾐﾑﾒﾓﾔﾕﾖﾗﾘﾙﾚﾛﾜﾝﾞﾟﾠﾡﾢﾣﾤﾥﾦﾧﾨﾩﾪﾫﾬﾭﾮﾯﾰﾱﾲﾳﾴﾵﾶﾷﾸﾹﾺﾻﾼﾽﾾ﾿￀￁ￂￃￄￅￆￇ￈￉ￊￋￌￍￎￏ￐￑ￒￓￔￕￖￗ￘ￚￛￜ￝￞￟￠￡￢￣￤￥￦￧￨￩￪￫￬￭￮￯";
        //public const string JPNFull = "ーぁあぃいぅうぇえぉおかがきぎくぐけげこごさざしじすずせぜそぞただちぢっつづてでとどなにぬねのはばぱひびぴふぶぷへべぺほぼぽまみむめもゃやゅゆょよらりるれろゎわゐゑをんァアィイゥウェエォオカガキギクグケゲコゴサザシジスズセゼソゾタダチヂッツヅテデトドナニヌネノハバパヒビピフブプヘベペホボポマミムメモャヤュユョヨラリルレロヮワヰヱヲンヴヵヶ゛゜";
    
    
        public static Dictionary<string, string> GetCharsetList()
        {
            return new Dictionary<string, string>()
            {
                { nameof(SmashCommon), SmashCommon },
                { nameof(ASCIILowerCase), ASCIILowerCase },
                { nameof(ASCIIUpperCase), ASCIIUpperCase },
                { nameof(ASCIIDigits), ASCIIDigits },
                { nameof(ASCIISpecials), ASCIISpecials },
                { nameof(Latin1Accents), Latin1Accents },
                { nameof(Latin1Quotes), Latin1Quotes },
                { nameof(Latin1Dashes), Latin1Dashes },
                { nameof(Latin1Specials), Latin1Specials },
                { nameof(RomanjiAccents), RomanjiAccents },
                { nameof(RomanjiSpecials), RomanjiSpecials },
                { nameof(JPNFullWidthDigits), JPNFullWidthDigits },
                { nameof(JPNFullWidthSpecials), JPNFullWidthSpecials },
                { nameof(JPNFullWidthLatin), JPNFullWidthLatin },
                { nameof(JPNKatakana), JPNKatakana },
                { nameof(JPNHiragana), JPNHiragana },
                { nameof(JPNPhonetic), JPNPhonetic },
                { nameof(JPNKanbun), JPNKanbun },
                { nameof(JPNHalfwidth), JPNHalfwidth },
            };
        }
    }
}
