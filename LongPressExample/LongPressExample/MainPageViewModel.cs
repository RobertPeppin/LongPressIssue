using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace LongPressExample
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ListItem> Items { get; } = new ObservableCollection<ListItem>();
        private string message;
        public string Message { get => message; set => SetProperty(ref message, value); }
        public ICommand LongPressCommand { get; }

        public MainPageViewModel()
        {
            LongPressCommand = new Command<ListItem>((i) => OnLongPress(i));

            BuildListOfItems();
        }

        private void BuildListOfItems()
        {
            // Build a list of people
            Items.Clear();
            Items.Add(new ListItem() { Name = "Andrew Anders", JobTitle = "Junior Developer" });
            Items.Add(new ListItem() { Name = "Bernice Blenkinship", JobTitle = "Junior Developer" });
            Items.Add(new ListItem() { Name = "Carl Chadwick", JobTitle = "Developer" });
            Items.Add(new ListItem() { Name = "Dennis Dangerfield", JobTitle = "Developer" });
            Items.Add(new ListItem() { Name = "Erica Eastwick", JobTitle = "Developer" });
            Items.Add(new ListItem() { Name = "Frank Fields", JobTitle = "Developer" });
            Items.Add(new ListItem() { Name = "Greta Green", JobTitle = "Senior Developer" });
            Items.Add(new ListItem() { Name = "Heta Hills", JobTitle = "Senior Developer" });
            Items.Add(new ListItem() { Name = "Ingrid Ingles", JobTitle = "Lead Developer" });
            Items.Add(new ListItem() { Name = "James Jose", JobTitle = "Solution Architect" });
            Items.Add(new ListItem() { Name = "Kate Kloss", JobTitle = "Enterprise Architect" });
        }

        private void OnLongPress(ListItem pressed)
        {
            Message = $"{pressed.Name} : {pressed.JobTitle} was long pressed at {DateTime.Now.ToShortTimeString()}.";
        }

        public void SetProperty<T>(ref T item, T newValue, [CallerMemberName] string caller = "")
        {
            item = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}