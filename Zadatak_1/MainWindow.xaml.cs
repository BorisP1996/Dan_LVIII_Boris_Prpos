using System.Windows;
using System.Windows.Controls;

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
        // counter that says which player has next move
        int turn;
        //counts wins by player x
        int xCounter;
        //counts wins by player y
        int oCounter;
        //counts draw matches
        int drawCounter;
      
        /// <summary>
        /// when reset button is clicked, every button content is cleared and every button is enabled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button btn in WrapPanel.Children)
            {
                btn.Content = "";
                btn.IsEnabled = true;
            }
        }

        /// <summary>
        /// Decide if win happened (if 3 consecutive buttons have the same content)
        /// </summary>
        /// <param name="btnContent"></param>
        private void Win(string btnContent)
        {
            //compare array of 3 buttons with input button
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
                //if input button conetnt is "O" that means that player O won the game
                if (btnContent == "O")
                {

                    MessageBox.Show("Player O has won the game.");
                    //increment counter connected with lable that displays number of wins
                    oWins.Content = ++xCounter;
                }
                //if input button content is "X" that means that playes X won the game
                else if (btnContent == "X")
                {
                    MessageBox.Show("Player X has won the game.");
                    //increment counter connected with lable that displays number of wins
                    xWins.Content = ++oCounter;
                }
                //set every button to disabled after game is over
                disablebuttons();
            }
            //if no one wins =>game is tied
            else
            {
                //if there is one enabled button=>RETURN happens=>this meand that every button must be clicked before game is called draw
                foreach (Button btn in WrapPanel.Children)
                {
                    if (btn.IsEnabled == true)
                        return;
                }
                MessageBox.Show("Draw game.");
                //increment counter binded to the draw label
                drawCounterLabel.Content = ++drawCounter;
            }
        }
        /// <summary>
        /// Method will be called when someone has won, WrapPanel unifies all the buttons that represent fields
        /// </summary>
        private void disablebuttons()
        {
            foreach (Button btn in WrapPanel.Children)
            {
                btn.IsEnabled = false;
            }
        }
        /// <summary>
        /// Method happens when one button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void But_Click(object sender, RoutedEventArgs e)
        {
            //convert object to Button
            Button btn = sender as Button;
            //if match is starting=>first player button conetnt is O and label that says whos on the turn shows oposite player sign
            if (turn == 1)
            {
                btn.Content = "O";
               nextMove.Content = "X";
            }
            //if turn is 2, oposite happens, button content is X and label that says whos on the turn shows oposite player sign 
            else
            {
                btn.Content = "X";
                nextMove.Content = "O";
            }
            //after button is clicked=>it is disabled
            btn.IsEnabled = false;
            //checking for the win every time button is clicked,passing clicked button as the parameter
            Win(btn.Content.ToString());
            //turn increments for one
            turn += 1;
            //after it is incremented again, it gets set to one again, allowing the whole procces to start again (basicaly it is some king of loop)
            if (turn > 2)
                turn = 1;
        }

    }
}
