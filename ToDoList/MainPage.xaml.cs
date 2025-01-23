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
            System.Diagnostics.Debug.WriteLine("Clear All Button Clicked");
            taskList.Children.Clear(); // This removes all children from the taskList
                }

        void OnClearDoneClicked(object sender, EventArgs e) 
        {
            System.Diagnostics.Debug.WriteLine("Clear Done Button Clicked");
            // We'll use a list to store labels to remove because we can't modify the collection while iterating over it
            List<View> labelsToRemove = new List<View>();

            foreach (View child in taskList.Children)
            {
                if (child is Label label && label.TextDecorations == TextDecorations.Strikethrough)
                {
                    labelsToRemove.Add(child);
                }
                }

            // Now remove all labels that were marked for removal
            foreach (View label in labelsToRemove)
            {
                taskList.Children.Remove(label);
            }
        }
    }
}