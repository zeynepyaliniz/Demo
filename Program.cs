// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
MyClass myClass = new();
var sum = myClass.Sum(3,5);
Console.WriteLine(sum);
class MyClass {
    public int Sum(int firstNumber,int secondNumber) { 
        return firstNumber + secondNumber;
    }
}