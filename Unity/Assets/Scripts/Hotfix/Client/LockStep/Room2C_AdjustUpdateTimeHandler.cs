namespace ET.Client
{
    [MessageHandler(SceneType.LockStep)]
    public class Room2C_AdjustUpdateTimeHandler: MessageHandler<Room2C_AdjustUpdateTime>
    {
        protected override async ETTask Run(Session session, Room2C_AdjustUpdateTime message)
        {
            Room room = session.Scene().GetComponent<Room>();
            int newInterval = (1000 + (message.DiffTime - LSConstValue.UpdateInterval)) * LSConstValue.UpdateInterval / 1000;

            if (newInterval < 40)
            {
                newInterval = 40;
            }

            if (newInterval > 66)
            {
                newInterval = 66;
            }
            
            room.FixedTimeCounter.ChangeInterval(newInterval, room.PredictionFrame);
            await ETTask.CompletedTask;
        }
    }
}