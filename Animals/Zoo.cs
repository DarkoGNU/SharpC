// https://github.com/gui-cs/Terminal.Gui
using Terminal.Gui;
using static Tools;

// Zdefiniuj okno Zoo
public class Zoo : Window
{
    private List<Zwierze> zwierzeta;

    public Zoo()
    {
        Title = "Aplikacja Zoo (Ctrl+Q aby wyjść)";
        zwierzeta = new List<Zwierze>();

        // Przycisk dodaj
        var przyciskDodaj = new Button()
        {
            Text = "Dodaj zwierzęta",
            IsDefault = true,
        };

        // Przycisk usuń
        var przyciskUsun = new Button()
        {
            Text = "Usuń zwierzęta",
            Y = Pos.Bottom(przyciskDodaj),
        };

        // Przycisk nakarm
        var przyciskNakarm = new Button()
        {
            Text = "Nakarm zwierzęta",
            Y = Pos.Bottom(przyciskUsun),
        };

        // Przycisk wypisz
        var przyciskWypisz = new Button()
        {
            Text = "Wypisz zwierzęta",
            Y = Pos.Bottom(przyciskNakarm),
        };

        // Przycisk wyjścia
        var przyciskWyjdz = new Button()
        {
            Text = "Wyjdź z programu",
            Y = Pos.Bottom(przyciskWypisz),
            X = Pos.Center(),
        };

        // Dodawanie zwierząt
        przyciskDodaj.Clicked += () =>
        {
            var noweZwierzeta = new List<Zwierze>();

            foreach (Type type in new List<Type>() { typeof(Papuga), typeof(Pstrag), typeof(Slon), typeof(Waz) })
            {
                for (int i = 0; i <= RandomInt(0, 2); i++)
                {
                    Zwierze NoweZwierze = (Zwierze?)Activator.CreateInstance(type) ?? throw new System.Exception();
                    zwierzeta.Add(NoweZwierze);
                    noweZwierzeta.Add(NoweZwierze);
                }
            }

            Application.Run(new AnimalList("Dodane zwierzęta (ESC lub Ctrl+Q aby wyjść))", noweZwierzeta));
        };

        przyciskUsun.Clicked += () =>
        {
            Application.Run(new AnimalList("Usuń wybrane zwierzęta (ESC lub Ctrl+Q, aby wyjść bez usuwania)", zwierzeta, true));
        };

        przyciskNakarm.Clicked += () =>
        {
            double zjedzono = 0;
            foreach (Zwierze zwierze in zwierzeta)
            {
                zjedzono += zwierze.Nakarm();
            }

            string info = string.Format("Ilość pokarmu: {0:0.###} kg", zjedzono);

            Application.Run(new SimpleInfo("Ilość pokarmu potrzebna do nakarmienia zoo (ESC lub Ctrl+Q aby wyjść)", info));
        };

        przyciskWypisz.Clicked += () =>
        {
            Application.Run(new AnimalList("Wszystkie zwierzęta (ESC lub Ctrl+Q aby wyjść))", zwierzeta));
        };

        // Wyjście z programu
        przyciskWyjdz.Clicked += () =>
        {
            Application.RequestStop();
        };

        // Dodaj elementy do okna
        Add(przyciskDodaj, przyciskUsun, przyciskNakarm, przyciskWypisz, przyciskWyjdz);
    }
}

public class SimpleInfo : Dialog
{
    public SimpleInfo(string tytul, string info)
    {
        Title = tytul;

        var infoLabel = new Label()
        {
            Text = '\n' + info,
        };

        // Przycisk wyjścia
        var przyciskWyjdz = new Button()
        {
            Text = "OK",
            Y = Pos.Bottom(infoLabel),
            X = Pos.Center(),
        };

        przyciskWyjdz.Clicked += () =>
        {
            Application.RequestStop();
        };

        Add(infoLabel, przyciskWyjdz);
    }
}

public class AnimalList : Dialog
{
    List<Zwierze> zwierzeta;
    bool deleteOnClick;

    public AnimalList(string tytul, List<Zwierze> listaZwierzat, bool deleteOnClick = false)
    { // , List<Zwierzeta> zwierzeta
        Title = tytul;
        zwierzeta = listaZwierzat;
        this.deleteOnClick = deleteOnClick;

        var lista = new ListView(zwierzeta)
        {
            Height = Dim.Fill(1),
            Width = Dim.Fill(),
            AllowsMarking = deleteOnClick ? true : false,
        };

        // Przycisk wyjścia
        var przyciskWyjdz = new Button()
        {
            Text = deleteOnClick ? "Usuń wybrane zwierzęta" : "Zamknij dialog",
            Y = Pos.Bottom(lista),
            X = Pos.Center(),
        };

        // Wyjście z programu
        przyciskWyjdz.Clicked += () =>
        {
            List<int> toDelete = new List<int>();

            // Wewnętrzna lista ListView powinna mieć taką samą długość, jak "zwierzeta"
            if (zwierzeta.Count != lista.Source.Count)
            {
                throw new System.Exception();
            }

            if (deleteOnClick)
            {
                // Iteruj od końca
                for (int i = zwierzeta.Count - 1; i >= 0; i--)
                {
                    if (lista.Source.IsMarked(i))
                    {
                        toDelete.Add(i);
                    }
                }

                foreach (int index in toDelete)
                {
                    zwierzeta.RemoveAt(index);
                }
            }

            Application.RequestStop();
        };

        Add(lista, przyciskWyjdz);
    }
}
