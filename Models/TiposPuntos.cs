using System.ComponentModel.DataAnnotations;

namespace Jeremy_Sanchez_AP1_P2.Models;

public class TiposPuntos
{
    [Key]
    public int TipoId { get; set; }

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    public string Descripcion { get; set; } = string.Empty;

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    public int ValorPuntos { get; set; }

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    public string Color { get; set; }

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    public string Icono { get; set; }

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    public bool Activo { get; set; } = true;

}