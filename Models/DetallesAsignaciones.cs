using System.ComponentModel.DataAnnotations;

namespace Jeremy_Sanchez_AP1_P2.Models;
public class DetallesAsignaciones
{
    [Key]
    public int DetalleId { get; set; }

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    [Range(1, int.MaxValue, ErrorMessage = "Debe ser una asignacion valida")]
    public int AsignacionId { get; set; }

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    [Range(1, int.MaxValue, ErrorMessage = "Debe ser un tipo de punto valido")]
    public int TipoId { get; set; }

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    [Range(1, int.MaxValue, ErrorMessage = "Debe ser un estudiante valido")]
    public int EstudianteId { get; set; }

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    [Range(1, int.MaxValue, ErrorMessage = "Debe ser un numero mayor que cero")]
    public int CantidadPuntos { get; set; }
}