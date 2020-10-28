using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using vocabteam.Models.Entities;

namespace vocabteam.Models.ViewModels
{
    public class PermissionModel : Permission
    {
        public PermissionModel() : base()
        {
        }
        
        public PermissionModel(Permission perm) : base(perm)
        {
            ObjectName = perm.ObjectName;
            Action = perm.Action;
        }
    }
}