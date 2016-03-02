using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using Oyster.Math;
using System.Diagnostics;

namespace Projecteuler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            System.Diagnostics.Process.GetCurrentProcess().ProcessorAffinity = (System.IntPtr)3;
        }
        # region ID1
        int answer = 0;
        private void btnAnswer_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    int b = i / 3;
                    int c = i / 5;
                    if (i == c * 5 || i == b * 3)
                    {
                        tbDebug.Text = tbDebug.Text + "\r\n" + i.ToString();
                        answer = answer + i;
                    }
                }
                catch { }

            }
                    tbAnswer.Text = answer.ToString();
        }
        #endregion
        #region ID2
        int ID2number1 = 1;
        int ID2number2 = 1;
        int ID2number3 = 0;
        int ID2evens = 0;
        private void btnID2_Click(object sender, EventArgs e)
        {
            while (ID2number3 < 4000000)
            {
                ID2number3 = ID2number1 + ID2number2;
                int numbertest = ID2number3 / 2;
                if (ID2number3 < 4000000)
                {
                    textBox2.Text = textBox2.Text + "\r\n" + ID2number3.ToString();
                    if (ID2number3 == numbertest * 2)
                    {
                        ID2evens = ID2evens + ID2number3;
                        textBox1.Text = ID2evens.ToString();
                    }
                }
                ID2number1 = ID2number2;
                ID2number2 = ID2number3;
            }
        }
        #endregion
        #region ID3
        long inputnum = 0;
        private void btnID3_Click(object sender, EventArgs e)
        {
            //tbID3inputnum is the textbox you can put in your custom number to find primes factors
            //tbIDwdebug is a textbox were you can see the prime factors.
            System.Diagnostics.Process.GetCurrentProcess().ProcessorAffinity = (System.IntPtr)3; //helps speed it up
            inputnum = Convert.ToInt64(tbID3inputnum.Text);
            long c = inputnum;
            for (long i = 1; i <= c; i++)
            {
                long d = inputnum / i;
                if (inputnum == d * i)
                {
                    tbID3debug.Text = tbID3debug.Text + "\r\n" + i.ToString() + " , " + d.ToString();
                    //tbID3answer is were the highest prime factor ends up in.
                    tbID3answer.Text = i.ToString();
                    inputnum = d;
                    //resets for the next round
                    i = 1;
                }
                //helps solve the custom input number by stoping the program when it hits 1 or 2 as a last prime
                if (inputnum == 1 || inputnum == 2)
                {
                    switch (inputnum)
                    {
                        case 1:
                            break;

                        case 2:
                            tbID3debug.Text = tbID3debug.Text + "\r\n" + inputnum.ToString() + " , 1";
                            break;

                    }
                    break;
                }
            }
            tbID3debug.Text = tbID3debug.Text + "\r\n";
        }
        #endregion
        #region ID4

        private void btnID4answer_Click(object sender, EventArgs e)
        {
            for (long i = 100; i < 1000; i++)
            {
                for (long q = 100; q < 1000; q++)
                {
                    palindromicnumber(i, q);
                }
            }
            tbID4answer.Text = amount.ToString() + "  " + ID4largestnumber.ToString();
        }
        int amount = 0;
        long ID4largestnumber = 0;
        private void palindromicnumber(long numberone, long numbertwo)
        {
            long answer = numbertwo * numberone;
            if (answer.ToString().Length % 2 == 0)
            {
                string input = answer.ToString();
                string firsthalf = input.Substring(0, input.Length / 2);
                string secondhalf = input.Substring(input.Length / 2, input.Length / 2);
                secondhalf = reverse(secondhalf);
                if (secondhalf == firsthalf)
                {
                    tbID4debug.Text = tbID4debug.Text + firsthalf + "   " + numberone + "  " + numbertwo + "\r\n" + secondhalf + "\r\n";
                    if (ID4largestnumber < answer)
                    {
                        ID4largestnumber = answer;
                    }
                    amount++;
                }
                
            }

        }
        private string reverse(string i)
        {
            Char[] array = i.ToCharArray();
            Array.Reverse(array);
            return new string(array);

        }
        #endregion
        #region ID5
        private void btnID5answer_Click(object sender, EventArgs e)
        {
            for (long i = 200; i < 1000000000; i++)
            {
                if (i % 2 == 0 && i % 3 == 0 && i % 4 == 0 && i % 5 == 0 && i % 6 == 0 && i % 7 == 0 && i % 8 == 0 && i % 9 == 0 && i % 10 == 0 && i % 11 == 0 && i % 12 == 0 && i % 13 == 0 && i % 14 == 0 && i % 15 == 0 && i % 16 == 0 && i % 17 == 0 && i % 18 == 0 && i % 19 == 0 && i % 20 == 0)
                {
                    tbID5debug.Text = i.ToString();
                    break;
                }
            }
        }
        #endregion
        #region ID6
        private void btnID6answer_Click(object sender, EventArgs e)
        {
            long firstnum = 0;
            long secondnum = 0;
            for (long i = 1; i <= 100; i++)
            {
                firstnum = firstnum + (i * i);
            }
            for (long i = 1; i <= 100; i++)
            {
                secondnum = secondnum + i;
            }
            secondnum = secondnum * secondnum;
            firstnum = secondnum - firstnum;
            tbID6debug.Text = firstnum.ToString();
        }
        #endregion
        #region ID7
        private void btnID7answer_Click(object sender, EventArgs e)
        {
            long input = 1;
            long i = 0;
            while (i < 100000)
            {
                isprime(input);
                if (notprime == false)
                {
                    i++;
                }
                input++;



            }
            input = input - 1;
                    tbID7debug.Text = tbID7debug.Text + "\r\n" + input.ToString();

        }
        bool notprime = true;
        private void isprime(long h)
        {
            long optim1;
            long optim2;
            if (h >= 100)
            {
                optim1 = (long)Math.Sqrt(h);
                optim2 = optim1 * (long)Math.Sqrt(optim1);
            }
            else { optim2 = h; }
                for (long g = 2; g <optim2; g++)
                {
                    if (h == 1 || h == 2)
                    {
                        notprime = false;
                        break;
                    }
                    if ( h% g == 0)
                    {
                        if (h != 2)
                        {
                            notprime = true;
                            break;
                        }
                        else { notprime = false; }
                    }
                    else { notprime = false; }

                }

        }
        private bool isprimeTest(long h)
        {
            bool output = true;
            long optim1;
            long optim2;
            if (h >= 100)
            {
                optim1 = (long)Math.Sqrt(h);
                optim2 = optim1 * (long)Math.Sqrt(optim1);
            }
            else { optim2 = h; }
            for (long g = 2; g < optim2; g++)
            {
                if (h == 1 || h == 2)
                {
                    break;
                }
                if (h % g == 0)
                {
                    if (h != 2)
                    {
                        output = false;
                        break;
                    }
                }

            }
            return output;

        }
        #endregion
        #region ID9
        private void btnID9answer_Click(object sender, EventArgs e)
        {
            long a = 1;
            long b = 1;
            long c = 1;
            double testanswer = 0;
            for (a=1; a < 1000; a++)
            {
                if (a + b + c == 1000)
                {
                    break;
                }
                for (b=1; b < 1000; b++)
                {
                    if (a + b + c == 1000)
                    {
                        break;
                    }
                    for (c=1; c < 1000; c++)
                    {
                        if (a + b + c == 1000)
                        {
                            testanswer = Math.Pow(a, 2) + Math.Pow(b, 2);
                            if (testanswer == Math.Pow(c, 2))
                            {
                                long answer = a * b * c;
                                tbID9debug.Text = answer.ToString();
                                tbID9debug.Text += "\r\n" + a + " " + b + " " + c;

                            }
                            break;
                        }
                    }
                }

            }
                
                if (a + b + c == 1000)
                {
                    
                }


        }
        #endregion
        #region ID10
        private void btnID10answer_Click(object sender, EventArgs e)
        {
            long input = 1;
            long answer = 2;
            long i = 1;
            Stopwatch sw = Stopwatch.StartNew();
            while (i <= 2000000)
            {
                if (isprimeTest(i))
                {
                    //tbID10debug.Text = tbID10debug.Text + "\r\n" + i.ToString();
                    answer = answer + i;
                }
                    i++;


            }
            sw.Stop();
            tbID10debug.Text = tbID10debug.Text + "\r\n" + answer.ToString() + "\r\n" + ((sw.ElapsedMilliseconds).ToString());

        }
        #endregion

        private void btnID11answer_Click(object sender, EventArgs e)
        {
            IntX ID11answer = 1;
            for (IntX i = 1; i <= 100; i++)
            {
                ID11answer = ID11answer * i;
            }
            tbID11debug.Text = tbID11debug.Text + "\r\n" + ID11answer.ToString();
            string ID11stringanswer = ID11answer.ToString();
            Char[] testarray = ID11stringanswer.ToCharArray();
            IntX ID11realanswer = 0;
            for (int i = 0; i <= ID11stringanswer.Length - 1; i++)
            {
                    ID11realanswer = Convert.ToInt64(ID11stringanswer.Substring(i, 1)) + ID11realanswer;                
            }
            tbID11debug.Text = tbID11debug.Text + "\r\n" + ID11realanswer.ToString();


        }

        private void btnID16answer_Click(object sender, EventArgs e)
        {
            IntX ID16answer = 2;
            for (IntX i = 2; i <= 1000; i++)
            {
                ID16answer = ID16answer * 2;
            }
            Int32 ID11realanswer = 0;
            string ID16stringanswer = ID16answer.ToString();


            for (Int32 i = 0; i <= ID16stringanswer.ToString().Length - 1; i++)
            {
                ID11realanswer = Convert.ToInt32(ID16stringanswer.Substring(i,1)) +  ID11realanswer;
            }
            //tbID16debug.Text = ID11realanswer.ToString();
            tbID16debug.Text = ID16answer.ToString();

        }

        private void btnID8answer_Click(object sender, EventArgs e)
        {
            string n1  = "73167176531330624919225119674426574742355349194934";
            string n2  = "96983520312774506326239578318016984801869478851843";
            string n3  = "85861560789112949495459501737958331952853208805511";
            string n4  = "12540698747158523863050715693290963295227443043557";
            string n5  = "66896648950445244523161731856403098711121722383113";
            string n6  = "62229893423380308135336276614282806444486645238749";
            string n7  = "30358907296290491560440772390713810515859307960866";
            string n8  = "70172427121883998797908792274921901699720888093776";
            string n9  = "65727333001053367881220235421809751254540594752243";
            string n10 = "52584907711670556013604839586446706324415722155397";
            string n11 = "53697817977846174064955149290862569321978468622482";
            string n12 = "83972241375657056057490261407972968652414535100474";
            string n13 = "82166370484403199890008895243450658541227588666881";
            string n14 = "16427171479924442928230863465674813919123162824586";
            string n15 = "17866458359124566529476545682848912883142607690042";
            string n16 = "24219022671055626321111109370544217506941658960408";
            string n17 = "07198403850962455444362981230987879927244284909188";
            string n18 = "84580156166097919133875499200524063689912560717606";
            string n19 = "05886116467109405077541002256983155200055935729725";
            string n20 = "71636269561882670428252483600823257530420752963450";
            string input = n1 + n2 + n3 + n4 + n5 + n5 + n6 + n7 + n8 + n9 + n10 + n11 + n12 + n13 + n14 + n15 + n16 + n17 + n18 + n19 + n20;
            Int32 topnum = 0;
            for (int i = 0; i <= 995; i++)
            {
                string teststring = input.Substring(i, 5);
                int testnum = 1;
                    for (int g = 0; g < 5; g++)
                    {
                        testnum = testnum * Convert.ToInt32(teststring.Substring(g, 1));
                    }
                if (testnum > topnum)
                {
                    topnum = testnum;
                }
            }
            tbID8debug.Text = topnum.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 81; i < 1000; i++)
            {
                 double a = Math.Pow(Convert.ToDouble(i - 80), 2);
                 double b = Math.Pow(Convert.ToDouble(i - 40), 2);
                double c = Math.Pow(Convert.ToDouble(i),2);
                if (c == a + b)
                {
                    textBox3.Text = a.ToString() + "  " + b.ToString() + "   " + c.ToString() + "  " + i.ToString();
                    break;
                }
            }
        }

        private void btnSolve35_Click(object sender, EventArgs e)
        {
            int answer = 0;
            for(int i = 999999; i > 1; i -= 1)
            {
                if (isprimeTest(i))
                {
                    bool isCircularPrime = true;
                    foreach (Int64 num in rotatedArrangments(i))
                    {
                        if (!isprimeTest(num))
                            isCircularPrime = false;
                        //tbDebug35.Text += "\r\n    " + num;
                    }
                    if (isCircularPrime)
                    {
                        tbDebug35.Text += "\r\n\r\n" + i;
                        answer++;
                    }
                }
            }
            tbAnswer35.Text = answer.ToString();
        }
        private List<Int64> rotatedArrangments(int input)
        {
            List<Int64> output = new List<long>();

            int length = input.ToString().Length;
            String num = input.ToString();
            foreach(Char letter in num)
            {
                num = num.Substring(1, num.Length - 1) + letter;
                output.Add(Int64.Parse(num));
            }

            return output;
        }


        private void btnProblem15_Click(object sender, EventArgs e)
        {
            Int64 size = 20 + 1;
            Int64[,] grid = new Int64[size,size];
            grid[0,0] = 1;
            for (int y = 0; y < size; y++)
            {
                for(int x = 0; x < size; x++)
                {
                    if(grid[x,y] != 1)
                    {
                            Int64 newValue = 0;
                            if (x - 1 >= 0)
                                newValue += grid[x - 1, y];
                            if (y - 1 >= 0)
                                newValue += grid[x, y - 1];
                            grid[x, y] = newValue;
                    }
                }
            }
            int length = grid[size - 1, size - 1].ToString().Length + 1;
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    tbDebug15.Text += reSizeText(grid[x,y].ToString(), length, x);
                }
                tbDebug15.Text += "\r\n";
            }
            tbOutput15.Text = grid[size - 1, size - 1] + "";
        }
        public string reSizeText(string text, int length, int column)
        {
            int numLength = text.Length;
            for (int i = 0; i < length - numLength; i++)
                text = " " + text;
            return text;
        }

        private void btnSolve11_Click(object sender, EventArgs e)
        {
            tbInput11.Text = tbInput11.Text.Replace("\n ", "\n");      //cleans the input
            string[] firstRun = tbInput11.Text.Split('\n');
            string[][] secondRun = new string[firstRun.Length][];
            for(int i = 0; i < firstRun.Length; i++)
                secondRun[i] = firstRun[i].Split(' ');
            int maxX = firstRun[0].Split(' ').Length, maxY = secondRun.Length, iteratorX = 0, iteratorY = 0;
            Int32[][] grid = new Int32[maxY + 1][];
            for (int j = 0; j < maxX; j++)
                grid[j] = new int[maxY];
            for (iteratorY=0 ; iteratorY < maxY; iteratorY++)
                for (iteratorX = 0; iteratorX < maxX; iteratorX++)
                    grid[iteratorX][iteratorY] = Int32.Parse(secondRun[iteratorY][iteratorX]);
            /*for (int y = 0; y < maxX; y++) { 
                for (int x = 0; x < maxY; x++)
                    tbTest11.Text += reSizeText(grid[x][y].ToString(), 2, x) + " ";
                tbTest11.Text += "\r\n";
            }*/
            Int64 maxVar = 0;
            Int64 oldVar = 0;
            int bestX = 0, bestY = 0, dir = 0; // 0 = hor 1 = ver 2 = slate 3 = ops slate
            for (int y = 0; y < maxX -4; y++)
                for (int x = 0; x < maxY - 4; x++)
                {
                    maxVar = returnLargestNum(grid[x][y] * grid[x + 1][y] * grid[x + 2][y] * grid[x + 3][y], maxVar);             //horizatal
                    if(maxVar != oldVar)
                    {
                        bestX = x;
                        bestY = y;
                        dir = 0;
                    }
                    maxVar = returnLargestNum(grid[x][y] * grid[x][y + 1] * grid[x][y + 2] * grid[x][y + 3], maxVar);             //vertical
                    if (maxVar != oldVar)
                    {
                        bestX = x;
                        bestY = y;
                        dir = 1;
                    }
                    maxVar = returnLargestNum(grid[x][y] * grid[x + 1][y + 1] * grid[x + 2][y + 2] * grid[x + 3][y + 3], maxVar); //slant
                    if (maxVar != oldVar)
                    {
                        bestX = x;
                        bestY = y;
                        dir = 2;
                    }
                    maxVar = returnLargestNum(grid[x + 3][y] * grid[x + 2][y + 1] * grid[x + 1][y + 2] * grid[x][y + 3], maxVar); //other slant
                    if (maxVar != oldVar)
                    {
                        bestX = x;
                        bestY = y;
                        dir = 3;
                        Debug.WriteLine((x + 3) + " " + (y) + " " + (x + 2) + " " + (y + 1) + " " + (x + 1) + " " + (y + 2) + " " + (x) + " " + (y + 3));
                    }
                    oldVar = maxVar;
                }
            tbOutput11.Text = maxVar.ToString() + "  " + bestX + ", " + bestY + "  " + dir;
            for (int y = 0; y < maxX; y++)
            {
                for (int x = 0; x < maxY; x++)
                {
                    //if(x == bestX && y == bestY)
                    //    tbTest11.Text += reSizeText("(" + grid[x][y].ToString() + ")", 4, x) + " ";
                    if(dir == 1 && x- bestX < 4 && x - bestX >= 0)
                        tbTest11.Text += reSizeText("*" + grid[x][y].ToString(), 3, x) + " ";
                    else if (dir == 2 && x - bestX < 4 && x - bestX >= 0 && y - bestY < 4 && y - bestY >= 0)
                        tbTest11.Text += reSizeText("*" + grid[x][y].ToString(), 3, x) + " ";
                    else if (dir == 3 && ((x == bestX + 3 && y == bestY) || (x == bestX + 2 && y == bestY + 1) || (x == bestX + 1 && y == bestY + 2) || (x == bestX && y == bestY + 3)))
                        tbTest11.Text += reSizeText("*" + grid[x][y].ToString(), 3, x) + " ";
                    else 
                        tbTest11.Text += reSizeText(grid[x][y].ToString(), 3, x) + " ";
                }
                tbTest11.Text += "\r\n";
            }

        }
        public Int64 returnLargestNum(Int64 newNum, Int64 oldNum)
        {
            if (newNum > oldNum)
                return newNum;
            return oldNum;
        }

        private void btnInput19_Click(object sender, EventArgs e)
        {
            int[] months = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int year = 1900;
            int day = 1;
            int dayNumber = 0;
            int month = 0;
            int countSundays = 0;
            while(isntDone(year, month, dayNumber))
            {
                day++;
                dayNumber++;
                if (day == 7)
                {
                    day = 0;
                    if(year > 1900 && dayNumber == 1)
                        countSundays++;
                }
                if((isLeapYear(year) && month == 1 && dayNumber == months[month] + 1) || (!isLeapYear(year) && dayNumber == months[month]) || (isLeapYear(year) && month != 1 && dayNumber == months[month]))
                {
                    dayNumber = 0;
                    month++;
                }
                if(month == 12)
                {
                    month = 0;
                    year++;
                }

            }
            string output = "";
            switch (day)
            {
                case 0:
                    output = "Sunday";
                    break;
                case 1:
                    output = "Monday";
                    break;
                case 2:
                    output = "Tuesday";
                    break;
                case 3:
                    output = "Wednesday";
                    break;
                case 4:
                    output = "Thursday";
                    break;
                case 5:
                    output = "Friday";
                    break;
                case 6:
                    output = "Saturday";
                    break;

            }
            tbOutput19.Text = output + " How many sundays: " + countSundays;
        }
        public bool isntDone(int year, int month, int day)
        {
            if (year == 2001)
            {
                if (month == 0)
                {
                    if (day == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool isLeapYear(int year)
        {
            if (year % 4 == 0 && year % 100 != 0)
                return true;
            if (year % 4 == 0 && year % 100 == 0 && year % 400 == 0)
                return true;
            return false;
        }
        private void btnAnswer23_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            short length = 28123;
            List<int> abundantNumbers = new List<int>();
            for (short i = 11; i < length; i++)
                if (isPerfectNumber(i) == 1)
                    abundantNumbers.Add(i);
            Boolean[] list = new Boolean[length];
            for (short i = 0; i < abundantNumbers.Count; i++)
                for (short j = 0; j < abundantNumbers.Count; j++)
                {
                    int num = abundantNumbers[i] + abundantNumbers[j];
                    if (num < list.Length)
                        if (list[num] == false)
                            list[num] = true;
                }
            int sum = 0;
            for (int i = 0; i < list.Length; i++)
                if (list[i] == false)
                    sum += i;
            timer.Stop();
            tbDebug23.Text += "\r\n" + timer.Elapsed.ToString();
            tbAnswer23.Text = sum.ToString();
        }
        public int isPerfectNumber(int number)
        {
            int total = 1;
            for(int i = 2; i <= Math.Sqrt(number); i++)
                if(number % i == 0)
                {
                    total += i;
                    if(i * i != number)
                        total += number / i;
                }
            if (total == number)
                return 0;
            else if (total < number)
                return -1;
            else 
                return 1;
        }
    }
}
