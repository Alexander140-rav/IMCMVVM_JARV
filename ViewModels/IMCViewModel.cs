using System.ComponentModel;
using System.Windows.Input;
using IMCMVVM_JARV.Models;

namespace IMCMVVM_JARV.ViewModels
{
    public class IMCViewModel : INotifyPropertyChanged
    {
        public string PesoT { get; set; } = "";
        public string EstaturaT { get; set; } = "";

        private string resultado = "Ingresa tus datos";

        public string Resultado
        {
            get { return resultado; }
            set
            {
                resultado = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Resultado)));
            }
        }

        public ICommand CalcularCommand { get; }

        public IMCViewModel()
        {
            CalcularCommand = new Command(Calcular);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Calcular()
        {
            // Validar Peso
            if (!double.TryParse(PesoT, out double peso) || !double.IsFinite(peso) || peso <= 0)
            {
                Resultado = "Escribe un peso válido mayor que cero.";
                return;
            }

            // Validar Estatura
            if (!double.TryParse(EstaturaT, out double estatura) || !double.IsFinite(estatura) || estatura <= 0)
            {
                Resultado = "Escribe una estatura válida mayor que cero.";
                return;
            }

            // Instanciar Modelo
            Persona persona = new Persona
            {
                Peso = peso,
                Estatura = estatura
            };

            double imc = persona.CalcularIMC();

            if (!double.IsFinite(imc))
            {
                Resultado = "Revisa el peso y estatura.";
                return;
            }

            // Clasificación del IMC
            string clasificacion = "";

            if (imc < 18.5)
            {
                clasificacion = "Peso bajo";
            }
            else if (imc < 25.0)
            {
                clasificacion = "Peso normal";
            }
            else if (imc < 30.0)
            {
                clasificacion = "Sobrepeso";
            }
            else
            {
                clasificacion = "Obesidad";
            }

            // Mostrar IMC y la clasificación obtenida
            Resultado = $"IMC: {imc:F2} - {clasificacion}";
        }
    }
}