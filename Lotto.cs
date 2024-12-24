namespace Lotto
{
    public partial class Lotto : Form
    {
        static Random rnd = new Random();
        int licznikLosów = 1;
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
                string nazwaZak³adki = "Los" + " " + licznikLosów++ + ".";
                TabPage nowaZakladka = new TabPage(nazwaZak³adki);
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
                MessageBox.Show("Osi¹gniêto maksymaln¹ iloœæ g³osów w jednej grze", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void UsunZakladke()
        {
            if (tabLosy.TabPages.Count > 1)
            {
                tabLosy.TabPages.RemoveAt(tabLosy.TabPages.Count - 1);
                licznikLosów--;
            }
            else
            {
                MessageBox.Show("Musisz posiadaæ chocia¿ jeden los.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            result = $"Czêstotliwoœæ wystêpowania liczb w {iloscSymulacji} losowaniach:\n\n";
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
            MessageBox.Show("Utwórz los, wype³niaj¹c puste okienka liczbami z przedzia³u od 1 do 49. " +
                "W ramach tej samej gry mo¿esz posiadaæ do 10 losów, dodaj lub usuñ swój los, u¿ywaj¹c przycisków pod panelem. " +
                "Gdy wszystkie pola zostan¹ prawid³owo uzupe³nione, sprawdŸ swoje losy, klikaj¹c przycisk 'LOSUJ'." +
                "Ka¿dy los zostanie sprawdzony, a wyniki zostan¹ wyœwietlone osobno dla ka¿dej zak³adki. " +
                "Program poinformuje Ciê równie¿, który los mia³ najwiêksz¹ liczbê trafieñ." +
                "\n\n'Szczêœliwa szóstka' zmienia siê z ka¿dym w³¹czeniem programu. Mo¿na j¹ podejrzeæ po pierwszym losowaniu, klikaj¹c przycisk 'Odkryj szczêœliw¹ szóstkê'. " +
                "\n\nMo¿esz równie¿ przeprowadziæ symulacjê wielu losowañ klikaj¹c odpowiedni przycisk",
                "Instrukcja", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void btnSymulacja_Click(object sender, EventArgs e)
        {
            string input = "10"; // Przyk³adowa wartoœæ
            if (InputBox.Show("Liczba symulacji", "Podaj liczbê symulacji do wykonania:", ref input) == DialogResult.OK)
            {
                if (int.TryParse(input, out int liczbaSymulacji))
                {
                    Symulacja(liczbaSymulacji);
                    MessageBox.Show(result, "Symulacja", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    MessageBox.Show("Proszê podaæ prawid³ow¹ liczbê.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                MessageBox.Show("Wszystkie liczby musz¹ byæ w zakresie od 1 do 49.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (!uniqueNumbers.Add(number))
                            {
                                MessageBox.Show("Ka¿da liczba na losie musi byæ unikalna.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            userNumbers.Add(number);
                        }
                        else
                        {
                            MessageBox.Show("Wszystkie pola musz¹ byæ uzupe³nione liczbami.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }


                int trafienia = userNumbers.Intersect(szczesliwaSzostka).Count();


                string zakladkaName = zakladka.Text;
                string informacja = $"Zak³adka {zakladkaName}: {trafienia} trafieñ.";
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
                informacjaKoncowa = $"Najwiêcej trafieñ ({maxTrafien}) mia³y losy: {string.Join(", ", najlepszeLosy)}.";
            }
            else
            {
                informacjaKoncowa = "¯aden los nie trafi³ ¿adnej liczby.";
            }
            MessageBox.Show(informacjaKoncowa, "Najlepszy los", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnSzostka.Visible = true;
        }



        private void btnSzostka_Click(object sender, EventArgs e)
        {
            string informacja = string.Join(", ", szczesliwaSzostka);
            MessageBox.Show(informacja, "Szczêœliwa szóstka", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
       
    }
}
