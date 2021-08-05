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
    /// Interaction logic for CreateProject.xaml
    /// </summary>
    public partial class CreateProject : Page
    {
        private readonly Regex regex = new Regex(@"^\d{1,3}$");
        public SolidColorBrush background = new SolidColorBrush(Colors.White);
        public CreateProject()
        {
            InitializeComponent();
        }

        private void btnCancelCreate_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenu());
        }

        private void btnCreateProject_Click(object sender, RoutedEventArgs e)
        {
            string[] inputs = { txtHealth.Text, txtStamina.Text, txtOxygen.Text, txtFood.Text, txtWeight.Text, txtMelee.Text, txtSpeed.Text };
            bool isValid = true;
            for(int i = 0; i< inputs.Length; i++)
            {
                isValid = regex.IsMatch(inputs[i]);
                if (!isValid)
                {
                    
                    MessageBox.Show("Stats must be a number!");
                    break;
                }
            }
            if (isValid)
            {
                Project project = new Project
                {
                    Name = txtSpecies.Text,
                    Generation = new Generation
                    {
                        Health = int.Parse(txtHealth.Text),
                        Stamina =int.Parse(txtStamina.Text),
                        Oxygen = int.Parse(txtOxygen.Text),
                        Food =   int.Parse(txtFood.Text),
                        Weight = int.Parse(txtWeight.Text),
                        Melee =  int.Parse(txtMelee.Text),
                        Speed =  int.Parse(txtSpeed.Text),
                    }
                };
                var dh = new XMLDataHandler();
                bool createProject = dh.CreateProject(project);
                if (createProject)
                {
                    NavigationService.Navigate(new MainMenu());
                }
                else
                {
                    MessageBox.Show("Project Already Exists!");
                }
            }

        }

        private void stat_TextChanged(object sender, TextChangedEventArgs e)
        {
            var source = e.Source as TextBox;
            bool isValid = regex.IsMatch(source.Text);
            if (!isValid)
            {
                lblStatError.Visibility = Visibility.Visible;
                source.Background = new SolidColorBrush(Colors.IndianRed);
            }
            else
            {
                lblStatError.Visibility = Visibility.Hidden;
                source.Background = new SolidColorBrush(Colors.White);
            }
        }
    }
}
