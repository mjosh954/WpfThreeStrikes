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
    /// Interaction logic for EndGameView.xaml
    /// </summary>
    public partial class EndGameView : Window
    {


        public EndGameView(bool win, Model.Prize prize, GameViewModel gameViewModel)
        {
            InitializeComponent();
            EndGameViewModel vm = new EndGameViewModel(win, prize, gameViewModel);
            DataContext = vm;
            if(vm.CloseAction == null)
                vm.CloseAction = Close;
        }

        
        private void btnMain_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }
}
