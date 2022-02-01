namespace VijayAnand.Toolkit
{
    /// <summary>Frequently used constants</summary>
    public static class Constants
    {
        /// <summary>
        /// ASCII character set represented as constants with meaningful names including its frequently used aliases
        /// </summary>
        public static class Ascii
        {
            #region Invisible Characters
            /// <summary>Null - \0</summary>
            public const char Null = '\x00';

            public const char HeadingStart = '\x01';

            public const char TextStart = '\x02';

            public const char TextEnd = '\x03';

            public const char TransmissionEnd = '\x04';

            public const char Enquiry = '\x05';

            public const char Acknowledgement = '\x06';

            /// <summary>Bell - \a</summary>
            public const char Bell = '\x07';

            /// <summary>Backspace - \b</summary>
            public const char Backspace = '\x08';

            /// <summary>Horizontal tab - \t</summary>
            public const char HorizontalTab = '\x09';

            /// <summary>Alias for <see cref="HorizontalTab"/></summary>
            public const char Tab = '\x09';

            /// <summary>Line feed - \n</summary>
            public const char LineFeed = '\x0A';

            /// <summary>Vertical tab - \v</summary>
            public const char VerticalTab = '\x0B';

            /// <summary>Form feed - \f</summary>
            public const char FormFeed = '\x0C';

            /// <summary>Carriage return - \r</summary>
            public const char CarriageReturn = '\x0D';

            public const char ShiftOut = '\x0E';

            public const char ShiftIn = '\x0F';

            public const char DataLinkEscape = '\x10';

            public const char DeviceControl1 = '\x11';

            public const char DeviceControl2 = '\x12';

            public const char DeviceControl3 = '\x13';

            public const char DeviceControl4 = '\x14';

            public const char NegativeAcknowledgement = '\x15';

            public const char SynchronousIdle = '\x16';

            public const char TransmissionBlockEnd = '\x17';

            public const char Cancel = '\x18';

            public const char MediumEnd = '\x19';

            public const char Substitue = '\x1A';

            /// <summary>Escape - \e</summary>
            public const char Escape = '\x1B';

            public const char FileSeparator = '\x1C';

            public const char GroupSeparator = '\x1D';

            public const char RecordSeparator = '\x1E';

            public const char UnitSeparator = '\x1F';
            #endregion

            /// <summary>&#32;</summary>
            public const char Space = '\x20';

            /// <summary>&#33;</summary>
            public const char ExclamationMark = '\x21';

            /// <summary>&quot;</summary>
            public const char DoubleQuote = '\x22';

            /// <summary>&#35;</summary>
            public const char Hash = '\x23';

            /// <summary>&#35; - Alias for <see cref="Hash"/></summary>
            public const char Number = '\x23';

            /// <summary>&#35; - Alias for <see cref="Hash"/></summary>
            public const char Pound = '\x23';

            /// <summary>&#36;</summary>
            public const char Dollar = '\x24';

            /// <summary>&#37;</summary>
            public const char Percent = '\x25';

            /// <summary>&amp;</summary>
            public const char Ampersand = '\x26';

            /// <summary>&apos;</summary>
            public const char SingleQuote = '\x27';

            /// <summary>&#40;</summary>
            public const char LeftParentheses = '\x28';

            /// <summary>&#40; - Alias for <see cref="LeftParentheses"/></summary>
            public const char OpenParentheses = '\x28';

            /// <summary>&#41;</summary>
            public const char RightParentheses = '\x29';

            /// <summary>&#41; - Alias for <see cref="RightParentheses"/></summary>
            public const char CloseParentheses = '\x29';

            /// <summary>&#42;</summary>
            public const char Asterisk = '\x2A';

            /// <summary>&#43;</summary>
            public const char Plus = '\x2B';

            /// <summary>&#44;</summary>
            public const char Comma = '\x2C';

            /// <summary>&#45;</summary>
            public const char Minus = '\x2D';

            /// <summary>&#45; See also <see cref="Minus"/></summary>
            public const char Hyphen = '\x2D';

            /// <summary>&#46;</summary>
            public const char Period = '\x2E';

            /// <summary>&#46; - Alias for <see cref="Period"/></summary>
            public const char Dot = '\x2E';

            /// <summary>&#47;</summary>
            public const char Slash = '\x2F';

            /// <summary>&#47; - Alias for <see cref="Slash"/></summary>
            public const char ForwardSlash = '\x2F';

            /// <summary>&#48;</summary>
            public const char Zero = '\x30';

            /// <summary>&#49;</summary>
            public const char One = '\x31';

            /// <summary>&#50;</summary>
            public const char Two = '\x32';

            /// <summary>&#51;</summary>
            public const char Three = '\x33';

            /// <summary>&#52;</summary>
            public const char Four = '\x34';

            /// <summary>&#53;</summary>
            public const char Five = '\x35';

            /// <summary>&#54;</summary>
            public const char Six = '\x36';

            /// <summary>&#55;</summary>
            public const char Seven = '\x37';

            /// <summary>&#56;</summary>
            public const char Eight = '\x38';

            /// <summary>&#57;</summary>
            public const char Nine = '\x39';

            /// <summary>&#58;</summary>
            public const char Colon = '\x3A';

            /// <summary>&#59;</summary>
            public const char Semicolon = '\x3B';

            /// <summary>&lt;</summary>
            public const char LessThan = '\x3C';

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
            /// <summary>&#61;</summary>
            public const char Equals = '\x3D';
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

            /// <summary>&#61; - Alias for <see cref="Equals"/></summary>
            public const char Equality = '\x3D';

            /// <summary>&gt;</summary>
            public const char GreaterThan = '\x3E';

            /// <summary>&#63;</summary>
            public const char QuestionMark = '\x3F';

            /// <summary>&#64;</summary>
            public const char At = '\x40';

            /// <summary>&#65;</summary>
            public const char UppercaseA = '\x41';

            /// <summary>&#66;</summary>
            public const char UppercaseB = '\x42';

            /// <summary>&#67;</summary>
            public const char UppercaseC = '\x43';

            /// <summary>&#68;</summary>
            public const char UppercaseD = '\x44';

            /// <summary>&#69;</summary>
            public const char UppercaseE = '\x45';

            /// <summary>&#70;</summary>
            public const char UppercaseF = '\x46';

            /// <summary>&#71;</summary>
            public const char UppercaseG = '\x47';

            /// <summary>&#72;</summary>
            public const char UppercaseH = '\x48';

            /// <summary>&#73;</summary>
            public const char UppercaseI = '\x49';

            /// <summary>&#74;</summary>
            public const char UppercaseJ = '\x4A';

            /// <summary>&#75;</summary>
            public const char UppercaseK = '\x4B';

            /// <summary>&#76;</summary>
            public const char UppercaseL = '\x4C';

            /// <summary>&#77;</summary>
            public const char UppercaseM = '\x4D';

            /// <summary>&#78;</summary>
            public const char UppercaseN = '\x4E';

            /// <summary>&#79;</summary>
            public const char UppercaseO = '\x4F';

            /// <summary>&#80;</summary>
            public const char UppercaseP = '\x50';

            /// <summary>&#81;</summary>
            public const char UppercaseQ = '\x51';

            /// <summary>&#82;</summary>
            public const char UppercaseR = '\x52';

            /// <summary>&#83;</summary>
            public const char UppercaseS = '\x53';

            /// <summary>&#84;</summary>
            public const char UppercaseT = '\x54';

            /// <summary>&#85;</summary>
            public const char UppercaseU = '\x55';

            /// <summary>&#86;</summary>
            public const char UppercaseV = '\x56';

            /// <summary>&#87;</summary>
            public const char UppercaseW = '\x57';

            /// <summary>&#88;</summary>
            public const char UppercaseX = '\x58';

            /// <summary>&#89;</summary>
            public const char UppercaseY = '\x59';

            /// <summary>&#90;</summary>
            public const char UppercaseZ = '\x5A';

            /// <summary>&#91;</summary>
            public const char LeftSquareBracket = '\x5B';

            /// <summary>&#91; - Alias for <see cref="LeftSquareBracket"/></summary>
            public const char OpenSquareBracket = '\x5B';

            /// <summary>&#92;</summary>
            public const char BackSlash = '\x5C';

            /// <summary>&#93;</summary>
            public const char RightSquareBracket = '\x5D';

            /// <summary>&#93; - Alias for <see cref="RightSquareBracket"/></summary>
            public const char CloseSquareBracket = '\x5D';

            /// <summary>&#94;</summary>
            public const char Caret = '\x5E';

            /// <summary>&#94; - Alias for <see cref="Caret"/></summary>
            public const char Circumflex = '\x5E';

            /// <summary>&#95;</summary>
            public const char Underscore = '\x5F';

            /// <summary>&#96;</summary>
            public const char Grave = '\x60';

            /// <summary>&#96; - Alias for <see cref="Grave"/></summary>
            public const char Accent = '\x60';

            /// <summary>&#97;</summary>
            public const char LowercaseA = '\x61';

            /// <summary>&#98;</summary>
            public const char LowercaseB = '\x62';

            /// <summary>&#99;</summary>
            public const char LowercaseC = '\x63';

            /// <summary>&#100;</summary>
            public const char LowercaseD = '\x64';

            /// <summary>&#101;</summary>
            public const char LowercaseE = '\x65';

            /// <summary>&#102;</summary>
            public const char LowercaseF = '\x66';

            /// <summary>&#103;</summary>
            public const char LowercaseG = '\x67';

            /// <summary>&#104;</summary>
            public const char LowercaseH = '\x68';

            /// <summary>&#105;</summary>
            public const char LowercaseI = '\x69';

            /// <summary>&#106;</summary>
            public const char LowercaseJ = '\x6A';

            /// <summary>&#107;</summary>
            public const char LowercaseK = '\x6B';

            /// <summary>&#108;</summary>
            public const char LowercaseL = '\x6C';

            /// <summary>&#109;</summary>
            public const char LowercaseM = '\x6D';

            /// <summary>&#110;</summary>
            public const char LowercaseN = '\x6E';

            /// <summary>&#111;</summary>
            public const char LowercaseO = '\x6F';

            /// <summary>&#112;</summary>
            public const char LowercaseP = '\x70';

            /// <summary>&#113;</summary>
            public const char LowercaseQ = '\x71';

            /// <summary>&#114;</summary>
            public const char LowercaseR = '\x72';

            /// <summary>&#115;</summary>
            public const char LowercaseS = '\x73';

            /// <summary>&#116;</summary>
            public const char LowercaseT = '\x74';

            /// <summary>&#117;</summary>
            public const char LowercaseU = '\x75';

            /// <summary>&#118;</summary>
            public const char LowercaseV = '\x76';

            /// <summary>&#119;</summary>
            public const char LowercaseW = '\x77';

            /// <summary>&#120;</summary>
            public const char LowercaseX = '\x78';

            /// <summary>&#121;</summary>
            public const char LowercaseY = '\x79';

            /// <summary>&#122;</summary>
            public const char LowercaseZ = '\x7A';

            /// <summary>&#123;</summary>
            public const char LeftCurlyBracket = '\x7B';

            /// <summary>&#123; - Alias for <see cref="LeftCurlyBracket"/></summary>
            public const char LeftCurlyBrace = '\x7B';

            /// <summary>&#123; - Alias for <see cref="LeftCurlyBracket"/></summary>
            public const char OpenCurlyBrace = '\x7B';

            /// <summary>&#124;</summary>
            public const char VerticalBar = '\x7C';

            /// <summary>&#124; - Alias for <see cref="VerticalBar"/></summary>
            public const char Pipe = '\x7C';

            /// <summary>&#125;</summary>
            public const char RightCurlyBracket = '\x7D';

            /// <summary>&#125; - Alias for <see cref="RightCurlyBracket"/></summary>
            public const char RightCurlyBrace = '\x7D';

            /// <summary>&#125; - <see cref="RightCurlyBracket"/></summary>
            public const char CloseCurlyBrace = '\x7D';

            /// <summary>&#126;</summary>
            public const char Tilde = '\x7E';

            // Invisible
            public const char Delete = '\x7F';
        }
    }
}