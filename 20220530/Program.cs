/*
    Using Lambda expressions in C# to eliminate the need for forloops, and relying on splits to determine whether or not we have duplicates. 
    Tried to use indexOf but quickly occured to me that the indexOf function fell in the same character every single time. 
    Solution works with capital strings as well. 
*/

bool allUnique(string word){
    return word.Select(character => word.Split(character).Length > 2)
                .Where(result => result==true).Count() >=2;
}


Console.WriteLine(allUnique("Cassidy"));
Console.WriteLine(allUnique("cat & dog"));
Console.WriteLine(allUnique("cat+dog"));
