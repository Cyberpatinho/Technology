using Course.Interfaces;
namespace Course.Events
{

    class Balance
    {
        public event EventHandler<BalanceArgs> Movement;

        public int amount;

        public void OnMovement(char key)
        {
            Movement?.Invoke(this, new BalanceArgs {
                Key = key
            });
        }
    }

    public class BalanceArgs : EventArgs
    {
        public char Key { get; set; }
    }

    class PiggyBank : IChallenge
    {

        public void Solution()
        {

            Balance balance = new Balance();
            balance.Movement += (sender, eventArgs) => {
                switch (eventArgs.Key)
                {
                    case 'a':
                        Console.WriteLine("Adding $1 to the piggy bank :)");
                        balance.amount++;
                        break;
                    case 'r':
                        int newBalance = balance.amount - 1;
                        Console.WriteLine(newBalance > 0? "Removing $1 from the piggy bank :(" : "The piggy bank's balance is $0, it has no coins to remove.");
                        balance.amount = Math.Max(0, newBalance);
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
                
                Console.WriteLine($"The piggy bank's balance is ${balance.amount}.");
            };

            balance.Movement += (sender, EventArgs) => {
                if (balance.amount >= 500) 
                {
                    Console.WriteLine("Goal of $500 achieved. ");
                    System.Environment.Exit(0);
                }
            };

            bool done = false;
            do 
            {
                Console.WriteLine("\nPress 'a' to add $1 or 'r' to remove: ");
                char key = Console.ReadKey(true).KeyChar;
                if (key != 'a' && key != 'r') 
                {
                    Console.WriteLine("\nInvalid input: the piggy bank broke :(");
                    System.Environment.Exit(0);
                }

                balance.OnMovement(key);
                
            } while (!done);

        }


    }

}
