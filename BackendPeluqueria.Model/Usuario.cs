using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPeluqueria.Model
{
    public class Usuario
    {
        public int Usuario_id { get; set; }
        public string Usuario_nombre { get; set; }
        public string Usuario_apellido { get; set; }
        public string Usuario_nickname { get; set; }
        public string Usuario_password { get; set; }
        public string Usuario_email { get; set; }
        public string Usuario_sexo { get; set; }
        public string Usuario_foto { get; set; }
        public int Fk_usuario_perfil_id { get; set; }
        public DateTime Usuario_fecha_creacion { get; set; }
        public DateTime Usuario_fecha_nacimiento { get; set; }
    }
}
