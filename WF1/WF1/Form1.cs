namespace WF1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Tavolsag
        {
            int varosszam;
            public List<int> MaxTavolsag = new List<int>();


            public Tavolsag(int varosszam)
            {
                this.varosszam = varosszam;
            }



            int minTavolsag(int[] tavolsag, bool[] bennevan)
            {
                int minimum = int.MaxValue;
                int minind = -1;


                for (int i = 0; i < varosszam; i++)
                {
                    if (bennevan[i] == false && tavolsag[i] <= minimum)
                    {
                        minimum = tavolsag[i];
                        minind = i;

                    }
                }
                return minind;
            }



            public void MaxTav(int[] tavolsag)
            {


                int maximum = int.MinValue;
                int maxind = -1;
                for (int i = 0; i < tavolsag.Length; i++)
                {
                    if (tavolsag[i] > maximum)
                    {
                        maximum = tavolsag[i];
                        maxind = i;
                    }

                }

                this.MaxTavolsag.Add(maximum);
            }


            public void LegrovidebbUt(int[,] csucsmatrix, int ut)
            {
                int[] tavolsag = new int[varosszam];
                bool[] bennevan = new bool[varosszam];

                for (int i = 0; i < varosszam; i++)
                {
                    tavolsag[i] = int.MaxValue;
                    bennevan[i] = false;

                }
                tavolsag[ut] = 0;

                for (int s = 0; s < varosszam - 1; s++)
                {
                    int e = minTavolsag(tavolsag, bennevan);
                    bennevan[e] = true;

                    for (int j = 0; j < varosszam; j++)
                    {
                        if (!bennevan[j] && csucsmatrix[e, j] != 0 && tavolsag[e] != int.MaxValue && tavolsag[e] + csucsmatrix[e, j] < tavolsag[j])
                            tavolsag[j] = tavolsag[e] + csucsmatrix[e, j];
                    }


                }


                MaxTav(tavolsag);




            }



        }



        private void button1_Click(object sender, EventArgs e)
        {
            string[] raw_input = richTextBox1.Lines;

            int varosszam = Convert.ToInt32(raw_input[0].Split(new char[] { '\r', '\n', ' '})[0]);
            int utszam = Convert.ToInt32(raw_input[0].Split(new char[] {'\r', '\n', ' '})[1]);

            int[,] csucsmatrix = new int[varosszam, varosszam];

            for (int i = 1; i < utszam; i++)
            {
                string[] current_input = raw_input[i].Split(new char[] { '\r', '\n', ' ' });
                int a = Convert.ToInt32(current_input[0]);
                int b = Convert.ToInt32(current_input[1]);
                int w = Convert.ToInt32(current_input[2]);

                csucsmatrix[a - 1, b - 1] = w;
                csucsmatrix[b - 1, a - 1] = w;
            }

            Tavolsag t = new Tavolsag(varosszam);


            for (int i = 0; i < varosszam; i++)
            {
                t.LegrovidebbUt(csucsmatrix, i);
                Console.WriteLine(t.MaxTavolsag);
            }


            int minind = -1;
            int mintav = int.MaxValue;

            for (int i = 0; i < t.MaxTavolsag.Count; i++)
            {
                if (t.MaxTavolsag[i] < mintav)
                {
                    mintav = t.MaxTavolsag[i];
                    minind = i + 1;
                }

            }

            listBox2.Items.Add(minind.ToString());
            listBox2.Items.Add(mintav.ToString());
        }
    }
}