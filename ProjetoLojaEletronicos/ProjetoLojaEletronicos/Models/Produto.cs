using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoLojaEletronicos.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public double Valor {  get; set; }
        public long FKCategoriaId { get; set; }
        [ForeignKey ("CategoriaID")]
        public Categoria? Categoria { get; set; }
    }
}
