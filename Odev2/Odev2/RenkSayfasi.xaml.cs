using System;
using Microsoft.Maui.Controls;

namespace Odev2;

public partial class RenkSayfasi : ContentPage
{
    public RenkSayfasi()
    {
        InitializeComponent();  // Sayfa ba�lat
    }

    private void RenkGuncelle(object sender, ValueChangedEventArgs e)
    {
        // Slider'dan de�er oku
        int r = (int)redSlider.Value;
        int g = (int)greenSlider.Value;
        int b = (int)blueSlider.Value;

        // Etiketleri g�ncelle
        redLabel.Text = $"R: {r}";
        greenLabel.Text = $"G: {g}";
        blueLabel.Text = $"B: {b}";

        //HESAPLAMA(��LEM) YAPILAN YER     RGB de�erlerinden HEX renk �retimi, kopyalama ve rastgele �retim
        // HEX renk kodu �ret
        string hex = $"#{r:X2}{g:X2}{b:X2}";
        renkKoduLabel.Text = $"Renk: {hex}";
        // Arka plan� canl� de�i�tir
        renkSayfasi.BackgroundColor = Color.FromRgb(r, g, b);
    }


    private async void Kopyala_Clicked(object sender, EventArgs e)
    {
        // HEX kodunu panoya kopyala
        string renkKodu = renkKoduLabel.Text;
        await Clipboard.SetTextAsync(renkKodu);
        await DisplayAlert("Kopyaland�", $"{renkKodu}", "OK");   //KOPYALAMA ��LEM�NDE ONAY MESAJI VER�L�R HATA KONTROL�
    }

    private void Rastgele_Clicked(object sender, EventArgs e)
    {
        // Slider�lara rastgele RGB de�erleri ata
        Random rnd = new Random();
        redSlider.Value = rnd.Next(0, 256);
        greenSlider.Value = rnd.Next(0, 256);
        blueSlider.Value = rnd.Next(0, 256);
    }
}
