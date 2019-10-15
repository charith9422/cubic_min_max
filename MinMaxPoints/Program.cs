using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMaxPoints
{
    class Solution {

        

        public double[] GetUserInputs() {

            double[] input = new double[4];

            Console.WriteLine("Enter Coefficients");
            Console.Write("Enter a:");
            string a_input = Console.ReadLine();

            Console.Write("Enter b:");
            string b_input = Console.ReadLine();

            Console.Write("Enter c:");
            string c_input = Console.ReadLine();
            
            Console.Write("Enter d:");
            string d_input = Console.ReadLine();

            if (a_input.Equals(null) || a_input != "")
            {

                double a = Convert.ToDouble(a_input);
                if (a != 0)
                {
                    if ((b_input.Equals(null) || b_input != "") && (c_input.Equals(null) || c_input != "") && (d_input.Equals(null) || d_input != ""))
                    {
                        double b = Convert.ToDouble(b_input);
                        double c = Convert.ToDouble(c_input);
                        double d = Convert.ToDouble(d_input);
                         
                        input[0] = a;
                        input[1] = b;
                        input[2] = c;
                        input[3] = d;
                    }
                    else {
                        b_input = "0";
                        c_input = "0";
                        d_input = "0";
                        double b = Convert.ToDouble(b_input);
                        double c = Convert.ToDouble(c_input);
                        double d = Convert.ToDouble(d_input);

                        input[0] = a;
                        input[1] = b;
                        input[2] = c;
                        input[3] = d;

                    }
                    
                    //Console.WriteLine(a + " " + b + " " + c + " " + d);
                }
                else {
                    //Console.WriteLine("Coeffient a can't be zero!");
                    SolveZero(a_input, b_input, c_input, d_input);

                    //double[] newCoefficients = Equation(a,b,c,d); 
                }
            }
            else {
                Console.WriteLine("Coeffient a can't be null!");
            }

            return input;
            

        }

        public void SolveZero(string a_in, string b_in, string c_in, string d_in) {

            double a_ini = Convert.ToDouble(a_in);
            double b_ini = Convert.ToDouble(b_in);
            double c_ini = Convert.ToDouble(c_in);
            double d_ini = Convert.ToDouble(d_in);

            double[] firstDeriValues = GetFirstDerivative(a_ini, b_ini, c_ini, d_ini);
            double a_dash = firstDeriValues[1];
            double b_dash = firstDeriValues[2];


            if (a_dash != 0)
            {

                double x_dash = Math.Round((-b_dash / a_dash),3); ;
                double y_val = (b_ini * Math.Pow(x_dash, 2)) + (c_ini * x_dash) + d_ini;
                if (b_ini > 0)
                {

                    Console.WriteLine("Minimum point is (" + x_dash + "," + y_val + ")");
                }
                else
                {

                    Console.WriteLine("Maximum point is (" + x_dash + "," + y_val + ")");
                }
            }
            else {

                Console.WriteLine("There is no any maximum or minimum point");
            }
            

            

            
        }

        public double[] GetFirstDerivative(double a, double b, double c,double d) {
            double[] deriValues = new double[4];
            double a_dash = a * 3;
            double b_dash = b * 2;
            double c_dash = c * 1;
            double d_dash = d * 0;
            deriValues[0] = a_dash;
            deriValues[1] = b_dash;
            deriValues[2] = c_dash;
            deriValues[3] = d_dash;
            return deriValues;

        }
        public double [] GetSecondDerivative(double a_dash, double b_dash, double c_dash)
        {
            //GetFirstDerivative();
            double[] deriValues = new double[3];
            double a_double_dash = a_dash * 2;
            double b_double_dash = b_dash * 1;
            double c_double_dash = c_dash * 0;

            deriValues[0] = a_double_dash;
            deriValues[1] = b_double_dash;
            deriValues[2] = c_double_dash;

            return deriValues;




        }

        public void Solve() {

            double[] initialCoefficients = GetUserInputs();
            double a_ini = initialCoefficients[0];
            double b_ini = initialCoefficients[1];
            double c_ini = initialCoefficients[2];
            double d_ini = initialCoefficients[3];

            double[] firstDeriValues = GetFirstDerivative(a_ini,b_ini,c_ini,d_ini);
            double a_dash = firstDeriValues[0];
            double b_dash = firstDeriValues[1];
            double c_dash = firstDeriValues[2];
            double d_dash = firstDeriValues[3];

            double determinent = Math.Pow(b_dash, 2) - (4 * a_dash * c_dash);


            if (determinent >= 0)
            {

                double root1 = Math.Round((-b_dash + (Math.Pow(determinent, 0.5))) / (2 * a_dash), 3);
                double root2 = Math.Round((-b_dash - (Math.Pow(determinent, 0.5))) / (2 * a_dash), 3);



                double[] secondDeriValues = GetSecondDerivative(a_dash, b_dash,c_dash);
                double a_double_dash = secondDeriValues[0];
                double b_double_dash = secondDeriValues[1];
                double c_double_dash = secondDeriValues[2];



                if (root1 == root2)
                {

                    double root = root1;

                    double y_val = (a_double_dash * root) + b_double_dash;

                    double y_final = a_ini * (Math.Round(Math.Pow(root, 3), 3)) + b_ini * (Math.Round(Math.Pow(root, 2), 3)) + c_ini * (root) + d_ini;

                    if (y_val > 0)
                    {

                        Console.WriteLine("Minimum point is (" + root + "," + y_final + ")");
                    }
                    else
                    {

                        Console.WriteLine("Maximum point is (" + root + "," + y_final + ")");
                    }


                }
                else
                {

                    double y_val1 = (a_double_dash * root1) + b_double_dash;
                    double y_val2 = (a_double_dash * root2) + b_double_dash;

                    double y_final1 = (a_ini * (Math.Round(Math.Pow(root1, 3), 3))) + (b_ini * (Math.Round(Math.Pow(root1, 2), 3))) + (c_ini * (root1)) + d_ini;
                    double y_final2 = (a_ini * (Math.Round(Math.Pow(root2, 3), 3))) + (b_ini * (Math.Round(Math.Pow(root2, 2), 3))) + (c_ini * (root2)) + d_ini;

                    if ((y_val1 > 0) && (y_val2 > 0))
                    {

                        Console.WriteLine("Minimum points are (" + root1 + "," + y_final1 + ") & (" + root2 + "," + y_final2 + ")");
                    }
                    else if ((y_val1 < 0) && (y_val2 < 0))
                    {

                        Console.WriteLine("Maximum points are (" + root1 + ", " + y_final1 + ") & (" + root2 + ", " + y_final2 + ")");
                    }
                    else if ((y_val1 > 0) && (y_val2 < 0))
                    {

                        Console.WriteLine("Minimum point is (" + root1 + ", " + y_final1 + ") & Maximum point is (" + root2 + ", " + y_final2 + ")");
                    }
                    else if ((y_val1 < 0) && (y_val2 > 0))
                    {

                        Console.WriteLine("Maximum point is (" + root1 + ", " + y_final1 + ") & Minimum point is (" + root2 + ", " + y_final2 + ")");
                    }
                }
            }
            else {

                Console.WriteLine("No real roots in derived equation!");
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Solution s1 = new Solution();
            s1.Solve();
            Console.ReadKey();
        }
    }
}
