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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArtifitialUnintteligence_proto
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Resp_Opt_MenuItem_Checked(object sender, RoutedEventArgs e)
        {
            unmoViewModel.Resp_opt = true;
        }

        private void Resp_Opt_MenuItem_Unchecked(object sender, RoutedEventArgs e)
        {
            unmoViewModel.Resp_opt = false;
        }

        private void AddLogure_TextChanged(object sender, TextChangedEventArgs e)
        {
            tb_Logure.ScrollToEnd();
        }
    }
}
