using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEC.ImageProcessor
{
    internal class Options
    {
        [Option('d', "directory", Required = true, HelpText = "Directory of files to be processed.")]
        public string Directory { get; set; } = ".";


        [Option('f', "format",
          Required = true,
          HelpText = "Format to convert to. jpg, png, webp. Default is webp.")]
        public string Format { get; set; } = "webp";


        [Option('o', "overwrite",
          Required = false,
          Default = false,
          HelpText = "Overwrite target file if it exists. Default is false.")]
        public bool Overwrite { get; set; }
    }
}
