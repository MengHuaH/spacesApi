using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacesApi.Domain.Enums;
public enum RoomState
{
    open = 0, 
    closed = 1,
}

public enum RoomPersonnelSituation
{
    have = 0,
    not = 1,
}

public enum RoomPowerSupply
{
    open = 0,
    closed = 1,
}
