using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineMinimum
{
    public partial class saloon : Form
    {
        Panel pnlSeat;
        public saloon()
        {
            InitializeComponent();
        }

        private void saloon_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
            CreateExitButton();
            CreateScreen();
            CreateSeatPanel();
            CreateSeatCharInfo();
            CreateSeatBelt();
            CreateRefreshButton();
        }

        void CreateRefreshButton()
        {
            Button btnRefresh = new Button();
            btnRefresh.Size = new Size(100, 30);
            btnRefresh.Location = new Point(this.Width - 250, this.Height - 100);
            btnRefresh.Text = "refresh";
            btnRefresh.BackColor = Color.LightBlue;
            btnRefresh.ForeColor = Color.Red;
            btnRefresh.Font = GetFont();
            btnRefresh.Click += BtnRefresh_Click;

            this.Controls.Add(btnRefresh);

           
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            pnlSeat.Dispose();
            CreateSeatPanel();
            CreateSeatCharInfo();
            CreateSeatBelt();
        }

        void CreateSeatBelt()
        {
            int koltukNo = 1;
            int sayi = 65;

            for (int i = 0; i < 7; i++)
            {
                string harf = Convert.ToChar(sayi + i).ToString();
                for (int j = 0; j < 13; j++)
                {
                    Button btnSeat = new Button();
                    btnSeat.BackColor = Color.Maroon;
                    btnSeat.ForeColor = Color.White;
                    btnSeat.Font = GetFont();
                    btnSeat.TextAlign = ContentAlignment.MiddleCenter;
                    btnSeat.Location = new Point(j * 95 + 115, i * 95 + 20);
                    btnSeat.Size = new Size(50, 50);
                    btnSeat.Text = harf + koltukNo.ToString();
                    btnSeat.Click += BtnSeat_Click;
                    pnlSeat.Controls.Add(btnSeat);
                    koltukNo++;
                    
                }
                koltukNo = 1;

            }
        }

        void BtnSeat_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.BackColor==Color.Green)
            {
                DialogResult result = MessageBox.Show("do you want to cancel to sale " + btn.Text + " blet?", " sales cancel operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result==DialogResult.Yes)
                {
                    btn.BackColor = Color.Maroon;
                }


            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want to sale" + btn.Text + " belt ?", "sales operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    btn.BackColor = Color.Green;
                }
            }
            //4 aşama mesaj+başlık+buton+icon
            

        }

        void CreateSeatCharInfo()
        {
            int sayi = 65;
            for (int i = 0; i < 8; i++)
            {
                Label lblInfo = new Label();
                lblInfo.Location = new Point(20,i * 95 + 20);
                lblInfo.Font = GetFont();
                lblInfo.Text = Convert.ToChar(sayi + i).ToString();
                lblInfo.TextAlign = ContentAlignment.MiddleCenter;
                lblInfo.BackColor = Color.Black;
                lblInfo.ForeColor = Color.White;
                lblInfo.Size = new Size(50, 50);
                pnlSeat.Controls.Add(lblInfo);
            }


        }

        void CreateSeatPanel()
        {
            pnlSeat = new Panel();
            pnlSeat.BackColor = Color.LightGray;
            pnlSeat.Size = new Size(this.Width - 210, 660);
            pnlSeat.Location = new Point(100, 70);
            this.Controls.Add(pnlSeat);
        }

        void CreateScreen()
        {
            Label lblScreen = new Label();
            lblScreen.Location = new Point(100, 20);
            lblScreen.Size = new Size(this.Width - 210, 20);
            lblScreen.Text = "SCREEN";
            lblScreen.TextAlign = ContentAlignment.MiddleCenter;
            lblScreen.Font = GetFont();
            lblScreen.BackColor = Color.Black;
            lblScreen.ForeColor = Color.White;
            this.Controls.Add(lblScreen);

        }

         Font GetFont()
        {
            return new Font("Arial", 12f);
        }

        void CreateExitButton()
        {
            Button btnExit = new Button();
            btnExit.Size = new Size(100, 30);
            btnExit.BackColor = Color.Red;
            btnExit.ForeColor = Color.White;
            btnExit.Font = GetFont();
            btnExit.Location = new Point(0, 0);
            btnExit.Location = new Point(this.Width - 150, this.Height - 100);
            btnExit.Text = "EXIT";
            btnExit.Click += BtnExit_Click;
            this.Controls.Add(btnExit);

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
