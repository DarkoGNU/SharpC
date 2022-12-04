// https://github.com/gui-cs/Terminal.Gui
using Terminal.Gui;
using static Tools;

// Zdefiniuj okno Zoo
public class Zoo : Window {
    private List<Zwierze> zwierzeta;

	public Zoo ()
	{
		Title = "Aplikacja Zoo (Ctrl+Q aby wyjść)";
        zwierzeta = new List<Zwierze>();

        // Przycisk dodaj
		var przyciskDodaj = new Button () {
			Text = "Dodaj zwierzęta",
			IsDefault = true,
		};

        // Przycisk usuń
		var przyciskUsun = new Button () {
			Text = "Usuń zwierzęta",
            Y = Pos.Bottom(przyciskDodaj),
		};

        // Przycisk nakarm
		var przyciskNakarm = new Button () {
			Text = "Nakarm zwierzęta",
            Y = Pos.Bottom(przyciskUsun),
		};

        // Przycisk wypisz
		var przyciskWypisz = new Button () {
			Text = "Wypisz zwierzęta",
            Y = Pos.Bottom(przyciskNakarm),
		};

        // Przycisk wyjścia
		var przyciskWyjdz = new Button () {
			Text = "Wyjdź z programu",
			Y = Pos.Bottom(przyciskWypisz),
			X = Pos.Center (),
		};

        // Dodawanie zwierząt
        przyciskDodaj.Clicked += () =>
        {
            int oldSize = zwierzeta.Count();

            foreach (Type type in new List<Type>(){ typeof(Papuga), typeof(Pstrag), typeof(Slon), typeof(Waz) })
            {
                for (int i = 0; i <= RandomInt(0, 2); i++)
                {
                    Zwierze NoweZwierze = (Zwierze?) Activator.CreateInstance(type) ?? throw new System.Exception();
                    zwierzeta.Add(NoweZwierze);
                }
            }

            var newView = new TextField();
            Add(newView);
            for (int i = oldSize - 1; i < zwierzeta.Count(); i++) {
                newView.Add(new Label(Text = zwierzeta[i].Opis()));
            }
        };

        // Wyjście z programu
		przyciskWyjdz.Clicked += () => {
            Application.RequestStop();
		};


        // Dodaj elementy do okna
		Add (przyciskDodaj, przyciskUsun, przyciskNakarm, przyciskWypisz, przyciskWyjdz);
	}
}
