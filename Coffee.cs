using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XuRzAsg4
{
    class Coffee
    {
        public readonly string name;
        private float C;//unit cost
        private float D;//demand
        private float K;//order cost
        private readonly float H;//holding cost
        public static int ccount;
        public static float wcount;
        string brandName;//formated brandname
        float fq, fc, fcy;//formated Q,TAC,T

        public Coffee()
        {
            //ccount++;
        }

        public Coffee(string name, double D, double C)
        {
            this.name = name;
            this.C = (float)C;
            this.D = (float)D;
            this.K = 20;
            this.H = (float)0.3 * this.C;
            ccount++;
            wcount += Q(this.D, this.K, this.H);
        }

        public Coffee(Coffee oldcoffee)
        {
            this.name = oldcoffee.name;
            this.C = oldcoffee.C;
            this.D = oldcoffee.D;
            this.K = oldcoffee.K;
            this.H = oldcoffee.H;
            ccount++;
            wcount += Q(D,K,H);
        }

        ~Coffee()
        {
            ccount--;
        }

        public float Q(double D, double K, double H)
        {
            return (float)System.Math.Sqrt(2 * D * K / H);
        }

        public float TAC(double D, double K, double H, double C)
        {
            return (float)(Q(D,K,H) / 2 * H + D * K / Q(D,K,H) + D * C);
        }

  
        public virtual string toString()
        {
            brandName = this.name.PadRight(20);//20 spaces

            fq = (float)Math.Round(this.Q(D,K,H), 2);
            String q = fq.ToString("0.00");//covert to demecial 0.00
            q = q.PadRight(15);

            fc = (float)Math.Round(this.TAC(D,K,H,C), 2);
            String c = fc.ToString("0.00");
            c = c.PadRight(15);

            return (brandName + q + c);
        }
    }
}
 