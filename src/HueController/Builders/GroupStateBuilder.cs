using PReardon.HueController.Groups.Model;
using System.Net.Http;
using System.Threading.Tasks;

namespace PReardon.HueController.Builders
{
    public class GroupStateBuilder
    {
        private string _groupId;
        public SetGroupStateRequest GroupState { get; private set; }

        public GroupStateBuilder()
        {
            GroupState = new SetGroupStateRequest();
        }

        public GroupStateBuilder(string groupId): this()
        {
            _groupId = groupId;
        }

        private void SetGroupId(string groupId)
        {
            _groupId = groupId;
        }

        public async Task SendAsync(HueController controller)
        {
            await controller.Groups.SetGroupStateAsync(_groupId, GroupState);
        }
    }



}
