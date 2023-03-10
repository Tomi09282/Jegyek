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
using System.Collections.ObjectModel;

namespace WpfApp7
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

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sr = new StreamWriter("naplo.csv",append:true, encoding:Encoding.UTF8);

            if (txtNev.Text=="" || dpDate.Text=="")
                MessageBox.Show("Nem írtál be Nevet/Dátumot");
            else
                sr.WriteLine($"{txtNev.Text};{cbTargy.Text};{dpDate.Text};{sliJegy.Value}");

            sr.Close();
        }


        List<Osztalyzat> Jegyek = new List<Osztalyzat>();

        private void btnBetolt_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader("naplo.csv", encoding:Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(";");
                Osztalyzat ujJegy = new Osztalyzat(sor[0], sor[1], sor[2], int.Parse(sor[3]));
                Jegyek.Add(ujJegy);
            }
            sr.Close();
            dgAdatok.ItemsSource = Jegyek;

        }

        private void sliJegy_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }
    }
}
