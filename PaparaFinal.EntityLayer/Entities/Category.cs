namespace PaparaFinal.EntityLayer.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public string Tag { get; set; }
    public string Url { get; set; }
    public virtual List<CategoryProduct> CategoryProducts { get; set; } 
}