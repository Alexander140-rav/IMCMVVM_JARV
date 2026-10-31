using System;
using System.Collections.Generic;
using System.Text;

namespace IMCMVVM_JARV.Models
{
    public class Persona
    {
        // Datos Numericos necesarios para el calculo de IMC

        //variables 
        public double Estatura { get; set; }
        public double Peso { get; set; }

        
        // Metodo que devuelve el IMC utilizando los datos de la persona 
        public double CalcularIMC()
        {
            // Formula para calcular el IMC
            return Peso / (Estatura * Estatura);
        }
    }
}
