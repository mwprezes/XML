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
        private XMLWriter writer;
        private XSLTransformation transform;
        private Gra selectedGame;

        public MainWindow()
        {
            collection = new Kolekcja();
            reader = new XMLReader();
            writer = new XMLWriter();
            transform = new XSLTransformation();
            InitializeComponent();
        }

        private void read_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            if (fileDialog.ShowDialog() == true)
            {
                collection = new Kolekcja();
                string file = fileDialog.FileName;
                reader.Read(file, collection);
                //listBox.ItemsSource = collection.Games;
                //listBox.DisplayMemberPath = "Title";
                writer.originalFile = file;
                /*foreach(Gra game in collection.Games)
                {
                    ListBoxItem itm = new ListBoxItem();
                    itm.Content = game.Title;
                    listBox.Items.Add(itm);
                }*/
                UpdateCollection();
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

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            if (title_txt.Text != null && id_txt.Text != null && genre_txt.Text != null)
            {
                Gra game = new Gra();
                game.Title = title_txt.Text;
                game.Dev = dev_txt.Text;
                game.ReleseDate = relese_txt.Text;
                game.Publisher = publisher_txt.Text;
                game.Price = price_txt.Text;
                game.Madedate = production_txt.Text;
                game.Id = id_txt.Text;
                game.Genere = genre_txt.Text;

                collection.AddGame(game);
                UpdateCollection();
            }
        }

        private void del_btn_Click(object sender, RoutedEventArgs e)
        {
            if(selectedGame != null)
            {
                collection.Games.Remove(selectedGame);
                UpdateCollection();
            }
        }

        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            if (fileDialog.ShowDialog() == true)
            {
                string file = fileDialog.FileName;
                writer.Write(file, collection);
            }
        }

        private void transopen_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileOpenDialog = new OpenFileDialog();
            fileOpenDialog.Filter = "XSLT files (*.xslt)|*.xslt|All files (*.*)|*.*";

            if (fileOpenDialog.ShowDialog() == true)
            {
                string fileOpen = fileOpenDialog.FileName;
                transform.fileXSL = fileOpen;
            }
      
        }

        private void transsave_btn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fileSaveDialog = new SaveFileDialog();
            fileSaveDialog.Filter = "XHTML files (*.xhtml)|*.xhtml|All files (*.*)|*.*";

            if (fileSaveDialog.ShowDialog() == true)
            {
                string fileSave = fileSaveDialog.FileName;
                transform.Transform(writer.originalFile, fileSave);
            }
        }


    }
}
