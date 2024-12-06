using System.Net;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Web;

//////////////////////////////////
// MAKE SURE NAMESPACE IS CORRECT
//////////////////////////////////
namespace myhrapp.Pages;

public class SalaryModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private ITokenAcquisition _tokenAcquisition;

    //////////////////////////////////
    // PASTE THE API URL PREFIX 
    //////////////////////////////////
    private string _apiPrefix = "api://blusubs-api";

    public SalaryModel(ILogger<IndexModel> logger, ITokenAcquisition tokenAcquisition)
    {
        _logger = logger;
        _tokenAcquisition = tokenAcquisition;
    }

    public void OnGet()
    {
        var client = new HttpClient();

        //////////////////////////////////
        // UNCOMMENT FOLLOWING LINES AFTER CONFIGURING THE WEB APP WITH API ACCESS PERMISSIONS
        //////////////////////////////////
        var accessToken = _tokenAcquisition.GetAccessTokenForUserAsync(new[] { $"{_apiPrefix}/Salary.Read" }).Result;         
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        //////////////////////////////////
        // ENTER THE CORRECT PORT OF THE WEB API
        //////////////////////////////////
        var salary = client.GetStringAsync("https://localhost:7200/api/Salary?empId=5").Result;
        Console.WriteLine($"Salary: {salary}");
        ViewData["Salary"] = salary;

    }  
}
