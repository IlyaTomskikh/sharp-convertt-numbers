using System;
using System.Linq;
using System.Text;

namespace NumberSystem
{
    public class Class1
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter an input number system");
            var inp = Console.ReadLine();
            if (inp == null) return;
            var n = int.Parse(inp);
            
            Console.WriteLine("Enter an output number system");
            inp = Console.ReadLine();
            if (inp == null) return;
            var m = int.Parse(inp);
            
            var stringBuilder = new StringBuilder("Enter a number in ");
            stringBuilder.Append(n).Append(" number system");
            Console.WriteLine(stringBuilder);
            inp = Console.ReadLine();
            if (inp == null || inp.Any(variable => int.Parse(variable.ToString()) >= n))
            {
                Console.WriteLine("Incorrect input");
                return;
            }
            var number = int.Parse(inp);
            
            var newNumber = 0;
            if (n != m && n > 1 && m > 1)
            {
                var inp10 = n < 10 ? FromNto10(n, number) : number;
                if (m == 16)
                {
                    stringBuilder.Clear();
                    stringBuilder.Append("Number ").Append(number).Append(" in ").Append(n).Append(" number system = ")
                        .Append(number.ToString("X")).Append(" in ").Append(m).Append(" number system");
                    return;
                }
                newNumber =  From10ToM(m, inp10);
            }
            else if (n > 1 && m > 1) newNumber = number;
            stringBuilder.Clear();
            stringBuilder.Append("Number ").Append(number).Append(" in ").Append(n).Append(" number system = ")
                .Append(newNumber).Append(" in ").Append(m).Append(" number system");
            Console.WriteLine(stringBuilder);
        }

        private static int FromNto10(int n, int inp)
        {
            int in10 = 0, power = 0;
            while (inp != 0)
            {
                int nTimesPower = 1,
                    i = power;
                while (i > 0)
                {
                    nTimesPower *= n;
                    --i;
                }
                in10 +=  inp % 10 * nTimesPower;
                inp /= 10;
                ++power;
            }
            return in10;
        }

        private static int From10ToM(int m, int in10)
        {
            var outM = 0;
            while (in10 != 0)
            {
                outM += in10 % m;
                outM *= 10;
                in10 /= m;
            }
            return ReverseInt(outM);
        }
        
        private static int ReverseInt(int num)
        {
            var result = 0;
            while (num > 0) 
            {
                result = result * 10 + num % 10;
                num /= 10;
            }
            return result;
        }
    }
}