using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryToDocs.Model
{
    public class TipoDocumento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CodigoTipoDocumento { get; set; }
        public int IdSubProcesso { get; set; }
        public int IdUsuarioCriacao { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public int IdUsuarioAlter { get; set; }
        public DateTime DataAlteracao { get; set; }

    }
}
