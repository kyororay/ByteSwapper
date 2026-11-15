//想定区切り文字：「」「 」「,」「, 」「,0x」「 0x」「, 0x」

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ByteSwapper
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                if (Clipboard.ContainsText())
                {
                    var input = Clipboard.GetText();
                    if (!string.IsNullOrEmpty(input))
                    {
                        input = input.Replace("0x", "").Replace(", ", " ").Replace(",", " ");
                        var byte_ary = input.Split(' ');
                        if (byte_ary.Length == 1) //区切り文字無し
                        {
                            var list = new List<string>();
                            if (input.Length % 2 != 0)
                                input = "0" + input;
                            for (int i = 0; i < input.Length; i += 2)
                                list.Add(input.Substring(i, 2));
                            byte_ary = list.ToArray();
                        }

                        var output = string.Join("", byte_ary.Reverse());
                        Clipboard.SetText(output);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("<---------- Error message ---------->");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
