using PAckLibrarry;

{
    Person john = new Person()
    {
        Name = "John"
    };
    Person jane = new Person()
    {
        Name = "Jane"
    };
    Person sarah = new Person()
    {
        Name = "Sarah"
    };

    john.Marry(jane);

    john.OutputSpouses();
    jane.OutputSpouses();
    sarah.OutputSpouses();

    Person baby1 = john.ProcreateWith(jane);
    baby1.Name = "John II";
    Console.WriteLine($"{baby1.Name} was born on {baby1.Born}");

    Person baby2 = Person.Procreate(john, jane);
    baby2.Name = "John III";

    john.WriteChildrenToConsole();
    sarah.WriteChildrenToConsole();
    jane.WriteChildrenToConsole();

    string s1 = "Hello ";
    string s2 = "World";
    string s3 = s1 + s2;
    Console.WriteLine(s3);

    if (john + sarah)
    {
        Console.WriteLine($"{john.Name} and {sarah.Name} successfully got married.");
    }

    Person baby3 = john * sarah;
    baby3.Name = "John IV";

    Person baby4 = john * jane;
    baby4.Name = "John V";
    john.WriteChildrenToConsole();
    john.OutputSpouses();
    sarah.WriteChildrenToConsole();
    jane.WriteChildrenToConsole();

    // New scenarios
    Console.WriteLine("\nNew Scenarios:");

    Person alice = new Person() { Name = "Alice" };
    Person bob = new Person() { Name = "Bob" };
    alice.Marry(bob);

    Console.WriteLine($"Does the couple have kids? {alice.HasKids()}");

    Person charlie = new Person() { Name = "Charlie", Born = DateTimeOffset.Now.AddYears(-2) };
    alice.AdoptKid(charlie);

    Console.WriteLine($"Does the couple have kids now? {alice.HasKids()}");

    charlie.ShowParents();

    Console.WriteLine($"Is {charlie.Name} a step-child? {charlie.IsStepChild}");

    // Example of a step-child
    Person david = new Person() { Name = "David", Born = DateTimeOffset.Now.AddYears(-3) };
    Person eve = new Person() { Name = "Eve" };
    david.Parents.Add(alice);
    david.Parents.Add(eve);

    Console.WriteLine($"Is {david.Name} a step-child? {david.IsStepChild}");
    david.ShowParents();

    Console.Read();
}




