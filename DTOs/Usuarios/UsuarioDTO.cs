﻿namespace DTOs.Usuarios {
    public class UsuarioDTO {
        public int? Id { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int PerfilAcesso { get; set; }
    }
}
