using System;
using Microsoft.Maui.Controls;

namespace Odev2;

public partial class RenkSayfasi : ContentPage
{
    public RenkSayfasi()
    {
        InitializeComponent();  // Sayfa baþlat
    }

    private void RenkGuncelle(object sender, ValueChangedEventArgs e)
    {
        // Slider'dan deðer oku
        int r = (int)redSlider.Value;
        int g = (int)greenSlider.Value;
        int b = (int)blueSlider.Value;

        // Etiketleri güncelle
        redLabel.Text = $"R: {r}";
        greenLabel.Text = $"G: {g}";
        blueLabel.Text = $"B: {b}";

        //HESAPLAMA(ÝÞLEM) YAPILAN YER     RGB deðerlerinden HEX renk üretimi, kopyalama ve rastgele üretim
        // HEX renk kodu üret
        string hex = $"#{r:X2}{g:X2}{b:X2}";
        renkKoduLabel.Text = $"Renk: {hex}";
        // Arka planý canlý deðiþtir
        renkSayfasi.BackgroundColor = Color.FromRgb(r, g, b);
    }


    private async void Kopyala_Clicked(object sender, EventArgs e)
    {
        // HEX kodunu panoya kopyala
        string renkKodu = renkKoduLabel.Text;
        await Clipboard.SetTextAsync(renkKodu);
        await DisplayAlert("Kopyalandý", $"{renkKodu}", "OK");   //KOPYALAMA ÝÞLEMÝNDE ONAY MESAJI VERÝLÝR HATA KONTROLÜ
    }

    private void Rastgele_Clicked(object sender, EventArgs e)
    {
        // Slider’lara rastgele RGB deðerleri ata
        Random rnd = new Random();
        redSlider.Value = rnd.Next(0, 256);
        greenSlider.Value = rnd.Next(0, 256);
        blueSlider.Value = rnd.Next(0, 256);
    }
}
