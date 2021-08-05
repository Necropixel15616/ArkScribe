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
using ArkScribe.FrontEnd.Views;
using ArkScribeBackend.DataHandler;
using ArkScribeBackend.Objects;

namespace ArkScribeFrontEnd.Views
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
            var dh = new XMLDataHandler();
            List<Project> projects = dh.GetProjects();
            ProjectsDataGrid.ItemsSource = projects;
            

        }

        private void btnEditProject_Click(object sender, RoutedEventArgs e)
        {
            Project project = (Project)(e.Source as Button).DataContext;
            NavigationService.Navigate(new MutateProject(project));
        }
        private void btnDeleteProject_Click(object sender, RoutedEventArgs e)
        {
            Project project = (Project)(e.Source as Button).DataContext;
            MessageBoxResult result = MessageBox.Show("Are you sure you wish to delete this project?", "Delete Project", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var dh = new XMLDataHandler();
                bool deleteProject = dh.DeleteProject(project.Id);
                if (deleteProject)
                {
                    NavigationService.Navigate(new MainMenu());
                }
                else
                {
                    MessageBox.Show("Unable to Delete Project!");
                    NavigationService.Navigate(new MainMenu());
                }
            }
        }

        private void btnCreateProject_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateProject());
        }

        private void ProjectsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
