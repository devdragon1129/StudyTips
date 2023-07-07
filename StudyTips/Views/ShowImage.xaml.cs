using StudyTips.Models;

namespace StudyTips.Views;

public partial class ShowImage : ContentPage
{
	IconItem iconItem = null;

	public ShowImage(IconItem item)
	{
        InitializeComponent();
        iconItem = item;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        BindingContext = iconItem;
    }

    protected override bool OnBackButtonPressed()
    {
        Navigation.PopAsync();
        return true;
    }
}