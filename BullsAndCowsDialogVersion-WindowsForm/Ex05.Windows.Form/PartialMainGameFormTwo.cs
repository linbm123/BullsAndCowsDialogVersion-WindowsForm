using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05.Windows.MyForm
{
    public partial class MainGameForm : Form
    {
        public void DisableCurrentButtonsLineAndEnableNextLine(Button i_Btn)
        {
            for (int index = 0; index < 4; index++)
            {
                m_ButtonsColorGuessing2dArr[m_CurrentUserIteration + 1, index].Enabled = true;
                m_ButtonsColorGuessing2dArr[m_CurrentUserIteration + 1, index].Text = "Select Color";
                m_ButtonsColorGuessing2dArr[m_CurrentUserIteration, index].Enabled = false;
            }

            m_CurrentUserIteration++;
        }

        public void DisplayGameStatusToUserWithMessegeBox(bool isUserWon)
        {
            if (m_CurrentUserIteration == (m_UserMaxNumOfIteration - 1) && !isUserWon)
            {
                MessageBox.Show("Unfortunatly, You Lose !!!", "Game Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Congratulations, You Win !!!", "Game Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            for (int index = 0; index < 4; index++)
            {
                m_ButtonsColorGuessing2dArr[m_CurrentUserIteration, index].Enabled = false;
            }
        }

        public void ExposeRandomColors()
        {
            for (int index = 0; index < 4; index++)
            {
                m_ButtonRandomColorList[index].BackColor = m_RandomColorList[index];
            }
        }

        public void DisplayResults(List<Color> i_Results)
        {
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    if ((2 * row + col) < i_Results.Count)
                    {
                        if (i_Results[2 * row + col] != null)
                        {
                            m_ButtonsColorResulets2dArr[m_CurrentUserIteration, row, col].BackColor = i_Results[2 * row + col];
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public void GetSelectedColors(Button[,] i_Matrix, int i_Row, out List<Color> o_Colors)
        {
            o_Colors = new List<Color>();

            for (int i = 0; i < 4; i++)
            {
                o_Colors.Add(i_Matrix[i_Row, i].BackColor);
            }
        }

        public bool IsCurrentLineCompleted(Button[,] i_Matrix, int lineNum)
        {
            bool isLineCompleted = true;

            for (int index = 0; index < 4; ++index)
            {
                if (i_Matrix[lineNum, index].BackColor.IsSystemColor && isLineCompleted)
                {
                    isLineCompleted = false;
                    break;
                }
            }

            return isLineCompleted;
        }
    }
}
