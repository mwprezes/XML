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

namespace XML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Kolekcja collection;
        private XMLReader reader;

        public MainWindow()
        {
            collection = new Kolekcja();
            reader = new XMLReader();
            reader.Read("E:/Pobrane/zzSchool/XML/zad5/Repo/XML/zadanie5.xml", collection);
            InitializeComponent();
        }
    }
}
