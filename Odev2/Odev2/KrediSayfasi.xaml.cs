namespace Odev2
{
    public partial class KrediSayfasi : ContentPage
    {
        public KrediSayfasi()
        {
            InitializeComponent(); // XAML içeriğini başlat
        }

        private void VadeSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int vade = (int)e.NewValue;
            vadeLabel.Text = $"Vade: {vade} Ay";
        }

        private void Hesapla_Clicked(object sender, EventArgs e)
        {
            // Giriş doğrulama ve değişken atamaları
            if (double.TryParse(tutarEntry.Text, out double tutar) &&
                double.TryParse(faizEntry.Text, out double oran) &&
                vadeSlider.Value > 0 &&               //SLİDER 0 VEYA NEGATİFSE KONTROLÜ
                krediPicker.SelectedIndex != -1)     //GEÇERSİZ GİRİŞ KONNTROLÜ
            {
                int vade = (int)vadeSlider.Value;

                // Kredi türüne göre KKDF ve BSMV belirle
                double kkdf = 0;
                double bsmv = 0;

                string secilenKredi = krediPicker.SelectedItem.ToString();

                switch (secilenKredi)
                {
                    case "İhtiyaç Kredisi":
                        kkdf = 0.15; bsmv = 0.10;
                        break;
                    case "Taşıt Kredisi":
                        kkdf = 0.15; bsmv = 0.05;
                        break;
                    case "Konut Kredisi":
                        kkdf = 0.00; bsmv = 0.00;
                        break;
                    case "Ticari Kredi":
                        kkdf = 0.00; bsmv = 0.05;
                        break;
                }
                
                // Aylık brüt faiz hesaplama
                double brutFaiz = (oran / 100) + (oran / 100 * bsmv) + (oran / 100 * kkdf);

                //HESAPLAMA(İŞLEM) YAPILAN KISIM    Kredi tutarı, faiz oranı, vade ile aylık taksit ve toplam
                // Taksit hesaplama
                double taksit = ((Math.Pow(1 + brutFaiz, vade) * brutFaiz) / (Math.Pow(1 + brutFaiz, vade) - 1)) * tutar;
                double toplam = taksit * vade;
                double toplamFaiz = toplam - tutar;

                // Sonuç yazdır
                sonucLabel.Text = $"Aylık Taksit: {taksit:F2} ₺\n" +
                                  $"Toplam Ödeme: {toplam:F2} ₺\n" +
                                  $"Toplam Faiz: {toplamFaiz:F2} ₺";
            }
            else
            {
                sonucLabel.Text = "Lütfen tüm bilgileri eksiksiz ve doğru girin.";   //UYARI METNİ
            }
        }

    }
}
