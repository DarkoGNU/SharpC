using static Tools;

class Papuga :  Zwierze {
    public Papuga() : base(RandomInt(5, 60), RandomDouble(80, 130), "Papuga", "ptak") {
        apetyt = 0.3;
    }
}
