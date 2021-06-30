public Program()
{
    var comm = IGC.UnicastListener;
    Runtime.UpdateFrequency = UpdateFrequency.Update100;

    IMyBroadcastListener listen = IGC.RegisterBroadcastListener("IRL.Scout.Channel");
}

public void read(IMyUnicastListener unisource) {
    if (unisource.HasPendingMessage) {
        MyIGCMessage messageUni = unisource.AcceptMessage();
        Echo("Unicast received from address " + messageUni.Source.ToString() + "\n\r");
        Echo("Data: " + messageUni.Data.ToString());
    } else {
        Echo($"No message found {unisource.HasPendingMessage}");
    }
}

public void Main(string argument, UpdateType updateSource)
{
    IMySensorBlock sensor = (IMySensorBlock)GridTerminalSystem.GetBlockWithName("Detection.Sensor");
    IMyTextPanel panel = (IMyTextPanel) GridTerminalSystem.GetBlockWithName("Detection.Input");
    StringBuilder buff = new StringBuilder("", 300);
    IMyTextPanel outPanel = (IMyTextPanel) GridTerminalSystem.GetBlockWithName("Detection.Output");

    panel.ReadText(buff, true);
    outPanel.WriteText(buff.ToString());


    IMyLaserAntenna laser = (IMyLaserAntenna) GridTerminalSystem.GetBlockWithName("Detection.LaserAntenna");

    IMyProgrammableBlock pb = (IMyProgrammableBlock) GridTerminalSystem.GetBlockWithName("Detection.ProgrammableBlock");
    outPanel.WriteText($"Entity ID: {pb.EntityId}");
    IMyUnicastListener unisource = IGC.UnicastListener;
    Echo("Reading...\n");
    read(unisource);
    reads();
}
