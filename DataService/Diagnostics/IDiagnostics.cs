using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Diagnostics
{
    public interface IDiagnostics
    {
        void LogToDebugger(float result, int Operator);
        void LogToDatabase(float result, int Operator);
        
    }
}
