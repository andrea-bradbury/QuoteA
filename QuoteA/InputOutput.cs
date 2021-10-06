using System;
using PCLStorage;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuoteA.Model;


namespace QuoteA
{


    /// <summary>
    /// This class actually should be called something more useful! It manages all use of the Quotes objects.
    /// It collected the list of Quotes objects
    /// Generated a random Quotes object from the list
    /// And alsoi handles reading and writing to json files.
    /// </summary>


    public class InputOutput
    {
        

        public string FileName { get; set; }

        public string FolderName { get; set; }

        string fileName = "QuotesAppContentsJson";
        string folderName = "QuotesApp";


        // Collects all Quotes objects saved as list

        List<Quotes> listOfQuoteObjects = new List<Quotes>();



        ///Takes input of a Quote object and adds to a list. This list then will be given to the IO class to be saved as file.
        public void AddToList(Quotes quoteObject)
        {
            listOfQuoteObjects.Add(quoteObject);

        }


        ///Gets a random quotes object from the list
        
        public Quotes GetRandomQuote()
        {

            Random rnd = new Random();

            Quotes randomQuote = listOfQuoteObjects[rnd.Next()];


            return randomQuote;

        }


        /// Saving the lists of quotes objects into a file

        public async Task<bool> saveToFile()
        {
            try
            {

                //Serialize the list of Quotes objects

                string jsonFile = JsonConvert.SerializeObject(listOfQuoteObjects);


                // Open the folder

                IFolder folder = FileSystem.Current.LocalStorage;

                folder = await folder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);


                //Open file

                IFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);

                
                //Write to file
                await file.WriteAllTextAsync(jsonFile);



                return true;
            }
            catch 
            {
                ///Needs a directory not found exception
                return false;
            }
            

        }




        ///Reading from the json file 
        
        public async Task<bool> readFromFile()
        {
            try
            {

                IFolder folder = FileSystem.Current.LocalStorage;


                //Open or create a folder 

                folder = await folder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);


                //Open file

                IFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);


                //Gets content from file

                string loadedContent = await file.ReadAllTextAsync();


                //Turns file content into Quotes objects and puts them in list
                listOfQuoteObjects = JsonConvert.DeserializeObject<List<Model.Quotes>>(loadedContent);

               

                return true;
            }
            catch
            {
                ///Needs an exception for if a file doesn't exist

                return false;
            }

            
        }

        


    }
}
