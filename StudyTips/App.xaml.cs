using StudyTips.Models;
using StudyTips.Views;

namespace StudyTips;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new MainPage());
	}
}
