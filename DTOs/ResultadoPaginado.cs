using System.Collections.Generic;

namespace DTOs {
    public class ResultadoPaginado<T> {

        public ResultadoPaginado(int totalDeRegistrosEncontrados, int pagina, int registrosPorPagina, List<T> registros) {
            TotalDeRegistrosEncontrados = totalDeRegistrosEncontrados;
            Pagina = pagina;
            RegistrosPorPagina = registrosPorPagina;
            Registros = registros;
        }

        public int TotalDeRegistrosEncontrados { get; }
        public int Pagina { get; }
        public int RegistrosPorPagina { get; }
        public List<T> Registros { get; }
    }
}
