using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using HandyControl.Controls;
using HandyControl.Tools;

namespace HandyControlDemo.Data
{
    public class PropertyGridDemoModel
    {
        [Category("Category1")]
        public string String { get; set; }

        [Category("Category2")]
        public int Integer { get; set; }

        [Category("Category2")]
        public bool Boolean { get; set; }

        [Category("Category1")]
        public Gender Enum { get; set; }

        [Category("Custom Editors")]
        [DisplayName("Another string")]
        [Editor(typeof(TextWithButtonPropertyEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string OtherString { get; set; }

        public HorizontalAlignment HorizontalAlignment { get; set; }

        public VerticalAlignment VerticalAlignment { get; set; }

        public ImageSource ImageSource { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public class TextWithButtonPropertyEditor : PropertyEditorBase
    {
        public override FrameworkElement CreateElement(PropertyItem propertyItem)
        {
            var panel = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };

            var textBox = new System.Windows.Controls.TextBox()
            {
                Text = propertyItem.Value as string,
                Width = 240,
                MaxWidth = 240
            };
            panel.Children.Add(textBox);

            panel.Children.Add(new Button()
            {
                Style = ResourceHelper.GetResource<Style>("ButtonSuccess"),
                Content = "Paste",
                Command = ApplicationCommands.Paste,
                CommandTarget = textBox
            });

            return panel;
        }

        public override DependencyProperty GetDependencyProperty() => System.Windows.Controls.TextBox.TextProperty;
    }
}
