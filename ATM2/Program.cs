using System;
using System.Linq;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(String cardNum,
    int pin,
    String firstName,
    String lastName,
    double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;

    }
    public String getNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public void setfirstName(String newFirstname)
    {
        firstName = newFirstname;
    }

    public void setlastFirst(string newLastname)
    {
        lastName = newLastname;
    }

    public void setcardNum (String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setpin (int newPin)
    {
        pin = newPin;
    }
    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Widhdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }
        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit?");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit + currentUser.getBalance());
            Console.WriteLine("Thank you for your $$. Your new balance is : " + currentUser.getBalance());
        }

        void widhdraw (cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to widhdraw: ");
            double widhdrawal = Double.Parse(Console.ReadLine());
            //Check if teh user has enough money
            if (currentUser.getBalance() < widhdrawal)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - widhdrawal);
                Console.WriteLine("You're good to go! Thank you");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance : " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("6873467362454", 1234, "mary", "sly", 160.67));
        cardHolders.Add(new cardHolder("7647365763475", 3445, "mes", "stan", 16099.67));
        cardHolders.Add(new cardHolder("4376736573654", 3444, "lin", "liam", 16330.67));
        cardHolders.Add(new cardHolder("8734892409455", 3333, "stan", "andrew", 16440.6447));
        cardHolders.Add(new cardHolder("3989482933948", 6666, "luke", "wiggins", 12360.67));

        Console.WriteLine("Welcome to ATM");
        Console.WriteLine("Please insert your debt card");
        String debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card nor recognized. Please try again");
                }
            }
            catch
            {
                Console.WriteLine("Card nor recognized. Please try again");
            }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect Pin. Please try again");
                }
            }
            catch
            {Console.WriteLine("Incorrect Pin. Please try again"); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName()+ " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {option = int.Parse(Console.ReadLine());}
            catch
            {  }
            if (option == 1)
            { deposit(currentUser); }
            else if (option == 2)
            { widhdraw(currentUser); }
            else if (option == 3)
            { balance(currentUser); }
            else if (option == 4)
            { break; }
            else
            { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day :)");
    }
}