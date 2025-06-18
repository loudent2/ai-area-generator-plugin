using System;
using System.Windows.Forms;

namespace AIAreaGeneratorPlugin
{
    public class AreaGenForm : Form
    {
        private RadioButton outdoorRadio;
        private RadioButton indoorRadio;
        private Panel dynamicPanel;
        private Button generateBtn;

        public AreaGenForm()
        {
            this.Text = "AI Area Generator";
            this.Width = 460;
            this.Height = 380;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            Label typeLabel = new Label { Text = "Area Type:", Left = 10, Top = 15, Width = 80 };

            outdoorRadio = new RadioButton { Text = "Outdoor", Left = 100, Top = 12, Width = 80 };
            indoorRadio = new RadioButton { Text = "Indoor", Left = 200, Top = 12, Width = 80 };

            outdoorRadio.CheckedChanged += (s, e) => UpdateDynamicFields();
            indoorRadio.CheckedChanged += (s, e) => UpdateDynamicFields();

            dynamicPanel = new Panel { Left = 10, Top = 50, Width = 420, Height = 240 };
            generateBtn = new Button { Text = "Generate", Left = 310, Top = 300, Width = 100 };

            generateBtn.Click += GenerateBtn_Click;

            this.Controls.AddRange(new Control[] {
        typeLabel, outdoorRadio, indoorRadio, dynamicPanel, generateBtn
    });

            UpdateDynamicFields(); // initial layout
        }


        private void UpdateDynamicFields()
        {
            dynamicPanel.Controls.Clear();

            if (outdoorRadio.Checked)
                LoadOutdoorFields();
            else
                LoadIndoorFields();
        }

        private void LoadOutdoorFields()
        {
            dynamicPanel.Controls.AddRange(new Control[] {
                new Label { Text = "Area Name:", Left = 0, Top = 0 },
                new TextBox { Name = "Name", Left = 100, Top = 0, Width = 250 },

                new Label { Text = "Width:", Left = 0, Top = 40 },
                new NumericUpDown { Name = "Width", Left = 100, Top = 40, Width = 60, Minimum = 4, Maximum = 64, Value = 16 },

                new Label { Text = "Height:", Left = 170, Top = 40 },
                new NumericUpDown { Name = "Height", Left = 270, Top = 40, Width = 60, Minimum = 4, Maximum = 64, Value = 16 },

                new Label { Text = "Terrain Type:", Left = 0, Top = 80 },
                new ComboBox {
                    Name = "Tileset",
                    Left = 100, Top = 80, Width = 250,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Items = { "Forest", "Desert", "Mountains", "Swamp", "City Ruins" }
                },

                new Label { Text = "Theme:", Left = 0, Top = 120 },
                new TextBox { Name = "Theme", Left = 100, Top = 120, Width = 250 }
            });
        }

        private void LoadIndoorFields()
        {
            dynamicPanel.Controls.AddRange(new Control[] {
                new Label { Text = "Area Name:", Left = 0, Top = 0 },
                new TextBox { Name = "Name", Left = 100, Top = 0, Width = 250 },

                new Label { Text = "Width (tiles):", Left = 0, Top = 40 },
                new NumericUpDown { Name = "Width", Left = 100, Top = 40, Width = 60, Minimum = 4, Maximum = 32, Value = 8 },

                new Label { Text = "Height (tiles):", Left = 170, Top = 40 },
                new NumericUpDown { Name = "Height", Left = 270, Top = 40, Width = 60, Minimum = 4, Maximum = 32, Value = 8 },

                new Label { Text = "Tileset:", Left = 0, Top = 80 },
                new ComboBox {
                    Name = "Tileset",
                    Left = 100, Top = 80, Width = 250,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Items = { "Castle Interior", "Mine", "Drow Interior", "Crypt", "Wizard Tower" }
                },

                new Label { Text = "Theme:", Left = 0, Top = 120 },
                new TextBox { Name = "Theme", Left = 100, Top = 120, Width = 250 }
            });
        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            string name = GetTextBoxValue("Name");
            int width = GetNumericValue("Width");
            int height = GetNumericValue("Height");
            string tileset = GetComboBoxValue("Tileset");
            string theme = GetTextBoxValue("Theme");

            if (string.IsNullOrEmpty(name.Trim()) || string.IsNullOrEmpty(tileset.Trim()))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            var request = new AreaGenerationRequest
            {
                AreaName = name.Trim(),
                Type = outdoorRadio.Checked ? AreaType.Outdoor : AreaType.Indoor,
                Width = width,
                Height = height,
                Tileset = tileset.Trim(),
                Theme = theme.Trim()
            };

            AreaGenerator.Generate(request);
        }



        private string GetTextBoxValue(string name) =>
            (dynamicPanel.Controls[name] as TextBox)?.Text ?? "";

        private int GetNumericValue(string name) =>
            (int)((dynamicPanel.Controls[name] as NumericUpDown)?.Value ?? 0);

        private string GetComboBoxValue(string name) =>
            (dynamicPanel.Controls[name] as ComboBox)?.SelectedItem?.ToString() ?? "";
    }
}
