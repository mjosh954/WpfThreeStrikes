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
using WpfThreeStrikes.ViewModel;

namespace WpfThreeStrikes.View
{
    /// <summary>
    /// Interaction logic for StartView.xaml
    /// </summary>
    public partial class StartView : Window
    {

        

        public StartView()
        {
            InitializeComponent();
            DataContext = new StartViewModel();
        }


        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            HelpView view = new HelpView();
            view.ShowDialog();
        }

        private void StartView1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
