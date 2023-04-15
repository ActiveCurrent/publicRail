using AI;
using BlockTypes;
using Pipliz;
using Pipliz.Collections.Native;
using Unity.Mathematics;
using Jobs;
using Jobs.Implementations.Construction;
using ModLoaderInterfaces;
using NetworkUI;
using NetworkUI.AreaJobs;
using NetworkUI.Items;
using Science;
using Shared;
using System;
using System.Reflection;
using static Players;
using BlockEntities;
using NPC;
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

namespace james.publicRail {
    [ModLoader.ModManager]
    public class GoalRail:GoalLandmark {
        public static readonly GoalRail.RailFilter StockpileFilterInstance = new GoalRail.RailFilter();

        public override ushort ErrorIconType => BuiltinBlocks.Indices.crate;

        public override bool AllowBannerFallback => true;

        public override ILandmarkFilter LandmarkFilter => (ILandmarkFilter)GoalRail.StockpileFilterInstance;

        public override LandmarkType LandmarkType => LandmarkManager.CrateType;

        public override void OnReachedGoal(NPCBase npc) {
            this.succeeded = true;
            this.pathToGoal.Clear();
            npc.Job.OnNPCAtStockpile(ref npc.state);
        }

        public class RailFilter:ILandmarkFilter {
            public void CheckLandmarks(
              int3 chunkPosition,
              object context,
              ref UnsafeNativeSortedList<ushort, PlausibleLandmark, LandmarkSorter, UnsafePersistentAllocator> plausibleLandmarks) {
                if (!(context is Colony colony))
                    plausibleLandmarks.Clear();
                else
                    ServerManager.BlockEntityTracker.CrateTracker.FilterLandmarks((Vector3Int)chunkPosition, colony, ref plausibleLandmarks);
            }

        }
    }
}
