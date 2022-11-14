/*Crear una aplicación que solicite la temperatura diaria promedio para el lapso de un mes.
 Al finalizar se debe informar cual es la temperatura mínima registrada,
 cual la máxima y el promedio de temperatura mensual.
 
 Se archivo en una lista
 se recupero del archivo la lista y se convirtio en Array*/

using System;
using System.IO;
using System.Collections.Generic;
namespace TP8_ej7Plus
{
    class Program
    {       
        static void Main(string[] args)
        {
            Console.Clear();
            const int dia = 7;
            const int semana = 4;
            int minima = 1000;
            int diaDeMinima  = 0;
            int maxima = -1000;
            int diaDeMaxima  = 0;
            int sumaTemperatura = 0;
            int promedio = 0;
            string entrada = "";
            int [,] arregloTemperatura = new int [semana, dia];
            for (int i = 0; i < semana; i++)
            {
                for (int e = 0; e < dia; e++)
                {
                    Console.WriteLine("Ingrese la temperatura del "+ ((i*7)+(e+1))+"° dia");
                    arregloTemperatura[i,e] = Convert.ToInt32(Console.ReadLine());
                }
            }

//hacer operaciones
            for (int i = 0; i < semana; i++)
            {
                for (int e = 0; e < dia; e++)
                {
                    if (arregloTemperatura[i,e]<minima)
                    {
                        minima = arregloTemperatura[i,e];
                        diaDeMinima = (i*7)+(e+1);
                    }
                    if (arregloTemperatura[i,e]>maxima)
                    {
                        maxima = arregloTemperatura[i,e];
                        diaDeMaxima = (i*7)+(e+1);
                    }
                    sumaTemperatura = sumaTemperatura + arregloTemperatura[i,e];
                }
            }
            promedio = sumaTemperatura/arregloTemperatura.Length;

//mostrar resultados
            Console.WriteLine("A partir de las temperaturas del mes se obtuvieron los siguientes resultados:");
            Console.WriteLine("La temperatura míminma fue de "+ minima+"° C. el día "+diaDeMinima);
            Console.WriteLine("La temperatura Máxima fue de "+ maxima+"° C. el día "+diaDeMaxima);
            Console.WriteLine("El promedio de temperaturas registradas en el mes fue de "+ promedio +"° C.");

//convertir array en lista Y archivar
            List <String> lista = new List<string>();
            for (int i = 0; i < semana; i++)
            {
                for (int e = 0; e < dia; e++)
                {
                    lista.Add (((i*7)+(e+1))+"° dia: "+Convert.ToString(arregloTemperatura[i,e])+"° C.");
                }
            }
            File.WriteAllLines("temperaturas mensuales.txt", lista);

//salir o mostrar los dias archivados en la lista
            string [] arregloNuevo=lista.ToArray();
            Console.WriteLine("['D' para mostrar los detalles de temperatura diarios] - [cualquier otra tecla para salir]");
            entrada = Console.ReadLine();
            switch (entrada)
            {
            case "d" or "D":
                for (int i = 0; i < 28; i++)
                {
                        Console.WriteLine(arregloNuevo[i]);
                }
                break;
                default:
                break;
            }
        }
    }
}