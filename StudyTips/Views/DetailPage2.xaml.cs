using StudyTips.Models;

namespace StudyTips.Views;

public partial class DetailPage2 : ContentPage
{
    DetailItem detailItem = null;

    public DetailPage2(string caption, DetailItem item)
    {
        InitializeComponent();

        //NavigationPage.SetHasNavigationBar(this, false);

        this.detailItem = new DetailItem(item.index, item.description);
        this.detailItem.description = "#" + item.index + "\n\n" + item.description;
        this.detailItem.caption = caption;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        BindingContext = detailItem;
    }

    protected override bool OnBackButtonPressed()
    {
        Navigation.PopAsync();
        return true;
    }
}