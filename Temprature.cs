using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessData
{
    public class Temprature
    {
        public int Dy { get; set; }
        public double MxT { get; set; }
        public double MnT { get; set; }

        public Temprature() { } 
        public Temprature(string str)
        {
            Dy = Convert.ToInt16(str.Substring(2, 2));
            string strMxt = str.Substring(6, 4);
            string strMnt = str.Substring(10, 4);

            if(strMxt.IndexOf('*')>-1)
            strMxt = strMxt.Remove(strMxt.IndexOf('*'),1);
            if (strMnt.IndexOf('*') > -1)
                strMnt = strMnt.Remove(strMnt.IndexOf('*'), 1);

            MxT = Convert.ToDouble(strMxt);
            MnT = Convert.ToDouble(strMnt);

        }
    }
}
