using System;

namespace mapz_project_zhu
{
    class Program
    {
        public int P_n_calculation(int num, double left, double right)
        {
            double ps = 0;
            int result = 0;

            ps = (-(((right - 18) * (right + 6)) / 144)) - (-(((left - 18) * (left + 6)) / 144));
            result = Convert.ToInt32(num * ps);

            return result;
        }

        public void show_results(double left, double right, int real, int calculated)
        {
            Console.WriteLine($"***\n[{left},{right}]\nCalculated: {calculated};\nReal: x-{real}\n");
        }

        public double[] left_boundary_initiation(double[] left, int start)
        {
            left[0] = start;
            for(int i = 1; i < 10; i++)
            {
                left[i] = left[i-1] + 1.2;
            }

            return left;
        }

        public double[] right_boundary_initiation(double[] right, int start)
        {
            right[0] = start + 1.2;
            for (int i = 1; i < 10; i++)
            {
                right[i] = right[i - 1] + 1.2;
            }

            return right;
        }

        public void action(int numbers, int[] real_num_x1, int[] real_num_x2,
            int[] calculation_num_x1, int[] calculation_num_x2, double[] left_x1, double[] right_x1,
            double[] left_x2, double[] right_x2)
        {
            for (int i = 0; i < numbers; i++)
            {
                my_cls my = new my_cls();

                my.calculate_x();
                my.show_result();

                for (int j = 0; j < 10; j++)
                {
                    real_num_x1[j] += my.num_in_boundaries_x1(left_x1[j], right_x1[j]);
                    real_num_x2[j] += my.num_in_boundaries_x2(left_x2[j], right_x2[j]);
                    calculation_num_x1[j] = P_n_calculation(numbers, left_x1[j], right_x1[j]);
                    calculation_num_x2[j] = P_n_calculation(numbers, left_x2[j], right_x2[j]);
                }
            }

            for (int i = 0; i < 10; i++)
            {
                show_results(left_x2[i], right_x2[i], real_num_x2[i], calculation_num_x2[i]);
            }
            for (int i = 0; i < 10; i++)
            {
                show_results(left_x1[i], right_x1[i], real_num_x1[i], calculation_num_x1[i]);
            }
        }

        static void Main(string[] args)
        {
            //INITIALIZATION
            /////////////////////////////////////////////////////////
            Program prg = new Program();
            int[] real_num_x1 = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] real_num_x2 = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] calculation_num_x1 = new int[10];
            int[] calculation_num_x2 = new int[10];

            double[] left_x1 = new double[10];//10 - number of intervals
            double[] right_x1 = new double[10];

            double[] left_x2 = new double[10];//10 - number of intervals
            double[] right_x2 = new double[10];

            left_x1 = prg.left_boundary_initiation(left_x1, -6);
            right_x1 = prg.right_boundary_initiation(right_x1, -6);

            left_x2 = prg.left_boundary_initiation(left_x2, -18);
            right_x2 = prg.right_boundary_initiation(right_x2, -18);

            ////////////////////////////////////////////////////////////
            Console.WriteLine("How many numbers:");
            int numbers = Convert.ToInt32(Console.ReadLine());

            if (numbers > 0)
            {
                prg.action(numbers, real_num_x1, real_num_x2, calculation_num_x1, 
                    calculation_num_x2, left_x1, right_x1, left_x2, right_x2);
            }

            Console.ReadLine();
        }
    }
}
