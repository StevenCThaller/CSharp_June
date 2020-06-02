using System;

namespace OOPIntro
{
    class SmartPhone : CellPhone
    {
        private string CCNumber { get; set; }

        public SmartPhone(string num, string ccnum) : base(num)
        {
            this.CCNumber = ccnum;
        }

        public bool BuyApp(string AppName)
        {
            if(this.CCNumber.Length == 16)
            {
                System.Console.WriteLine($"You successfully bought {AppName}");
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    class CellPhone: Phone
    {
        public CellPhone(string num) : base(num, "Battery") 
        {}

        public void Text(Phone phone, string message)
        {
            System.Console.WriteLine($"You sent \"{message}\" to {phone.Number}.");
        }
    }

    class HomePhone : Phone
    {
        public bool Corded { get; set; }

        // Because we have already determined that the HomePhone class extends the Phone class,
        // we can recycle the Phone's constructor to build that base object that this class
        // builds on top of.
        public HomePhone(string num, bool Corded) : base(num, "Plug In")
        {
            this.Corded = Corded;
        }
    }
    
    abstract class Phone
    {
        // These are the attributes of my phone object
        // public string Color { get; set; }
        // public int Memory { get; set; }
        public string Number { get; set; }
        public string PowerSource { get; set; }
        // public string Owner { get; set; }
        // private string CCNumber { get; set; }

        // This is the constructor method to actually
        // create new instances of my phone class
        // public Phone(string Number) 
        // {
        //     this.Number = Number; // Assigning the number from the parameters of the constructor to the Number attribute of the phone
        //     // this.Color = Color; // Assigning the color from the parameters of the constructor to the Color attribute of the phone
        //     // this.Memory = Memory; // Assigning the memory from the parameters of the constructor to the Memory attribute of the phone
        //     // this.Owner = Owner;
        //     // this.CCNumber = ccnum;
        //     this.PowerSource = "Plug In";
        // }
       


        public Phone(string Number, string Power)
        {
            this.Number = Number;
            this.PowerSource = Power;
        }


        public bool Call(Phone phone)
        {
            if(phone.Number.Length != 10)
            {
                return false;    
            }
            else 
            {
                System.Console.WriteLine($"You dialed {phone.Number}!");
                return true;
            }
        }

        class Human
        {
            public DateTime Birthday { get; }

            public int Age { get
            {
                //calculates the numerical age
                // based on the Birthday field
                return 234;
            } 
            }
        }

        
    }
}