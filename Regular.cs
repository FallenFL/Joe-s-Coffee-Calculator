using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XuRzAsg4
{
    class Regular : Coffee
    {
        enum cfDensity { light, medium, dark };
        public new readonly string name;
        private float C;//unit cost
        private float D;//demand
        private float K;//order cost
        private readonly float H;//holding cost
        private float density;
    
        string brandName;//formated brandname
        float fq, fc, fd,fu,fdetail;//formated Q,TAC,T

        public Regular()
        {
            //ccount++;
        }

        public Regular(string name, double D, double C, double density)
        {
            this.name = name;
            this.C = (float)C;
            this.D = (float)D;
            this.K = 20;
            this.H = (float)0.3 * this.C;
            this.density = (float)density;
            if (D < density) this.D = (float)density;
            ccount++;
            wcount += Q(D, K, H);
        }

        public Regular(Regular oldcoffee)
        {
            this.name = oldcoffee.name;
            this.C = oldcoffee.C;
            this.D = oldcoffee.D;
            this.K = oldcoffee.K;
            this.H = oldcoffee.H;
            this.density = oldcoffee.density;
            ccount++;
            wcount += Q(D, K, H);
        }

        ~Regular()
        {
            ccount--;
        }

        public override string toString()
        {
            brandName = this.name.PadRight(13);//20 spaces

            fq = (int)Math.Round(Q(D, K, H), 2);
            String q = fq.ToString();
            q = q.PadRight(8);

            fd = (int)Math.Round(D, 2);
            String d = fd.ToString();
            d = d.PadRight(8);

            fc = (float)Math.Round(TAC(D, K, H, C), 2);
            String c = fc.ToString("0.00");//covert to demecial 0.00
            c = c.PadRight(8);

            fu = (float)Math.Round(C, 2);
            String u = fu.ToString("0.00");
            u = u.PadRight(8);

            fdetail = (int)Math.Round(density, 2);
            cfDensity newDensity = (cfDensity)fdetail; 
            String de = newDensity.ToString();
            de = de.PadRight(8);

            return (brandName + u + d + de + q + c);
        }
    }
}
