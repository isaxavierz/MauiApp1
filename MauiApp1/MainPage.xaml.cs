namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        string filePath = Path.Combine(FileSystem.AppDataDirectory, "Texto.txt");

        public MainPage()
        {
            InitializeComponent();
            showButton.IsVisible = false;
            if (File.Exists(filePath))
            {
                editorText.Text = File.ReadAllText(filePath);
            }

        }

        private void saveButton_Clicked(object sender, EventArgs e)
        {
            string texto = editorText.Text;
            File.WriteAllText(filePath, texto);
            DisplayAlert("Parabéns!", "Arquivo salvo com sucesso.", "Fechar");

            showButton.IsVisible = true;
            editorText.Text = "";

        }


        private async void deleteButton_Clicked(object sender, EventArgs e)
        {
          
            bool answer = await DisplayAlert("Alerta", "Deseja deletar o arquivo?", "Sim", "Não");

            if (answer)
            {
                
                string apagar = "";
               
                editorText.Text = apagar;
                editorText.Placeholder = "Digite sua nota";

                
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                else
                {
                    await DisplayAlert("Erro", "O arquivo não foi encontrado.", "OK");
                }
            }
        }

        private void showButton_Clicked(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                editorText.Text = File.ReadAllText(filePath);
            }
        }
    }
}
