using System;
namespace ADOPM3_02_18a;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Factory!");

        var fm = new csFactoryMontor();
        var fa = new csFactoryAlarm(fm);
        var sm = new csServiceMan(fm);

        bool _ok = fm.CheckStatus();

        Console.WriteLine("Factory check complete");
        if (_ok)
        {
            Console.WriteLine("All ok!");
        }
        else
        {
            Console.WriteLine("There was a problem!");
        }

        
    }
}

