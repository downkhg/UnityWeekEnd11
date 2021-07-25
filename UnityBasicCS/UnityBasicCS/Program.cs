using System;

namespace UnityBasicCS
{
    class Program
    {
        static void Main(string[] args)
        {//구문
            Console.WriteLine("Hello World!");
            Console.WriteLine("KHG");
            Console.WriteLine("Add:" + Add(10, 20));
            ValMain();
        }//구문끝

        static int Add(int a, int b)
        {
            int c = a + b;
            return c;
        }

        static void ValMain()
        {
            //내용
        }
    }
}
