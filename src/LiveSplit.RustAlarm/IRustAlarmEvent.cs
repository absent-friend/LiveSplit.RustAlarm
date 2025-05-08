using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveSplit.RustAlarm
{
    internal interface IRustAlarmEvent
    {
        void Apply();
        void Undo();
    }
}
