using System;

namespace NumbersGame
{
    class Program
    {
        //Main Method
        static void Main(string[] args)
        {

            try
            {
                StartSequence();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong...\n {0}.", e.Message);
            }
            finally
            {
                Console.WriteLine("The program is finished");
            }
        }


        //StartSequence Method
        static void StartSequence()
        {
            try
            {
                //Setting up variables
                int arraySize, sum, product;
                decimal quotient;

                //Setting up the array
                Console.WriteLine("Enter a number greater than zero");
                arraySize = Convert.ToInt32(Console.ReadLine());
                int[] numArray = new int[arraySize];

                //Calling the other methods
                Populate(numArray);
                sum = GetSum(numArray);
                product = GetProduct(numArray, sum);
                quotient = GetQuotient(product);

                //Because I can't use global variables compute everything recorded in the other methods
                int mult = product / sum;
                decimal denom = product / quotient;
                string arrayList = string.Join(",", numArray);

                //The final messages
                Console.WriteLine($"Your array size is: {arraySize}");
                Console.WriteLine($"The numbers in the array are: {arrayList}");
                Console.WriteLine($"The sum of the array is: {sum}");
                Console.WriteLine($"{sum} * {mult} = {product}");
                Console.WriteLine($"{product} / {denom} = {quotient}");
            }

            //The catch statements, didn't say to use throw here so I didn't
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        //Populate Method
        static int[] Populate(int[] arrIn)
        {
            //Setting up this method's variables
            int size = arrIn.Length;
            int temp;

            //For each location in the array ask for a user input.
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Please enter number {0} of {1}", i+1, size);
                //The instructions say to store as string then covert but the instructor's example does this and it is a one line solution so I like it better
                temp = Convert.ToInt32(Console.ReadLine());
                arrIn[i] = temp;
            }

            //the return
            return arrIn;

            //No exceptions, as defined by the instructions
        }

        //GetSum Method
        static int GetSum(int[] arrIn)
        {
            //Setting up this method's variables
            int size = arrIn.Length;
            int sum = 0;

            //For each location in the array ask for a user input.
            for (int i = 0; i < size; i++)
            {
                sum += arrIn[i];
            }

            //Throw error if sum is under 20
            if (sum < 20)
            {
                throw new Exception($"Value of {sum} is to low and must be at least 20");
            }

            //Return computed sum
            return sum;
        }

        //GetProduct Method
        static int GetProduct(int[] arrIn, int sumIn)
        {

            try
            {
                //Setting up this method's variables
                int size = arrIn.Length;
                int temp, product;

                //Ask the user to select one of their values in the array
                Console.WriteLine($"Please enter number between 1 and {size}");
                //The instructions say to store as string then covert but the instructor's example does this and it is a one line solution so I like it better
                temp = Convert.ToInt32(Console.ReadLine());
                //Subtract one from the user input to handle zero based indexing
                temp = arrIn[temp - 1];

                //Compute the product
                product = sumIn * temp;

                //return statement
                return product;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }


        }

        //GetQuotient Method
        static decimal GetQuotient(int product)
        {
            try
            {
                //Setting up this method's variables
                decimal temp;
                decimal decProduct = Convert.ToDecimal(product);

                //Ask the user to give a number to divide the product by
                Console.WriteLine($"Please enter number to divide your product {product} by");
                //The instructions say to store as string then covert but the instructor's example does this and it is a one line solution so I like it better
                temp = Convert.ToDecimal(Console.ReadLine());

                //Compute the quotient
                decimal quotient = decimal.Divide(decProduct, temp);

                //return statement
                return quotient;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
