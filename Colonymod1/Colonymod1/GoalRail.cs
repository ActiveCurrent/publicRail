using AI;
using BlockTypes;
using Pipliz;
using Pipliz.Collections.Native;
using Unity.Mathematics;

namespace NPC {
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
