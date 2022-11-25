using System;  
using Xamarin.Forms;  
using Xamarin.Forms.Xaml;  
using LoginPageSample.ViewModels;  
  
namespace LoginPageSample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            var vm = new LoginViewModel();
            this.BindingContext = vm;
            vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Erro", "Credenciais Inválidas", "OK");
            vm.DisplayValidLoginPrompt += () => DisplayAlert("Sucesso", "Usuário autenticado!", "OK");
            InitializeComponent();

            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                vm.SubmitCommand.Execute(null);
                vm.RegisterCommand.Execute(null);
            };
        }
    }
}
