using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDefinitionService.saveeventdata
{
    static class TXTWriter
    {
        public static void Write(string input)
        {
            string fileName = string.Format(@"C:\mok\log_{0}b.txt", DateTime.Now.Year + DateTime.Now.DayOfYear);
            using (FileStream file = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            using (StreamWriter _writer = new StreamWriter(file, Encoding.UTF8))
            {
                _writer.Write(input);
            }
        }
        public static void Writetime(string input)
        {
            string fileName = string.Format(@"C:\mok\time_{0}b.txt", DateTime.Now.Year + DateTime.Now.DayOfYear);
            using (FileStream file = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            using (StreamWriter _writer = new StreamWriter(file, Encoding.UTF8))
            {
                _writer.Write(input);
            }
        }
    }
}
