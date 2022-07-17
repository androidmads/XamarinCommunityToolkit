using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinCommunityToolkit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseQuickTourPage : Popup
    {
        public BaseQuickTourPage()
        {
            InitializeComponent();
            NextCommand = new Command<BaseQuickTourPage>(async (page) => await Next(page));
            SkipCommand = new Command(async () => await Skip());
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            Size size = new Size();
            size.Width = mainDisplayInfo.Width / mainDisplayInfo.Density;
            size.Height = mainDisplayInfo.Height / mainDisplayInfo.Density;
            Size = size;
        }

        public static readonly BindableProperty ActualStepProperty = BindableProperty.Create(nameof(ActualStep), typeof(int), typeof(BaseQuickTourPage), propertyChanged: OnActualStepChanged);
        public static readonly BindableProperty TotalStepsProperty = BindableProperty.Create(nameof(TotalSteps), typeof(int), typeof(BaseQuickTourPage), propertyChanged: OnTotalStepsChanged);
        public static readonly BindableProperty NextCommandProperty = BindableProperty.Create(nameof(NextCommand), typeof(ICommand), typeof(BaseQuickTourPage));
        public static readonly BindableProperty NextPageProperty = BindableProperty.Create(nameof(NextPage), typeof(BaseQuickTourPage), typeof(BaseQuickTourPage), propertyChanged: OnNextPageChanged);
        public static readonly BindableProperty SkipCommandProperty = BindableProperty.Create(nameof(SkipCommand), typeof(ICommand), typeof(BaseQuickTourPage));
        public static readonly BindableProperty BodyContentProperty = BindableProperty.Create(nameof(BodyContent), typeof(ContentView), typeof(BaseQuickTourPage), propertyChanged: OnBodyContentChanged);

        private static void OnBodyContentChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((BaseQuickTourPage)bindable).body.Content = (ContentView)newValue;
        }

        private static void OnTotalStepsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((BaseQuickTourPage)bindable).total.Text = ((int)newValue).ToString();
        }

        private static void OnActualStepChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((BaseQuickTourPage)bindable).actual.Text = ((int)newValue).ToString();
            if (((BaseQuickTourPage)bindable).total.Text == ((BaseQuickTourPage)bindable).actual.Text)
            {
                ((BaseQuickTourPage)bindable).nextbtn.Text = "DONE";
            }
        }

        private static void OnNextPageChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //((BaseQuickTourPage)bindable).next.Content = (ContentView)newValue;
        }

        public ContentView BodyContent
        {
            get => (ContentView)GetValue(BodyContentProperty);
            set => SetValue(BodyContentProperty, value);
        }

        public int ActualStep
        {
            get => (int)GetValue(ActualStepProperty);
            set => SetValue(ActualStepProperty, value);
        }

        public ICommand NextCommand
        {
            get => (ICommand)GetValue(NextCommandProperty);
            set => SetValue(NextCommandProperty, value);
        }

        public BaseQuickTourPage NextPage
        {
            get => (BaseQuickTourPage)GetValue(NextPageProperty);
            set => SetValue(NextPageProperty, value);
        }

        public ICommand SkipCommand
        {
            get => (ICommand)GetValue(SkipCommandProperty);
            set => SetValue(SkipCommandProperty, value);
        }

        public int TotalSteps
        {
            get => (int)GetValue(TotalStepsProperty);
            set => SetValue(TotalStepsProperty, value);
        }

        private async Task Next(BaseQuickTourPage page)
        {
            if (isNavigating)
            {
                return;
            }

            isNavigating = true;

            Dismiss(null);
            if (page != null)
            {
                await Application.Current.MainPage.Navigation.ShowPopupAsync(page);
            }

            isNavigating = false;
        }

        private async Task Skip() => Dismiss(null);

        private bool isNavigating = false;

        private void NextButtonClicked(object sender, EventArgs e)
        {
            if (TotalSteps == ActualStep)
            {
                SkipCommand?.Execute(null);
            }
            else
            {
                NextCommand?.Execute(NextPage);
            }
        }

        private void SkipButtonClicked(object sender, EventArgs e)
        {
            SkipCommand?.Execute(null);
        }
    }
}