using System.Collections.Generic;
using System.Drawing;

namespace Ex05.Windows.MyForm
{
    public static class ColorGuessingGameFormsHandling
    {
        private static WelcomeGameForm s_FirstFormWelcomeGame;
        private static MainGameForm s_SecondFormMainGame;
        private static ColorChoiceGameForm s_ThirdFormColorSelect;

        public static void Run()
        {
            s_FirstFormWelcomeGame = new WelcomeGameForm();
            s_FirstFormWelcomeGame.ShowDialog();
        }

        public static void RunSecondForm(int i_UserNumOfGuessing)
        {
            s_FirstFormWelcomeGame.Hide();
            s_FirstFormWelcomeGame.Close();
            s_SecondFormMainGame = new MainGameForm(i_UserNumOfGuessing);
            s_SecondFormMainGame.ShowDialog();
            s_FirstFormWelcomeGame = new WelcomeGameForm();
            s_FirstFormWelcomeGame.ShowDialog();
        }

        public static void RunThirdForm(List<Color> i_SelectedColors, out Color o_Color)
        {
            s_ThirdFormColorSelect = new ColorChoiceGameForm(i_SelectedColors);
            s_ThirdFormColorSelect.ColorFormShowDialog(out o_Color);
        }
    }
}