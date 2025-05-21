using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace WPFvarosok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Varos> varosok=new List<Varos>();
        public MainWindow()
        {
            InitializeComponent();
            Fajlbeolvas();
        }

        private void lb_varosok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string kivalaszt = lb_varosok.SelectedItem.ToString();
            foreach (var item in varosok)
            {
                if (item.Varosnev==kivalaszt)
                {
                    tbl_nev.Text = $"Város: {item.Varosnev}";
                    tbl_jaras.Text = $"Járás: {item.Jaras}";
                    tbl_kisterseg.Text = $"Kistérség: {item.Kisterseg}";
                    tbl_nepesseg.Text = $"Népesség: {item.Nepesseg} fő";
                    tbl_terulet.Text = $"Terület: {item.Terulet} n.km.";
                }
            }
        }
        private void Fajlbeolvas()
        {
            using (StreamReader olvas = new StreamReader("varosok.txt"))
            {
                olvas.ReadLine();
                while (!olvas.EndOfStream)
                {
                    string[] sor = olvas.ReadLine().Split(',');
                    string vnev=sor[1].Substring(1,sor[1].Length-2);
                    string jaras=sor[2].Substring(1,sor[2].Length-2);
                    string kisterseg=sor[3].Substring(1,sor[3].Length-2);
                    Varos egyVaros = new Varos(sor[0], vnev, jaras, kisterseg, sor[4], sor[5]);
                    varosok.Add(egyVaros);
                    
                    lb_varosok.Items.Add(vnev);
                }
            }
        }

        private void btn_kereses_Click(object sender, RoutedEventArgs e)
        {
            List<string> keresetVarosok = new List<string>();
            string keres=tbx_kereses.Text;
            int szamlal = 0;
            foreach (var item in varosok)
            {
                if (item.Varosnev.ToLower().Contains(keres.ToLower()))
                {
                    keresetVarosok.Add(item.Varosnev);

                }
                else
                {
                    szamlal++;
                }

            }
            if (szamlal==varosok.Count)
            {
                tbx_kereses.Clear();
                MessageBox.Show("Nincs a keresésének megfelelő elem","Baj van főnök",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            if (tbx_kereses.Text!="")
            {
                lb_varosok.Items.Clear();
                lb_varosok.ItemsSource = keresetVarosok;
                tbx_kereses.Clear();
            }
            
        }
    }
}
