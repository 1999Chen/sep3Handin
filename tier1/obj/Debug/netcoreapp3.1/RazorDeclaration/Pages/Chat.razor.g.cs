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
#line 2 "C:\Users\lsy19\Desktop\sep3final\tier1\Pages\Chat.razor"
using tier1.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\lsy19\Desktop\sep3final\tier1\Pages\Chat.razor"
using tier1.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\lsy19\Desktop\sep3final\tier1\Pages\Chat.razor"
using tier1.Services;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Chat")]
    public partial class Chat : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 41 "C:\Users\lsy19\Desktop\sep3final\tier1\Pages\Chat.razor"
       
    private int index;
    public string friend = "";
    IFriendService _friendService=new friendService();
    List<Friend> Templist = new List<Friend>();
    IChatMessageService chatMessageService=new chatMessageService();
    IUserService _userService=new UserService();
    List<string> friendslist=new List<string>();
    List<ChatMessage> chatMessagelist=new List<ChatMessage>();
    List<string> resultList=new List<string>();
    private ChatMessage _chatMessage=new ChatMessage();

    

    
    protected override void OnInitialized()
    {
        Templist.Clear();
        friendslist.Clear();
        Templist = _friendService.getFriends(_userService.getcurrentName());
        Console.WriteLine(Templist.Count);
        chatMessagelist.Clear();
        foreach (var f in Templist)
        {
            if (f.username1 != _userService.getcurrentName() && f.accept.Equals(true))
            {
                friendslist.Add(f.username1);
            }
            else if (f.username2 != _userService.getcurrentName() && f.accept.Equals(true))
            {
                friendslist.Add(f.username2);
            }
        }
    }

    
    public async Task startChat(string username)
    {
        resultList.Clear();
        friend = username;
        chatMessagelist = chatMessageService.getAllMessages(_userService.getcurrentName(), username);
        foreach (var msg in chatMessagelist)
        {
            Console.WriteLine(msg.date);
            if (msg.nameSend == _userService.getcurrentName())
            {
                resultList.Add(msg.date);
                resultList.Add("Me"+":"+msg.message);
            }
            else
            {
                resultList.Add(msg.date);
                resultList.Add(msg.nameSend+":"+msg.message);
            }
        }

    }

    public void sendMessage()
    {
        ChatMessage chatMessage = new ChatMessage
        {
            message = _chatMessage.message,
            nameReceived = friend,
            nameSend = _userService.getcurrentName()
        };
        chatMessageService.sendMessage(chatMessage);
        startChat(friend);
    }

    

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
