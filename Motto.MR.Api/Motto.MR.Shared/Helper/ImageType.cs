using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Motto.MR.Shared.Helper
{
    public static class ImageType
    {
        public static string GetImageType(string base64String)
        {
            // Expressão regular para extrair o tipo de imagem
            string pattern = @"^data:image/(?<type>[a-zA-Z]+);base64";

            Match match = Regex.Match(base64String, pattern);

            if (match.Success)
            {
                return match.Groups["type"].Value.ToLower();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
