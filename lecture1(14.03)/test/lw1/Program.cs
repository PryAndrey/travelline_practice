using System;
using System.Linq;

namespace lw1
{
    internal class Program
    {
        const string OUTPUT_PRODUCT_NAME = "Введите название продукта";
        const string OUTPUT_PRODUCT_COUNT = "Введите количество продукта";
        const string OUTPUT_USER_NAME = "Введите ваше имя";
        const string OUTPUT_ADRESS = "Введите адресс доставки";
        static public string ConfirmOrder(string name, int count, string nameProduct, string adress)
        {
            return $"Здраствуйте, {name} вы заказали {count} {nameProduct} на адресс {adress}, все верно?\n" +
                "Если все верно - нажмите Enter, или напишите что-нибудь, если что-то не так";
        }
        static public string Confirmation(string name, int count, string nameProduct, string adress)
        {
            return $"{name}!\n" +
                $"Ваш заказ {nameProduct} в количестве {count} оформлен!\n" +
                $"Ожидайте доставку по адресу {adress} к {DateTime.Now.Day + 3}";
        }

        static void Main(string[] args)
        {
            bool enter = false;
            while (!enter)
            {
                Console.WriteLine(OUTPUT_PRODUCT_NAME);
                string nameProduct = Console.ReadLine();
                if (nameProduct.Length == 0)
                    continue;

                Console.WriteLine(OUTPUT_PRODUCT_COUNT);
                string countStr = Console.ReadLine();
                if (countStr.Length == 0 || !countStr.All(char.IsDigit))
                    continue;
                int count = int.Parse(countStr);

                Console.WriteLine(OUTPUT_USER_NAME);
                string name = Console.ReadLine();
                if (nameProduct.Length == 0)
                    continue;

                Console.WriteLine(OUTPUT_ADRESS);
                string adress = Console.ReadLine();
                if (adress.Length == 0)
                    continue;

                Console.WriteLine(ConfirmOrder(name, count, nameProduct, adress));
                string answer = Console.ReadLine();

                if (answer.Length != 0)
                    continue;
                
                enter = true;
                Console.WriteLine(Confirmation(name, count, nameProduct, adress));
            }
        }
    }
}
