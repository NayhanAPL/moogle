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
            List<string> queryll = new List<string>() { "a", "b", "c" };
            List<int> distancia = new List<int>() { 0,1,3};
            List<string> nombresTxt = new List<string>() { "txt1", "txt2", "txt3", "txt4", "txt5", "txt6", };
            List<string> Txt1 = new List<string>() { "j", "a", "s", "f", "c", "a", };
            List<string> Txt2 = new List<string>() { "a", "b", "c", "c", "u", "j", };
            List<string> Txt3 = new List<string>() { "j", "m", "d", "n", "x", "v", };
            List<string> Txt4 = new List<string>() { "v", "b", "c", "f", "z", "h", };
            List<string> Txt5 = new List<string>() { "x", "n", "s", "d", "s", "j", };
            List<string> Txt6 = new List<string>() { "a", "x", "s", "f", "z", "b", };
            List<List<string>> listTxt = new List<List<string>>() { Txt1, Txt2, Txt3, Txt4, Txt5, Txt6 };

            var x = RelevanciaDist(nombresTxt, listTxt, queryll, distancia);
            foreach (var item in x)
            {
                Console.WriteLine(item.Key + "  " + item.Value);
            }
           
        }
        public static Dictionary<double, string> RelevanciaDist(List<string> nombresTxt, List<List<string>> listTxt, List<string> queryll, List<int> distancia)
        {
            int contTxt = 0;
            Dictionary<double, string> resultados = new Dictionary<double, string>();
            foreach (var txt in listTxt)
            {
                contTxt++;
                int index = -1;
                int pos = 0;
                int varPos = 0;
                List<int> rel = new List<int>(queryll.Count - 1); for (int i = 0; i < rel.Count; i++) { rel[i] = 10; }
          
                List<int> promedio = new List<int>();
                int hasta = txt.Count - (index + 1);
                for (int i = pos; i < queryll.Count; i++)
                {
                    if (pos == queryll.Count - 1) break;
                    index = txt.IndexOf(queryll[i], index + 1, hasta);
                    if (index == -1 && pos == i) { pos++; i = pos-1; hasta = txt.Count - (varPos + 1); promedio.Add(10-rel); rel = 10; }
                    if(index != -1) 
                    {
                        if (pos == i) varPos = index;
                        int dist = distancia[i] - distancia[pos];
                        if (pos != i)
                        {
                            List<int> res = new List<int>(queryll.Count-1);
                            res[0] = index - varPos > distancia[i] - distancia[pos] ? (index - varPos) - dist : dist - (index - varPos);
                            if (res < rel) rel = res;
                            index = varPos; 
                        }
                        hasta = (txt.Count - index) >= 10 + dist ? 10 + dist : txt.Count - (index + 2); 
                    }
                    if (index == -1 && pos != i) index = varPos;
                    if (i == queryll.Count - 1 && pos != queryll.Count - 1) 
                    { i= pos-1; index= varPos; hasta = txt.Count - (varPos + 2);}
                }
                double orden = promedio.Average();
                resultados.Add(orden, nombresTxt[contTxt]);
                
            }
            Dictionary<double, string> ordenado = new Dictionary<double, string>();
            for (int i = 0; i < nombresTxt.Count; i++)
            {
                ordenado.Add(resultados.Max().Key, resultados.Max().Value);
                resultados.Remove(resultados.Max().Key);
            }
            
            return ordenado;
        }
    }
}
