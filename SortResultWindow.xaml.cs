using System;
using System.Collections.Generic;
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

namespace FileSortingSystemV2._0
{
    /// <summary>
    /// Логика взаимодействия для SortResultWindow.xaml
    /// </summary>
    public partial class SortResultWindow : Window
    {
        public SortResultWindow()
        {
            InitializeComponent();
        }
            
        public void AddInfo(string text)
        {
            resultTextBox.Items.Add(text);
        }

        public void EndSorting()
        {
            closeBtn.Visibility = Visibility.Visible;
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
