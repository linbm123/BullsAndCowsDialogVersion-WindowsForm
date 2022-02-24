using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05.Windows.MyForm
{
    public partial class MainGameForm : Form
    {
        private readonly int m_UserMaxNumOfIteration;
        private readonly int m_ResizeFormSizeToAdd;
        private readonly List<Color> m_RandomColorList;
        private readonly List<Label> m_LabelHorizontalLinesList;
        private readonly List<Button> m_ButtonRandomColorList;
        private readonly Button[,] m_ButtonsColorGuessing2dArr;
        private readonly Button[,,] m_ButtonsColorResulets2dArr;
        private readonly Button[] m_ButtonCheckResuletsArr;
        public ExtensionMethodsAndLogic m_ExtAndLogic;
        private Button m_ButtonCancel;
        private int m_CurrentUserIteration;

        public MainGameForm(int i_UserNumOfGuessing)
        {
            m_ResizeFormSizeToAdd = 80;
            m_CurrentUserIteration = 0;
            m_UserMaxNumOfIteration = i_UserNumOfGuessing;
            m_RandomColorList = new List<Color>(4);
            m_LabelHorizontalLinesList = new List<Label>(i_UserNumOfGuessing);
            m_ExtAndLogic = new ExtensionMethodsAndLogic();
            m_ButtonRandomColorList = new List<Button>();
            m_ButtonsColorGuessing2dArr = new Button[i_UserNumOfGuessing, 4];
            m_ButtonsColorResulets2dArr = new Button[i_UserNumOfGuessing, 2, 2];
            m_ButtonCheckResuletsArr = new Button[i_UserNumOfGuessing];

            initializeSecondForm(m_UserMaxNumOfIteration);
            initializeSecondFormComponents(m_UserMaxNumOfIteration);
            m_ExtAndLogic.SelectRandomColor(m_RandomColorList);
        }

        private void initializeSecondForm(int i_UserNumOfGuessing)
        {
            this.Text = "Color Guessing Game";
            int heightToAdd = m_ResizeFormSizeToAdd * i_UserNumOfGuessing;
            this.Size = new Size(500, 230 + heightToAdd);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void initializeSecondFormComponents(int i_UserNumOfGuessing)
        {
            int quarterScreenWidth = (this.Width / 4 * 3) / 5;

            for (int index = 0; index < 4; index++)
            {
                m_ButtonRandomColorList.Add(new Button());
                m_ButtonRandomColorList[index].BackColor = Color.Black;
                m_ButtonRandomColorList[index].Size = new Size(60, 60);
                m_ButtonRandomColorList[index].Top = 15;
                m_ButtonRandomColorList[index].Left = (quarterScreenWidth * (index + 1)) - (m_ButtonRandomColorList[index].Width / 2) - 30;
                this.Controls.Add(m_ButtonRandomColorList[index]);
            }

            for (int row = 0; row <= i_UserNumOfGuessing; row++)
            {
                m_LabelHorizontalLinesList.Add(new Label());
                m_LabelHorizontalLinesList[row].Size = new Size(this.Width, 1);
                m_LabelHorizontalLinesList[row].BorderStyle = BorderStyle.FixedSingle;
                m_LabelHorizontalLinesList[row].Left = 0;
                m_LabelHorizontalLinesList[row].Top = m_ButtonRandomColorList[0].Bottom + 20 + (m_ResizeFormSizeToAdd * row);
                this.Controls.Add(m_LabelHorizontalLinesList[row]);
            }

            for (int row = 0; row < i_UserNumOfGuessing; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    m_ButtonsColorGuessing2dArr[row, col] = new Button();
                    m_ButtonsColorGuessing2dArr[row, col].Size = new Size(60, 60);
                    m_ButtonsColorGuessing2dArr[row, col].Top = m_LabelHorizontalLinesList[row].Bottom + 10;
                    m_ButtonsColorGuessing2dArr[row, col].Left = m_ButtonRandomColorList[col].Left;
                    this.Controls.Add(m_ButtonsColorGuessing2dArr[row, col]);
                    m_ButtonsColorGuessing2dArr[row, col].Click += m_ButtonsColorGuessing2dArr_Click;

                    if (row == 0)
                    {
                        m_ButtonsColorGuessing2dArr[row, col].Text = "Select Color";
                    }
                    else
                    {
                        m_ButtonsColorGuessing2dArr[row, col].Enabled = false;
                        m_ButtonsColorGuessing2dArr[row, col].Text = string.Empty;
                    }
                }

                m_ButtonCheckResuletsArr[row] = new Button();
                m_ButtonCheckResuletsArr[row].Size = new Size(60, 30);
                m_ButtonCheckResuletsArr[row].Text = "--->>";
                m_ButtonCheckResuletsArr[row].Enabled = false;
                m_ButtonCheckResuletsArr[row].Top = 
                    (m_ButtonsColorGuessing2dArr[row, 3].Height / 4) + 
                    m_LabelHorizontalLinesList[row].Bottom + 10;
                m_ButtonCheckResuletsArr[row].Left = m_ButtonsColorGuessing2dArr[row, 3].Right + 20;
                this.Controls.Add(m_ButtonCheckResuletsArr[row]);
                m_ButtonCheckResuletsArr[row].Click += m_ButtonCheckResuletsArr_Click;

                for (int innerRow = 0; innerRow < 2; innerRow++)
                {
                    for (int innerCol = 0; innerCol < 2; innerCol++)
                    {
                        m_ButtonsColorResulets2dArr[row, innerRow, innerCol] = new Button();
                        m_ButtonsColorResulets2dArr[row, innerRow, innerCol].Size = new Size(25, 25);
                        m_ButtonsColorResulets2dArr[row, innerRow, innerCol].Enabled = false;
                        m_ButtonsColorResulets2dArr[row, innerRow, innerCol].Top = 10 + m_LabelHorizontalLinesList[row].Bottom +
                            (innerRow * (m_ButtonsColorResulets2dArr[row, innerRow, innerCol].Height + 10));
                        m_ButtonsColorResulets2dArr[row, innerRow, innerCol].Left = (innerCol *                                                                                            
                            (m_ButtonsColorResulets2dArr[row, innerRow, innerCol].Width + 10)) +
                            m_ButtonCheckResuletsArr[row].Right + 20;
                        this.Controls.Add(m_ButtonsColorResulets2dArr[row, innerRow, innerCol]);
                    }
                }
            }

            m_ButtonCancel = new Button();
            m_ButtonCancel.Text = "Back";
            m_ButtonCancel.BackColor = Color.FromArgb(220, 220, 220);
            m_ButtonCancel.Font = new Font(FontFamily.GenericSerif, 20f);
            m_ButtonCancel.Size = new Size(130, 40);
            m_ButtonCancel.Left = this.Left + (this.Width / 2) - (m_ButtonCancel.Width / 2);
            m_ButtonCancel.Top = m_LabelHorizontalLinesList[i_UserNumOfGuessing].Bottom - (m_ButtonCancel.Height / 2) + 
                ((this.ClientSize.Height - m_LabelHorizontalLinesList[i_UserNumOfGuessing].Bottom) / 2);
            this.Controls.Add(m_ButtonCancel);
            m_ButtonCancel.Click += m_ButtonCancel_Click;
        }

        private void m_ButtonCheckResuletsArr_Click(object sender, EventArgs e)
        {
            Button currentButtonCheck = sender as Button;
            currentButtonCheck.Enabled = false;

            GetSelectedColors(m_ButtonsColorGuessing2dArr, m_CurrentUserIteration, out List<Color> o_UserColors);
            bool isUserWin = m_ExtAndLogic.CompereBetweenUserGuessingAndRandomColors(
                o_UserColors, 
                m_RandomColorList, 
                out List<Color> o_Results);
            DisplayResults(o_Results);

            if (isUserWin || m_CurrentUserIteration == (m_UserMaxNumOfIteration - 1))
            {
                ExposeRandomColors();
                DisplayGameStatusToUserWithMessegeBox(isUserWin);
            }
            else
            {
                DisableCurrentButtonsLineAndEnableNextLine(currentButtonCheck);
            }
        }

        private void m_ButtonsColorGuessing2dArr_Click(object sender, EventArgs e)
        {
            Button currentButten = sender as Button;

            GetSelectedColors(m_ButtonsColorGuessing2dArr, m_CurrentUserIteration, out List<Color> selectedColors);
            ColorGuessingGameFormsHandling.RunThirdForm(selectedColors, out Color o_Color);

            if (!o_Color.IsEmpty)
            {
                currentButten.Text = string.Empty;
                currentButten.BackColor = o_Color;
            }

            if (IsCurrentLineCompleted(m_ButtonsColorGuessing2dArr, m_CurrentUserIteration))
            {
                m_ButtonCheckResuletsArr[m_CurrentUserIteration].Enabled = true;
            }
        }

        private void m_ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
