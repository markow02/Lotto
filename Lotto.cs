namespace Lotto
{
    public partial class Lotto : Form
    {
        static Random rnd = new Random();
        int licznikLos�w = 1;
        string result;
        int iloscSymulacji;
        private List<int> szczesliwaSzostka;

        public Lotto()
        {
            InitializeComponent();
            btnSzostka.Visible = false;
            DodajZakladke(null, null);
            Symulacja(iloscSymulacji);
            szczesliwaSzostka = GeneratorLotto();
        }

        private void DodajZakladke(object sender, EventArgs e)
        {
            if (tabLosy.TabPages.Count < 10)
            {
                string nazwaZak�adki = "Los" + " " + licznikLos�w++ + ".";
                TabPage nowaZakladka = new TabPage(nazwaZak�adki);
                int margines = 22;
                int szerokoscTextBoxa = 43;
                int szerokoscPanelu = 768 - (2 * margines);
                int calkowitaSzerokosc = szerokoscTextBoxa * 6;
                int odstep = (szerokoscPanelu - calkowitaSzerokosc) / (6 - 1);


                for (int i = 0; i < 6; i++)
                {
                    TextBox textBox = new TextBox();
                    textBox.Width = szerokoscTextBoxa;
                    textBox.Font = new Font(textBox.Font.FontFamily, 20);
                    textBox.Location = new Point(margines + i * (szerokoscTextBoxa + odstep), 10);
                    nowaZakladka.Controls.Add(textBox);
                }

                tabLosy.TabPages.Add(nowaZakladka);
                tabLosy.SelectedTab = nowaZakladka;
            }
            else
            {
                MessageBox.Show("Osi�gni�to maksymaln� ilo�� g�os�w w jednej grze", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void UsunZakladke()
        {
            if (tabLosy.TabPages.Count > 1)
            {
                tabLosy.TabPages.RemoveAt(tabLosy.TabPages.Count - 1);
                licznikLos�w--;
            }
            else
            {
                MessageBox.Show("Musisz posiada� chocia� jeden los.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private List<int> GeneratorLotto()
        {
            HashSet<int> unikalneLiczby = new HashSet<int>();
            while (unikalneLiczby.Count < 6)
            {
                int number = rnd.Next(1, 50); // Zakres 1-49
                unikalneLiczby.Add(number);
            }
            return unikalneLiczby.ToList();
        }

        private void Symulacja(int iloscSymulacji)
        {
            Dictionary<int, int> czestotliwosc = new Dictionary<int, int>();
            for (int i = 1; i <= 49; i++)
            {
                czestotliwosc[i] = 0;
            }

            for (int i = 0; i < iloscSymulacji; i++)
            {
                List<int> lottoNumbers = GeneratorLotto();
                foreach (int number in lottoNumbers)
                {
                    czestotliwosc[number]++;
                }
            }

            result = $"Cz�stotliwo�� wyst�powania liczb w {iloscSymulacji} losowaniach:\n\n";
            foreach (var kvp in czestotliwosc.OrderBy(kvp => kvp.Key))
            {
                result += $"{kvp.Key}: {kvp.Value}\n";
            }
        }

        private void btnDodajLos_Click(object sender, EventArgs e)
        {
            DodajZakladke(sender, e);
        }

        private void btnUsunLos_Click(object sender, EventArgs e)
        {
            UsunZakladke();
        }

        private void linkLabelZasady_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Utw�rz los, wype�niaj�c puste okienka liczbami z przedzia�u od 1 do 49. " +
                "W ramach tej samej gry mo�esz posiada� do 10 los�w, dodaj lub usu� sw�j los, u�ywaj�c przycisk�w pod panelem. " +
                "Gdy wszystkie pola zostan� prawid�owo uzupe�nione, sprawd� swoje losy, klikaj�c przycisk 'LOSUJ'." +
                "Ka�dy los zostanie sprawdzony, a wyniki zostan� wy�wietlone osobno dla ka�dej zak�adki. " +
                "Program poinformuje Ci� r�wnie�, kt�ry los mia� najwi�ksz� liczb� trafie�." +
                "\n\n'Szcz�liwa sz�stka' zmienia si� z ka�dym w��czeniem programu. Mo�na j� podejrze� po pierwszym losowaniu, klikaj�c przycisk 'Odkryj szcz�liw� sz�stk�'. " +
                "\n\nMo�esz r�wnie� przeprowadzi� symulacj� wielu losowa� klikaj�c odpowiedni przycisk",
                "Instrukcja", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void btnSymulacja_Click(object sender, EventArgs e)
        {
            string input = "10"; // Przyk�adowa warto��
            if (InputBox.Show("Liczba symulacji", "Podaj liczb� symulacji do wykonania:", ref input) == DialogResult.OK)
            {
                if (int.TryParse(input, out int liczbaSymulacji))
                {
                    Symulacja(liczbaSymulacji);
                    MessageBox.Show(result, "Symulacja", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    MessageBox.Show("Prosz� poda� prawid�ow� liczb�.", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public void btnLosuj_Click(object sender, EventArgs e)
        {
            int maxTrafien = 0;
            List<string> najlepszeLosy = new List<string>();

            foreach (TabPage zakladka in tabLosy.TabPages)
            {
                List<int> userNumbers = new List<int>();
                HashSet<int> uniqueNumbers = new HashSet<int>();

                foreach (Control control in zakladka.Controls)
                {
                    if (control is TextBox textBox)
                    {
                        if (int.TryParse(textBox.Text, out int number))
                        {
                            if (number < 1 || number > 49)
                            {
                                MessageBox.Show("Wszystkie liczby musz� by� w zakresie od 1 do 49.", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (!uniqueNumbers.Add(number))
                            {
                                MessageBox.Show("Ka�da liczba na losie musi by� unikalna.", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            userNumbers.Add(number);
                        }
                        else
                        {
                            MessageBox.Show("Wszystkie pola musz� by� uzupe�nione liczbami.", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }


                int trafienia = userNumbers.Intersect(szczesliwaSzostka).Count();


                string zakladkaName = zakladka.Text;
                string informacja = $"Zak�adka {zakladkaName}: {trafienia} trafie�.";
                MessageBox.Show(informacja, "Wynik losowania", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (trafienia > maxTrafien)
                {
                    maxTrafien = trafienia;
                    najlepszeLosy.Clear();
                    najlepszeLosy.Add(zakladkaName);
                }
                else if (trafienia == maxTrafien)
                {
                    najlepszeLosy.Add(zakladkaName);
                }
            }

            string informacjaKoncowa;
            if (maxTrafien > 0)
            {
                informacjaKoncowa = $"Najwi�cej trafie� ({maxTrafien}) mia�y losy: {string.Join(", ", najlepszeLosy)}.";
            }
            else
            {
                informacjaKoncowa = "�aden los nie trafi� �adnej liczby.";
            }
            MessageBox.Show(informacjaKoncowa, "Najlepszy los", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnSzostka.Visible = true;
        }



        private void btnSzostka_Click(object sender, EventArgs e)
        {
            string informacja = string.Join(", ", szczesliwaSzostka);
            MessageBox.Show(informacja, "Szcz�liwa sz�stka", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
       
    }
}
