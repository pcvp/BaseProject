﻿using BaseAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BaseAPI.Data.Dtos {
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public Models.Gerente Gerente { get; set; }
    }
}
