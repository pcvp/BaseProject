using System;

namespace DTOs.Filtro {

    public class FiltroPesquisaDTO : FiltroPaginadoDTO {
        public string Nome { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}