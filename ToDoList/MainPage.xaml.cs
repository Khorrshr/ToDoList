using Microsoft.Maui.Controls;

namespace ToDoList
{
    public partial class MainPage : ContentPage
    {
        private int taskCounter = 0;


        public MainPage()
        {
            InitializeComponent();
        }

        void OnLabelTapped(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                // Toggle the TextDecorations of the label
                label.TextDecorations = label.TextDecorations == TextDecorations.Strikethrough
                    ? TextDecorations.None
                    : TextDecorations.Strikethrough;

                System.Diagnostics.Debug.WriteLine($"Toggled: {label.Text} - State: {label.TextDecorations}");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Sender is not a Label.");
            }
        }

        void OnCreateTaskClicked(object sender, EventArgs e)
        {
            taskCounter++;
            var newLabel = new Label
            {
                Text = $"Task {taskCounter}",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnLabelTapped;
            newLabel.GestureRecognizers.Add(tapGestureRecognizer);

            taskList.Children.Add(newLabel);
        }

        /*
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
        */


    }
}