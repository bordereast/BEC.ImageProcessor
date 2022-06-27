using CommandLine;
using System;

namespace BEC.ImageProcessor // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(RunOptions)
                .WithNotParsed(HandleParseError);
        }

        static void RunOptions(Options opts)
        {
            // remove period if present
            opts.Format = opts.Format.Replace(".", "");

            var converter = new ConvertImage(opts);
            converter.Convert();
        }
        static void HandleParseError(IEnumerable<Error> errs)
        { 
        }
    }
}