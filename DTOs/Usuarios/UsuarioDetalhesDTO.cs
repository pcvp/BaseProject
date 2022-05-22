namespace DTOs.Usuarios {
    public class UsuarioDetalhesDTO {
        public UsuarioDetalhesDTO() { }

        public UsuarioDetalhesDTO(int id,string nome, string email, string senha, string telefone) {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Telefone = telefone;
        } 
        
        public UsuarioDetalhesDTO(string nome, string email, string senha, string telefone) {
            Nome = nome;
            Email = email;
            Senha = senha;
            Telefone = telefone;
        }

        public int? Id { get; set; }
        public string Nome { get; set; }     
        public string Email { get; set; }       
        public string Senha { get; set; }
        public string Telefone { get; set; }
    }
}
