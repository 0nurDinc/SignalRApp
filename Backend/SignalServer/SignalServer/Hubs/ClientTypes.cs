using Microsoft.AspNetCore.SignalR;
using SignalServer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalServer.Hubs
{
    public class ClientTypes:Hub
    {
        #region Client Types

        public async Task SendCallerMessage(string message)
        {
            await Clients.Caller.SendAsync("receiveMessage",message);
        }

        public async Task SendAllMessage(string message)
        {
            await Clients.All.SendAsync("receiveMessage",message);
        }

        public async Task SendOthersMessage(string message)
        {
            await Clients.Others.SendAsync("receiveMessage", message);
        }

        #endregion

        #region AllExpect

        public async Task AllExcpectSendMessage(string[] targetClients, string message)
        {
            await Clients.AllExcept(targetClients).SendAsync("receiveMessage", message);
        }

        #endregion

        #region Client

        public async Task ClientMessage(string connectionID, string message)
        {
            await Clients.Client(connectionID).SendAsync("receiveMessage", message);
        }

        #endregion

        #region Clients


        public async Task ClientsSendMessage(string[] targetClients,string message)
        {
            await Clients.Clients(targetClients).SendAsync("receiveMessage", message);
        }

        #endregion

        #region Groups

        static List<GroupClient> groupClients = new List<GroupClient>();
        public async Task AddToGroup(string groupName)
        {
            GroupClient client = groupClients.FirstOrDefault(x => x.GroupName == groupName && x.ConnectionId == Context.ConnectionId);
            if(!(client is null))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId,groupName);
                groupClients.Add(new GroupClient()
                {
                    ConnectionId = Context.ConnectionId,
                    GroupName = groupName,
                });
            }
        }


        #region Group

        public async Task GroupSendMessage(string groupName, string message)
        {
            await Clients.Group(groupName).SendAsync("receiveMessage", message);
        }
        #endregion

        #region GroupExpect

        public async Task GroupExpectSendMessage(string groupName, string[] targetClients, string message)
        {
            await Clients.GroupExcept(groupName, targetClients).SendAsync("receiveMessage", message);
        }
        #endregion

        #region Groups

        public async Task GetGroupClient(string groupName)
        {
            var data = groupClients.Where(g => g.GroupName == groupName).Select(x => x.ConnectionId).ToList();
            await Clients.Caller.SendAsync("getGroupClients", data);
        }


        public async Task GroupSendMessages(string[] groups,string message)
        {
            await Clients.Groups(groups).SendAsync("receiveMessage", message);
        }


        public async Task GetGroupsClients(string[] groupsName)
        {
            List<string> groupData = new List<string>();
            foreach (var item in groupData)
            {
                groupData.AddRange(groupClients.Where(x => x.GroupName == item).Select(x => x.ConnectionId).ToList());
            }

            await Clients.Caller.SendAsync("getGroupClients", groupData);
        }


        #endregion

        #region OthersInGroup


        public async Task OtherInGroupSendMessage(string groupName,string message)
        {
            await Clients.OthersInGroup(groupName).SendAsync("receiveMessage", message);
        }

        #endregion

        #endregion


    }
}
