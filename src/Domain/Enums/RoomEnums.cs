using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacesApi.Domain.Enums;
public enum RoomState
{
    closed = 0,
    appointment = 1,
    open = 2,
}

public enum RoomPersonnelSituation
{
    not = 0,
    have = 1,
}

public enum RoomPowerSupply
{
    closed = 0,
    open = 1,
}
