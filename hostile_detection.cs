string channel;

public string TimeStamp() {
    string day = DateTime.Today.ToString("dddd");  
    string year = DateTime.Now.Year.ToString("0000");  
    string month = DateTime.Now.Month.ToString("00");  
    string date = DateTime.Now.Day.ToString("00");  
    string hour = DateTime.Now.Hour.ToString("00");  
    string minute = DateTime.Now.Minute.ToString("00");  
    string second = DateTime.Now.Second.ToString("00"); 
    string month2 = "";
    string day2;
    switch (day)  
            {  
                case "Sun":  
                    day2 = "Sunday";  
                    break;  
                case "Mon":  
                    day2 = "Monday";  
                    break;  
                case "Tue":  
                    day2 = "Tuesday";  
                    break;  
                case "Wed":  
                    day2 = "Wednesday";  
                    break;  
                case "Thu":  
                    day2 = "Thursday";  
                    break;  
                case "Fri":  
                    day2 = "Friday";  
                    break;  
                case "Sat":  
                    day2 = "Saturday";  
                    break;  
                case "Sunday":  
                    day2 = "Sunday";  
                    break;  
                case "Monday":  
                    day2 = "Monday";  
                    break;  
                case "Tuesday":  
                    day2 = "Tuesday";  
                    break;  
                case "Wednesday":  
                    day2 = "Wednesday";  
                    break;  
                case "Thursday":  
                    day2 = "Thursday";  
                    break;  
                case "Friday":  
                    day2 = "Friday";  
                    break;  
                case "Saturday":  
                    day2 = "Saturday";  
                    break;  
                //I'm Use Jakarta Timezone, change this case from your Timezone  
                case "Minggu":  
                    day2 = "Sunday";  
                    break;  
                case "Senin":  
                    day2 = "Monday";  
                    break;  
                case "Selasa":  
                    day2 = "Tuesday";  
                    break;  
                case "Rabu":  
                    day2 = "Wednesday";  
                    break;  
                case "Kamis":  
                    day2 = "Thursday";  
                    break;  
                case "Jum'at":  
                    day2 = "Jum'at";  
                    break;  
                case "Jumat":  
                    day2 = "Friday";  
                    break;  
                case "Sabtu":  
                    day2 = "Sunday";  
                    break;  
                default:  
                    day2 = "UnKnown";  
                    break;  
            }   
    return day2 + " , " + date + " " + month2 + " " + year + "  " + hour + ":" + minute + ":" + second;
}

public Program() {
    Runtime.UpdateFrequency = UpdateFrequency.Update100;
    channel = "IRL.Scout.Channel";
    IMyBroadcastListener listen = IGC.RegisterBroadcastListener(channel);
}

public void send(string msg) {
    long receiverAddress = 76135322053061969;

    Echo($"Msg sent successfully: {IGC.SendUnicastMessage(receiverAddress, channel, msg)}");
    Echo($"Message sent: {msg}");
}

public void Main(string argument, UpdateType updateSource)
{
    IMyLaserAntenna ant = (IMyLaserAntenna) GridTerminalSystem.GetBlockWithName("Laser Antenna [Dro]");
    
    StringBuilder sb = new StringBuilder("___SCOUT_LOG___").Append('\n');
    sb.Append("PB Address: ").Append(IGC.Me).Append('\n');
    sb.Append(TimeStamp()).Append('\n');
    Echo(sb.ToString());
    send(sb.ToString());
}
