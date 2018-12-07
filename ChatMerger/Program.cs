using System;
using System.IO;
using HtmlAgilityPack;

namespace ChatMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 2)
            {
                if (File.Exists(args[0]))
                {
                    if (File.Exists(args[1]))
                    {
                        HtmlDocument document1 = new HtmlDocument();
                        HtmlDocument document2 = new HtmlDocument();
                        document1.Load(args[0]);
                        document2.Load(args[1]);
                        
                        Console.WriteLine("Hello world    " + document2.DocumentNode.SelectSingleNode(".//div[@class='chatlog']"));
                        var msg1 = document1.DocumentNode.SelectSingleNode(".//div[@class='chatlog']").ChildNodes;
                        var log2 = document2.DocumentNode.SelectSingleNode(".//div[@class='chatlog']");
                        log2.AppendChildren(msg1);
                        FileStream sw = new FileStream(args[1], FileMode.Create);
                        document2.Save(sw);
                    }
                    else
                    {
                        Console.WriteLine("Second path is invalid");
                    }
                }
                else
                {
                    if (!File.Exists(args[1]))
                    {
                        Console.WriteLine("First and second path is invalid");
                    }
                    else
                    {
                        Console.WriteLine("First path is invalid");
                    }
                }
            }
            else
            {
                Console.WriteLine("Too few arguments");
            }
        }
    }
}
