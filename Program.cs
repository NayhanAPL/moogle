using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoogleNY
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public static Dictionary<string, int> RelevanciaDist(List<List<string>> listTxt, List<string> queryll, List<int> distancia)
        {

            foreach (var txt in listTxt)
            {
                int index = -1;
                int pos = 0;
                int ind = 0;
                bool finCad = false;
                int hasta = txt.Count - (index + 1);
                for (int i = pos; i < queryll.Count; i++)
                {
                    
                    index = txt.IndexOf(queryll[i], index + 1, hasta);
                    if (index == -1 && finCad) { pos++; i = pos; hasta = txt.Count - (index + 1); }
                    else 
                    {
                        hasta = (txt.Count - index) >= 10 ? 10 : txt.Count - (index + 1); 

                    }
                }
            }
            return new Dictionary<string, int>();
        }
    }
}
