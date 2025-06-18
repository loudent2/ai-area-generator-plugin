using System;
using System.Collections.Generic;
using System.Text;

namespace AIAreaGeneratorPlugin
{
    public enum AreaType
    {
        Outdoor,
        Indoor
    }

    public class AreaGenerationRequest
    {
        public string AreaName { get; set; } = string.Empty;
        public AreaType Type { get; set; }
        public int Width { get; set; } = 16;
        public int Height { get; set; } = 16;
        public string Tileset { get; set; } = string.Empty;
        public string Theme { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Type} Area '{AreaName}' ({Width}x{Height}) using '{Tileset}', theme: '{Theme}'";
        }
    }
}
