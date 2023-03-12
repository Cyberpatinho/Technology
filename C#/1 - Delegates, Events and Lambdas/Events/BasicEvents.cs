using Course.Interfaces;
namespace Course.Events
{

    public delegate void myEventHandler(string value);

    public class EventPublisher
    {
        private string theVal;
        public event myEventHandler onValueChanged;

        public string Val
        {
            set {
                theVal = value;
                onValueChanged(theVal);
            }
        }
    }

    public class BasicEvents : ICourse
    {

        public void Sandbox()
        {
            EventPublisher obj = new EventPublisher();
            obj.onValueChanged += new myEventHandler(obj_valueChanged);
            obj.onValueChanged += delegate (string val) 
            {
                Console.WriteLine($"The value changed to {val}");
            };

            string str;
            do {
                Console.WriteLine("Enter a value: ");
                str = Console.ReadLine();
                if (!str.Equals("exit")) {
                    obj.Val = str;
                }
            } while (!str.Equals("exit"));
            Console.WriteLine("Goodbye!");

        }

        private void obj_valueChanged(string value)
        {
            Console.WriteLine("The value changed to {0}", value);
        }

    }
}
