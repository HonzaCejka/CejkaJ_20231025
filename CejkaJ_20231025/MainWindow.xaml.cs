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

namespace CejkaJ_20231025
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool Shape { get; set; }
        public MainWindow()
        {
            InitializeComponent();            
            checkshape();
        }
        //ukol 2
        public void checkshape()
        {
            if (cb.SelectedIndex == 0)
            {
                thirdSite.Visibility = Visibility.Visible;
                thirdSiteName.Visibility = Visibility.Visible;
                digit.Visibility = Visibility.Visible;
                Shape = true;
            }
            else
            {
                thirdSiteName.Visibility = Visibility.Collapsed;
                thirdSite.Visibility = Visibility.Collapsed;
                digit.Visibility = Visibility.Collapsed;
                Shape = false;
            }
        }
        public double calc(bool shape)
        {
            double vysledek = 0;
            double a = double.Parse(firstSite.Text);
            double b = double.Parse(secondSite.Text);            
            if (shape == true)
            {
                double c = double.Parse(thirdSite.Text);
                double meziobsah = (a + b+c)/2.0;
                double mezivysledek = meziobsah * (meziobsah-a) * (meziobsah-b) * (meziobsah-c);
                vysledek = Math.Sqrt(mezivysledek);
                vysledek = Math.Round(vysledek, 2);
                return vysledek;
            }
            else
            {
                vysledek = a * b;
                return vysledek;
            }
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            checkshape();
        }

        private void CalcBtn_Click(object sender, RoutedEventArgs e)
        {            
            if (Shape == true)
            {
                result.Text = "Obsah Trojuhelniku je "+ calc(Shape).ToString() + " cm ctverecnich";
            }
            else
            {
                result.Text = "Obsah Obdelniku je " + calc(Shape).ToString() + " cm ctverecnich";
            }
        }

        //ukol 2
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int x = int.Parse(X.Text);
            int y = int.Parse(Y.Text);
            int n = int.Parse(N.Text);
            generate(x,y,n-1);
        }

        public void generate(int x,int y,int n)
        {
            VysledekGrid.Children.Clear();
            
            for (int i = 0; i < x; i++)
            {
                
                VysledekGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(25)});                           
                for (int j = 0; j < y; j++)
                {
                    if (j==n||i==n)
                    {
                        Rectangle mainrec = new Rectangle();
                        mainrec.Fill = Brushes.Green;
                        mainrec.Stroke = Brushes.Black;
                        VysledekGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(25) });
                        Grid.SetRow(mainrec, i);
                        Grid.SetColumn(mainrec, j);
                        VysledekGrid.Children.Add(mainrec);
                    }
                    else
                    {
                        Rectangle mainrec = new Rectangle();
                        mainrec.Fill = Brushes.White;
                        mainrec.Stroke = Brushes.Black;
                        VysledekGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(25) });
                        Grid.SetRow(mainrec, i);
                        Grid.SetColumn(mainrec, j);
                        VysledekGrid.Children.Add(mainrec);
                    }
                }
            }
            

        }        

    }
}
