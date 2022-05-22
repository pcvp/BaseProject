using System;

namespace DTOs.Filtro {

    public class FiltroPaginadoDTO {
        public int Pagina { get; set; } = 1;
        public int RegistrosPorPagina { get; set; } = 10;
    }
}