using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryToDocs.Model.FileStructo
{
    public class SubProcesso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CodigoSubProcesso { get; set; }
        public int IdProceso { get; set; }
        public int IdUsuarioCriacao { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public int IdUsuarioAlter { get; set; }
        public DateTime DataAlteracao { get; set; }

    }
}
