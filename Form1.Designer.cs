namespace morpionGUI;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    // Déclarer le tableaude9 cases

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private Case[] tabCases = new Case[9];
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(400, 400);
        this.Text = "Morpion";

        // Créer un grid
        TableLayoutPanel tableau = new TableLayoutPanel(); // créer une nouvelle instance de grid
        tableau.RowCount = 3; // nombre de lignes
        tableau.ColumnCount = 3; // nombre de colonnes
        tableau.Size = new System.Drawing.Size(400,400); // taille du tablea
        for(int i=0; i<9 ; i++){
            // Créer des boutons
            tabCases[i] = new Case(i); // créer un nouvelle case
            tabCases[i].Size = new System.Drawing.Size(100,100); // taille des cases
            tabCases[i].Click+= new EventHandler(this.onCaseClick); // += car on peut attacher plusieurs signatures
            tableau.Controls.Add(tabCases[i]); // on ajoute les cases
        }
        this.Controls.Add(tableau);
    }

    #endregion
}
