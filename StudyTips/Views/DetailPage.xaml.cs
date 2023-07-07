using StudyTips.Models;

namespace StudyTips.Views;

public partial class DetailPage : ContentPage
{
    MainItem mainItem = null;

	public DetailPage(MainItem item)
	{
		InitializeComponent();

        //NavigationPage.SetHasNavigationBar(this, false);

        this.mainItem = item;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        BindingContext = mainItem;
    }

    protected override bool OnBackButtonPressed()
    {
        Navigation.PopAsync();
        return true;
    }

    private void detailContent_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var detailItem = (DetailItem)e.CurrentSelection[0];           

            Navigation.PushAsync(new DetailPage2(mainItem.caption, detailItem));

            // Unselect the UI
            detailContent.SelectedItem = null;
        }
    }
}