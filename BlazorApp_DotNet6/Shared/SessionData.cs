using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace BlazorApp_DotNet6.Shared;

public class SessionData
{
    private const string AdminUserId = "AdminUserId";//int Id in UserTbl
    private const string AdminUserName = "AdminUserName";//user name string in UserTbl
    private const string CustomerUserName = "CustomerUserName";//string user name
    private const string CustomerAccId = "CustomerAccId";//int Id in accmaster table

    private readonly ProtectedSessionStorage _sessionStorage;

    public SessionData(ProtectedSessionStorage protectedSessionStorage)
    {
        _sessionStorage = protectedSessionStorage;
    }

    public async Task SetAdminUserIdAsync(int userId)
    {
        await _sessionStorage.SetAsync(AdminUserId, userId);
    }
    public async Task SetCustomerAccIdAsync(int Id)
    {
        await _sessionStorage.SetAsync(CustomerAccId, Id);
    }

    public async Task SetAdminUserNameAsync(string adminUserName)
    {
        await _sessionStorage.SetAsync(AdminUserName, adminUserName);
    }
    public async Task SetCustomerLoginNameAsync(string userName)
    {
        await _sessionStorage.SetAsync(CustomerUserName, userName);
    }

    public async Task<int> GetAdminUserIdAsync()
    {
        var ss = await _sessionStorage.GetAsync<int>(AdminUserId);
        if (ss.Success)
        {
            return ss.Value;
        }
        else
        {
            return 0;
        }
    }

    public async Task<int> GetCustomerAccIdAsync()
    {
        var ss = await _sessionStorage.GetAsync<int>(CustomerAccId);
        if (ss.Success)
        {
            return ss.Value;
        }
        else
        {
            return 0;
        }
    }

    public async Task<string> GetAdminUserNameAsync()
    {
        var ss = await _sessionStorage.GetAsync<string>(AdminUserName);
        if (ss.Success)
        {
            return ss.Value ?? "";
        }
        else
        {
            return "";
        }
    }

    public async Task<string> GetCustomerUserNameAsync()
    {
        var ss = await _sessionStorage.GetAsync<string>(CustomerUserName);
        if (ss.Success)
        {
            return ss.Value ?? "";
        }
        else
        {
            return "";
        }
    }

}
