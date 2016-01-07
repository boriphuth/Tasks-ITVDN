using System;
using System.IO;

namespace TDD_VideoShop
{
    public static class TextWriterFactory
    {
        static TextWriter textWriter;
        public static void SetTextWriter(TextWriter mockWriter)
        {
            textWriter = mockWriter;
        }
        public static TextWriter GetTextWriter(string path)
        {
            if (textWriter != null)
            {
                return textWriter;
            }
            return new StreamWriter(path,true);
        }
    }
}