using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarvelApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListCellTemplate
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(ListCellTemplate));
        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        
        public static readonly BindableProperty SubtitleProperty = BindableProperty.Create(nameof(Subtitle), typeof(string), typeof(ListCellTemplate));
        public string Subtitle
        {
            get => (string) GetValue(SubtitleProperty);
            set => SetValue(SubtitleProperty, value);
        }
        
        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(ListCellTemplate));
        public string ImageSource
        {
            get => (string) GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }

        public ListCellTemplate()
        {
            InitializeComponent();
        }
    }
}