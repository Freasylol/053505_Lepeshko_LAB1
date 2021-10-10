using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

class Program
{
    static bool CheckPositiveInt(string str)
    {
        Regex regExp = new Regex(@"[0-9]");
        MatchCollection match = regExp.Matches(str);
        return (match.Count == str.Length) && (str[0] != '-' || str[0] != '0') && (str.Length != 0);
    }

    static TypeOfWork TypeOfWorkInit()
    {
        int reward = 0;
        Console.WriteLine("Enter title of work");
        string title = Console.ReadLine();
        Console.WriteLine("Enter reward for work");
        string rewardStr = Console.ReadLine();
        if (CheckPositiveInt(rewardStr))
        {
            reward = int.Parse(rewardStr);
        }
        Console.WriteLine("Type of work is succesfully initialized");
        return new TypeOfWork(title, reward);
    }
    
    static Employee EmployeeInit(MyCustomCollection<TypeOfWork> workCollection)
    {
        MyCustomCollection<TypeOfWork> workList = new MyCustomCollection<TypeOfWork>();
        Console.WriteLine("Enter name of employee");
        string name = Console.ReadLine();
        Console.WriteLine("Enter lastName of employee");
        string lastName = Console.ReadLine();
        Console.WriteLine("Enter the type of work performed by that employee(type n to stop typing)");
        workCollection.Print();
        string workChoice = Console.ReadLine();
        while (workChoice != "n")
        {
            for (int i = 0; i < workCollection.Count; i++)
            {
                if (workChoice == workCollection[i].title)
                {
                    workList.Add(workCollection[i]);
                }
            }
            workChoice = Console.ReadLine();
        }
       
        return new Employee(name, lastName, workList);
    }

    static void ChooseAction()
    {
        MyCustomCollection<TypeOfWork> workCollection = new MyCustomCollection<TypeOfWork>();
        MyCustomCollection<Employee> employeeCollection = new MyCustomCollection<Employee>();
        Console.WriteLine("Enter num of action you want to do(0 - exit, 1 - Enter info about different types of work, 2 - Enter info about employees and completed work by themselves, 3 - Enter last name of employee to get info about his salary, 4 - Get info about salarys for all workers");
        string choice = Console.ReadLine();
        while (choice != "0")
        {
            switch (choice)
            {
                case "0":
                    break;
                case "1":
                    TypeOfWork workType = TypeOfWorkInit();
                    workCollection.Add(workType);
                    workCollection.Print();
                    break;
                case "2":
                    if (workCollection.Count != 0)
                    {
                        Employee employee = EmployeeInit(workCollection);
                        employeeCollection.Add(employee);
                    }
                    else
                    {
                        Console.WriteLine("You can't initialize worker with empty workCollection");
                    }
                    break;
                case "3":
                    if (employeeCollection.Count != 0)
                    {
                        Console.WriteLine("Enter last name of employee to get his salary");
                        string lastName = Console.ReadLine();
                        for (int i = 0; i < employeeCollection.Count; i++)
                        {
                            if (employeeCollection[i].lastName == lastName)
                            {
                                Console.WriteLine("Salary of " + lastName + " is " + employeeCollection[i].CountSalary());
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("You can't get salary of employee by last name when employeeCollection is empty");
                    }
                    break;
                case "4":
                    for (int i = 0; i < employeeCollection.Count; i++)
                        Console.WriteLine("Salary of " + employeeCollection[i].lastName + " is " + employeeCollection[i].CountSalary());
                    break;
                default:
                    Console.WriteLine("You entered wrong num of action");
                    break;
            }
            Console.WriteLine("Enter num of action you want to do(0-exit, 1 - Enter info about different types of work, 2 - Enter info about employees and completed work by themselves, 3 - Enter last name of employee to get info about his salary, 4 - Get info about salarys for all workers");
            choice = Console.ReadLine();
        }
    }

    static void Main(string[] args)
    {

        ChooseAction();
        Console.ReadLine();
    }
}
