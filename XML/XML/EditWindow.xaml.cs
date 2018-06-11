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
using System.Windows.Shapes;

namespace XML
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private Kolekcja collection;
        Gra game;
        MainWindow win;

        public EditWindow()
        {
            InitializeComponent();
        }

        public EditWindow(Gra game, Kolekcja coll, MainWindow win)
        {
            this.win = win;
            this.collection = coll;
            this.game = game;
            InitializeComponent();
            title_txt.Text = game.Title;
            dev_txt.Text = game.Dev;
            relese_txt.Text = game.ReleseDate;
            publisher_txt.Text = game.Publisher;
            price_txt.Text = game.Price;
            production_txt.Text = game.Madedate;
            id_txt.Text = game.Id;
            genre_txt.Text = game.Genere;
        }

        private void apply_btn_Click(object sender, RoutedEventArgs e)
        {
            int index = -1;
            for(int i = 0; i < collection.Games.Count; i++)
            {
                if(collection.Games[i].Title == game.Title)
                {
                    index = i;
                }
            }

            game.Title = title_txt.Text;
            game.Dev = dev_txt.Text;
            game.ReleseDate = relese_txt.Text;
            game.Publisher = publisher_txt.Text;
            game.Price = price_txt.Text;
            game.Madedate = production_txt.Text;
            game.Id = id_txt.Text;
            game.Genere = genre_txt.Text;

            collection.Games[index] = game;
            win.UpdateCollection();
        }
    }
}
