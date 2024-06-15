using System;

public static class Globals
{
	public const int currentYear = 2024;
}


public class DealershipProgram
{
	static void Main(string[] args)
	{
		//global int currentYear = 2024;
		
		//string model = "jazz";
		//string manufacturer = "honda";
		//string colour = "silver";
		//int age = 17;

		Car car1 = new Car("jazz", "honda", "silver", 17);
		Car car2 = new Car("V40", "volvo", "silver", 6);


		Console.WriteLine(car1.manufacturer + " " + car1.model);
		//Console.WriteLine(car1.getManufactureYear(Globals.currentYear));
		Console.WriteLine(car1.getPrintout());
		Console.WriteLine(car2.getManufactureYear(Globals.currentYear));

		UserInterface.DisplayOptions();

	}
}


class UserInterface
{
	public static void DisplayOptions()
	{
		Console.WriteLine("1: Create New Entry");
		Console.WriteLine("2: Display Entries");
		Console.WriteLine("3: Search For Entry");
		Console.WriteLine("4: Modify Entry");
		Console.WriteLine("0: Exit Browser");

		//int userSelection = Convert.ToInt32(Console.ReadLine());
		int userSelection = getInt();
		Console.WriteLine(userSelection);
	}

	public static int getInt()
	{
		bool validInt = false;
		string userEntry = "";

		while (validInt != true) 
		{
            userEntry = Console.ReadLine();
            
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
		return colour + " " + getManufactureYear(Globals.currentYear) + " " + manufacturer + " " + model;
	}

}