using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinCommunityToolkit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BehavioursSample : ContentPage
    {
        public BehavioursSample()
        {
            InitializeComponent();
        }

        private void MaxLengthReachedBehavior_MaxLengthReached(object sender, Xamarin.CommunityToolkit.Behaviors.MaxLengthReachedEventArgs e)
        {
            DisplayAlert("XCT", "Max Length Reached", "OK");
        }
    }
}