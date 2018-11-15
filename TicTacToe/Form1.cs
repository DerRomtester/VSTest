using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        
        bool turn = true;   // true = X ist am Zug // false = Y ist am Zug
        int turn_count = 0; // Mit dem Turn Count wir die Anzahl der Züge ermittelt


        public Form1()
        {
            InitializeComponent();
        }

        // Generischer Button für alle 9 Knöpfe
        private void button_click(object sender, EventArgs e)
        {
            // Der generische Button Sender wird immer in der Variable b gespeichert
            Button b = (Button)sender;

            // Wenn Turn Wahr dann ist X am Zug ansonsten Y
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn; // Turn wird immer Nach dem Klick auf den Anderen Wert gesetzt mit if turn
            turn_count++;

            b.Enabled = false; // Deaktiviert einen Knopf wenn dieser bereits genutzt wurde
            checkforwinner(); // Ermittelt Nach jedem Klick ob es bereits einen Gewinner gibt
            
        }

        private void checkforwinner()
        {
            bool winner = false;

            // Horizontale Ermittlung des Gewinners
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
            {
                winner = true;
            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            {
                winner = true;
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {
                winner = true;
            }
     
            // Vertikale Ermittlung des Gewinners
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {
                winner = true;
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            {
                winner = true;
            }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {
                winner = true;
            }

            //Diagonale Checks
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {
                winner = true;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
            {
               winner = true;
            }

            // Ermittlung des Gewinners
            if (winner) // Gewinnner = Wahr
            {
                disable_buttons();
                string gewinner = " ";
                if(turn)
                {
                    gewinner = "O";
                } else
                {
                    gewinner = "X";
                }
                MessageBox.Show(gewinner + " hat das Spiel gewonnnen!");

            } else
            {
                if (turn_count == 9)
                    MessageBox.Show("Unentschieden");
            }

        }

        // Methode zum deaktivieren aller Buttons wenn es einen Gewinner gibt
        private void disable_buttons()
        {
            try
            {
                foreach (Control c in Controls) // Control = Basisklasse für Steuerelemente d.h. alle Steuerelemente werden deaktviert
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch (Exception)
            {
            }
    
        }

        private void neuesSpielToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            try
            {
                foreach (Control c in Controls) // Control = Basisklasse für Steuerelemente d.h. alle Steuerelemente werden deaktviert
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch (Exception)
            {
            }
            
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
