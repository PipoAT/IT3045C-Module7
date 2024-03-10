using System.ComponentModel.DataAnnotations;

namespace Assignment7.Entities;

public class Person
{
    public int PersonID { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string LastName { get; set; }
    [MaxLength(50)]
    public string NickName { get; set; }

}
