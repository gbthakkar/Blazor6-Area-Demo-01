using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BlazorApp_DotNet6.ViewModel;

public class Login
{
    private string? _loginId;

    [Required]
    [DisplayName("Login Name")]
    [UserNameValidation]
    public string? LoginId
    {
        get => _loginId?.ToUpper();
        set => _loginId = value?.ToUpper();
    }


    [Required]
    public string? Password { get; set; }
}
