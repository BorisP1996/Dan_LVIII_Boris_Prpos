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

namespace Zadatak_1
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

        int turn;
        int xCounter;
        int oCounter;
        int drawCounter;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            turn = 1;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button btn in WrapPanel.Children)
            {
                btn.Content = "";
                btn.IsEnabled = true;

            }
        }

        private void Win(string btnContent)
        {
            if ((But1.Content == btnContent & But2.Content == btnContent &
                 But3.Content == btnContent)
               | (But1.Content == btnContent & But4.Content == btnContent &
                 But7.Content == btnContent)
               | (But1.Content == btnContent & But5.Content == btnContent &
                 But9.Content == btnContent)
               | (But2.Content == btnContent & But5.Content == btnContent &
                 But8.Content == btnContent)
               | (But3.Content == btnContent & But6.Content == btnContent &
                 But9.Content == btnContent)
               | (But4.Content == btnContent & But5.Content == btnContent &
                 But6.Content == btnContent)
               | (But7.Content == btnContent & But8.Content == btnContent &
                 But9.Content == btnContent)
               | (But3.Content == btnContent & But5.Content == btnContent &
                 But7.Content == btnContent))
            {
                if (btnContent == "O")
                {

                    MessageBox.Show("Player O has won the game.");
                    oWins.Content = ++xCounter;
                }
                else if (btnContent == "X")
                {
                    MessageBox.Show("Player X has won the game.");
                    xWins.Content = ++oCounter;
                }
                disablebuttons();
            }

            else
            {
                foreach (Button btn in WrapPanel.Children)
                {
                    if (btn.IsEnabled == true)
                        return;
                }
                MessageBox.Show("Draw game.");
                drawCounterLabel.Content = ++drawCounter;
            }
        }
        private void disablebuttons()
        {
            foreach (Button btn in WrapPanel.Children)
            {
                btn.IsEnabled = false;
            }
        }
        private void But_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (turn == 1)
            {
                btn.Content = "O";
               nextMove.Content = "X";
            }
            else
            {
                btn.Content = "X";
                nextMove.Content = "O";
            }
            btn.IsEnabled = false;
            Win(btn.Content.ToString());
            turn += 1;
            if (turn > 2)
                turn = 1;
        }

    }
}
