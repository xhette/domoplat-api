using Domoplat.System.Database.Entities;

namespace Domoplat.Tariffs.Entities;

/// <summary>
/// Компания, предоставляющая услуги ЖКХ
/// </summary>
public class Company : IDomoplatEntity<Guid>
{
    /// <summary>
    /// Идентификатор компании
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Название компании
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Адрес компании
    /// </summary>
    public string Address { get; set; }
    
    /// <summary>
    /// Телефон компании
    /// </summary>
    public string Phone { get; set; }
    
    /// <summary>
    /// Email компании
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// ИНН компании
    /// </summary>
    public string Inn { get; set; }
    
    /// <summary>
    /// КПП компании
    /// </summary>
    public string Kpp { get; set; }
    
    /// <summary>
    /// ОГРН компании
    /// </summary>
    public string Ogrn { get; set; }
    
    /// <summary>
    /// Активен ли компания
    /// </summary>
    public bool IsActive { get; set; }
    
    /// <summary>
    /// Дата создания компании
    /// </summary>
    public DateTime CreatedAt { get; set; }
    
    /// <summary>
    /// Дата обновления компании
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Тарифы компании
    /// </summary>
    public virtual ICollection<CompanyTariffs> CompanyTariffs { get; set; }
}
