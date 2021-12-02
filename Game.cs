using System;
using System.Collections.Generic;
using System.Linq;

namespace morpionGUI // Note: actual namespace depends on the project name.
{
    public class Game
        {
           public char[,] grid; // on déclare un tableau de tableaux de caractères qu'on appelle grid
            // char est le type (charactère)
            // [] est un tableau
            // [,] = tableau à deux dimensions (tableau de tableau)

            public char currentPlayer;

            public Game(){ // constructeur de la classe Game
                this.grid = new char[,] {{' ', ' ', ' '},
                                {' ', ' ', ' '},
                                {' ', ' ', ' '}}; // grid est un tableau de 3 tableaux
                this.currentPlayer = 'O'; // on commence par le joueur O
            }

            public void displayGrid(){ // logique pour afficher le tableau
                // i= lignes
                // j= colonnes
                for(int i=0; i<grid.GetLength(0); i++){ // parcourt les lignes
                    for(int j=0; j< grid.GetLength(1); j++){ //parcourt les colonnes
                        Console.Write(grid[i,j]);
                        if(j!=2){ // on ajoute un | tant qu'on est pas à l'index 2
                            Console.Write("|");
                        }
                    }
                    Console.Write("\n"); // on saute une ligne
                }
            }

            public void changeCurrentPlayer(){ // logique pour changer de joueur
                if(currentPlayer=='O'){
                    currentPlayer='X'; // un = affectation ; 2 == on vérife l'égalité
                } else {
                    currentPlayer='O';
                }
            }

            private int getPlayerValue(String text){ //fonction récursive (qui s'appelle elle-même)
               Console.Write(text); // text = "Entrer la *** à jouer"
               String value = Console.ReadLine(); // input user
               try {
                   int i = Int32.Parse(value); // on attribue la sasie user ligne.length et colonne.length
                   if(i > 2){ // si l'input est supérieur à 2, donc que la valeur saisie n'existe pas dans notre tableau qui va de l'index à 0 à 2 en colonne ou en ligne, 
                   // on exécute le catch (donc on redemande à l'user de saisir une nouvelle valeur)
                       return getPlayerValue(text);
                   }
                   return i; // valeur saisie x et y
               } catch(FormatException){
                   return getPlayerValue(text); // si on arrive par à avoir une valeur correcte, on repose la question
               }
            }

            public int getPlayerValueX(){
                return getPlayerValue("Entrez la ligne de la case à jouer");
            }
            public int getPlayerValueY(){
                return getPlayerValue("Entrez la colonne de la case à jouer");
            }

            public bool isWin(){
                for(int i=0; i<3; i++){ // gagner sur toutes les lignes
                    if(grid[i,0] == grid[i,1] && grid[i,1] == grid[i,2] && grid[i,0] !=' '){
                        return true;
                    }
                }
                for(int i=0; i<3; i++){ // gagner sur toutes les colonnes
                    if(grid[0,i] == grid[1,i] && grid[1,i] == grid[2,i] && grid[0,i] !=' '){
                        return true;
                    }
                }
                if(grid[0,0] == grid[1,1] && grid[1,1] == grid[2,2] && grid[0,0] !=' '){ // gagner en diagonale from the top corner left to the bottom corner right
                    return true;
                }
                if(grid[0,2] == grid[1,1] && grid[1,1] == grid[2,0] && grid[0,2] !=' '){ // gagner en diagonale from the top corner right to the bottom corner left
                    return true;
                }
                return false;
            }

            public bool isNull(){
                for(int i=0; i<grid.GetLength(0); i++){  // on boucle sur les lignes
                    for(int j=0; j< grid.GetLength(1); j++){ // on boucle sur les colonnes
                        if(grid[i, j] == ' '){ // s'il existe une case vide, la partie ne peut pas être nulle
                            return false;
                        }
                    }
                }
                return true;
            }
        }
}