using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace MyApp// Note: actual namespace depends on the project name.
{
    internal class Program
    {
        class ConsultaMedica
        {
            public string? NombrePaciente { get; set; }

            public DateTime FechaCita { get; set; }

            public string? RazonConsulta { get; set; }

            public double CostoConsulta { get; set; }
        }

        private static List<ConsultaMedica> citas = new List<ConsultaMedica>();
        static void Main(string[] args)
        {
            Console.WriteLine("\n---------CITAS DE CLINCIA DENTISTA---------------");
            int opcion;
            do
            {
                Console.WriteLine("1. Agregar una nueva cita");
                Console.WriteLine("2. Mostrar citas");
                Console.WriteLine("3. Salir");
                Console.WriteLine("Seleccione una opcion");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            AgregarCita();
                            break;

                        case 2:
                            MostrarCitas();
                            break;

                        case 3:
                            Console.WriteLine("\nSaliendo del programa");
                            break;

                        default:
                            Console.WriteLine("Opcion no valida intentelo de nuevo");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ingrese un numero valido");
                }

            } while (opcion != 3);
        }
        static void AgregarCita()
        {
            ConsultaMedica consulta = new ConsultaMedica();

            Console.WriteLine($"Ingrese los datos para la cita:");
            Console.Write("Nombre del paciente: ");
            consulta.NombrePaciente = Convert.ToString(Console.ReadLine());

            Console.Write("Fecha de la cita (DD/MM/YYYY HH:MM): ");
            consulta.FechaCita = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Razon de la consulta: ");
            consulta.RazonConsulta = Convert.ToString(Console.ReadLine());

            Console.Write("Costo de la consulta: ");
            consulta.CostoConsulta = Convert.ToDouble(Console.ReadLine());

            citas.Add(consulta);

            // CREAR EL NOMBRE DEL ARCHIVO SEGUN EL FORMATO ESPECIFICADO
            string nombreArchivo = $"Cita{citas.Count:D3}_{consulta.NombrePaciente}.txt";
            GuardarConsultaEnArchivo(consulta, nombreArchivo);
        }
        static void GuardarConsultaEnArchivo(ConsultaMedica consulta, string nombreArchivo)
        {
            // AGREGAR EL NUMERO DE ITERACION AL NOMBRE DEL ARCHIVO
            string nombreCompleto = $"{nombreArchivo}#{consulta.NombrePaciente}.txt";

            // CREAR EL CONTENIDO DEL ARCHIVO
            string contenido = $"Nombre del paciente: {consulta.NombrePaciente}\n" +
                               $"Fecha de cita: {consulta.FechaCita}\n" +
                               $"Razon de Consulta: {consulta.RazonConsulta}\n" +
                               $"Costo de consulta: {consulta.CostoConsulta}\n";

            // GUARDAR EL CONTENIDO EN EL ARCHIVO
            File.WriteAllText(nombreCompleto, contenido);

            Console.WriteLine($"\nCita guardada en el archivo: {nombreCompleto}");

        }

        static void MostrarCitas()
        {
            if (citas.Count == 0)
            {
                Console.WriteLine("No hay citas para mostrar.");
                return;
            }

            Console.WriteLine("\nListas de citas");
            for (int i = 0; i < citas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {citas[i].NombrePaciente},{citas[i].FechaCita}");
            }

            Console.WriteLine("\nSeleccione el numerto de la cita para ver detalles: ");
            int Seleccione = Convert.ToInt32(Console.ReadLine());

            if (Seleccione >= 1 && Seleccione <= citas.Count)
            {
                MostrarDetallesCita(citas[Seleccione - 1]);
            }
            else
            {
                Console.WriteLine("Numero de citas no valido");
            }
        }

        static void MostrarDetallesCita(ConsultaMedica cita)
        {
            Console.WriteLine($"\nDetallles de la cita");
            Console.WriteLine($"Nombre del paciente: {cita.NombrePaciente}");
            Console.WriteLine($"Fecha de Cita: {cita.FechaCita}");
            Console.WriteLine($"Razon de consulta: {cita.RazonConsulta}");
            Console.WriteLine($"Costo de consulta: ${cita.CostoConsulta}");
        }
    }
}

// NOMBRE: PEDRO ANTONIO ALVAREZ HERNANDEZ
// CODIGO: U20230697