using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Controls;

namespace ControlWorks
{
    public class Screen : Notify
    {
        public Screen(string tag, string title, UserControl content)
        {
            Tag = tag;
            Title = title;
            Content = content;
        }

        private string tag;
        public string Tag
        {
            get => tag;
            set { tag = value; OnPropertyChanged(new PropertyChangedEventArgs("Tag")); }
        }
        
        private string title;
        public string Title
        {
            get => title;
            set { title = value; OnPropertyChanged(new PropertyChangedEventArgs("Title")); }
        }

        private UserControl content;
        public UserControl Content
        {
            get => content;
            set { content = value; OnPropertyChanged(new PropertyChangedEventArgs("Content")); }
        }
    }
}
