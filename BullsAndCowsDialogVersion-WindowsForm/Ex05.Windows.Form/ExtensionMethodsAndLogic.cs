using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;

namespace Ex05.Windows.MyForm
{
    public class ExtensionMethodsAndLogic
    {
        public readonly List<Color> Colors = new List<Color>()
        {
            Color.Violet,
            Color.Red,
            Color.Green,
            Color.BlueViolet,
            Color.Blue,
            Color.Yellow,
            Color.Brown,
            Color.White
        };

        public void SelectRandomColor(List<Color> i_Matrix)
        {
            List<int> randomNums = new List<int>(4);
            Random rand = new Random();
            int num;

            for (int index = 0; index < 4; index++)
            {
                num = rand.Next(0, 8);
                if (!randomNums.Contains(num))
                {
                    i_Matrix.Add(Colors[num]);
                    randomNums.Add(num);
                    Debug.WriteLine(Colors[num]);
                }
                else
                {
                    index--;
                }
            }
        }

        public bool CompereBetweenUserGuessingAndRandomColors(
            List<Color> o_UserColors,
            List<Color> m_RandomColorList,
            out List<Color> o_Results)
        {
            o_Results = new List<Color>();
            List<Color> bul = new List<Color>();
            List<Color> pgia = new List<Color>();

            for (int userColorIndex = 0; userColorIndex < o_UserColors.Count; userColorIndex++)
            {
                for (int randomColorIndex = 0; randomColorIndex < m_RandomColorList.Count; randomColorIndex++)
                {
                    if (o_UserColors[userColorIndex] == m_RandomColorList[randomColorIndex] && userColorIndex == randomColorIndex)
                    {
                        bul.Add(Color.Black);
                    }
                    else if (o_UserColors[userColorIndex] == m_RandomColorList[randomColorIndex])
                    {
                        pgia.Add(Color.Yellow);
                    }
                }
            }

            o_Results.AddRange(bul);
            o_Results.AddRange(pgia);

            return bul.Count == 4 ? true : false;
        }
    }
}