using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy
{
    public int candyType;
    public Candy(int candyType_){
      candyType = candyType_;
    }

    public double DecideWhichCandy(){
        double candyValue = 6.00;
        if(candyType == 2)
            candyValue = 7.00;
        else if(candyType == 3)
            candyValue = 8.00;
        return candyValue;
    }
}
