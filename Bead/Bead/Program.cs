namespace Bead
{
     class Program
    {
        public struct telephely
        {
            public int A;
            public int B;
            public int weight;
        }
        static void Main(string[] args)
        {
            List<telephely> T=new();
            string line = Console.ReadLine();
            var l = line.Split(' ');
            int N = int.Parse(l[0]);
            int M = int.Parse(l[1]);

            for (int i = 0; i < M; i++)
            {

                string l2=Console.ReadLine();
                var tokens = l2.Split(' ');
                T.Add(new telephely
                {
                    A = int.Parse(tokens[0]),
                    B = int.Parse(tokens[1]),
                    weight = int.Parse(tokens[2])
                });;


            }

           
        }
    }
}