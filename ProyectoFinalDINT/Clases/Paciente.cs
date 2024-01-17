using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PracticaDINTproyecto.Clases
{
    internal class Paciente
    {
        private String Nombre { get; set; }
        private String Apellidos { get; set; }
        private String Dni { get; set; }
        private DateTime FechaNacimiento { get; set; }
        private int Sesiones { get; set; }
        private DateTime UltimaSesion { get; set; }
        private DateTime ProximaSesion { get; set; }
        private String Comentario { get; set; }

        private static List<Paciente> pacientes = new List<Paciente>();

        public List<Paciente> getPatients()
        {
            return pacientes;

        }

        public void addPatient(Paciente p)
        {
            pacientes.Add(p);
        }

       /* public void editPatient(String nombre, String Apellidos, String Dni, )
        {

        }*/
    }
}