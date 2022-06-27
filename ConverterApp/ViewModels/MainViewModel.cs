using System.Windows.Input;
using ConverterApp.Services;
using ConverterApp.ViewModels.Base;
using ConverterApp.Infrastructure.Commands;
using ConverterApp.Models;
using ConverterApp.Views;

namespace ConverterApp.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        #region Свойства
        private CurrencyModel.Root _data;
        public CurrencyModel.Root Data
        {
            get => _data;
            set => Set(ref _data, value);
        }

        private decimal _currencyValueFrom = 0;
        public decimal CurrencyValueFrom
        {
            get => _currencyValueFrom;
            set
            {
                if (Set(ref _currencyValueFrom, value) &&
                    SelectedCurrencyFrom != null &&
                    SelectedCurrencyTo != null)
                {
                    CurrencyValueTo = value * SelectedCurrencyFrom.Value / SelectedCurrencyTo.Value;
                }
            }
        }

        private decimal _currencyValueTo = 0;
        public decimal CurrencyValueTo
        {
            get => _currencyValueTo;
            set
            {
                if (Set(ref _currencyValueTo, value) &&
                    SelectedCurrencyFrom != null &&
                    SelectedCurrencyTo != null)
                {
                    CurrencyValueFrom = value * SelectedCurrencyTo.Value / SelectedCurrencyFrom.Value;
                }
            }
        }

        private CurrencyModel.Currency _selectedCurrencyFrom;
        public CurrencyModel.Currency SelectedCurrencyFrom
        {
            get => _selectedCurrencyFrom;
            set
            {
                if (Set(ref _selectedCurrencyFrom, value) && SelectedCurrencyTo != null)
                {
                    CurrencyValueTo = CurrencyValueFrom * value.Value / SelectedCurrencyTo.Value;
                }
            }
        }

        private CurrencyModel.Currency _selectedCurrencyTo;
        public CurrencyModel.Currency SelectedCurrencyTo
        {
            get => _selectedCurrencyTo;
            set
            {
                if (Set(ref _selectedCurrencyTo, value) && SelectedCurrencyFrom != null)
                {
                    CurrencyValueTo = CurrencyValueFrom * SelectedCurrencyFrom.Value / value.Value;
                }
            }
        }
        #endregion

        #region Команды
        public ICommand LoadDataCommand { get; }
        private void OnLoadDataCommandExecuted()
        {
            Data = DataService.GetCurrencyData();
        }

        public ICommand NavigateToConverterPageCommand { get; }
        private void OnNavigateToConverterPageCommandExecuted()
        {
            NavigationService.Instance.Navigate(typeof(ConverterPage));
        }

        public ICommand NavigateToSelectionPageFromCommand { get; }
        private void OnNavigateToSelectionPageFromCommandExecuted()
        {
            NavigationService.Instance.Navigate(typeof(CurrencySelectionPageFrom));
        }

        public ICommand NavigateToSelectionPageToCommand { get; }
        private void OnNavigateToSelectionPageToCommandExecuted()
        {
            NavigationService.Instance.Navigate(typeof(CurrencySelectionPageTo));
        }
        #endregion

        public MainViewModel()
        {
            LoadDataCommand = new RelayCommand(OnLoadDataCommandExecuted);
            NavigateToConverterPageCommand = new RelayCommand(OnNavigateToConverterPageCommandExecuted);
            NavigateToSelectionPageFromCommand = new RelayCommand(OnNavigateToSelectionPageFromCommandExecuted);
            NavigateToSelectionPageToCommand = new RelayCommand(OnNavigateToSelectionPageToCommandExecuted);
        }
    }
}
