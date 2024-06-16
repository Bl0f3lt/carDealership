using System;

public static class Globals
{
	//Global variables which maybe required in all parts of program.
	public const int currentYear = 2024;
}


public class DealershipProgram
{
	static void Main(string[] args)
	{
		//Main Code Block.
		Car car1 = new Car("jazz", "honda", "silver", 17);
		Car car2 = new Car("V40", "volvo", "silver", 6);

		Console.WriteLine(car1.getPrintout());
		Console.WriteLine(car2.getManufactureYear(Globals.currentYear));


		UserInterface UI1 = new UserInterface();

		UserInterface.DisplayOptions();
		int selection = UI1.getUserSelection();
		UI1.callOptionMethod(selection);
	}
}


class UserInterface
{
    bool carMapExists 
    { get; set; }
    Dictionary<string, object>? carMap
    { get; set; }

    public UserInterface(Dictionary<string,object>? carMap = null)
	{
		//Constructor. Can be used to import existing dictionaries. Creates one if not.
		if (carMap != null)
		{
			this.carMapExists = true;
			this.carMap = carMap;
		}
		else
		{
            this.carMapExists = false;
			this.carMap = new Dictionary<string, object>();
		}

	}

	public static void DisplayOptions()
	{
		//Displays a Console menu and gets users selection
		Console.WriteLine("1: Create New Entry");
		Console.WriteLine("2: Display Entries");
		Console.WriteLine("3: Search For Entry");
		Console.WriteLine("4: Modify Entry");
		Console.WriteLine("0: Exit Browser");

	}


	public static int getInt()
	{
		//Takes input and only returns if valid integer.
		bool validInt = false;
		string? userEntry = ""; //? signifys maybe null.

		while (validInt != true) 
		{
            userEntry = Console.ReadLine();
            
			//Try Catch for doing type validation
			try
            {
                Convert.ToInt32(userEntry);
				validInt = true;
            }
            catch
            {
                Console.WriteLine("Please Enter a Valid Number! Try Again.");
            }
			
        }
        
		return Convert.ToInt32(userEntry);


    }

	public int getUserSelection()
	{
		//Get user input and return
        int userSelection = getInt();
		return userSelection;
    }

	public string getNonNullString()
	{
		bool isNull = true;
		string? capturedString = "";
        while (isNull) {
            capturedString = Console.ReadLine();
			if (capturedString != null) { isNull = false; }
			else { Console.WriteLine("Null value entered! Please enter non null value"); }
        }
		return capturedString;
	}

	public object getCarDetails()
	{
		Console.WriteLine("Enter model Name; ");
		string modelName = getNonNullString();
        Console.WriteLine("Enter manufacturer Name; ");
        string manufacturerName = getNonNullString();
        Console.WriteLine("Enter colour Name; ");
        string carColour = getNonNullString();
        Console.WriteLine("Enter car age; ");
        int carAge = getInt();

		return new Car(modelName,manufacturerName,carColour,carAge);

    }


	private void createNewEntry()
	{
        //Dictionary<string,object> carMap = new Dictionary<string,object>(); 
        Console.WriteLine("Enter Number plate: ");
		//string numPlate = Console.ReadLine();
		string numPlate = getNonNullString();
		object car1 = getCarDetails();

		this.carMap[numPlate] = car1;

    }

	private void displayEntries()
	{
		int entryNum = 0;
		foreach (KeyValuePair<string, object> elements in this.carMap)
		{
			Console.WriteLine("{0} : {1}", entryNum,elements.Key);
			entryNum++;
		}
	}


	public void callOptionMethod(int userSelection)
	{
		//Switch Case to Translate User input to program function.
		//Console outputs are for debug and not final.
		switch (userSelection)
		{
			case 1:
				Console.WriteLine("Create New Entry");
				createNewEntry();
				break;

			case 2:
				Console.WriteLine("Displaying Entries");
				if (this.carMapExists != true) {
					displayEntries();
				}
				else
				{
					Console.WriteLine("Cannot output entries as no entries exist!.");
				}
				break;

			case 3:
				Console.WriteLine("Search Entry");
				break;

			case 4:
				Console.WriteLine("Modify Entry");
				break;

			case 0:
				Console.WriteLine("Exit Browser");
				break;

		}
	}


}


class Car
{
	public string model;
	public string manufacturer;
	public string colour;
    public int age;

    public Car(string modelName, string manufacturerName, string carColour, int carAge)
	{
		//Constructor for Car class
		model = modelName;
		manufacturer = manufacturerName;
		age = carAge;
		colour = carColour;
	}

    public int getManufactureYear(int currentYear)
	{
		return currentYear - age;

	}

	public string getPrintout()
	{
		//Gives printout of cars details.
		return colour + " " + getManufactureYear(Globals.currentYear) + " " + manufacturer + " " + model;
	}

}