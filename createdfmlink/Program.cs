using System;

namespace createdfmlink
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("createdfmlink [プロジェクト ファイル名 (.cbproj)]");
                return -1;
            }

            try
            {
                MainEngine.Create(args[0]);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return -1;
            }

            return 0;
        }
    }
}
