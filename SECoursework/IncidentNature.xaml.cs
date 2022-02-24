using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Data;

namespace SECoursework
{
    /// <summary>
    /// Interaction logic for IncidentNature.xaml
    /// </summary>
    public partial class IncidentNature : Window
    {
        public IncidentNature()
        {
            InitializeComponent();
        }

        public string nature;
        SaveIncidentNature saveIncidentNature = new SaveIncidentNature();


        private void natureCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            nature = ((ComboBoxItem)natureCombo.SelectedItem).Content as string;
            ((MainWindow)Application.Current.MainWindow).disSirNature.Text = nature;
            saveIncidentNature.SaveNature(nature);
            string natureFile = @"E:\ELM outputs\Significant_Incident_Report_Nature_List\NatureList.csv";

            if (File.Exists(natureFile))
            {
                // Display the trending list window
                TrendingList trendingListWindow = new TrendingList();
                trendingListWindow.Show();
            }
            this.Close();
        }
       

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
