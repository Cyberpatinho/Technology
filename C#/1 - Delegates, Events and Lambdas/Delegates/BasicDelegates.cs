using System.Text;
using Course.Interfaces;
namespace Course.Delegates
{

    public static class F
    {
        public static string Func1(int arg1, int arg2) 
        {
            return (arg1 + arg2).ToString();
        }

        public static string Func2(int arg1, int arg2)
        {
            return (arg1 * arg2).ToString();
        }

        public static string Func3(int arg1, int arg2)
        {
            return "no use for parameters.";
        }
    }

    public class NotStatic
    {
        public string Method1(int arg1, int arg2) 
        {
            return arg1.ToString() + arg2.ToString();
        }
    }

    public class BasicDelegates : ICourse
    {
        public delegate string MyDelegate(int arg1, int arg2);

        public void Sandbox()
        {

            MyDelegate f1 = F.Func1;
            MyDelegate f2 = F.Func2;
            MyDelegate f3 = F.Func3;

            Console.WriteLine($"Result for f1: {f1(2, 5)}");
            Console.WriteLine($"Result for f2: {f2(2, 5)}");
            Console.WriteLine($"Result for f3: {f3(2, 5)}");

            f2 = F.Func3;
            Console.WriteLine($"Result for f2: {f2(2, 5)}");

            NotStatic ns = new NotStatic();
            MyDelegate f4 = ns.Method1;

            Console.WriteLine($"Result for f4: {f4(2, 5)}");

            MyDelegate f5 = delegate (int arg1, int arg2) {

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < arg1; i++) sb.Append(arg1.ToString());
                for (int i = 0; i < arg2; i++) sb.Append(arg2.ToString());
                return sb.ToString();
            };

            Console.WriteLine($"Result for anonymous f5 delegate: {f5(2, 5)}");

            MyDelegate composable = f1 + f2 + f3;
            Console.WriteLine($"The result of a chain of delegates is the return of the last one: {composable(2, 5)}");


        }

    }

}