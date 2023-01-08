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
    [DataType(DataType.Currency)]
    public decimal PrecoUnitario { get; set; }

    [Required(ErrorMessage = "Informe a unidade")]
    [EnumDataType(typeof(Unidade))]
    public Unidade Unidade { get; set; }

    [Display(Name = "Criado em"), DataType(DataType.Date)]
    public DateTime CriadoEm { get; }

    [Display(Name = "Última atualização"), DataType(DataType.Date)]
    public DateTime UltimaAtualizacao { get; set; }

    public Produto() {
        CriadoEm = DateTime.Now;
        UltimaAtualizacao = DateTime.Now;
    }

    public void SinalizarAtualizacao() {
        UltimaAtualizacao = DateTime.Now;
        return;
    }
}
