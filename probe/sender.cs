string channel;

public string TimeStamp()
{
    string day = DateTime.Today.ToString("dddd");
    string year = DateTime.Now.Year.ToString("0000");
    string month = DateTime.Now.Month.ToString("00");
    string date = DateTime.Now.Day.ToString("00");
    string hour = DateTime.Now.Hour.ToString("00");
    string minute = DateTime.Now.Minute.ToString("00");
    string second = DateTime.Now.Second.ToString("00");
    return day + " , " + date + " " + month + " " + year + "  " + hour + ":" + minute + ":" + second;
}

public Program()
{
    channel = "IRL.Scout.Channel";
    IMyBroadcastListener listen = IGC.RegisterBroadcastListener(channel);
}

public void send(string msg)
{
    long receiverAddress = 76135322053061969;

    Echo($"Msg sent successfully: {IGC.SendUnicastMessage(receiverAddress, channel, msg)}");
    Echo($"Message sent: {msg}");
}

public void Main(string argument, UpdateType updateSource)
{
    IMyTextPanel input = (IMyTextPanel) GridTerminalSystem.GetBlockWithName("LCD Panel");
    StringBuilder sb = new StringBuilder("___SCOUT_LOG___").Append('\n');
    sb.Append("PB Address: ").Append(IGC.Me).Append('\n');
    sb.Append(TimeStamp()).Append('\n');
    sb.Append("Radar Output:\n\n");
    input.ReadText(sb, true);
    send(sb.ToString());
}
