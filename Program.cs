using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Text;

// List for employees
List<Employee> employeeList = new List<Employee>();

string? input = ""; // variable for user input in functions
bool keepGoing = true; // condition used for while loop

// user menu
void displayMenu()
{
    Console.WriteLine("\n*********************");
    Console.WriteLine("1. Create New Employee");
    Console.WriteLine("2. View All Employees");
    Console.WriteLine("3. Search Employees");
    Console.WriteLine("4. Delete Employee");
    Console.WriteLine("5. Quit");
    Console.WriteLine("*********************\n");
    Console.Write("Enter your choice: \n");
}

// Display options menu loop

while (keepGoing)
{

    displayMenu();

    int choice = 0;

    try
    {
        choice = int.Parse(Console.ReadLine() ?? "");
    }
    catch (Exception)
    {
        Console.WriteLine("Invalid choice. Please enter a choice of 1-5.");
        continue;
    }

    // condition to exit
    if (choice == 5)
    {
        keepGoing = false;
    }

    // switch menu to run user's choice
    switch (choice)
    {
        case 1:
            createEmployee();
            break;
        case 2:
            displayEmployees();
            break;
        case 3:
            searchMenu();
            break;
        case 4:
            deleteEmployee();
            break;
        default:
            Console.WriteLine("Goodbye!");
            break;
    }
}

// functions

// Create New Employee
void createEmployee()
{
    Console.Write("What is the employee's name? ");
    string? name = Console.ReadLine() ?? "";

    Console.Write("What is employee's title? ");
    string? title = Console.ReadLine() ?? "";


    Console.WriteLine("Enter employee's start date as mm/dd/yyyy");
    input = Console.ReadLine() ?? "";
    DateTime startDate = Convert.ToDateTime(input);
    try {
        startDate = DateTime.ParseExact(input, "MM/dd/yyyy", null);
    } catch (Exception) {
        Console.WriteLine("Invalid entry. Please enter in the correct date format of MM/dd/yyyy");
    }

    Employee employee = new Employee(name, title);
    Random random = new Random();
    int num = random.Next(1000, 9999);
    employee.setID(num);
    employee.getStartDate(startDate);
    employeeList.Add(employee);

    Console.WriteLine("\n");
    Console.WriteLine("New Employee has been added.  Employee ID: " + employee.getID());
    employee.updateFile();
}

// View All Employees
void displayEmployees()
{
    Console.WriteLine("*******************");
    Console.WriteLine("View all Employees");
    Console.WriteLine("******************* \n");

    foreach (Employee employee in employeeList)
    {
        employee.printList();
    }
}

void searchMenu()
{
    bool valid = true;
    Console.WriteLine("*********************");
    Console.WriteLine("Search Employees by: ");
    Console.WriteLine("1. Employee ID ");
    Console.WriteLine("2. Name ");
    Console.WriteLine("3. Return to main menu.");
    Console.WriteLine("********************* \n");

    Console.WriteLine("Enter your choice: ");
    while (valid)
    {
        int sChoice = 0;

        try
        {
            sChoice = int.Parse(Console.ReadLine() ?? "");
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid Choice.  Please enter a choice of 1 or 2.");
            continue;
        }

        if (sChoice == 3)
        {
            valid = false;
        }

        switch (sChoice)
        {
            case 1:
                searchByID();
                break;
            case 2:
                searchByName();
                break;
            default:
                Console.WriteLine("You've chosen to return to the main menu. ");
                break;
        }
    }
}

void searchByID()
{
    Console.WriteLine("Please enter employee ID: ");
    int emID;
    input = Console.ReadLine();
    try
    {
        emID = int.Parse(input ?? "");
        if (emID >= 1000 && emID <= 9999)
        {
            var filterID = employeeList.Where(e => e.idNumber == emID);

            foreach (Employee e in filterID)
            {
                Console.WriteLine(e.printEmployee());
            }
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Please enter a valid ID number.");
    }
}

void searchByName()
{
    Console.WriteLine("Please enter employee name: ");
    input = Console.ReadLine() ?? "";

    var filterName = employeeList.Where(e => e.name.StartsWith(input) || e.name.Contains($" {input}"));

    foreach (Employee e in filterName)
    {
        Console.WriteLine(e.printEmployee());
    }
}

void deleteEmployee()
{
    try
    {
        Console.WriteLine("Enter the ID # of the employee to delete: ");
        string? userInput = Console.ReadLine() ?? "";
        int userDelete = Convert.ToInt32(userInput);
        Console.WriteLine($"Employee # {userDelete} has been deleted from the database");

        var filterDel = employeeList.Where(e => e.idNumber == userDelete);

        foreach (Employee e in filterDel)
        {
            employeeList.Remove(e);
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Invalid entry. Please try again. ");
    }

}