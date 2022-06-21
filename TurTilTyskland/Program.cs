using System;

public static class InputManager
{
    public static float ReadLine()
    {
        string answer;
        while (true)
        {
            answer = Console.ReadLine();
            if (answer == null) {
                Console.WriteLine("Answer must be a non-null value");
                continue;
            }

            if (!float.TryParse(answer, out float value))
            {
                Console.WriteLine("The input must be a number");
                continue;
            }
            break;
        }
  
        return float.Parse(answer);
    }
}


public class FuelPrices
{
    public float foreign_fuel_price;
    public float home_fuel_price;
    public FuelPrices ()
    {
        Console.WriteLine("What's the german fuel price in DKK?");
        foreign_fuel_price = InputManager.ReadLine();
        Console.WriteLine("What's the danish fuel price in DKK?");
        home_fuel_price = InputManager.ReadLine();
    }
}


public class Car
{
    public float km_per_l;
    public float need_for_fuel;
    public Car()
    {
        Console.WriteLine("What's the car's mileage in km/l");
        km_per_l = InputManager.ReadLine();
        Console.WriteLine("How much fuel can the car take in l?");
        need_for_fuel = InputManager.ReadLine();
    }
}


public class Distance
{ 
    public float distance;
    public Distance() 
    {
        Console.WriteLine("Whats the distance to Germany from your current placement?");
        distance = InputManager.ReadLine();
    }
}


public class CarTrip
{
    public static void Main()
    {
        FuelPrices FuelPrices1 = new FuelPrices();
        Car Car1 = new Car();
        Distance Distance1 = new Distance();

        float liters_used;
        float foreign_gas_bill;
        float home_gas_bill;
        double bill_difference;

        liters_used = Distance1.distance * 2 / Car1.km_per_l;
        foreign_gas_bill = (liters_used + Car1.need_for_fuel) * FuelPrices1.foreign_fuel_price;
        home_gas_bill = FuelPrices1.home_fuel_price * Car1.need_for_fuel;
        bill_difference = home_gas_bill - foreign_gas_bill;

        if (bill_difference > 0)
        {
            Console.WriteLine("You could save " + bill_difference + " DKK if you drove to germany");
        }
        else if (bill_difference < 0)
        {
            Console.WriteLine("You would lose " + -bill_difference + " DKK if you drove to germany");
        }
        else
        {
            Console.WriteLine("Financially you'd get the same result, so do whatever you feel like");
        }
    }
}