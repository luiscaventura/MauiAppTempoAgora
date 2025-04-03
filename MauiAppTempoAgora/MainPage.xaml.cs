using MauiAppTempoAgora.Models;
using MauiAppTempoAgora.Services;
using System.Threading.Tasks;

namespace MauiAppTempoAgora
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }



        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(txt_cidade.Text))
                {
                    Tempo? t = await DataService.GetPrevisao(txt_cidade.Text);

                    if (t != null) 
                    {
                        string dados_previsao = "";

                        dados_previsao = $"Latitude: {t.lat} \n" +
                                         $"Longitude: {t.lon} \n" +
                                         $"Nascer do sol: {t.sunrise} \n" +
                                         $"Por do sol: {t.sunset} \n" +
                                         $"Tem Máx: {t.temp_max} \n" +
                                         $"Temp Min: {t.temp_min} \n" +
                                         $"Descrição do clima: {t.description} \n" +
                                         $"Velocidade do vento: {t.speed} \n" + //Adicionado a velocidade do vento
                                         $"Visibilidade: {t.visibility} \n"; // Adicionado a visibilidade

                        lbl_res.Text = dados_previsao;

                    }
                    else 
                    {

                        lbl_res.Text = "O nome da cidade não foi encontrado"; 
                        // Substituito para aparecer mensagem que o nome da cidade não foi encontrado
                    }
                }
                else 
                {
                    lbl_res.Text = "Preencha a cidade:";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "Ok");
            }
        }
    }

}
