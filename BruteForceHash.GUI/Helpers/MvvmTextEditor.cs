using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Search;
using System.ComponentModel;
using System.Windows;

#pragma warning disable CA2211 // Non-constant fields should not be visible
namespace BruteForceHash.GUI.Helpers
{
    public class MvvmTextEditor : TextEditor, INotifyPropertyChanged
    {
        public static DependencyProperty TextProperty =

            DependencyProperty.Register("Text", typeof(string), typeof(MvvmTextEditor),
            new PropertyMetadata((obj, args) =>
            {
                MvvmTextEditor target = (MvvmTextEditor)obj;
                target.Text = (string)args.NewValue;
            })
        );

        public new string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void RaisePropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public MvvmTextEditor() : base(new TextArea())
        {
            SearchPanel.Install(TextArea);
        }
    }
}
#pragma warning restore CA2211 // Non-constant fields should not be visible
