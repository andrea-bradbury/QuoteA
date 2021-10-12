using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PCLStorage;
using Newtonsoft.Json;
using QuoteA.Model;



namespace QuoteA
{
    

    public partial class MainPage : ContentPage
    {
        InputOutput inputOutput;



        public MainPage()
        {
            
            InitializeComponent();

            App app = (App)Application.Current;

            inputOutput = app.inputOutput;

            

        }

        


        ///Take the quote and author input and create Quotes object.

        void buttonSaveQuote_Clicked(System.Object sender, System.EventArgs e)
        {
            
            string quoteInput = entryQuote.Text;

            string authorInput = entryAuthor.Text;


            Quotes Model = new Quotes(quoteInput, authorInput);


            inputOutput.AddToList(Model);


            DisplayAlert($"{Model.Saying}, {Model.Author}", "This quote has been added.", "OK");


            //Need to add in clears for the entry fields

            


        }


        ///Collects a random quote from the array of quote objects and displays in UI.

        void buttonRandomGenerate_Clicked(System.Object sender, System.EventArgs e)
        {

            Quotes quote = inputOutput.GetRandomQuote();


            labelQuoteText.Text = quote.Saying;


            labelQuoteAuthor.Text = quote.Author;


        }

        



    }
}
