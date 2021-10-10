using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TypeOfWork
{
    public TypeOfWork(string title,int reward)
    {
        this.title = title;
        this.reward = reward;
    }

    public override string ToString() => "\nTitle: " + title +  "\nReward: " + reward.ToString();

    public string title {get; set;}

    public int reward { get; set; }
}
