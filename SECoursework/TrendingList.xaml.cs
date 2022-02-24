
using System.IO;
using System.Windows;
using System.Windows.Controls;


namespace SECoursework
{
    /// <summary>
    /// Interaction logic for TrendingList.xaml
    /// </summary>
    public partial class TrendingList : Window
    {
        public TrendingList()
        {          
            InitializeComponent();
            addItems();
        }

        public void addItems()
        {
            if(File.Exists(@"E:\ELM outputs\Twitter_Hashtag_List\HashtagList.csv"))
            {
                string[] hashtags = File.ReadAllLines(@"E:\ELM outputs\Twitter_Hashtag_List\HashtagList.csv");
                foreach (string value in hashtags)
                {
                    string[] result = value.Split(',');
                    foreach (string v in result)
                    {
                        lstTrending.Items.Add(v);
                    }

                }
            }
            
            if(File.Exists(@"E:\ELM outputs\Twitter_Mention_List\MentionList.csv"))
            {
                string[] mentions = File.ReadAllLines(@"E:\ELM outputs\Twitter_Mention_List\MentionList.csv");
                foreach (string value in mentions)
                {
                    string[] result = value.Split(',');
                    foreach (string v in result)
                    {
                        lstMentions.Items.Add(v);
                    }

                }
            }
            

            if(File.Exists(@"E:\ELM outputs\Significant_Incident_Report_Nature_List\NatureList.csv"))
            {
                string[] natureFile = File.ReadAllLines(@"E:\ELM outputs\Significant_Incident_Report_Nature_List\NatureList.csv");
                foreach (string value in natureFile)
                {
                    string[] result = value.Split(',');
                    foreach (string v in result)
                    {
                        lstNature.Items.Add(v);
                    }

                }
            }
            

        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lstTrending_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lstMentions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lstNature_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
