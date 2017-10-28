using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DiskStartingPointEnum {
    public const float diskOneStartingLocation = .12f;
    public const float diskTwoStartingLocation = .16f;
    public const float diskThreeStartingLocation = .22f;
    public const float diskFourStartingLocation = .29f;
    public const float diskFiveStartingLocation = .34f;
    public const float diskSixStartingLocation = .6f;

    public static float GetDiskLocationByNumber(int diskNumber)
    {
        float diskLocation = 0;
        switch (diskNumber)
        {
            case 1:
                diskLocation = diskSixStartingLocation + diskFiveStartingLocation + diskFourStartingLocation +
                    diskThreeStartingLocation + diskTwoStartingLocation + diskOneStartingLocation;
            break;
            case 2:
                diskLocation = diskSixStartingLocation + diskFiveStartingLocation + diskFourStartingLocation +
                    diskThreeStartingLocation + diskTwoStartingLocation;
            break;
            case 3:
                diskLocation = diskSixStartingLocation + diskFiveStartingLocation + diskFourStartingLocation +
                    diskThreeStartingLocation;
            break;
            case 4:
                diskLocation = diskSixStartingLocation + diskFiveStartingLocation + diskFourStartingLocation;
            break;
            case 5:
                diskLocation = diskSixStartingLocation + diskFiveStartingLocation;
            break;
            case 6:
                diskLocation = diskSixStartingLocation;
            break;
        }

        return diskLocation;
    }
};
