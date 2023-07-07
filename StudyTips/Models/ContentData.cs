using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTips.Models
{
    internal class ContentData
    {
        public List<MainItem> mainItemList { get; set; } = new List<MainItem>();
        public List<IconItem> iconItemList { get; set; } = new List<IconItem>();

        public ContentData()
        {
            //AddData();
        }

        public void AddData()
        {
            mainItemList.Clear();

            mainItemList.Add(new MainItem("My Title1", "dotnet_bot.png"));
            mainItemList.Add(new MainItem("My Title1", "dotnet_bot.png"));
            mainItemList.Add(new MainItem("My Title1", "dotnet_bot.png"));
            mainItemList.Add(new MainItem("My Title1", "dotnet_bot.png"));
            mainItemList.Add(new MainItem("My Title1", "dotnet_bot.png"));
            mainItemList.Add(new MainItem("My Title1", "dotnet_bot.png"));
            mainItemList.Add(new MainItem("My Title1", "dotnet_bot.png"));
            mainItemList.Add(new MainItem("My Title1", "dotnet_bot.png"));
            mainItemList.Add(new MainItem("My Title1", "dotnet_bot.png"));
        }
    }
}
