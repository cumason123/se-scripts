float rotationVelocity = 3;

public void Center() {  
    Rotate(90);
}

public double CurrentTheta() {
    IMyRemoteControl remote = (IMyRemoteControl)GridTerminalSystem.GetBlockWithName("Guns.Left.Remote");
    Vector3D gravityVec = remote.GetNaturalGravity();
        
    return ToDegrees(AngleBetween(remote.WorldMatrix.Forward, gravityVec)) - 90;
}

void Rotate(float newAngle)
{
    IMyMotorStator thisRotor = (IMyMotorStator)GridTerminalSystem.GetBlockWithName("Guns.Left.Rotor.Yaw");
    double currentAngle = CurrentTheta();
   
    if (newAngle > currentAngle)
    {
        while (newAngle > currentAngle) {
            thisRotor.SetValueFloat("Velocity", rotationVelocity);
        }
        
    }
    else
    {
        while(newAngle < currentAngle) {
            thisRotor.SetValueFloat("Velocity", -rotationVelocity);
        }
    }
    thisRotor.SetValueFloat("Velocity", 0);
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
   double theta = ThetaSolver(325, distance, -33);
   Center();
}
