using System;

namespace OOPIntro
{

    class Program
    {
        static void Main(string[] args)
        {
            HomePhone gMa = new HomePhone("5551234567", true);
            HomePhone gPa = new HomePhone("3332341234", false);

            gMa.Call(gPa);

            CellPhone mom = new CellPhone("9872345874");
            CellPhone dad = new CellPhone("8772274669");

            mom.Text(dad, "It's my money, and I want it now!");
            dad.Call(mom);
            
            SmartPhone charlie = new SmartPhone("9873272238", "1111222233334444");
            
            charlie.Text(dad, "I need money too, I ran out of super boost crystals in my Raid Shadow Legends Game!");
            dad.Call(mom);
            mom.Text(charlie, "Ok fine, I'll give you an advance on your allowance");
            charlie.BuyApp("Raid Shadow Legends");
            charlie.Call(gMa);

            gMa.Number = "1234567890";
        }
    }
}
