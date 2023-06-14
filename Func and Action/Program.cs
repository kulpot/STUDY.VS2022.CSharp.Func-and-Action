using System;
using System.Collections.Generic;

//ref link:https://www.youtube.com/watch?v=SuwUZjQdUHQ&list=PLAE7FECFFFCBE1A54&index=7
//(Interview Question)Func can have a return argument while Action always returns void

//delegate T MeDelegate<T>(); //Generic type Delegate

class MainClass
{
    static void Main()
    {
        //Delegate -> MulticastDelegate -> MeDelegate
        //MeDelegate<int> d = ReturnFive;
        Func<int> d = ReturnFive;
        
        d += ReturnTen;
        d += Return22;
        Func<int, string, bool> f = TakeAnIntAndStringAndReturnABool;
        Action<string> a = TakeAStringAndReturnVoid;
        int value = d();
        
        foreach (int i in GetAllReturnValues(d))
            Console.WriteLine(i);
    }
    static void TakeAStringAndReturnVoid(string s)
    {

    }
    static bool TakeAnIntAndStringAndReturnABool(int i, string s)
    {
        return false;
    }
    static IEnumerable<TArg> GetAllReturnValues<TArg>(Func<TArg> d)
    {
        foreach (Func<TArg> del in d.GetInvocationList())
            yield return del();
    }
    static int ReturnFive() { return 5; }
    static int ReturnTen() { return 10; }
    static int Return22() { return 22; }
}