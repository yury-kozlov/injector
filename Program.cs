namespace IOC
{
    class Program
    {
        static void Main(string[] args)
        {
            // registering dependencies:
            Injector.Register(() => new CoffeeMachine()).AsSingleInstance();
            Injector.Register(() => new Developer(Injector.Resolve<CoffeeMachine>()));

            // resolving dependencies:
            var dev = Injector.Resolve<Developer>();
        }

        public class Developer
        {
            public CoffeeMachine CoffeeMachine { get; set; }

            public Developer(CoffeeMachine coffee)
            {
                CoffeeMachine = coffee;
            }
        }

        public class CoffeeMachine
        {
        }
    }
}
