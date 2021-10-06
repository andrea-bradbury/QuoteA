using System;
using Newtonsoft.Json;
using PCLStorage;
using System.Collections.Generic;
using System.Threading.Tasks;




namespace QuoteA.Model
{
    /// <summary>
    /// This class deals only with creating Quote objects from the JSON file
    /// </summary>

    public class Quotes
    {
        
        //The quote itself
        public string Saying { get; set; }

        //The person who said the saying
        public string Author { get; set; }

        
        //Contructor
        public Quotes(string saying, string author)
        {
            Saying = saying;
            Author = author;
        }


        




        


        

    }
}
