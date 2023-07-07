using StudyTips.Models;
using System.Diagnostics;

namespace StudyTips.Views;

public partial class MainPage : ContentPage
{
    Task initTask;

    public MainPage()
    {
        InitializeComponent();

        initTask = LoadData();

        //NavigationPage.SetHasNavigationBar(this, false);
    }

    public async Task<bool> LoadData()
    {
        int id = 0;
        int parentID = 0;

        try
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("content.txt");
            using var reader = new StreamReader(stream);

            ContentData contentData = new ContentData();

            while (!reader.EndOfStream)
            {
                string text = reader.ReadLine();
                Debug.WriteLine(text);

                if (text == "") continue;

                string[] textArray = text.Split(new char[] { '#' });
                if (textArray == null || textArray.Length == 0) continue;

                id = Convert.ToInt32(textArray[0]);
                parentID = Convert.ToInt32(textArray[1]);

                if (id > 10000)
                {
                    contentData.iconItemList.Add(new IconItem(textArray[2]));
                }
                else
                {
                    MainItem foundMainItem = null;

                    if (parentID == 0)
                    {
                        foreach (MainItem item in contentData.mainItemList)
                        {
                            if (item.id == id)
                            {
                                foundMainItem = item;
                                break;
                            }
                        }

                        if (foundMainItem == null)
                        {
                            foundMainItem = new MainItem(id, textArray[2], textArray[3]);
                            contentData.mainItemList.Add(foundMainItem);
                        }
                    }
                    else
                    {
                        foreach (MainItem item in contentData.mainItemList)
                        {
                            if (item.id == parentID)
                            {
                                foundMainItem = item;
                                break;
                            }
                        }

                        DetailItem detailItem = new DetailItem();
                        {
                            detailItem.index = (foundMainItem.detailItemList.Count + 1).ToString();
                            detailItem.id = id;
                            detailItem.parentID = parentID;
                            detailItem.description = textArray[2];
                        }
                        foundMainItem.detailItemList.Add(detailItem);
                    }
                }
            }
            reader.Close();

            Random random = new Random();

            foreach (MainItem mainItem in contentData.mainItemList)
            {
                mainItem.itemCount = mainItem.detailItemList.Count;
                mainItem.description = mainItem.detailItemList[random.Next() % mainItem.itemCount].description;
            }

            BindingContext = contentData;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            Debug.WriteLine(id);
        }

        return false;
    }


    protected override void OnAppearing()
    {
    }


    private async void ShareIcon_Clicked(object sender, EventArgs e)
    {
        string action = await DisplayActionSheet("Study Tips", "Share Apps", "More Apps", "Check out the best collection of Study Tips, be successful!");
        Debug.WriteLine("Action: " + action);
    }

    private void mainContent_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var mainItem = (MainItem)e.CurrentSelection[0];

            Navigation.PushAsync(new DetailPage(mainItem));

            // Unselect the UI
            mainContent.SelectedItem = null;
        }
    }

    private void iconItemContent_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            IconItem iconItem = e.CurrentSelection[0] as IconItem;

            Navigation.PushAsync(new ShowImage(iconItem));

            // Unselect the UI
            iconItemContent.SelectedItem = null;
        }
    }
}

