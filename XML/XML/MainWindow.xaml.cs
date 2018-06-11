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
        public Kolekcja collection;
        private XMLReader reader;
        private Gra selectedGame;

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
                listBox.ItemsSource = collection.Games;
                listBox.DisplayMemberPath = "Title";
                /*foreach(Gra game in collection.Games)
                {
                    ListBoxItem itm = new ListBoxItem();
                    itm.Content = game.Title;
                    listBox.Items.Add(itm);
                }*/
            }
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
                if (selectedGame != null)
                {
                    EditWindow win = new EditWindow(selectedGame, collection, this);
                    win.ShowDialog();
                }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string title = (listBox.SelectedItem as ListBoxItem).Content.ToString();
            //selectedGame = collection.Games.Find(x => x.Title == title);
            if (listBox.SelectedItem != null)
            {
                string title = (listBox.SelectedItem as Gra).Title;
                selectedGame = listBox.SelectedItem as Gra;
            }
        }

        public void UpdateCollection()
        {
            listBox.ItemsSource = null;
            listBox.Items.Clear();
            listBox.ItemsSource = collection.Games;
            listBox.DisplayMemberPath = "Title";
        }
    }
}
