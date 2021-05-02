using FuzzyLogicPCL;
using FuzzyLogicPCL.FuzzySets;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            FuzzySystem system = new FuzzySystem("GPS Zoom level");

            //INPUT: Variable lingÜística "distancia" con los limites de: 0 a 500.000 m
            LinguisticVariable distancia = new LinguisticVariable("Distancia", 0, 500000);

            //INPUT: Variable lingÜística "velocidad" con limites de: 0 a 200 Km/h
            LinguisticVariable velocidad = new LinguisticVariable("Velocidad", 0, 200);

             //Agregar el valor lingÜístico a la variable de entrada "distancia"
            distancia.AddValue(new LinguisticValue("Pequenia",new LeftFuzzySet(0, 500000,30, 50)));
            distancia.AddValue(new LinguisticValue("Media",new TrapezoidalFuzzySet(0, 500000, 40, 50, 100, 150)));    
            distancia.AddValue(new LinguisticValue("Grande",new RightFuzzySet(0, 500000, 100, 150))); 

             //Agregar el valor lingÜístico a la variable de entrada "velocidad"   
            velocidad.AddValue(new LinguisticValue("Baja",new LeftFuzzySet(0, 200,20, 30)));  
            velocidad.AddValue(new LinguisticValue("Media",new TrapezoidalFuzzySet(0, 200, 20, 30, 70, 80)));   
            velocidad.AddValue(new LinguisticValue("Rapida",new TrapezoidalFuzzySet(0, 200, 70, 80, 90, 110)));     
            velocidad.AddValue(new LinguisticValue("MuyRapida",new RightFuzzySet(0, 200, 90, 100))); 

            //Agregar al sistema las varibles: distancia y velocidad
            system.addInputVariable(distancia);
            system.addInputVariable(velocidad);

            //OUTPUT: Variable lingÜística "zoom" con los limites de: 0 a 5
            LinguisticVariable zoom = new LinguisticVariable("Zoom", 0, 5);

             //Agregar el valor lingÜístico a la variable de entrada "zoom"
            zoom.AddValue(new LinguisticValue("Bajo",new LeftFuzzySet(0, 5, 1, 2)));
            zoom.AddValue(new LinguisticValue("Normal",new TrapezoidalFuzzySet(0, 5, 1, 2, 3, 4)));    
            zoom.AddValue(new LinguisticValue("Grande",new RightFuzzySet(0, 5, 3, 4))); 

            system.addOutputVariable(zoom);

            //Creación de reglas
            system.addFuzzyRule("IF Distancia IS Pequenia AND Velocidad IS Baja THEN Zoom IS Normal");
            system.addFuzzyRule("IF Distancia IS Pequenia AND Velocidad IS Media THEN Zoom IS Normal");
            system.addFuzzyRule("IF Distancia IS Pequenia AND Velocidad IS Rapida THEN Zoom IS Grande");
            system.addFuzzyRule("IF Distancia IS Pequenia AND Velocidad IS MuyRapida THEN Zoom IS Grande");

            system.addFuzzyRule("IF Distancia IS Media AND Velocidad IS Baja THEN Zoom IS Bajo"); 
            system.addFuzzyRule("IF Distancia IS Media AND Velocidad IS Media THEN Zoom IS Normal");
            system.addFuzzyRule("IF Distancia IS Media AND Velocidad IS Rapida THEN Zoom IS Normal");
            system.addFuzzyRule("IF Distancia IS Media AND Velocidad IS MuyRapida THEN Zoom IS Grande");

            system.addFuzzyRule("IF Distancia IS Grande AND Velocidad IS Baja THEN Zoom IS Bajo"); 
            system.addFuzzyRule("IF Distancia IS Grande AND Velocidad IS Media THEN Zoom IS Bajo");
            system.addFuzzyRule("IF Distancia IS Grande AND Velocidad IS Rapida THEN Zoom IS Bajo");
            system.addFuzzyRule("IF Distancia IS Grande AND Velocidad IS MuyRapida THEN Zoom IS Bajo");
            

/*           //CASO PRUEBA 1
            system.SetInputVariable(distancia, 70.0);
            system.SetInputVariable(velocidad, 35.0);
            Console.WriteLine("\n"+"CASO PRUEBA 1--> Distancia 70 m,Velocidad 35 km/h "+  "\n" +"Resultado: "+system.Solve()+ "\n");

            //CASO PRUEBA 2
            system.SetInputVariable(distancia, 70.0);
            system.SetInputVariable(velocidad, 35.0);
            Console.WriteLine("\n"+"CASO PRUEBA 2--> Distancia 70 m,Velocidad 35 km/h "+  "\n" +"Resultado: "+system.Solve()+ "\n");

           //CASO PRUEBA 3
            system.SetInputVariable(distancia, 40.0);
            system.SetInputVariable(velocidad, 72.5);
            Console.WriteLine("\n"+"CASO PRUEBA 3--> Distancia 40 m,Velocidad 72.5 km/h "+  "\n" +"Resultado: "+system.Solve()+ "\n");

            //CASO PRUEBA 4
            system.SetInputVariable(distancia, 110.0);
            system.SetInputVariable(velocidad, 100.0);
            Console.WriteLine("\n"+"CASO PRUEBA 4--> Distancia 110 m,Velocidad 100 km/h "+  "\n" +"Resultado: "+system.Solve()+ "\n");
*/
            //CASO PRUEBA 5
            system.SetInputVariable(distancia, 160.0);
            system.SetInputVariable(velocidad, 45.0);
            Console.WriteLine("\n"+"CASO PRUEBA 5--> Distancia 160 m,Velocidad 45 km/h "+  "\n" +"Resultado: "+system.Solve()+ "\n");
/**/
        }
    }
}
