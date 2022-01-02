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
            Dictionary<string, List<int>> Txt1 = new Dictionary<string, List<int>>();
            Txt1.Add("a", new List<int>() { 4, 56, 242, 255, 534, 711 });
            Txt1.Add("b", new List<int>() { 7, 59, 246, 256, 554, 723 });
            Txt1.Add("c", new List<int>() { 23, 74, 286, 226, 600, 773 });
            Dictionary<string, List<int>> Txt2 = new Dictionary<string, List<int>>();
            Txt2.Add("a", new List<int>() { 4, 56, 242, 255, 534, 711 });
            Txt2.Add("b", new List<int>() { 34, 69, 256, 266, 584, 743 });
            Txt2.Add("c", new List<int>() { 47, 81, 276, 286, 600, 773 });
            Dictionary<string, List<int>> Txt3 = new Dictionary<string, List<int>>();
            Txt3.Add("a", new List<int>() { 4, 56, 242, 255, 534, 711 });
            Txt3.Add("b", new List<int>() { 5, 57, 243, 256, 554, 723 });
            Txt3.Add("c", new List<int>() { 7, 59, 286, 226, 600, 773 });
            List<Dictionary<string, List<int>>> listTxt = new List<Dictionary<string, List<int>>>() { Txt1, Txt2, Txt3};

            var x = Distancia(nombresTxt, listTxt, queryll, distancia);
            foreach (var item in x)
            {
                Console.WriteLine(item.Key + "  " + item.Value);
            }
            Console.ReadLine();
        }
        public static Dictionary<double, string> Distancia(List<string> nombresTxt, List<Dictionary<string, List<int>>> listDiccionary, List<string> queryll, List<int> distancia)
        {
            Dictionary<double, string> resultados = new Dictionary<double, string>();
            int contTxt = 0;
            foreach (var diccionario in listDiccionary)
            {
                List<int> promedio = new List<int>();

                for (int i = 0; i < queryll.Count-1; i++)
                {
                    for (int j = i+1; j < queryll.Count; j++)
                    {
                        int rel = 10;
                        int dif = distancia[j] - distancia[i];
                        foreach (var indexI in diccionario[queryll[i]])
                        {
                            foreach (var indexJ in diccionario[queryll[j]])
                            {
                                int res = indexJ - indexI > dif ? (indexJ - indexI) - dif : dif - (indexJ - indexI);
                                if (res < rel) rel = res;
                            }
                        }
                        promedio.Add(10-rel);
                    }
                }
                double pro = promedio.Average();
                resultados.Add(pro, nombresTxt[contTxt]); contTxt++;
            }
            resultados.OrderByDescending(result => result.Key);
            return resultados;
        }
    }
}
