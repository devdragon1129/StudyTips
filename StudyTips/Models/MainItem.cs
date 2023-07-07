using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTips.Models
{
    public class MainItem
    {
        public int id { get; set; }

        public string imagePath { get; set; }

        public string caption { get; set; }

        public string description { get; set; }

        public int itemCount { get; set; }

        public List<DetailItem> detailItemList { get; set; }

        public MainItem(int number, string title, string filePath)
        {
            id = number;
            imagePath = filePath;
            caption = title;
            description = "";

            detailItemList = new List<DetailItem>();
        }
        public MainItem(string title, string filePath)
        {
            imagePath = filePath;
            caption = title;
            description = "";

            detailItemList = new List<DetailItem>();
        }

        public MainItem(MainItem item)
        {
            item.detailItemList = new List<DetailItem>(item.detailItemList);

            int index = 0;
            foreach(DetailItem detailItem in item.detailItemList)
            {
                index++;
                detailItem.index = index.ToString();
            }
        }
    }
}
