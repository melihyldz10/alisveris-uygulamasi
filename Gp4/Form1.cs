using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gp4
{
    public partial class Form1 : Form
    {

        int param = 500;
        MessageBoxButtons Ok = MessageBoxButtons.OK;//MessageBoxlar.
        MessageBoxButtons OkCancel = MessageBoxButtons.OKCancel;



        public void toplam()
        {
            double toplam = 0;//double türünde toplam isimli bir degişken oluşturuldu.
            for (int i = 0; i < listbox_Tutar.Items.Count; i++)//listbox içerisindeki eleman sayılırını  count ile alır ve o kadar döndürürdük.
            {
                toplam += Convert.ToDouble(listbox_Tutar.Items[i]);//listboxtaki elemanları alıp toplam degişkenine atıyoruz.
            }
            txt_Fiyat.Text = toplam.ToString();//txt fiyat isimli textboxa toplam işleminin sonucunu yazar.
        }

        public void ekle()
        {
            int adet = 0; //adet degişkenini tanımlıyoruz. ve 0 degerini veriyoruz.
            adet += 1;//adet degişkeni her butona basıldıgında bir arttırıyoruz.
            listbox_Adet.Items.Add(adet.ToString());//listbox adet degişkeni içerisine adeti ekliyoruz.
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            lbl_para.Text = param.ToString();

        }



        //Para yükleme bölümü
        private void Money_Up_Click(object sender, EventArgs e)
        {
                groupBox1.Visible = true;//Butona Basıldıgı zaman grupbox1 gözükür.
            txt_bakiye.Text = lbl_para.Text;
                txt_tutar.Text = null;//tutarın içini butona basıldıgı zaman boşaltıyoruz daha önce yapılan işlemin çerezleri kalmaktadır.
                


        }



        //Para girişi Bu bölümden yapılır.
        private void Money_Upload_Click(object sender, EventArgs e)
        {
                int sayi = Convert.ToInt32(txt_tutar.Text);//sayi degişkeni içirisine dönüşümü yapılarak textboxtaki veriyi tutturdum.
                String islem = (param += sayi).ToString(); // islem degişkeninde ise paramı=param+sayi ile her defasında ekleme yaptırdım.
                txt_bakiye.Text = islem;//bakiye içerisine işlemde gerçekleştirilen toplama işlemini yazar.
                lbl_para.Text = islem;//label içerisinede islem içerisindeki toplama işlemini yazar.
                groupBox1.Visible = false;//Yükle butonuna basıldıgı zaman gruopbox kaybolur.
        }





        private void Urun1_Click(object sender, EventArgs e)
        {
            listbox_urun.Items.Add(txt_dvd.Text);//listbox urun içerisine textbox.dvd isimli textboxın içerisindeki degeri ekler.
            listbox_Tutar.Items.Add(txt_dvdF.Text);//listbox tutar içerisine textbox.dvdf isimli textboxın içerisindeki degeri ekler.
            //Ürün ekleme Methodu çagrılmıştır.
            ekle();
            //Ürün Toplama methodu çagrılmıştır.
            toplam();
        }



        //Ürün silme Butonu listbox içersindeki Tüm verileri silme.
        private void Product_clear_Click(object sender, EventArgs e)
        {
            listbox_Adet.Items.Clear();
            listbox_urun.Items.Clear();
            listbox_Tutar.Items.Clear();
            txt_Fiyat.Text = " ";
        }

        private void ShopF_Click(object sender, EventArgs e)
        {
            int s1 = Convert.ToInt32(lbl_para.Text);//s1 degişkenine lbl.text içerisindeki degeri çekmektedir.
            int s2 = Convert.ToInt32(txt_Fiyat.Text);//s2 degişkenine ise listbox içersindeki ürünlerin fiyatlarının toplamları çekilmektedir.
            if (s1 == s2)//eğer iki degişkeni birbirine eşit ise karar yapısı çalışıyor
            {
                //message box ile ekrana başarılı mesajı verilmiştir. Ok MESSAGE BOŞ YUKARIDA tanımlanmıştır.
                MessageBox.Show("Tebrikler. Alışverişiniz Başarılı!", "Alışveriş", Ok, MessageBoxIcon.Information);

                String sonuc = (s1 - s2).ToString();//string sonuc degişkeni içerisine s1 - s2 işlemlerini stringe çevirerek sonuc degişkeninde tutulmuştur.
                lbl_para.Text = sonuc;//artık yeni para miktarını lbl para içerisine yazılmıştır.
                txt_bakiye.Text = lbl_para.Text;//yeni miktar txt bakiye içerisine yazılmıştır. 
                //işlem gerçekleştiginden dolayı listbox içerisini yani sepetin içirisi boşaltılmıştır.
                listbox_Adet.Items.Clear();
                listbox_urun.Items.Clear();
                listbox_Tutar.Items.Clear();
              //ürünler silindigi için bir fiyatda kalmayacagı için fiyat textboxı  da null deger almıştır.
                txt_Fiyat.Text = " ";
            }
            //eğer s1>= s2 ise degerin içine girmektedir. burda bunu kullanmamın amacı paramın ürün fiyatından yüksek oldugu zamanda işlem yapabiliyor olmasıdır.
            else if (s1 >= s2)
            {
                //yukarıda belirtilen işlemlerin aynısıdır.
                MessageBox.Show("Tebrikler. Alışverişiniz Başarılı!", "Alışveriş", Ok, MessageBoxIcon.Information);
                String sonuc = (s1 - s2).ToString();
                lbl_para.Text = sonuc;
                txt_bakiye.Text = lbl_para.Text;
                listbox_Adet.Items.Clear();
                listbox_urun.Items.Clear();
                listbox_Tutar.Items.Clear();
                txt_Fiyat.Text = " ";        
            }
            else
            {
                //bu bölümde ise ekrana yetersiz bakiye uyarısı verilmiştir.
                MessageBox.Show("Yetersiz bakiye. Lütfen Bakiyenizi Kontrol ediniz.", "İşlem Başarısız.", OkCancel, MessageBoxIcon.Warning);
            }


        }
        //CD Ürünü
        private void Urun2_Click(object sender, EventArgs e)
        {

            listbox_urun.Items.Add(txt_cd.Text);
            listbox_Tutar.Items.Add(txt_cdF.Text);
            
            //Ürün ekleme
            ekle();
            //Ürün Toplama
            toplam();


        }

        private void Urun3_Click(object sender, EventArgs e)
        {

            listbox_urun.Items.Add(txt_kgt.Text);
            listbox_Tutar.Items.Add(txt_kgtF.Text);
            
            //Ürün ekleme
            ekle();
            //Ürün Toplama
            toplam();

        }

        private void Urun4_Click(object sender, EventArgs e)
        {
            listbox_urun.Items.Add(txt_kasa.Text);
            listbox_Tutar.Items.Add(txt_kasaF.Text);
            //Ürün ekleme
            ekle();
            //Ürün Toplama
            toplam();
        }

        private void Urun5_Click(object sender, EventArgs e)
        {
            listbox_urun.Items.Add(txt_pc.Text);
            listbox_Tutar.Items.Add(txt_pcF.Text);
            //Ürün ekleme
            ekle();
            //Ürün Toplama
            toplam();
        }
    }
}
