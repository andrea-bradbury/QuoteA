using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuoteA.Model;


namespace QuoteA
{
    public partial class App : Application
    {

        public InputOutput inputOutput { get; private set; } = new InputOutput();


        
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

           
        }

        protected override void OnStart()
        {
            //Try open the file of Quotes and save contents to objects

            inputOutput.readFromFile();
            

            
        }


        protected override void OnSleep()
        {
            //Save all Quote objects back to file

            inputOutput.saveToFile();
        }

        protected override void OnResume()
        {

        }
    }
}
