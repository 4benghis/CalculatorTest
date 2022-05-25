using DataService.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DataService.Diagnostics.Models;
using System.Collections;

namespace DataService.Calculator
{
    public class SimpleCalculator : ISimpleCalculator, IDiagnostics
    {
        public int Add(int start, int amount)
        {
            int result = start + amount;
            LogToDebugger(result, (int)OperatorType.ADD);
            return start + amount;
        }

        public float Divide(int start, int by)
        {
            float result = (float)start / (float)by;
            LogToDebugger(result, (int)OperatorType.DIVIDE);
            return result;
        }

        public int Multiply(int start, int by)
        {
            int result = start * by;
            LogToDebugger(result, (int)OperatorType.MULTIPLY);
            return result;
        }

        public int Subtract(int start, int amount)
        {
            int result = start - amount;
            LogToDebugger(result, (int)OperatorType.SUBTRACT);
            return result;
        }

        public void LogToDatabase(float result, int Operator)
        {
            //I couldn't remember how to set create a database just inside Visual Studio, but would likely use linq, or an entity framework.

            //using LINQ
            //using (var db = new dbCalculatorContext)
            //{
            //    Diagnostic newDiagnostic = new Diagnostic()
            //    {
            //        MonitoringDescriptionAttribute = string.Format("Did a calculation: {0}. RESULT: {1}", Operation, result.ToString()),
            //        OperationType = Operator,
            //        Success = true,
            //    };

            //    db.Diagnostics.InsertOnSubmit(newDiagnostic);
            //    db.submitChanges();
            //}
        }

        public void LogToDebugger(float result, int Operator)
        {
            var Operation = ((OperatorType)Operator).ToString();
            Debug.WriteLine(string.Format("Did a calculation: {0}. RESULT: {1}", Operation, result.ToString()));
        }

        public object GetPrimeNumber(int Number)
        {
            AllPrimes();
            var result = primes[Number];
            return result;
        }
        
        // initializing a max value
        static int MAX_SIZE = 1000000;
        static ArrayList primes = new ArrayList();

        static void AllPrimes()
        {
            // Create a boolean array "IsPrime[0-1000000]"and initialize all entries it as true.
            // A value in IsPrime[i] will finally be false if i is Not a IsPrime, else true.

            bool[] IsPrime = new bool[MAX_SIZE];

            // Init all as prime, process of elimination.
            for (int i = 0; i < MAX_SIZE; i++)
            {
                IsPrime[i] = true;
            }

            // Start with 2, we know 1 isn't prime.
            for (int p = 2; p * p < MAX_SIZE; p++)
            {
                // If IsPrime[p] is not changed, then it is a prime and it's multiples need to be checked.
                if (IsPrime[p] == true)
                {
                    // Update all multiples of p greater than or equal to the square of it
                    // numbers which are multiple of p and are less than p^2 are already been marked by a previous prime.
                    for (int i = p * p; i < MAX_SIZE; i += p)
                    {
                        IsPrime[i] = false;
                    }
                        
                }
            }

            // Store all prime numbers
            for (int p = 2; p < MAX_SIZE; p++)
            {
                if (IsPrime[p] == true)
                {
                    primes.Add(p);
                }
            }


        }
    }
}
