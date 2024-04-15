using DataAccess;
using Services.Interfaces;
using Models;
using Services.Implementations;

namespace TaxiManagerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUIService uiService = new UIService();

            uiService.Login();
            uiService.ShowMenu();
        }
    }
}
