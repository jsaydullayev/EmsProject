﻿using Ems.Data.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Data.Entities;
[Table("info_state", Schema ="info")]
public class State : BaseInfoEntity
{
}