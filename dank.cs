public double CurrentTheta() {
    IMyCockpit cockpit = (IMyCockpit) GridTerminalSystem.GetBlockWithName("Guns.Left.Cockpit");
    Vector3D gravityVec = cockpit.GetNaturalGravity();
        
    return ToDegrees(AngleBetween(cockpit.WorldMatrix.Forward, gravityVec)) - 90;
}

public static double ToDegrees(double rads) {
    return rads * 180 / Math.PI;
}

public static double AngleBetween(Vector3D v1, Vector3D v2) {
    double prod = Vector3D.Dot(v1, v2);
    return Math.Acos(prod / (v1.Length() * v2.Length()));
}

public double ThetaSolver(double speed, double dx, double dy) {
    double g = 9.81;
    double sqrt = Math.Sqrt(Math.Pow(speed, 4) - g * (g * Math.Pow(dx, 2) + 2 * Math.Pow(speed, 2) * dy));
    double numerator = Math.Pow(speed, 2) - sqrt;
    return Math.Atan(numerator / (g * dx));
}

public void Main(string argument, UpdateType updateSource)
{
    double distance = Double.Parse(argument);
    IMyCockpit cockpit = (IMyCockpit) GridTerminalSystem.GetBlockWithName("Guns.Left.Cockpit");
    IMyTextPanel panel = (IMyTextPanel) GridTerminalSystem.GetBlockWithName("Guns.Left.LCD");
    double theta = Math.Round(CurrentTheta(), 2);
    double goal = Math.Round(ThetaSolver(325, distance, -33));
    panel.WriteText($"Curr: {theta} degrees\nGoal: {goal} degrees\ndist: {distance}m", false);
    Echo("elev");
}
