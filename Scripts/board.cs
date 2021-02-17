using Godot;
using System;

public class board : Node
{

    public int rookBuff = 0;

    //pour Board()
    public int toPutX = 32;
    public int toPutY = 32;
    public int[] x = new int[8]{32, 96, 160, 224, 288, 352, 416, 480};
    public int[] y = new int[8]{32, 96, 160, 224, 288, 352, 416, 480};

    //pour RightCoor
    public float rightX;
    public float rightY;
    public float[] verifX = new float[8];
    public float[] verifY = new float[8];

    public float[] right = new float[2];


    public float[] RightCoor(float mouseX, float mouseY)
    {
        
        for (int i = 0; i < 8; i++)
        {
            verifX[i] = mouseX - x[i];
            verifY[i] = mouseY - y[i];
        }

        //Debug console
        GD.Print("Tableaux : " + verifX[2] + ", " + verifY[2]); //il faut avoir : valeur differente que celle du mouseX et mouseY
        GD.Print("X = " + x[1] + x[2] + x[3]); // il faut avoir les bonnes coordonnées

        float previousX = verifX[0];
        float previousY = verifY[0];


        for (int i = 0; i < 8; i++)
        {

            // valeur la plus proche de zéro (car il y a une soustraction dans la partie d'avant)
            if (Math.Abs(previousX) > Math.Abs(verifX[i]) || Math.Abs(previousX) == Math.Abs(verifX[i])) 
            {
                previousX = verifX[i];
                rightX = x[i];
            }   

            if (Math.Abs(previousY) > Math.Abs(verifY[i]) || Math.Abs(previousY) == Math.Abs(verifY[i])) 
            {
                previousY = verifY[i];
                rightY = y[i];
            }

        }

        //Debug concole
        GD.Print(rightX);
        GD.Print(rightY);

        right[0] = rightX;
        right[1] = rightY;

        return right;
    }

}
