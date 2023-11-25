using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.AutosCarpeta
{
    public class Tipos_Motor
    {
        public int MotorID { get; set; }
        public string Motor { get; set; }

        public Tipos_Motor()
        {
            MotorID = 0;
            Motor = string.Empty;
        }

        public Tipos_Motor(string motor, int id)
        {
            Motor = motor;
            MotorID = id;
        }

        public override string ToString()
        {
            return Motor;
        }
    }
}
