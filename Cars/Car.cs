public class Car: IComparable<Car> {
    public Guid ID { get; private set; }
    public string Color { get; set; }
    public string Brand { get; set; }
    public double MaxSpeed { get; set; }

    public Car(string Color, string Brand, double MaxSpeed)
    {
        this.ID = Guid.NewGuid();
        this.Color = Color; // a to z
        this.Brand = Brand; // a to z
        this.MaxSpeed = MaxSpeed; // sort descending
    }

    public override string ToString()
    {
        return string.Format("{0} {1}, top speed: {2:0.00} km/h (ID: {3})", Color, Brand, MaxSpeed, ID);
    }

    public int CompareTo(Car? compared)
    {
        if (Brand.CompareTo(compared.Brand) != 0) return Brand.CompareTo(compared.Brand);
        if (Color.CompareTo(compared.Color) != 0) return Color.CompareTo(compared.Color);
        return MaxSpeed.CompareTo(compared.MaxSpeed) * -1;
    }
}
