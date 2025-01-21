using Microsoft.Maui.Controls;

namespace ToDoList
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnLabelTapped(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                label.TextDecorations = label.TextDecorations == TextDecorations.Strikethrough
                    ? TextDecorations.None
                    : TextDecorations.Strikethrough;

                System.Diagnostics.Debug.WriteLine($"Toggled: {label.Text} - State: {label.TextDecorations}");
            }
        }

        void OnCreateTaskClicked(object sender, EventArgs e)
        {
            CreateTask();
        }

        void OnTaskEntryCompleted(object sender, EventArgs e)  // This method is called when Enter is pressed
        {
            CreateTask();
        }

        private void CreateTask()
        {
            string taskText = taskEntry.Text;
            if (!string.IsNullOrWhiteSpace(taskText))
            {
                var newLabel = new Label
                {
                    Text = taskText,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += OnLabelTapped;
                newLabel.GestureRecognizers.Add(tapGestureRecognizer);

                taskList.Children.Add(newLabel);

                // Clear the text field after adding the task
                taskEntry.Text = string.Empty;
            }
        }

        void OnClearAllClicked(object sender, EventArgs e)
        {
            taskList.Children.Clear(); // This removes all children from the taskList
        }
    }
}