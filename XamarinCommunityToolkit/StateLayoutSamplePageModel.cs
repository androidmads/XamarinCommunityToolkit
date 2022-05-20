using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.CommunityToolkit.UI.Views;

namespace XamarinCommunityToolkit
{
	public class StateLayoutSamplePageModel : ObservableObject
	{
		string customState = string.Empty;
		LayoutState mainState;

		public LayoutState MainState
		{
			get => mainState;
			set => SetProperty(ref mainState, value);
		}

		public ICommand FullscreenLoadingCommand { get; }

		public StateLayoutSamplePageModel()
		{
			FullscreenLoadingCommand = CommandFactory.Create(async () =>
			{
				MainState = LayoutState.Loading;
				await Task.Delay(2000);
				MainState = LayoutState.None;
			});
		}
	}
}
