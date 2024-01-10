using System;
using System.Collections.Generic;
using System.Text;

namespace AppForMobile
{
    public interface IPath
    {
        string GetDatabasePath(string filename);
    }
}
