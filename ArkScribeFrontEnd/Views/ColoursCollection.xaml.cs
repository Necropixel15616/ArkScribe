using ArkScribeBackend.DataHandler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArkScribe.FrontEnd.Views
{
    /// <summary>
    /// Interaction logic for ColoursCollection.xaml
    /// </summary>
    public partial class ColoursCollection : Page
    {
        public ColoursCollection(int id)
        {
            InitializeComponent();
            var dh = new XMLDataHandler();
            DataContext = dh.GetColours(id);
        }
    }
}
