using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05.Windows.MyForm
{
    public class ColorChoiceGameForm : Form
    {
        private ExtensionMethodsAndLogic m_ExAndLogic;
        private Button[,] m_ButtonColors;
        private int marging = 20;
        private Color currentColor;

        public ColorChoiceGameForm(List<Color> selectedColors)
        {
            m_ExAndLogic = new ExtensionMethodsAndLogic();
            initializeForm();
            initializeComponents(selectedColors);
        }

        private void initializeForm()
        {
            Text = "Color Options";
            Size = new Size(360, 230);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            StartPosition = FormStartPosition.CenterScreen;
        }        
        
        private void initializeComponents(List<Color> selectedColors)
        {
            m_ButtonColors = new Button[2, 4];

            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    m_ButtonColors[row, col] = new Button();
                    m_ButtonColors[row, col].Size = new Size(60, 60);
                    m_ButtonColors[row, col].BackColor = m_ExAndLogic.Colors[(4 * row) + col];
                    m_ButtonColors[row, col].Top = marging + ((marging + m_ButtonColors[row, col].Height) * row);
                    m_ButtonColors[row, col].Left = marging + ((m_ButtonColors[row, col].Width + marging) * col);
                    this.Controls.Add(m_ButtonColors[row, col]);
                    m_ButtonColors[row, col].Click += m_ButtonColors_Click;
                    if (selectedColors.Contains(m_ButtonColors[row, col].BackColor))
                    {
                        m_ButtonColors[row, col].Enabled = false;
                        m_ButtonColors[row, col].Text = "Already Selected";
                    }
                }
            }
        }

        private void m_ButtonColors_Click(object sender, EventArgs e)
        {
            Button currentButton = sender as Button;
            currentColor = currentButton.BackColor;
            this.Close();
        }

        public void ColorFormShowDialog(out Color o_Color)
        {
            this.ShowDialog();
            o_Color = currentColor;
        }
    }
}
