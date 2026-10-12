using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rendeles(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!IsNameValid())
                {
                    return;
                }

                int age = Convert.ToInt32(Age.Text);
                if (age < 18)
                {
                    MessageBox.Show("Az életkor nem lehet 18-nél kisebb!");
                    Age.Focus();
                    return;
                }
                if (age >= 100)
                {
                    MessageBox.Show("Az életkor nem lehet 100-nál nagyobb!");
                    Age.Focus();
                    return;
                }


                if (!IsLicenseValid())
                {
                    return;
                }

                if (!IsCarValid())
                {
                    return;
                }
                if (!IsDayValid())
                {
                    return;
                }
                if (!IsPaymentValid())
                {
                    return;
                }
                if (!IsTermsValid())
                {
                    return;
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Az életkor mezőbe számot kell írni!");
                Age.Focus();
                return;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Az életkor mezőbe túl nagy számot írtál!");
                Age.Focus();
                return;
            }

            SikeresRendeles();
        }

        private bool IsNameValid()
        {
            string name = Name.Text;

            if (name == null || name == "")
            {
                MessageBox.Show("A név nem lehet üres!");
                Name.Focus();
                return false;
            }
            if (name.Length < 3)
            {
                MessageBox.Show("A névnek legalább 3 karakter hosszúnak kell lennie!");
                Name.Focus();
                return false;
            }
            return true;
        }

        private bool IsLicenseValid()
        {
            string license = License.Text;

            if (license == null || license == "")
            {
                MessageBox.Show("A jogosítvány száma nem lehet üres!");
                License.Focus();
                return false;
            }
            if (license.Length < 6)
            {
                MessageBox.Show("A jogosítványnak legalább 6 karakter hosszúnak kell lennie!");
                License.Focus();
                return false;
            }
            return true;
        }

        private bool IsCarValid()
        {
            if (Car.SelectedItem == null )
            {
                MessageBox.Show("A jármű kiválasztása kötelező!");
                Car.Focus();
                return false;
            }
            return true;
        }

        private bool IsDayValid()
        {

            try
            {
                int days = Convert.ToInt32(Day.Text);
                if (days < 1 || days > 30)
                {
                    MessageBox.Show("A bérlés időtartama 1 és 30 nap között legyen!");
                    return false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("A bérlés időtartama mezőbe számot kell írni!");
                Day.Focus();
                return false;
            }
            catch (OverflowException)
            {
                MessageBox.Show("A bérlés időtartama mezőbe túl nagy számot írtál!");
                Day.Focus();
                return false;
            }


            return true;
        }

        private bool IsTermsValid()
        {
            if (Terms.IsChecked == false)
            {
                MessageBox.Show("El kell fogadni a feltételeket!");
                Terms.Focus();
                return false;
            }
            return true;
        }

        private bool IsPaymentValid()
        {
            if (Pay1.IsChecked==false & Pay2.IsChecked==false)
            {
                MessageBox.Show("A fizetési mód kiválasztása kötelező!");
                Pay1.Focus();
                return false;
            }
            return true;
        }

        private int Pricecalc()
        {
            int price = 0;
            int days = Convert.ToInt32(Day.Text);
            if (Car.SelectedIndex == 0)
            {
                price += 12000 * days;
            }
            else if (Car.SelectedIndex == 1)
            {
                price += 18000 * days;
            }
            else if (Car.SelectedIndex == 2)
            {
                price += 30000 * days;
            }
            else if (Car.SelectedIndex == 3)
            {
                price += 35000 * days;
            }

            if (Ins1.IsChecked == true)
            {

            }
            else if (Ins2.IsChecked == true)
            {
                price += 3000 * days;
            }
            else if (Ins3.IsChecked == true)
            {
                price += 6000 * days;
            }

            if (Extra1.IsChecked == true)
            {
                price += 1000 * days;
            }
            if (Extra2.IsChecked == true)
            {
                price += 1500 * days;
            }
            if (Extra3.IsChecked == true)
            {
                price += 2500 * days;
            }
            if (Extra4.IsChecked == true)
            {
                price += 5000;
            }
            return price;
        }

        private void SikeresRendeles()
        {
            string nev = Name.Text;
            string auto = "";

            if (Car.SelectedIndex == 0)
            {
                auto = "Suzuki";

            }
            else if (Car.SelectedIndex == 1)
            {
                auto = "Toyota Corolla";
            }
            else if (Car.SelectedIndex == 2)
            {
                auto = "BMW 3";

            }
            else if (Car.SelectedIndex == 3)
            {
                auto = "Tesla Model 3";

            }
            int idotartam = Convert.ToInt32(Day.Text);
            string biztositas = "";

            if(Ins1.IsChecked == true)
            {
                biztositas = "Alap";
            }
            else if (Ins2.IsChecked == true)
            {
                biztositas = "Extra";
            }
            else if (Ins3.IsChecked == true)
            {
                biztositas = "Teljes";
            }

            string extrak= "";
            
            if(Extra1.IsChecked == true)
            {
                extrak += "GPS, ";
            }
            if (Extra2.IsChecked == true)
            {
                extrak += "Gyerekülés, ";
            }
            if (Extra3.IsChecked == true)
            {
                extrak += "Extra sofőr, ";
            }
            if (Extra4.IsChecked == true)
            {
                extrak += "Autópálya matrica ";
            }

            string fizetes = "";
            if (Pay1.IsChecked == true)
            {
                fizetes = "Készpénz";
            }
            else if (Pay2.IsChecked == true)
            {
                fizetes = "Bankkártya";
            }

            int fizetendo = Pricecalc();

            MessageBox.Show($"Sikeres foglalás!\n\nÜgyfél: {nev}\nAutó: {auto}\nIdőtartam: {idotartam} nap\nBiztosítás: {biztositas}\nExtrák: {extrak}\nFizetés módja: {fizetes}\nFizetendő: {fizetendo} Ft.");
        }
    }
    
}