using System;
using System.Collections.Generic;
using System.Text;

namespace ArkScribeBackend.Objects
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Mutations { get; set; }
        public Generation Generation { get; set; }
    }
}
