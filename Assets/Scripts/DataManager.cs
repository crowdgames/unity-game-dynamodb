﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager {

    public static int index = 0;
    public static int points = 0;
    public static int mode = 4; //0 - Designer, 1 - Path, 2 - Random, 3 - No coins, 4 - HCG
    public static int NCOINS = 10;
    public static float play_time = 0.0f;
    public static string player_id = "";
    //public static string host = "viridian.ccs.neu.edu:3004";
    public static string host = "localhost:3004";
    
    public static string[] scenarios = new string[] {"Grocery Store","Pastry Shop","Clothing Store","Sports Store","Hardware Store"};

    public static Dictionary<string, string[]> hcg_items = new Dictionary<string, string[]>
    {
        { "Grocery Store",new string[]{ "bread", "candy", "carrot", "milk", "popcorn" } },
        { "Pastry Shop",new string[]{ "pie", "bun", "cake", "croissant", "donut" } },
        { "Clothing Store",new string[]{ "shirts","hat","sweater","coat","tshirt" } },
        { "Sports Store",new string[]{ "baseball", "basketball", "gloves", "soccerball", "cleats", "football" } },
        { "Hardware Store",new string[]{ "drill", "saw", "hammer", "nails", "pliers", "wrench", "axe" } }
    };

}