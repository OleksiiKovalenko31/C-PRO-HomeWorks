namespace HomeWork_3_Interface_and_Abstract_Klass

{
    public class Program
    {
        static void Main(string[] args)
        {
          MyArray randomInt = new MyArray(10);
            randomInt.Show();
            Console.WriteLine("---------------------------");
            randomInt.Show(randomInt.ToString());
            Console.WriteLine("---------------------------"); 
            randomInt.IntMax(randomInt._array);
            randomInt.IntMin(randomInt._array);
            randomInt.FloatAvg(randomInt._array);
            randomInt.BoolSearh(randomInt._array);
            Console.WriteLine("---------------------------");

            randomInt.SortByParam(true ,randomInt._array);
            randomInt.SortByParam(false, randomInt._array);



        }
    }
}
