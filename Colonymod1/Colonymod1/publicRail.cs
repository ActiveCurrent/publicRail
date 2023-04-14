using Jobs;
using Jobs.Implementations.Construction;
using ModLoaderInterfaces;
using NetworkUI;
using NetworkUI.AreaJobs;
using NetworkUI.Items;
using Pipliz;
using Science;
using Shared;
using System;
using System.Reflection;
using static Players;
using AI;
using BlockEntities;
using NPC;
using Pipliz.Collections.Native;
using Recipes;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Assertions;
using BlockEntities.Helpers;
using Transport.Elevator;
using static ItemTypesServer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pipliz.Networking;

namespace james.publicRail
{
    [ModLoader.ModManager]
    public class publicRail : IOnPlayerClicked
    {
        public void OnPlayerClicked(Players.Player player, PlayerClickedData click)
        {
            Chatting.Chat.Send(player, "publicRail 0.0.0.3");

            return;
        }

        
    }
}
