using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace YilanOyunu
{
    public partial class OyunAlaniForm : Form
    {

        Panel pnlYilanParcasi;
        Panel yem;
        List<Panel> yilan;
        Timer tmrOyun;
        Random rnd = new Random();
        int skor;
        bool yonDegisti = false;
        int panelX = 400;
        int panelY = 400;
        int yilanHizi = 20;
        string istikamet;

        public OyunAlaniForm()
        {
            InitializeComponent();
            this.Size = new Size(panelX + 16, panelY + 30 + 39);
            OyunuBaslat();
        }

        void OyunuBaslat()
        {
            skor = 0;
            yilan = new List<Panel>();
            tmrOyun = new Timer();
            istikamet = null;
            lblSkor.Text = "Skor: " + skor.ToString();
            pnlOyunAlani.Size = new Size(panelX, panelY);
            yonDegisti = false;

            pnlYilanParcasi = new Panel();
            pnlYilanParcasi.Size = new Size(20, 20);
            pnlYilanParcasi.Location = new Point(panelX / 2, panelY / 2);
            pnlYilanParcasi.BackColor = Color.White;
            pnlOyunAlani.Controls.Add(pnlYilanParcasi);
            yilan.Add(pnlYilanParcasi);

            yem = new Panel();
            yem.Size = new Size(20, 20);
            yem.Location = new Point(panelX / 2 + panelX / 10, panelY / 2);
            yem.BackColor = Color.Yellow;
            pnlOyunAlani.Controls.Add(yem);

            tmrOyun.Interval = 100;
            tmrOyun.Enabled = true;
            tmrOyun.Start();
            tmrOyun.Tick += TmrOyun_Tick;      
        }

        void ParcaEkle()
        {
            pnlYilanParcasi = new Panel();
            pnlYilanParcasi.Size = new Size(20, 20);
            pnlYilanParcasi.Location = new Point(yem.Location.X, yem.Location.Y);
            pnlYilanParcasi.BackColor = Color.Red;
            pnlOyunAlani.Controls.Add(pnlYilanParcasi);
            yilan.Add(pnlYilanParcasi);
        }

        void YilaniSagaHareketEttir()
        {
            pnlYilanParcasi = new Panel();
            pnlYilanParcasi.Size = new Size(20, 20);
            pnlYilanParcasi.Location = new Point(yilan[0].Location.X + yilanHizi, yilan[0].Location.Y);
            pnlYilanParcasi.BackColor = Color.Red;
            
            if(yilan[0].Location.X + 20 >= pnlOyunAlani.Size.Width || KendineCarptiMi())
            {
                YilaniOldur();
            }

            yilan.Insert(0, pnlYilanParcasi);
            pnlOyunAlani.Controls.Remove(yilan[yilan.Count - 1]);
            yilan.RemoveAt(yilan.Count - 1);

            for (int i = 0; i < yilan.Count; i++)
            {
                if(i == 0)
                {
                    yilan[i].BackColor = Color.White;
                } else
                {
                    yilan[i].BackColor = Color.Red;
                }
                pnlOyunAlani.Controls.Add(yilan[i]);
            }
          
            yonDegisti = false;
        }

        void YilaniSolaHareketEttir()
        {
            pnlYilanParcasi = new Panel();
            pnlYilanParcasi.Size = new Size(20, 20);
            pnlYilanParcasi.Location = new Point(yilan[0].Location.X - yilanHizi, yilan[0].Location.Y);
            pnlYilanParcasi.BackColor = Color.Red;

            if (yilan[0].Location.X <= 0 || KendineCarptiMi())
            {
                YilaniOldur();
            }

            yilan.Insert(0, pnlYilanParcasi);
            pnlOyunAlani.Controls.Remove(yilan[yilan.Count - 1]);
            yilan.RemoveAt(yilan.Count - 1);

            for (int i = 0; i < yilan.Count; i++)
            {
                if (i == 0)
                {
                    yilan[i].BackColor = Color.White;
                }
                else
                {
                    yilan[i].BackColor = Color.Red;
                }
                pnlOyunAlani.Controls.Add(yilan[i]);
            }

            yonDegisti = false;
        }

        void YilaniYukariHareketEttir()
        {
            pnlYilanParcasi = new Panel();
            pnlYilanParcasi.Size = new Size(20, 20);
            pnlYilanParcasi.Location = new Point(yilan[0].Location.X, yilan[0].Location.Y - yilanHizi);
            pnlYilanParcasi.BackColor = Color.Red;

            if (yilan[0].Location.Y <= 0 || KendineCarptiMi())
            {
                YilaniOldur();
            }

            yilan.Insert(0, pnlYilanParcasi);
            pnlOyunAlani.Controls.Remove(yilan[yilan.Count - 1]);
            yilan.RemoveAt(yilan.Count - 1);

            for (int i = 0; i < yilan.Count; i++)
            {
                if (i == 0)
                {
                    yilan[i].BackColor = Color.White;
                }
                else
                {
                    yilan[i].BackColor = Color.Red;
                }
                pnlOyunAlani.Controls.Add(yilan[i]);
            }

            yonDegisti = false;
        }

        void YilaniAsagiHareketEttir()
        {
            pnlYilanParcasi = new Panel();
            pnlYilanParcasi.Size = new Size(20, 20);
            pnlYilanParcasi.Location = new Point(yilan[0].Location.X, yilan[0].Location.Y + yilanHizi);
            pnlYilanParcasi.BackColor = Color.Red;

            if (yilan[0].Location.Y + 20 >= pnlOyunAlani.Size.Height || KendineCarptiMi())
            {
                YilaniOldur();
            }

            yilan.Insert(0, pnlYilanParcasi);
            pnlOyunAlani.Controls.Remove(yilan[yilan.Count - 1]);
            yilan.RemoveAt(yilan.Count - 1);

            for (int i = 0; i < yilan.Count; i++)
            {
                if (i == 0)
                {
                    yilan[i].BackColor = Color.White;
                }
                else
                {
                    yilan[i].BackColor = Color.Red;
                }
                pnlOyunAlani.Controls.Add(yilan[i]);
            }

            yonDegisti = false;
        }
        
        void YemOlustur()
        {
            yem.Location = new Point(rnd.Next(0, panelX/20) * 20, rnd.Next(0, panelY/20) * 20);
            foreach (Panel parca in yilan)
            {
                while(parca.Location == yem.Location)
                {
                    YemOlustur();
                }
                pnlOyunAlani.Controls.Add(yem);
            }             
        }

        bool KendineCarptiMi()
        {
            for (int i = 4; i < yilan.Count; i++)
            {
                if (yilan[i].Bounds.IntersectsWith(yilan[0].Bounds))
                {
                    return true;
                }
            }
            return false;
        }

        void YilaniOldur()
        {
            tmrOyun.Stop();
            tmrOyun.Enabled = false;
            MessageBox.Show("Oyun Bitti! \r\nSkor: " + skor);
            pnlOyunAlani.Controls.Clear();
            OyunuBaslat();
        }
        
        private void TmrOyun_Tick(object sender, EventArgs e)
        {
            Refresh();
                      
            if (yem.Bounds.IntersectsWith(yilan[0].Bounds))
            {
                skor++;
                lblSkor.Text = "Skor: "+ skor.ToString();
                pnlOyunAlani.Controls.Remove(yem);
                YemOlustur();
                ParcaEkle();
            }

            switch(istikamet)
            {
                case "saga":
                    YilaniSagaHareketEttir();
                    break;
                case "sola":
                    YilaniSolaHareketEttir();
                    break;
                case "yukari":
                    YilaniYukariHareketEttir();
                    break;
                case "asagi":
                    YilaniAsagiHareketEttir();
                    break;
            }

            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right && istikamet != "sola" && yonDegisti == false)
            {
                istikamet = "saga";
                yonDegisti = true;
            } 
            else if(e.KeyCode == Keys.Left && istikamet != "saga" && yonDegisti == false)
            {
                istikamet = "sola";
                yonDegisti = true;
            }
            else if (e.KeyCode == Keys.Up && istikamet != "asagi" && yonDegisti == false)
            {
                istikamet = "yukari";
                yonDegisti = true;
            }
            else if (e.KeyCode == Keys.Down && istikamet != "yukari" && yonDegisti == false)
            {
                istikamet = "asagi";
                yonDegisti = true;
            }
        }
  
    }
}
