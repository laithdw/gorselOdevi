using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace VizeOdev
{
    public partial class YapilacaklarListesi : ContentPage
    {
        public ObservableCollection<TodoItem> TodoItems { get; set; } = new ObservableCollection<TodoItem>();

        public YapilacaklarListesi()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void OnAddItemClicked(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(NewItemEntry.Text))
            {
                TodoItems.Add(new TodoItem { Text = NewItemEntry.Text });
                NewItemEntry.Text = string.Empty;
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is TodoItem selectedItem)
            {
                selectedItem.IsDone = !selectedItem.IsDone;
                UpdateTextDecorations(selectedItem);
            }
        }

        private void OnItemCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            var selectedItem = checkBox.BindingContext as TodoItem;
            UpdateTextDecorations(selectedItem);
        }

        private async void OnEditItemClicked(object sender, System.EventArgs e)
        {
            var button = sender as Button;
            var selectedItem = button.BindingContext as TodoItem;

            string result = await DisplayPromptAsync("Görevi Düzenle", "Görev metnini düzenleyin:", initialValue: selectedItem.Text);
            if (!string.IsNullOrEmpty(result))
            {
                selectedItem.Text = result;
            }
        }

        private void OnDeleteItemClicked(object sender, System.EventArgs e)
        {
            var button = sender as Button;
            var selectedItem = button.BindingContext as TodoItem;
            TodoItems.Remove(selectedItem

                );
        }

        private void UpdateTextDecorations(TodoItem item)
        {
            item.TextDecorations = item.IsDone ? TextDecorations.Strikethrough : TextDecorations.None;
        }
    }

    public class TodoItem : INotifyPropertyChanged
    {
        private string _text;
        private bool _isDone;
        private TextDecorations _textDecorations;

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        public bool IsDone
        {
            get => _isDone;
            set
            {
                _isDone = value;
                OnPropertyChanged();
            }
        }

        public TextDecorations TextDecorations
        {
            get => _textDecorations;
            set
            {
                _textDecorations = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}