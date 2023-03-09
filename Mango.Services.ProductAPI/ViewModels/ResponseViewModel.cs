namespace Mango.Services.ProductAPI.ViewModels;

public class ResponseViewModel
{
    public bool isSuccess { get; set; } = true;
    public object Result { get; set; }
    public string DisplayMessage { get; set; } = "";
    public List<string> ErrorMessages { get; set; }
}