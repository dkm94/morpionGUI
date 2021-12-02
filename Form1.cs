namespace morpionGUI;

public partial class Form1 : Form
{
    private Game game;
    public Form1()
    {
        InitializeComponent();
        game = new Game(); // on utilise game
    }

    public void restartGame(){ // fonction pour réinitialiser la grille
        for(int i=0; i<9; i++){ // on bouble sur les 9 cases (index 0 à 8)
            tabCases[i].Text=""; // On remplace tous les caractères des joueurs par des valeurs vides
        }
        game = new Game(); // On instancie une nouvelle partie
    }

    // x = colonne
    // y = ligne
    public void onCaseClick(object sender, System.EventArgs e){ // la fonction clic reprend généralement les arguments ci-contre
        Case caseSelected = (Case) sender; // variable caseSelected

        if(caseSelected.Text.Equals("")){ // si la case est vide,
            caseSelected.Text = game.currentPlayer+""; // on affiche le caractère du current player dans la case selectionnée
           int x = caseSelected.getCoord()[0]; // on récupère la coordonnée de la ligne
           int y = caseSelected.getCoord()[1]; // on récupère la coordonnée de colonne
           game.grid[x,y] = game.currentPlayer; // on affiche le caractère du currentPlayer dans la grille grâce aux coordonnées récupérées en x et y
            if(game.isWin()){ // en cas de victoire 
            MessageBox.Show("Victoire", //on affiche le texte correspondant
                $"{game.currentPlayer} a gagné !", //légende
                MessageBoxButtons.OK, // Bouton OK
                MessageBoxIcon.Information); // Icone de la boîte à message
                restartGame(); // et on réinitialise la grille
            } else if(game.isNull()){ // en cas de match nul
                MessageBox.Show("Match nul");// on affiche la boîte à message correspondante
                restartGame(); // puis on réinitialise la grille
            } else {
                game.changeCurrentPlayer(); // puis on change de joeur
            }

        }
        // on concat un caractère et un sring pour eviter une erreur comme quoi la valeur n'est pas un caractère
        //la fonction show reprend généralement les arguments suivants: un string text, un string légende, un bouton dans la boite de message et le type de message box. Dans cet ordre.
        // MessageBox.Show($"coordonées: {caseSelected.getCoord()[0]}, {caseSelected.getCoord()[1]}", // on récupère le premier entier, puis le deuxième
        //     "numero " + caseSelected.number, 
        //MessageBoxButtons.OK, 
        //MessageBoxIcon.Information);
    }
        
}
