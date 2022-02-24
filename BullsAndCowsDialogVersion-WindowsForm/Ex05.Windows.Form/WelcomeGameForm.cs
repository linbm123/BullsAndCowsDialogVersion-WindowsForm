using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Ex05.Windows.MyForm
{
    class WelcomeGameForm : Form
    {
        private readonly string r_ProjectDirectory;
        private Label m_LabelHeader;
        private PictureBox m_PictureBoxGameIcon;
        private Button m_ButtonExit;
        private Button m_ButtonStart;
        private Button m_ButtonNumOfChances;
        private int m_NumOfChances;

        public WelcomeGameForm()
        {
            m_NumOfChances = 4;
            string workingDirectory = Directory.GetCurrentDirectory();
            r_ProjectDirectory = Directory.GetParent(workingDirectory)?.Parent?.FullName;

            initializeForm();
            initializeComponents();
        }

        private void initializeForm()
        {
            this.Text = "Color Guessing Game";
            this.Size = new Size(500, 400);
            this.BackColor = Color.AliceBlue;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void initializeComponents()
        {
            m_LabelHeader = new Label();
            m_LabelHeader.Text = "Welcome To The Color Guessing Game";
            m_LabelHeader.Font = new Font(FontFamily.GenericSerif, 20f);
            m_LabelHeader.AutoSize = true;
            m_LabelHeader.BackColor = Color.Transparent;
            m_LabelHeader.Width = 100;
            m_LabelHeader.Top = 20;
            m_LabelHeader.Click += m_ButtonStart_Click;
            this.Controls.Add(m_LabelHeader);
            m_LabelHeader.Left = this.ClientSize.Width / 2 - m_LabelHeader.Width / 2;

            m_ButtonStart = new Button();
            m_ButtonStart.Text = "START";
            m_ButtonStart.Width = 100;
            m_ButtonStart.Top = this.ClientSize.Height - m_ButtonStart.Height - 20;
            m_ButtonStart.Left = this.ClientSize.Width - m_ButtonStart.Width - 20;
            m_ButtonStart.Click += m_ButtonStart_Click;
            this.Controls.Add(m_ButtonStart);

            m_ButtonExit = new Button();
            m_ButtonExit.Text = "Exit";
            m_ButtonExit.Width = 100;
            m_ButtonExit.Top = this.ClientSize.Height - m_ButtonStart.Height - 20;
            m_ButtonExit.Left = m_ButtonStart.Left - m_ButtonExit.Width - 20;
            m_ButtonExit.Click += m_ButtonExit_Click;
            this.Controls.Add(m_ButtonExit);

            m_ButtonNumOfChances = new Button();
            m_ButtonNumOfChances.Text = string.Format("Number of Chances : {0}", m_NumOfChances);
            m_ButtonNumOfChances.Width = this.ClientSize.Width / 6 * 4;
            m_ButtonNumOfChances.Height = m_ButtonExit.Width / 2;
            m_ButtonNumOfChances.Top = this.ClientSize.Height / 2 - m_ButtonNumOfChances.Height * 2;
            m_ButtonNumOfChances.Left = this.ClientSize.Width / 2 - m_ButtonNumOfChances.Width / 2;
            m_ButtonNumOfChances.Click += m_ButtonNumOfChances_Click;
            this.Controls.Add(m_ButtonNumOfChances);

            m_PictureBoxGameIcon = new PictureBox();
            m_PictureBoxGameIcon.Load(string.Format(@"{0}\Images\color-wheel.png", r_ProjectDirectory));
            m_PictureBoxGameIcon.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);
            m_PictureBoxGameIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            m_PictureBoxGameIcon.Top = 0;
            m_PictureBoxGameIcon.Left = 0;
            this.Controls.Add(m_PictureBoxGameIcon);
        }

        private void m_ButtonNumOfChances_Click(object sender, EventArgs e)
        {
            if(m_NumOfChances >= 10)
            {
                m_NumOfChances = 4;
            }
            else
            {
                m_NumOfChances++;
            }

            m_ButtonNumOfChances.Text = string.Format("Number of Chances : " + m_NumOfChances);
        }

        private void m_ButtonStart_Click(object sender, EventArgs e)
        {
            ColorGuessingGameFormsHandling.RunSecondForm(m_NumOfChances);
        }

        private void m_ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
