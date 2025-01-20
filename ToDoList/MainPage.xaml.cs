using Microsoft.Maui.Controls;//

namespace ToDoList
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnRadioButtonChecked(object sender, CheckedChangedEventArgs e)
        {
            // Handle the selection
            RadioButton radioButton = (RadioButton)sender;

            if (radioButton.Content is Label label)
            {
                if (radioButton.IsChecked)
                {
                    // Apply strikethrough to the label's text
                    label.TextDecorations = TextDecorations.Strikethrough;
                    System.Diagnostics.Debug.WriteLine($"Selected option: {label.Text}");
                }
                else
                {
                    // Remove strikethrough if the radio button is deselected
                    label.TextDecorations = TextDecorations.None;
                }
            }
        }
    }
}