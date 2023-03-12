using Course.Interfaces;
namespace Course.Delegates
{
    public class Shipping : IChallenge
    {

        public delegate decimal ShippingFee(decimal price);
        
        private List<ShippingFee> feeFunctions;

        public Shipping()
        {
            feeFunctions = new List<ShippingFee>()
            {
                (decimal price) => {
                    decimal total = price * new decimal(0.25);
                    return total;
                },
                (decimal price) => {
                    decimal total = price * new decimal(0.12) + 25;  
                    return total;
                },
                (decimal price) => {
                    decimal total = price * new decimal(0.08);
                    return total;
                },
                (decimal price) => {
                    decimal total = price * new decimal(0.04) + 25;
                    return total;
                }
            };
        }

        public void Solution()
        {
            bool done = false;
            do
            {
                int zone = GetInput<int>("Enter the shipment zone", Convert.ToInt32);
                decimal price = GetInput<decimal>("Enter the item price", Convert.ToDecimal);
                
                try
                {
                    ShippingFee f = feeFunctions[zone - 1];
                    Console.WriteLine($"Shipping fee is {f(price)}\n\n");
                }
                catch
                {
                    Console.WriteLine($"Zone {zone} is not registered.\n\n");
                }

            } while (!done);
        }


        private T GetInput<T>(string msg, Func<string, T> convert)
        {
            T ret = default;
            bool ok = false;

            do
            {
                Console.WriteLine($"{msg}. Type 'exit' to end:");
                string input = Console.ReadLine();

                if (input == "exit")
                {
                    System.Environment.Exit(0);
                }

                try
                {
                    ret = convert(input);
                    ok = true;
                }
                catch
                {
                    Console.WriteLine("Invalid input\n\n");
                }

            } while (!ok);

            return ret;
        }

    }

}