using Course.Interfaces;
using Course.Delegates;
using Course.Events;
namespace Course
{
    class Program
    {
        public static void Main(string[] args)
        {
            //ICourse bd = new BasicDelegates();
            //bd.Sandbox();

            //IChallenge shipping = new Shipping();
            //shipping.Solution();

            //ICourse be = new BasicEvents();
            //be.Sandbox();

            IChallenge pb = new PiggyBank();
            pb.Solution();

        }
    }

}
