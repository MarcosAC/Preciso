using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Helpers.Controls.CardView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardView : ContentView
    {
        public static readonly BindableProperty CardTitleProperty =
            BindableProperty.Create(
                nameof(CardTitle),
                typeof(string),
                typeof(CardView),
                string.Empty
            );

        public static readonly BindableProperty CardDescriptionProperty =
            BindableProperty.Create(
                nameof(CardDescription),
                typeof(string),
                typeof(CardView),
                string.Empty
            );

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(
                nameof(BorderColor),
                typeof(Color),
                typeof(CardView),
                Color.DarkGray
            );

        public string CardTitle
        {
            get => (string)GetValue(CardTitleProperty);
            set => SetValue(CardTitleProperty, value);
        }

        public string CardDescription
        {
            get => (string)GetValue(CardDescriptionProperty);
            set => SetValue(CardDescriptionProperty, value);
        }

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        public CardView()
        {
            InitializeComponent();
        }
    }
}