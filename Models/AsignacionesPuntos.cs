using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jeremy_Sanchez_AP1_P2.Models;
public class AsignacionesPuntos
{
    [Key]
    public int AsignacionId { get; set; }

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    [Range(1, int.MaxValue, ErrorMessage = "Debe ser un estudiante valido")]
    public int EstudianteId { get; set; }

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    [Range(1, int.MaxValue, ErrorMessage = "Debe ser un numero mayor que cero")]
    public int TotalPuntos { get; set; }

    [ForeignKey("AsignacionId")]
    public ICollection<DetallesAsignaciones> DetallesAsignaciones { get; set; } = new List<DetallesAsignaciones>();
}