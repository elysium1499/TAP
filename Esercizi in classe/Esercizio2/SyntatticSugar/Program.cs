using System;

namespace SyntatticSugar {

    public class ComplexNumbers
    {
        public int Real { get; }     
        public int Immaginary { get; }             
        public static implicit operator ComplexNumbers(int from) {
            return new ComplexNumbers(from, 0);
        }
        public ComplexNumbers(int re, int im)
        {
            Real = re;
            Immaginary = im;
        }
        public void Print()
        {
            Console.WriteLine($"({Real}, {Immaginary})");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("My first complex number");
            new ComplexNumbers(7, 42).Print();      //sarebbe stato meglio usare toString invece di print
            ComplexNumbers x = 5;                   //se facessi ((ComplexNumber)5).Print(); avrei reso l'implicito esplicito
            x.Print();
        }
    }
}
