using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T.C_Numarası_Sorgulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_sorgula_Click(object sender, EventArgs e)
        {
            lbl_sonuc.Visible = false;
            tcNumaraSorgula();
        }

        private void tcNumaraSorgula()
        {
            char[] tcNumara = masked_tc.Text.ToCharArray();
            int deger1=0, deger2=0, toplam=0;
            if(tcNumara.Length==11)
            {
                if (Convert.ToInt32(tcNumara[0].ToString()) != 0)
                {
                    for (int i = 0; i < 10; i ++)
                    {
                        toplam = toplam + tcNumara[i];
                        if(i%2==0)
                        {
                            if(i!=10)
                            {
                                deger1 = deger1 + Convert.ToInt32(tcNumara[i].ToString());
                            }
                        }
                        else
                        {
                            if(i!=9)
                            {
                                deger2 = deger2 + Convert.ToInt32(tcNumara[i].ToString());
                            }
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("T.C Numaranız 0 ile başlayamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("T.C Numaranız 11 Haneli Olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            if(deger1!=0)
            {
                if (((deger1 * 7) - deger2) % 10 == Convert.ToInt32(tcNumara[9].ToString()) && toplam % 10 == Convert.ToInt32(tcNumara[10].ToString()))
                {
                    //MessageBox.Show("TC Numarası Doğru", "Onaylandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbl_sonuc.Text = "Girilen T.C Numarası\ndoğrudur.";
                    lbl_sonuc.TextAlign = ContentAlignment.MiddleCenter;
                    lbl_sonuc.ForeColor = Color.Green;
                    lbl_sonuc.Visible = true;
                }
                else
                {
                    //MessageBox.Show("TC Numarası Doğru Değil", "ONAYLANMADI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    lbl_sonuc.Text = "Girilen T.C Numarası\ndoğru değildir.";
                    lbl_sonuc.TextAlign = ContentAlignment.MiddleCenter;
                    lbl_sonuc.ForeColor = Color.Red;
                    lbl_sonuc.Visible = true;
                }
            }
        }

        
    }
}
