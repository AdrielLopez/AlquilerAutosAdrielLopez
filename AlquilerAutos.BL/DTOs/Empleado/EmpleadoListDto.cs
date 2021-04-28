﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerAutos.BL.DTOs.Empleado
{
    public class EmpleadoListDto:ICloneable
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        private string nombrecompleto;

        public string NombreCompleto
        {
            get { return Nombre +" "+Apellido; }
            set { nombrecompleto = value; }
        }


        public int LocalidadId { get; set; }
        public int ProvinciaId { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
