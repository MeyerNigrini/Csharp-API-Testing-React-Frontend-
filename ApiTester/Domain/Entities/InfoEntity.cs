namespace ApiTester.Domain.Models;

public class InfoEntity : KeyValuePairModel
{
    public int Id { get; set; }
    public string Type { get; set; }  // Add Type property here
}
