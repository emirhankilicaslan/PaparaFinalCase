namespace PaparaFinal.DtoLayer.CategoryDtos;

public class UpdateCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public string Tag { get; set; }
    public string Url { get; set; }
}