using ArkScribe.Backend.Objects;
using ArkScribeBackend.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ArkScribeBackend.DataHandler
{
    public class XMLDataHandler
    {
        //Create a string for the file path, leading to Local.
        //Creates a folder called ArkScribe and then a retrieves an Xml file called DinoFile.xml.
        string filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ArkScribe\\DinoFile.xml");

        //a Function for inserting a new project into DinoFile.xml.
        public bool CreateProject(Project project)
        {
            //Opens the xml file.
            var file = XDocument.Load(filepath);
            
            //Gathers the first element where the name attribute of the Project element is equal to the new project name.
            //Compared it with a null value to determine if the project already exists with that name. 
            //this is so projects dont get overwritten by mistake.
            var doesProjectExist = file.Root.Descendants("Project").Where(e => e.Attribute("Name").Value == project.Name).FirstOrDefault();
            if (doesProjectExist == null)
            {
                //this gathers a list of every Project.
                //it then cycles through each project, comparing the id's of the current and previous id.
                //if the current id is higher, that id overrides the previous one. 
                //after it has finished, it takes the id, increments it by 1 and assigns that id to the new project.
                List<XElement> elements = file.Root.Descendants("Project").ToList();
                var id = 0;
                foreach(var e in elements)
                {
                    if(int.Parse(e.Attribute("Id").Value) > id)
                    {
                        id = int.Parse(e.Attribute("Id").Value);
                    }
                }
                project.Id = id + 1;
                
                //Creates a Generation object using the Generation property of Project.
                //this is just so every time Generation is referred in the coming code, its not Project.Generation.
                Generation generation = project.Generation;

                //Creates a new instance of an Xml Element and assigns the root as Project.
                //Then it creates 2 attributes for the Project element. the Id and the Name.
                XElement element = new XElement("Project");
                element.Add(new XAttribute("Name", project.Name));
                element.Add(new XAttribute("Id", project.Id));
                element.Add(new XElement("TotalMutations", 0));

                //Creates a child element of Project called generation. Each Project will contain multiple instances of generation eventually.
                //Then it goes through every property of Generation. It creates a Child element of Generation named after the property and assigned the property value.
                element.Add(new XElement("Generation"));
                element.Element("Generation").Add(new XAttribute("Mutations", 0));
                foreach (var prop in generation.GetType().GetProperties())
                {
                    if (prop.Name != "Mutations")
                    {
                        var value = prop.GetValue(generation);
                        element.Element("Generation").Add(new XElement(prop.Name, value));
                    }
                }

                //Add the new element and children to the Xml file and save the changes.
                file.Root.Add(element);
                file.Save(filepath);
                return true;
            }
            else
            {
                //if a project with the same name already exists, Tell the user.
                return false;
            }

        }

        //a Function for finding an existing project and deleting it.
        public bool DeleteProject(int id)
        {
            //Open the xml file.
            var file = XDocument.Load(filepath);
            
            //Retrieve the Element and children where the given Id equals the Element Id Attribute value.
            //Then Remove the element from the Xml file and save it.
            XElement element = file.Root.Descendants("Project").Where(p => p.Attribute("Id").Value == id.ToString()).FirstOrDefault();
            if (element != null)
            {
                element.Remove();
                file.Save(filepath);
                return true;
            }
            else
            {
                Console.WriteLine("Removal of project unsuccessful. Project not found");
                return false;
            }
        }

        //a Function for retrieving the highest stats of every project.
        public List<Project> GetProjects()
        {
            //open the file.
            var file = XDocument.Load(filepath);

            //Instantiate a new list of Projects.
            List<Project> projects = new List<Project>();

            //Instantiate a temporary list of XElements in the root element with the tag Project. 
            List<XElement> _projects = file.Root.Descendants("Project").ToList();

            //loop through each project in the XElement List.
            foreach(var _project in _projects)
            {
                //Collect the Id and Name of the current project.
                var project = new Project
                {
                    Id = int.Parse(_project.Attribute("Id").Value),
                    Name = _project.Attribute("Name").Value,
                    Mutations = int.Parse(_project.Element("TotalMutations").Value)
                };

                //Instantiate a new instance of Generation, assigning 0 to all values because a number cant be larger than null.
                var generation = new Generation
                {
                    Mutations = 0,
                    Health = 0,
                    Stamina = 0,
                    Oxygen = 0,
                    Food = 0,
                    Weight = 0,
                    Melee = 0,
                    Speed = 0
                };

                //Loop through all the Generations of the current project.
                foreach(var g in _project.Descendants("Generation"))
                {
                    //loop through all the properties of the Generation object.
                    foreach (var prop in generation.GetType().GetProperties())
                    {
                        //get the current value of the property from the generation object.
                        var value = prop.GetValue(generation);

                        //get the value of the property from the child element.
                        if (prop.Name != "Level" && prop.Name != "Mutations")
                        {
                            var property = g.Element(prop.Name);
                            if (property != null)
                            {
                                //only get the value of the property if it is larger than the previous one.
                                //we only want to retrieve the highest values of each to display.
                                if (int.Parse(property.Value) > int.Parse(value.ToString()))
                                {
                                    //assign the value to a variable.
                                    value = int.Parse(property.Value);

                                    //set the property value to the new value.
                                    prop.SetValue(generation, value);
                                }
                            }
                        }
                    }
                }
                //add the collection of highest stats to the current project.
                //then add the project to the list of projects.
                project.Generation = generation;
                projects.Add(project);
            }
            //return the list of projects.
            return projects;
        }

        //A Function for retrieving a single project.
        public Project GetProject(int id)
        {
            //Open the File.
            var file = XDocument.Load(filepath);
            
            //Get the project from the file where the Id equals the given Id.
            XElement _project = file.Root.Descendants("Project").Where(p => int.Parse(p.Attribute("Id").Value) == id).FirstOrDefault();

            //Instantiate a new Project Object. This will be our returned project once we retrieve the data.
            var project = new Project
            {
                Id = int.Parse(_project.Attribute("Id").Value),
                Name = _project.Attribute("Name").Value,
                Mutations = int.Parse(_project.Element("TotalMutations").Value),
                Generation = new Generation
                {
                    Health = 0,
                    Stamina = 0,
                    Oxygen = 0,
                    Food = 0,
                    Weight = 0,
                    Melee = 0,
                    Speed = 0
                }
            };
            //go through each generation in the retrieved project.
            foreach(var _generation in _project.Descendants("Generation"))
            {
                //for each generation, go through the properties of the generation object.
                foreach(var prop in project.Generation.GetType().GetProperties())
                {
                    //if the property name equals Mutations or Level, dont do anything.
                    //This is because Mutations is an attribute and Level has a particular get method that ignored the stored value.
                    if (prop.Name != "Mutations" && prop.Name != "Level")
                    {
                        //Get the value of the property from the object above.
                        var value = prop.GetValue(project.Generation);
                        
                        //if the element name isn't null and the value of the element is greater than the value of the property, the property value now equals the element value.
                        if (_generation.Element(prop.Name) != null && int.Parse(_generation.Element(prop.Name).Value) > int.Parse(value.ToString()))
                        {
                            value = int.Parse(_generation.Element(prop.Name).Value);
                            prop.SetValue(project.Generation, value);
                        }
                    }
                }
            }
            //return the project once the highest stats have been retrieved.
            return project;
        }

        //A Function for adding a new stat to the appropriate generation.
        public void AddMutation(int id, Stat stat)
        {
            //Open the file.
            var file = XDocument.Load(filepath);

            //Get the project being edited based off the project Id.
            XElement project = file.Root.Elements("Project").Where(p => int.Parse(p.Attribute("Id").Value) == id).FirstOrDefault();

            //get the total mutations value, increment it by 1 and replace it in the file.
            XElement totalMutations = new XElement("TotalMutations", int.Parse(project.Element("TotalMutations").Value)+1);
            project.Element("TotalMutations").Remove();
            project.Add(totalMutations);

            //Instantiate 2 new variables for later user.
            //One is a mutations count.
            //The other is the a tracker to determine if we need to edit an existing generation, or create a new one.
            var mutations = 0;
            var generation = project.Descendants("Generation").Where(e => int.Parse(e.Attribute("Mutations").Value) == 0).FirstOrDefault();

            //go through each generation
            foreach (var _generation in project.Descendants("Generation"))
            {
                //if the current generations mutation value is greater than the variable.
                //the variable equals the generation attribute value.
                if(int.Parse(_generation.Attribute("Mutations").Value) > mutations)
                {
                    mutations = int.Parse(_generation.Attribute("Mutations").Value);
                }

                //get the element where the name equals the stat in question.
                //then assign the generation a value from the temporary generation.
                XElement _element = _generation.Element(stat.Name);
                generation = _generation;

                //if the stat wasn't found, break out of the loop.
                if(_element == null)
                {
                    break;
                }
            }

            //get the stat from the retrieved generation.
            //if it doesnt exist, create it in the current generation and assign the value.
            //otherwise create a new generation.
            XElement createOrEdit = generation.Element(stat.Name);
            if(createOrEdit == null)
            {
                generation.Add(new XElement(stat.Name, stat.Points));
            }
            else
            {
                XElement e = new XElement("Generation");
                e.Add(new XAttribute("Mutations", mutations+1));
                e.Add(new XElement(stat.Name, stat.Points));
                project.Add(e);
            }

            //Save the changes.
            file.Save(filepath);
             
        }

        //A Function for removing the latest addition to a stat.
        public bool RemoveMutation(int id, string stat)
        {
            //Open the File.
            var file = XDocument.Load(filepath);
            //Get the project in mention.
            XElement project = file.Root.Descendants("Project").Where(p => int.Parse(p.Attribute("Id").Value) == id).FirstOrDefault();
            
            //Instantiate a new instance of a Generation Element, at the lowest level.
            var generation = project.Descendants("Generation").Where(p => int.Parse(p.Attribute("Mutations").Value) == 0).FirstOrDefault();
            
            //Loop through all the generations of the project.
            foreach(var _generation in project.Descendants("Generation"))
            {
                //Get the stat that is going to be removed.
                XElement _element = _generation.Element(stat);
                
                //if the stat wasn't found, break out of the loop.
                if(_element == null)
                {
                    break;
                }
                
                //if the loop continues, overwrite the previouos generation with the latest.
                generation = _generation;
            }

            //if the mutations value of the generation is 0, dont remove it.
            if (int.Parse(generation.Attribute("Mutations").Value) >= 1)
            {
                //remove the generation.
                generation.Element(stat).Remove();

                //check if the generation is now empty. if it is, remove that generation entirely.
                if (generation.IsEmpty == true)
                {
                    generation.Remove();
                }
                
                //update the total mutations so it decrements by 1.
                var totalMutations = int.Parse(project.Element("TotalMutations").Value) - 1;
                project.Element("TotalMutations").Remove();
                project.Add(new XElement("TotalMutations", totalMutations));
            }
            else
            {
                return false;
            }
            
            //Save the changes.
            file.Save(filepath);
            return true;
        }

        //A Function for retrieving a list of colours
        public List<ColourGeneration> GetColours(int id)
        {
            List<ColourGeneration> colours = new List<ColourGeneration>();
            colours.Add(new ColourGeneration { Region1 = 1 });
            return colours;
        }
    }
}
