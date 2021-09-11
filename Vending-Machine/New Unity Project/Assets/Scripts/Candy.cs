using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy
{
    public int candy_type;
    public Candy(int candy_type_){
      candy_type = candy_type_;
    }

    public double decideWhichCandy(){
        double candy_value = 6.00;
        if(candy_type == 2)
            candy_value = 7.00;
        else
            candy_value = 8.00;
        return candy_value;
    }
}
