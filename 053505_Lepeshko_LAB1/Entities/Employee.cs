 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Employee
{
    public Employee(string name, string lastName, MyCustomCollection<TypeOfWork> workList)
    {
        this.name = name;
        this.lastName = lastName;
        this.workList = workList;
    }

    public override string ToString() => name + lastName + workList.ToString();

    public int CountSalary()
    {
        int counter = 0;
        for (int i = 0; i < workList.Count; i++)
        {
            counter += workList[i].reward;
        }
        return counter;
    }

    public string name {get; set;}

    public string lastName { get; set;}

    public MyCustomCollection<TypeOfWork> workList = new MyCustomCollection<TypeOfWork>();
}
