# injector
Represents a simple implementation of DI (dependencies injector).

Using:
    // registering dependencies:
    Injector.Register(() => new CoffeeMachine()).AsSingleInstance();
    Injector.Register(() => new Developer(Injector.Resolve<CoffeeMachine>()));

    // resolving dependencies:
    var dev = Injector.Resolve<Developer>();
