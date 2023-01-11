using System.ComponentModel.DataAnnotations;

namespace CalculadoraPrecos.Models;
public class Pizza {
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe um nome")]
    [MinLength(3, ErrorMessage = "O nome deve ter ao menos {1} caracteres")]
    public string Nome { get; set; }

    public List<Produto> Ingredientes { get; set; } = new();

    [Required(ErrorMessage = "Informe uma porcentagem de lucro")]
    [Range(0.01, double.MaxValue, ErrorMessage = "A porcentagem de lucro mínima é 0.01%")]
    public decimal Lucro { get; set; }

    [Display(Name = "Preço total")]
    [DataType(DataType.Currency)]
    public decimal PrecoTotal { get; set; }

    public Pizza() { }
}
