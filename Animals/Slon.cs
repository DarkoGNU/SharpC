using static Tools;

class Slon :  Zwierze {
    public Slon() : base(RandomInt(10, 50), RandomDouble(3000, 6000), "Słoń", "ssak") {
        apetyt = 0.10;
    }
}
