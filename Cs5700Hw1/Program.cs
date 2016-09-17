using System;
using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;
using Cs5700Hw1.Serialization;

namespace Cs5700Hw1
{
    public class Options
    {
        [Option('i', "input", Required = true,
             HelpText =
                 "The names and types of the file inputs, e.g. -i file1.json,Json;file2.xml,Xml, format is <file_name>,<file_type>;<file_name>,<file_type>; ... etc. Valid file types are 'Xml' and 'Json'"
         )]
        public string InputFiles { get; set; }

        [Option('o', "output", Required = false, DefaultValue = "out.txt",
             HelpText = "The name of the output result file. default=out.txt")]
        public string OutputFile { get; set; }

        [HelpOption]
        public string GetUsage() => HelpText.AutoBuild(this,
            current => HelpText.DefaultParsingErrorsHandler(this, current));
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var options = new Options();
            if (Parser.Default.ParseArguments(args, options))
            {
                var outFileName = options.OutputFile;

                var fileInfos = new List<FileInfo>();
                var inputs = options.InputFiles?.Split(';');
                if ((inputs == null) || (inputs.Length < 1))
                {
                    Console.WriteLine("Filenames are a required input");
                    return;
                }
                foreach (var i in inputs)
                {
                    var fi = i.Split(',');
                    if (fi.Length != 2)
                    {
                        Console.WriteLine("Filenames were not in the proper format");
                        return;
                    }
                    var fileType = (FileType) Enum.Parse(typeof(FileType), fi[1]);
                    fileInfos.Add(new FileInfo(fi[0], fileType));
                }

                //Run matching
                var matcherRunner = new MatcherRunner(fileInfos, outFileName);
                matcherRunner.Run();
            }
        }
    }
}