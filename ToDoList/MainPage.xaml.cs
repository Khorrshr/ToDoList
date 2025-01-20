using Microsoft.Maui.Controls;//

namespace ToDoList
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnRadioButtonChk(object sender, CheckedChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Event triggered");
            RadioButton radioButton = (RadioButton)sender;

            if (radioButton.Content is Label label)
            {
                System.Diagnostics.Debug.WriteLine($"Before toggle: {label.TextDecorations}");
                label.TextDecorations = label.TextDecorations == TextDecorations.Strikethrough
                    ? TextDecorations.None
                    : TextDecorations.Strikethrough;
                System.Diagnostics.Debug.WriteLine($"After toggle: {label.TextDecorations}");
                System.Diagnostics.Debug.WriteLine($"Option toggled: {label.Text}");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Content is not a Label");
                System.Diagnostics.Debug.WriteLine($"Content type: {radioButton.Content.GetType().Name}");
            }
        }
    }
}