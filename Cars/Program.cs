List<Car> carList = new List<Car>{
    new Car("Red", "Toyota", 140.34),
    new Car("Blue", "Toyota", 150),
    new Car("Blue", "Toyota", 160),
    new Car("Blue", "Toyota", 170),
    new Car("Orange", "Toyota", 330),
    new Car("Green", "Toyota", 483),
    new Car("White", "Fiat", 110),
    new Car("Black", "Nissan", 160.73),
    new Car("Silver", "Opel", 165),
    new Car("Pink", "Ford", 190),
};

Console.WriteLine("\nCars unsorted: ");
carList.ForEach(car => Console.WriteLine(car));

carList.Sort();

Console.WriteLine("\nCars sorted: ");
carList.ForEach(car => Console.WriteLine(car));
