using System.Text;




namespace HomeWork_2_2__Instrument
{

    internal class Program
    {

        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = Encoding.GetEncoding(1251);


            Violin violin = new Violin();
            // Виводимо інформацію про інструмент
            violin.ShowInfo();
            // Виводимо звук інструменту
            violin.ShowSound();
            // Виводимо опис інструменту
            violin.ShowDesc();
            // Виводимо історію інструменту
            violin.ShowHistory();
            Console.WriteLine("----------------------");
            // Створюємо об'єкт класу Trombone
            Trombone trombone = new Trombone();
            // Виводимо інформацію про інструмент
            trombone.ShowInfo();
            // Виводимо звук інструменту
            trombone.ShowSound();
            // Виводимо опис інструменту
            trombone.ShowDesc();
            // Виводимо історію інструменту
            trombone.ShowHistory();
            Console.WriteLine("----------------------");
            // Створюємо об'єкт класу Ukulele
            Ukulele ukulele = new Ukulele();
            // Виводимо інформацію про інструмент
            ukulele.ShowInfo();
            // Виводимо звук інструменту
            ukulele.ShowSound();
            // Виводимо опис інструменту
            ukulele.ShowDesc();
            // Виводимо історію інструменту
            ukulele.ShowHistory();
            Console.WriteLine("----------------------");
            // Створюємо об'єкт класу Cello
            Cello cello = new Cello();
            // Виводимо інформацію про інструмент

            cello.ShowInfo();
            // Виводимо звук інструменту
            cello.ShowSound();
            // Виводимо опис інструменту
            cello.ShowDesc();
            // Виводимо історію інструменту
            cello.ShowHistory();
            Console.WriteLine("----------------------");


        }
    }
}
