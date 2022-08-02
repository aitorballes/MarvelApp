using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarvelApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemTemplate
    {
        
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(ItemTemplate));
        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        
        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(ItemTemplate));
        public string ImageSource
        {
            get => (string) GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }
        
        public ItemTemplate()
        {
            InitializeComponent();
        }
    }
}