namespace DTOs {
    public class ObjetoBasicoDTO {

        public ObjetoBasicoDTO() {
        }

        public ObjetoBasicoDTO(int id, string nome) {
            Id = id;
            Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
    }
}