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
            //tengo que implementar que revise todas las palabras no solo la primera que encuentra
            foreach (var txt in listTxt)
            {
                int index = -1;
                int pos = 0;
                int varPos = 0;
                int rel = 10;
                List<int> promedio = new List<int>();
                int hasta = txt.Count - (index + 1);
                for (int i = pos; i < queryll.Count; i++)
                {
                    if (pos == queryll.Count - 1) break;
                    index = txt.IndexOf(queryll[i], index + 1, hasta);
                    if (index == -1 && pos == i) { pos++; i = pos; hasta = txt.Count - (pos + 1); }
                    if(index != -1) 
                    {
                        if (pos == i) varPos = index;
                        int dist = distancia[i] - distancia[pos];
                        if (pos != i)
                        {
                            int res = index - varPos > distancia[i] - distancia[pos] ? (index - varPos) - dist : dist - (index - varPos);
                            if (res < rel) rel = res;
                            index = varPos;
                        }
                        hasta = (txt.Count - index) >= 10 + dist ? 10 + dist : txt.Count - (index + 2); 
                    }
                    if (i == queryll.Count - 1 && pos != queryll.Count - 1) 
                    { pos++; i= pos; index= -1; hasta = txt.Count - (pos + 1);}
                }
            }
            return new Dictionary<string, int>();
        }
    }
}
