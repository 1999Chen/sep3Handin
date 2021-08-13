// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Assignment.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\lsy19\Desktop\sep3final\tier1\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lsy19\Desktop\sep3final\tier1\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\lsy19\Desktop\sep3final\tier1\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\lsy19\Desktop\sep3final\tier1\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\lsy19\Desktop\sep3final\tier1\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\lsy19\Desktop\sep3final\tier1\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\lsy19\Desktop\sep3final\tier1\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\lsy19\Desktop\sep3final\tier1\_Imports.razor"
using Assignment;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\lsy19\Desktop\sep3final\tier1\_Imports.razor"
using Assignment.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lsy19\Desktop\sep3final\tier1\Pages\ProfileView.razor"
using tier1.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\lsy19\Desktop\sep3final\tier1\Pages\ProfileView.razor"
using tier1.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/ProfileView")]
    public partial class ProfileView : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 138 "C:\Users\lsy19\Desktop\sep3final\tier1\Pages\ProfileView.razor"
       
    IUserService client = new UserService();

    public string username { set; get; }

    public string password { set; get; }

    public string firstname { set; get; }

    public string lastname { set; get; }

    public int age { set; get; }

    public string sex { set; get; }

    public string birthday { set; get; }

    public string hobbies { set; get; }

    public string major { set; get; }

    public string hometown { set; get; }

    public string description { set; get; }


    private string tobeEditedfirstname;
    private string tobeEditedlastname;
    private string tobeEditedsex = "M";
    private DateTime tobeEditedbirthday;
    private string tobeEditedhometown;
    private string tobeEditedhobbies;
    private string tobeEditedmajor;
    private string tobeEditeddescription;
    private int tobeEditedage;
    private string tobeEditpassword;


    public void setSex(ChangeEventArgs args)
    {
        string result = args.Value.ToString();
        tobeEditedsex = result;
    }

    public void setMajor(ChangeEventArgs args)
    {
        string result = args.Value.ToString();
        tobeEditedmajor = result;
    }


    protected override void OnInitialized()
    {
        try
        {
            User user = client.getUserInfo(client.getcurrentName());
            Console.WriteLine("a2" + client.getcurrentName());
            firstname = user.firstname;
            lastname = user.lastname;
            age = user.age;
            sex = user.sex;
            major = user.major;
            description = user.description;
            hometown = user.hometown;
            hobbies = user.hobbies;
            username = user.username;
            birthday = user.birthday;
            tobeEditedfirstname = firstname;
            tobeEditedlastname = lastname;
            tobeEditedsex = sex;
            if (string.IsNullOrEmpty(birthday))
            {
                tobeEditedbirthday = DateTime.UtcNow;
            }
            else
            {
                tobeEditedbirthday = DateTime.Parse(user.birthday);
            }
            
            tobeEditedhometown = user.hometown;
            tobeEditedhobbies = user.hobbies;
            tobeEditedmajor = user.major;
            tobeEditeddescription = user.description;
            tobeEditedage = user.age;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task Logout()
    {
        NavigationManager.NavigateTo("/Logout");
    }

    public async Task editInfo()
    {
        try
        {

            if (string.IsNullOrEmpty(tobeEditpassword))
            {
                client.editInfo(username, password, tobeEditedfirstname, tobeEditedlastname, tobeEditedhobbies, tobeEditedsex, tobeEditedhometown, tobeEditeddescription, tobeEditedmajor, tobeEditedage, tobeEditedbirthday);

            }
            
            client.editInfo(username, tobeEditpassword, tobeEditedfirstname, tobeEditedlastname, tobeEditedhobbies, tobeEditedsex, tobeEditedhometown, tobeEditeddescription, tobeEditedmajor, tobeEditedage, tobeEditedbirthday);
            Console.WriteLine("EDIT TIER 1 UI");
            OnInitialized();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }





#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
