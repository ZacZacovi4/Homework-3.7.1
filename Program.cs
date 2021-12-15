using System;

namespace CodingTask
{

    interface ICoder
    {
        string Encode();
        string Decode();
    }

    public sealed class ACoder : ICoder
    {
        private string CodeString { get; set; }

        const string alfabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        public string Encode()
        {
            Console.WriteLine("Введите свою строчку для шифрования");
            CodeString = Console.ReadLine();
            var fullAlfabet = alfabet + alfabet.ToLower();
            var letterQty = fullAlfabet.Length;
            var retVal = "";
            var k = 1;
            for (int i = 0; i < CodeString.Length; i++)
            {
                var c = CodeString[i];
                var index = fullAlfabet.IndexOf(c);
                if (index < 0)
                {

                    retVal += c.ToString();
                }
                else
                {
                    var codeIndex = (letterQty + index + k) % letterQty;
                    retVal += fullAlfabet[codeIndex];
                }
            }
            Console.WriteLine($"Ваша зашифрованая строчка : ");
            return retVal;
        }

        // Для метода Decode можно использовать тот же самый метод что и в Encode только k = -1
        public string Decode()
        {
            Console.WriteLine($"Ваша расшифрованая строчка : ");
            return CodeString;
        }
    }

    public sealed class BCoder : ICoder
    {
        private string CodeString { get; set; }

        const string alfabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        public string Encode()
        {
            Console.WriteLine("Введите свою строчку для шифрования");
            CodeString = Console.ReadLine();
            var fullAlfabet = alfabet + alfabet.ToLower();
            var letterQty = fullAlfabet.Length;
            var retVal = "";
            var k = 32;
            var l = 34;
            for (int i = 0; i < CodeString.Length; i++)
            {
                var c = CodeString[i];
                var index = fullAlfabet.IndexOf(c);
                if (index < 0)
                {

                    retVal += c.ToString();
                }
                if (index < 33)
                {
                    var codeIndexB = letterQty - l - index;
                    retVal += fullAlfabet[codeIndexB];
                }
                else
                {
                    var codeIndexL = letterQty + k - index;
                    retVal += fullAlfabet[codeIndexL];
                }
            }
            Console.WriteLine($"Ваша зашифрованая строчка : ");
            return retVal;
        }

        // Для метода Decode можно использовать тот же самый метод что и в Encode, даже не надо ничего менять
        public string Decode()
        {
            Console.WriteLine($"Ваша расшифрованая строчка : ");
            return CodeString;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            ACoder aCoder = new ACoder();
            BCoder bCoder = new BCoder();
            Console.WriteLine(aCoder.Encode());
            Console.WriteLine(aCoder.Decode());

            Console.WriteLine(bCoder.Encode());
            Console.WriteLine(bCoder.Decode());

        }
    }
}