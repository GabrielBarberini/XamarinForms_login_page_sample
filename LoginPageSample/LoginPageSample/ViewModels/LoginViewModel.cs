using System;  
using System.ComponentModel;  
using System.Windows.Input;
using LoginPageSample.Models;
using Xamarin.Forms;  

namespace LoginPageSample.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public Action DisplayValidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public ICommand RegisterCommand { protected set; get; }
        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
            RegisterCommand = new Command(OnRegister);
        }
        public async void OnSubmit()
        {            
            try
            {
                Account acc = await App.Database.GetAccountAsync(email);                

                if (acc.Senha == password)
                    DisplayValidLoginPrompt();
                else
                    DisplayInvalidLoginPrompt();
            }
            catch (Exception)
            {               
                DisplayInvalidLoginPrompt();                                   
            }
        }

        public async void OnRegister()
        {
            Account acc = new Account()
            {
                Senha = password,
                Email = email
            };
            
            if (!string.IsNullOrWhiteSpace(email))
            {
                await App.Database.SaveAccountAsync(acc);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}