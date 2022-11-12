using System;
using System.Collections.Generic;

class ChapterOne
{
    /*
    public static void Main(string[] args)
    {
      string string1 = "enutsthes";
      string string2 = "thesenuts";
      Console.WriteLine(StringRotation(string1, string2));
    }
    */

    public static bool IsUnique(string myString)
    {
        Dictionary<char, char> trackMap = new Dictionary<char, char>();
        for (int i = 0; i < myString.Length; i++)
        {
            if (trackMap.ContainsKey(myString[i]))
            {
                return false;
            }
            else
            {
                trackMap.Add(myString[i], myString[i]);
            }
        }
        return true;
    }

    public static bool Permutation(string string1, string string2)
    {
        int[] asciiCount = new int[128];
        for (int i = 0; i < string1.Length; i++)
        {
            asciiCount[string1[i]]++;
        }

        for (int i = 0; i < string2.Length; i++)
        {
            asciiCount[string2[i]]--;
        }

        foreach (int i in asciiCount)
        {
            if (i != 0)
            {
                return false;
            }
        }

        return true;
    }

    public static string makeURL(string myString){
      string output = "";
      for(int i = 0; i < myString.Length; i++){
        if(myString[i] != ' '){
          output+= myString[i];
        }else{
          output+= "%20";
        }
      }

      return output;
    }

    public static bool permutationOfPalindrome(string myString){
      int[] asciiCount = new int[128];
      bool foundOne = false;

      for(int i = 0; i < myString.Length; i++){
        if(myString[i] < 91 && myString[i] > 64){
          var newString = "";
          for(int j = 0; j < myString.Length; j++){
            if(j == i){
              newString += (char) (myString[i] + 32);
            }else{
              newString += myString[j];
            }
          }
          myString = newString;
        }
      }
      foreach(char i in myString){
        if(i > 96 && i < 123){
          asciiCount[i]++;
        }
      }

      foreach(int i in asciiCount){
        if(i % 2 != 0){
          if(foundOne){
            return false;
          }else{
            foundOne = true;
          }
        }
      }

      return true;
      
    }
  public static bool oneAway(string string1, string string2){
    if(Equals(string1, string2)){
      return true;
    }

    //insert, remove, replace
    int[,] asciiCount = new int[128, 2];
 
    foreach(char i in string1){
      asciiCount[i, 0]++;
    }
    foreach(char j in string2){
      asciiCount[j, 1]++;
    }
    int charDiff = 0;
    for(int i = 0; i < 128; i++){
      charDiff += Math.Abs(asciiCount[i, 1] - asciiCount[i, 0]);
    }

    if(string1.Length == string2.Length){
      if(charDiff <=2){
        return true;
      }else{
        return false;
      }
    }else{
      return charDiff <= 1;
    }
    
  }
  public static string Compression(string myString){
    //for future reference, use StringBuilder, not string concatenation. This is essentially a List except a string, so instead of constant reallocation it dynamically resizes cleanly.
    bool differ = false;
    string result = "";
    int currentStreak = 1;
    char currentChar = myString[0];
    int pointer = 0;
    while(pointer < myString.Length - 1){
      if(myString[pointer + 1] == currentChar){
        currentStreak++;
        differ = true;
      }else{
        result += currentChar;
        result+= currentStreak.ToString();
        currentStreak = 1;
        currentChar = myString[pointer + 1];
      }
      pointer++;
    }
    if(!differ){
      return myString;
    }
    result += currentChar;
    result+= currentStreak.ToString();
    return result;
  }
  public static bool StringRotation(string string1, string string2){
    string fullString2 = string2 + string2;
    return fullString2.Contains(string1);
  }
}