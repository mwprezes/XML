using Microsoft.Win32;
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
            InitializeComponent();
        }

        private void read_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            if (fileDialog.ShowDialog() == true)
            {
                string file = fileDialog.FileName;
                reader.Read(file, collection);
            }
        }
    }
}
