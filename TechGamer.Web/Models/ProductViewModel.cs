﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TechGamer.Web.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo Ativo é obrigatório.")]
        [DisplayName("Ativo")]
        public bool Active { get; set; }

        [Required(ErrorMessage = "O campo Preço é obrigatório.")]
        [DisplayName("Preço")]
        public decimal Price { get; set; }

        [DisplayName("Imagem")]
        public string Image { get; set; }

        [Required(ErrorMessage = "O campo Quantidade em estoque é obrigatório.")]
        [DisplayName("Quantidade em Estoque")]
        public int StockQuantity { get; set; }
    }
}
