#nullable enable
using System.ComponentModel.DataAnnotations;

namespace CorpProductSystem.Shared.Models;
public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Название обязательно")]
    public string Name { get; set; } = string.Empty;

    // Разрешаем только положительные числа (от 0.01 до максимума)
    [Range(0.01, 999999999, ErrorMessage = "Цена должна быть больше нуля")]
    public decimal Price { get; set; }

    public string Description { get; set; } = string.Empty;
}