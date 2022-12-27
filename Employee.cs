public class Employee
{
    public string name { get; set; }
    public int idNumber;
    public string title { get; set; }
    public System.DateTime startDate { get; set; }
    Random random = new Random();

    public Employee(string eName, string jobTitle)
    {
        name = eName;
        title = jobTitle;

    }

    public void setID(int number)
    {
        idNumber = number;
    }

    public int getID()
    {
        return idNumber;
    }

    public void getStartDate(DateTime input) {
        startDate = input;
    }


    public void printList()
    {
        Console.WriteLine($"{name}, {title}");
        Console.WriteLine($"Employee ID: {idNumber}");
        Console.WriteLine($"Start Date: {startDate}\n");
    }

    public string printEmployee()
    {
        Console.WriteLine("\n");
        return $"{name}, {title} \nEmployee ID: {idNumber} \nStart Date: {startDate} \n";
    }

    public void updateFile()
    {
        using(StreamWriter file = new StreamWriter("employeedata.txt", true))
    {       
        file.WriteLine($"{name}, {title} \nEmployee ID: {idNumber} \nStart Date: {startDate} \n");
        }
    }

    // public void removeEmployee() 
    // {
    
    // }
}