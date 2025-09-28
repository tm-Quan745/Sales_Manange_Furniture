using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class SessionManager
{
    public static string CurrentSessionID { get; } = Guid.NewGuid().ToString();
}
  
