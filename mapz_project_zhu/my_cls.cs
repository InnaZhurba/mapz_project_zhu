using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mapz_project_zhu
{
    public class my_cls
    {
        private Random rnd = new Random();//використання класу, що надає випадкові числа 
        private double[] result { get; set; }//значення, х_1 та х_2
       

        public my_cls()//конструктор класу
        {
            result = new double[2];//ініціалізація змінної зі значеннями
        }

        private double NEXT(double MinValue, double MaxValue)//функція обирання випадкового числа із заданого інтервалу(проміжку)
        {
            return rnd.NextDouble() * (MaxValue - MinValue) + MinValue;
        }

        public void calculate_x()//обчислюємо х_1 та х_2 за функцією оберненою, що ми обрахували в етапі 3 курсової роботи
        {
            double rand = NEXT(0, 1);

            result[0] = -6 + 12 * Math.Sqrt(1 - rand);
            result[1] = -6 - 12 * Math.Sqrt(1 - rand);
        }

        public void show_result()//вивід х_1 та х_2
        {
            Console.WriteLine($"+: {result[0]}; -: {result[1]}\n");
        }

        public int num_in_boundaries_x1(double left, double right)//перевірка чи х_1 входить в інтервал
        {
            //при попаданні в інтервал повертається 1, що буде додане до загальної к-сті попадань
            if (result[0] >= left && result[0] <= right)
                return 1;

            return 0;
        }

        public int num_in_boundaries_x2(double left, double right)//перевірка чи х_2 входить в інтервал
        {
            //при попаданні в інтервал повертається 1, що буде додане до загальної к-сті попадань
            if (result[1] >= left && result[1] <= right)
                return 1;

            return 0;
        }
    }
}
