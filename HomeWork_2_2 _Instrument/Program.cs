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
            violin.ShowInfo(violin.Name);
            // Виводимо звук інструменту
            violin.ShowSound(violin.Sound);
            // Виводимо опис інструменту
            violin.ShowDesc(violin.Desc);
            // Виводимо історію інструменту
            violin.ShowHistory(violin.History);
            Console.WriteLine("----------------------");

            //Створюємо об'єкт класу Trombone
            Trombone trombone = new Trombone();
            // Виводимо інформацію про інструмент
            trombone.ShowInfo(trombone.Name);
            // Виводимо звук інструменту
            trombone.ShowSound(trombone.Sound);
            // Виводимо опис інструменту
            trombone.ShowDesc(trombone.Desc);
            // Виводимо історію інструменту
            trombone.ShowHistory(trombone.History);
            Console.WriteLine("----------------------");

            // Створюємо об'єкт класу Ukulele
            Ukulele ukulele = new Ukulele();
            // Виводимо інформацію про інструмент
            ukulele.ShowInfo(ukulele.Name);
            // Виводимо звук інструменту
            ukulele.ShowSound(ukulele.Sound);
            // Виводимо опис інструменту
            ukulele.ShowDesc(ukulele.Desc);
            // Виводимо історію інструменту
            ukulele.ShowHistory(ukulele.History);
            Console.WriteLine("----------------------");

            // Створюємо об'єкт класу Cello
            Cello cello = new Cello();
            // Виводимо інформацію про інструмент
            cello.ShowInfo(cello.Name);
            // Виводимо звук інструменту
            cello.ShowSound(cello.Sound);
            // Виводимо опис інструменту
            cello.ShowDesc(cello.Desc);
            // Виводимо історію інструменту
            cello.ShowHistory(cello.History);
            Console.WriteLine("----------------------");


        }
    }
}
