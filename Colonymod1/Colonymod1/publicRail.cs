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
using UnityEngine.Profiling;
using BlockEntities.Helpers;
using Transport.Elevator;
using static ItemTypesServer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pipliz.Networking;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;



namespace james.publicRail
{
    [ModLoader.ModManager]
    public class publicRail : GoalJob, PathingManager.IPathingThreadAction, IOnPlayerClicked, IOnNPCHit, INPCGoal
    {

        public void OnPlayerClicked(Players.Player player, PlayerClickedData click)
        {
            Chatting.Chat.Send(player, "publicRail 0.0.0.4");

            return;

        }

        public void OnNPCHit(NPCBase npc, ModLoader.OnHitData hit)
        {
            String jobbloc = npc.Job.GetJobLocation().Location.ToString();
            String myloc = npc.Position.ToString();

            float xdist = npc.Job.GetJobLocation().Location.x - npc.Position.x;
            xdist *= xdist;
            float ydist = npc.Job.GetJobLocation().Location.y - npc.Position.y;
            ydist *= ydist;
            float zdist = npc.Job.GetJobLocation().Location.z - npc.Position.z;
            zdist *= zdist;
            String distsquared = (xdist+ydist+zdist).ToString();

            Chatting.Chat.SendToConnected("job " + jobbloc);
            Chatting.Chat.SendToConnected("myloc " + myloc);
            Chatting.Chat.SendToConnected("distsquared " + distsquared);

            //npc.SetPosition(npc.Job.GetJobLocation().Location); //good to be used for sending along track, variable speed depending on track length

            npc.SetGoal<GoalStockpile>();

            Chatting.Chat.SendToConnected("Sending NPC to crate");
            return;
        }
        public override void OnNPCUpdate(NPCBase npc)
        { }

    }
}
