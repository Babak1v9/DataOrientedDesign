using System;
using System.Collections.Generic;
using System.Text;

namespace DataOrientedDesign
{
    public class SWP_Struct
    {
        public struct SWP
        {
            public SWP(int v1, int v2, string v3, string v4)
            {
                V1 = v1;
                V2 = v2;
                V3 = v3;
                V4 = v4;
            }

            public int V1 { get; set; }
            public int V2 { get; set; }
            public string V3 { get; set; }
            public string V4 { get; set; }
        }
    }
}
