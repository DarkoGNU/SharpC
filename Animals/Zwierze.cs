using static Tools;

abstract class Zwierze {
    static Random random = new Random();

    private static int maxId = 0;
    private int id;
    private int wiek;
    private double waga;
    protected bool samiec;
    protected double apetyt = 0.05; // Domyślny apetyt
    private string gatunek;
    private string gromada;

    public Zwierze(int wiek, double waga, string gatunek, string gromada) {
        maxId += 1;
        id = maxId;
        samiec = RandBool();

        this.wiek = wiek;
        this.waga = waga;
        this.gatunek = gatunek;
        this.gromada = gromada;
    }

    public int GetWiek() {
        return wiek;
    }

    public double GetWaga() {
        return waga;
    }

    public double Nakarm() {
        return waga * apetyt;
    }

    public string Opis() {
        return gatunek + ", " + Plec() + ", " + gromada + ".";
    }

    public string Plec() {
        return samiec ? "Samiec" : "Samica";
    }
}
