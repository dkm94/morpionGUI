namespace morpionGUI;
class Case:Button // héritage
//--> case (enfant) va hériter des attributs de button (parent)
{
   public int number;

   public Case(int n):base(){ // ajouter au constructeur de base: c'est le constructeur de case, mais on utilise aussi l'héritage du parent button
       this.number = n; //une case aura son numéro
   }

   // renvoyer le tableau de int
   public int[] getCoord(){
       int [] coord = new int[2]; // on attend 2 coordonnées dans le tableau (2 entiers)
        coord[0] = (this.number==0 || this.number==3 || this.number==6) ? 0 : 
                    (this.number==1 || this.number==4 || this.number==7) ? 1 : 2;
         coord[1] = (this.number==0 || this.number==1 || this.number==2) ? 0 : 
                    (this.number==3 || this.number==4 || this.number==5) ? 1 : 2;
       return coord;
   }
}