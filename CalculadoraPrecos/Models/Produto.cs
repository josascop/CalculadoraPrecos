using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CalculadoraPrecos.Models;

public class Produto {
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe um nome para o produto")]
    [MinLength(3, ErrorMessage = "O nome deve ter ao menos {1} caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Informe o preço do produto")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Preço inválido")]
    [Display(Name = "Preço unitário")]
    public decimal PrecoUnitario { get; set; }

    [DefaultValue(0)]
    [Display(Name = "Em estoque")]
    public uint EmEstoque { get; set; }

    [Required(ErrorMessage = "Informe o tipo do produto")]
    [EnumDataType(typeof(TipoProduto), ErrorMessage = "Tipo inválido")]
    public TipoProduto Tipo { get; set; }

    [Required(ErrorMessage = "Informe uma data de criação")]
    [Display(Name = "Criado em"), DataType(DataType.Date)]
    public DateTime CriadoEm { get; set; }

    [Display(Name = "Última atualização"), DataType(DataType.Date)]
    public DateTime UltimaAtualizacao { get; set; }

    public Produto() { }
}
