using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Webp;

namespace BEC.ImageProcessor
{
    internal class ConvertImage
    {
        private readonly Options options;

        internal ConvertImage(Options options)
        {
            this.options = options;
        }

        internal void Convert()
        {
            string[] formats = { ".jpg", ".jpeg", ".png", ".webp" };
            var files = Directory.EnumerateFiles(options.Directory, "*.*", new EnumerationOptions
            {
                RecurseSubdirectories = true,
                ReturnSpecialDirectories = false,
                IgnoreInaccessible = true,
                MatchCasing = MatchCasing.CaseInsensitive,
                MaxRecursionDepth = 10,
            }).Where(x => formats.Any(x.EndsWith));

            var encoder = new WebpEncoder
            {
                Method = WebpEncodingMethod.Level4
            };

            foreach (var file in files)
            {
                var f = file.ToLowerInvariant();

                // don't overwrite
                if(!options.Overwrite && f.EndsWith(options.Format.ToLowerInvariant(), StringComparison.InvariantCultureIgnoreCase))
                {
                    continue;
                }

                if(options.Overwrite || !File.Exists($"{f.TrimEnd('\\').TrimEnd('/')}.{options.Format}"))
                {
                    var image = Image.Load(file);
                    switch (options.Format)
                    {
                        case "webp":
                            image.SaveAsWebp($"{f.TrimEnd('\\').TrimEnd('/')}.{options.Format}", encoder);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(options.Format)); 
                    }
                }

            } // foreach

        }
    }
}
