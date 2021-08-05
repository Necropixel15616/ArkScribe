using ArkScribeBackend.DataHandler;
using ArkScribeBackend.Objects;
using ArkScribeFrontEnd.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for MutateProject.xaml
    /// </summary>
    public partial class MutateProject : Page
    {
        private readonly Regex regex = new Regex(@"^\d+$");
        public MutateProject(Project project)
        {
            InitializeComponent();
            DataContext = project;
        }

        private void Stat_AddMutation(object sender, RoutedEventArgs e)
        {
            if (regex.IsMatch(txtMutators.Text))
            {
                int mutators = int.Parse(txtMutators.Text);
                if(mutators <= 1)
                {
                    mutators = 1;
                }
                var source = e.Source as Button;
                string stat = source.Name.Substring(6);
                Project project = (Project)source.DataContext;
                var property = project.Generation.GetType().GetProperty(stat);
                int statIncrease = int.Parse(property.GetValue(project.Generation).ToString()) + 2 * mutators;
                var dh = new XMLDataHandler();
                if (statIncrease >= 255)
                {
                    MessageBox.Show("Cannot mutate past 254!");
                }
                else
                {
                    dh.AddMutation(project.Id, new Stat { Name = stat, Points = statIncrease });
                    DataContext = dh.GetProject(project.Id);
                }
            }
            else
            {
                MessageBox.Show("Mutator Count must be a number!");
            }
        }
        private void Stat_SubtractMutation(object sender, RoutedEventArgs e)
        {
            var source = e.Source as Button;
            string stat = source.Name.Substring(6);
            Project project = (Project)source.DataContext;
            var dh = new XMLDataHandler();
            bool successful = dh.RemoveMutation(project.Id, stat);
            if (!successful)
            {
                MessageBox.Show("Cannot remove base levels!");
            }
            DataContext = dh.GetProject(project.Id);
        }

        private void ValidateMutatorCount(object sender, TextChangedEventArgs e)
        {
            var source = e.Source as TextBox;
            bool isValid = regex.IsMatch(source.Text);
            if (!isValid)
            {
                lblError.Visibility = Visibility.Visible;
                source.Background = new SolidColorBrush(Colors.IndianRed);
            }
            else
            {
                lblError.Visibility = Visibility.Hidden;
                source.Background = new SolidColorBrush(Colors.White);
            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenu());
        }

        private void btnColourTab_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
