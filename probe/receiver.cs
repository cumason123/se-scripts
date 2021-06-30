string channel;
public Program()
{
    var comm = IGC.UnicastListener;
    Runtime.UpdateFrequency = UpdateFrequency.Update100;
    channel = "IRL.Scout.Channel";
    IMyBroadcastListener listen = IGC.RegisterBroadcastListener(channel);
}

public void append(string newText) {
    IMyTextPanel log = (IMyTextPanel) GridTerminalSystem.GetBlockWithName("LogPanel");
    StringBuilder sb = new StringBuilder("");
    log.ReadText(sb);
    if (sb.Length < newText.Length) {
          log.WriteText(newText);
    }
}
public void read(IMyUnicastListener unisource) {
    if (unisource.HasPendingMessage) {
        MyIGCMessage messageUni = unisource.AcceptMessage();
        Echo("Unicast received from address " + messageUni.Source.ToString() + "\n\r");
        string data = messageUni.Data.ToString();
        IMyTextPanel panel = (IMyTextPanel) GridTerminalSystem.GetBlockWithName("ReceiverPanel");
        panel.WriteText(data);
        append(data);
        Echo(data);
    }
}

public void Main(string argument, UpdateType updateSource)
{
    IMyUnicastListener unisource = IGC.UnicastListener;
    Echo("Reading...\n");
    read(unisource);
}
