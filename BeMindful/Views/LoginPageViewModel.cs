using System;
using System.Threading.Tasks;
using System.Windows.Input;
using DevExpress.Core;
//using DevExpress.Core.Commands;
//using DevExpress.Core.Navigation;
using DevExpress.UI.Xaml.Layout;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BeMindful.Views
{
    public class LoginPageViewModel : BindableBase, ISupportSaveLoadState, ISupportServices
    {
        string LogIn()
        {
            //insert your log in logic here
            throw new NotImplementedException();
        }
        string CreateAccountAndLogin()
        {
            //insert your registration logic here
            throw new NotImplementedException();
        }
        void NavigateToMainPage()
        {
            //insert your navigation logic here
        }

        #region Internal
        enum AnimationType
        {
            Normal, Instant
        }

        public ICommand SignInCommand { get; private set; }
        public ICommand SignUpCommand { get; private set; }
        public ICommand GoToSignUpViewCommand { get; private set; }
        public ICommand GoToSignInViewCommand { get; private set; }

        string passwordCore = string.Empty;
        string emailCore = string.Empty;
        string newUserEmailCore = string.Empty;
        string newUserPasswordCore = string.Empty;
        string newUserConfirmPasswordCore = string.Empty;
        string newUserLastNameCore = string.Empty;
        string newUserFirstNameCore = string.Empty;

        #region Properties
        [StateProperty]
        public string Password
        {
            get { return passwordCore; }
            set { SetProperty(ref passwordCore, value); }
        }
        [StateProperty]
        public string NewUserPassword
        {
            get { return newUserPasswordCore; }
            set { SetProperty(ref newUserPasswordCore, value); }
        }
        [StateProperty]
        public string NewUserConfirmPassword
        {
            get { return newUserConfirmPasswordCore; }
            set { SetProperty(ref newUserConfirmPasswordCore, value); }
        }
        [StateProperty]
        public string EMail
        {
            get { return emailCore; }
            set { SetProperty(ref emailCore, value); }
        }
        [StateProperty]
        public string NewUserEMail
        {
            get { return newUserEmailCore; }
            set { SetProperty(ref newUserEmailCore, value); }
        }
        [StateProperty]
        public string NewUserFirstName
        {
            get { return newUserFirstNameCore; }
            set { SetProperty(ref newUserFirstNameCore, value); }
        }
        [StateProperty]
        public string NewUserLastName
        {
            get { return newUserLastNameCore; }
            set { SetProperty(ref newUserLastNameCore, value); }
        }
        [StateProperty]
        public bool IsSignInView { get; set; }
        #endregion Properties

        public LoginPageViewModel()
        {
            IsSignInView = true;
            SignUpCommand = new DelegateCommand<object>(OnSignUpCommandExecute);
            SignInCommand = new DelegateCommand<object>(OnSignInCommandExecute);
            GoToSignUpViewCommand = new DelegateCommand<object>(o => GoToSignUpView(true));
            GoToSignInViewCommand = new DelegateCommand<object>(o => GoToSignInView());
        }

        private void ResetUserFields()
        {
            Password = string.Empty;
            EMail = string.Empty;
        }

        internal void ResetNewUserFields()
        {
            NewUserPassword = string.Empty;
            NewUserConfirmPassword = string.Empty;
            NewUserEMail = string.Empty;
            NewUserFirstName = string.Empty;
            NewUserLastName = string.Empty;
        }

        void GoToSignUpView(bool resetNewUserFields, AnimationType animationType = AnimationType.Normal)
        {
            IsSignInView = false;
            if (resetNewUserFields)
                ResetNewUserFields();
            string stateName = animationType == AnimationType.Instant ? "InstantSignUp" : "SignUp";
            serviceContainer.GetService<IVisualStateService>().GoToState(stateName, false);
        }

        void GoToSignInView(AnimationType animationType = AnimationType.Normal)
        {
            IsSignInView = true;
            ResetUserFields();
            string stateName = animationType == AnimationType.Instant ? "InstantSignIn" : "SignIn";
            serviceContainer.GetService<IVisualStateService>().GoToState(stateName, false);
        }

        void OnSignInCommandExecute(object parameter)
        {
            string errorMessage = LogIn();
            if (errorMessage == null)
            {
                NavigateToMainPage();
            }
            else
            {
                ShowErrorMessage(errorMessage);
            }
        }

        void OnSignUpCommandExecute(object parameter)
        {
            string errorMessage = CreateAccountAndLogin();
            if (errorMessage == null)
            {
                NavigateToMainPage();
            }
            else
            {
                ShowErrorMessage(errorMessage);
            }
        }

        async void ShowErrorMessage(string text)
        {
            IMessageDialogService messageDialogService = serviceContainer.GetService<IMessageDialogService>();
            messageDialogService.Content = text;
            await messageDialogService.ShowAsync();
        }

        void ISupportSaveLoadState.LoadState(object navigationParameter, PageStateStorage pageState)
        {
            bool oldIsSignInView = IsSignInView;
            pageState.LoadObjectState(this);
            if (oldIsSignInView != IsSignInView)
            {
                if (IsSignInView)
                    GoToSignInView(AnimationType.Instant);
                else
                    GoToSignUpView(false, AnimationType.Instant);
            }
        }

        void ISupportSaveLoadState.SaveState(PageStateStorage pageState)
        {
            pageState.SaveObjectState(this);
        }

        #region ISupportServices Members
        ServiceContainer serviceContainer = new ServiceContainer();
        ServiceContainer ISupportServices.ServiceContainer { get { return serviceContainer; } }
        #endregion
        #endregion Internal
    }
}