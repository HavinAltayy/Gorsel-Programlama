namespace Odev2;

public partial class VKISayfasi : ContentPage
{
    public VKISayfasi()
    {
        InitializeComponent();   // XAML ile bağlantıyı başlatır
    }

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        // Slider'dan alınan kilo ve boy değerleri
        double kilo = Math.Round(kiloSlider.Value * 10) / 10.0;      // Virgüllü (0.1) hassasiyet
        double boy = boySlider.Value;   // cm olarak

        // Ekrana göster
        kiloLabel.Text = $"Kilo: {kilo:F1} kg";
        boyLabel.Text = $"Boy: {boy:F0} cm";


        // Hesaplama için metreye çevir
        double boyMetre = boy / 100.0;
        //HESAPLAMA(İŞEM) YAPILAN YER    Kilo ve boy ile anlık VKİ hesaplaması + sınıflandırma
        double vki = kilo / (boyMetre * boyMetre);

        // VKİ'ye göre sınıflandırma
        string yorum = "";

        if (vki < 16)
            yorum = "İleri Düzeyde Zayıf";
        else if (vki < 17)
            yorum = "Orta Düzeyde Zayıf";
        else if (vki < 18.5)
            yorum = "Hafif Düzeyde Zayıf";
        else if (vki < 25)
            yorum = "Normal Kilolu";
        else if (vki < 30)
            yorum = "Hafif Şişman / Fazla Kilolu";
        else if (vki < 35)
            yorum = "1. Derecede Obez";
        else if (vki < 40)
            yorum = "2. Derecede Obez";
        else
            yorum = "3. Derecede Obez / Morbid Obez";

        // Sonucu etiketle göster
        vkiLabel.Text = $"VKİ: {vki:F2} → {yorum}";
    }
}

