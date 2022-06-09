int[] coinCombo(int[] coins, int amount){
    var result = coinCalculate(coins.ToList(), new List<int>{},amount).ToArray();
    Array.Sort(result);
    return result;
}

List<int> coinCalculate(List<int> coins, List<int> selectedCoins, int amount){
    if(amount == 0){
        return selectedCoins;
    }
    if(coins.Count == 0){
        return new List<int>{};
    }

    if(coins.Count > 0 && amount - coins[coins.Count-1] >=0){       
        for(int i = coins.Count-1; i >=0;i--){
            if(i < coins.Count){
                int passAmount = amount;
                passAmount = amount - coins[i];
                selectedCoins.Add(coins[i]);            
                return coinCalculate(coins,selectedCoins,passAmount);
            }
        }
    }else if(coins.Count > 0 && amount - coins[coins.Count-1] < 0){
        amount = amount + coins[coins.Count-1];
        selectedCoins.Remove(selectedCoins[selectedCoins.Count-1]);
        coins.Remove(coins[coins.Count-1]);
        return coinCalculate(coins,selectedCoins,amount);

    }
    return new List<int>{};
}



void displayCombo(int [] coins){
    string result="";
    for(int i=0; i < coins.Length;i++){
        if(i==coins.Length-1){
            result += coins[i];
        }else{
            result += coins[i]+",";
        }        
    }
    Console.WriteLine("["+result+"]");
}


displayCombo(coinCombo(new int[]{2,3,5,7}, 17));
displayCombo(coinCombo(new int[]{2,3,5}, 11));
