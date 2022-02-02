using System;

namespace TolleLib
{
    public class Class1
    {

        public int Zahl { get; set; } = 16;
        public void SagHallo()
        {
            Console.WriteLine("Hallo von der Besten Lib222");
        }


        public void LadeAlleDaten()
        {

            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {

                throw new Exception("Schade", ex);

            }
        }
    }
}
