using System;

namespace ClassLibTeam04Framework.IndividueleOpdracht.VahidBaradarkhodamKhosrowshahi
{
    internal class CsharpDeveloper:VahidBaradarkhodamKhosrowshahi
    {
        bool IsRemote=false;
        double DistanceWorkCommute;
        bool IsBiker=false;


        private double CalculateBycicleBonus(double distance)
        {
            
            if (!IsRemote || !IsBiker)
            {
                return 0;
            }
            else
            {
                DistanceWorkCommute = Math.Round(distance * 0.333 , 2);
            }
            return DistanceWorkCommute;

        }

        private string ToString(bool isBiker, bool isRemote)
        {
            isBiker = IsBiker;
            isRemote = IsRemote;
            if (isBiker)
            {
                return "Ik ben een C# Developer en ik fiets";
            }
            else if (isRemote)
            {
                return "Ik ben milieuvriendelijk en ik schrijf mijn code thuis.";
            }
            else
                return "Ik ben een C# Developer";
           


        }
    }
}