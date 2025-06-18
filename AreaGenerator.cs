using System;
using System.Windows.Forms;

namespace AIAreaGeneratorPlugin
{
    public static class AreaGenerator
    {
        public static void Generate(AreaGenerationRequest request)
        {
            // For now, just log what would happen
            string summary = $"[GENERATOR] Creating {request.Type} area:\n" +
                             $"- Name: {request.AreaName}\n" +
                             $"- Size: {request.Width} x {request.Height}\n" +
                             $"- Tileset: {request.Tileset}\n" +
                             $"- Theme: {request.Theme}";

            MessageBox.Show(summary, "AreaGenerator Called");

            // TODO: Load a template .ARE/.GIT or build from scratch
            // TODO: Generate tile/terrain layout
            // TODO: Write the resulting area files
        }
    }
}
