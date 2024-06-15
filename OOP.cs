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

		UserInterface.DisplayOptions();

	}
}


class UserInterface
{
	
	public static void DisplayOptions()
	{
		//Displays a Console menu and gets users selection
		Console.WriteLine("1: Create New Entry");
		Console.WriteLine("2: Display Entries");
		Console.WriteLine("3: Search For Entry");
		Console.WriteLine("4: Modify Entry");
		Console.WriteLine("0: Exit Browser");

		int userSelection = getInt();
		Console.WriteLine(userSelection);
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
            catch (Exception e)
            {
                Console.WriteLine("Please Enter a Valid Number! Try Again.");
            }
			
        }
        
		return Convert.ToInt32(userEntry);


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