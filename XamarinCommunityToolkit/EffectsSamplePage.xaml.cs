using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinCommunityToolkit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EffectsSamplePage : ContentPage
    {
        public EffectsSamplePage()
        {
            InitializeComponent();
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            Application.Current.Resources["StatusBarColor"] = ((Button)sender).TextColor;            
        }

        private void LifeCycleEffect_Loaded(object sender, EventArgs e)
        {
            Console.WriteLine("Image loaded...");
        }

        private void LifeCycleEffect_Unloaded(object sender, EventArgs e)
        {
            Console.WriteLine("Image Unloaded...");
        }
    }
}